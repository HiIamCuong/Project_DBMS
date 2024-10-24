CREATE PROCEDURE TaoHoaDonBan
    @Ma_San_Pham varchar(10),
    @So_Luong int
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ma_Hoa_Don_Ban int;
    DECLARE @Don_Gia float;
    DECLARE @Thanh_Tien float;

    -- Kiểm tra số lượng có hợp lệ không
    IF @So_Luong <= 0
    BEGIN
        RAISERROR('Số lượng phải lớn hơn 0.', 16, 1);
        RETURN;
    END

    -- Lấy đơn giá của sản phẩm
    SELECT @Don_Gia = Don_Gia FROM SanPham WHERE Ma_San_Pham = @Ma_San_Pham;

    -- Kiểm tra sản phẩm có tồn tại không
    IF @Don_Gia IS NULL
    BEGIN
        RAISERROR('Sản phẩm không tồn tại.', 16, 1);
        RETURN;
    END

    -- Tính tổng tiền
    SET @Thanh_Tien = @Don_Gia * @So_Luong;

    -- Tạo hóa đơn bán mới (không cần số điện thoại)
    INSERT INTO HoaDonBan (Ngay, SDT, Thanh_Tien)
    VALUES (GETDATE(), NULL, @Thanh_Tien);

    -- Lấy mã hóa đơn vừa tạo
    SET @Ma_Hoa_Don_Ban = SCOPE_IDENTITY();

    -- Thêm chi tiết hóa đơn bán
    INSERT INTO ChiTietDonBan (Ma_Hoa_Don_Ban, Ma_San_Pham, So_Luong, Don_Gia, Tong_Tien)
    VALUES (@Ma_Hoa_Don_Ban, @Ma_San_Pham, @So_Luong, @Don_Gia, @Thanh_Tien);
    
    PRINT 'Hóa đơn bán đã được tạo thành công với mã hóa đơn: ' + CAST(@Ma_Hoa_Don_Ban AS varchar);
END



CREATE FUNCTION LayMaHoaDonCuoi()
RETURNS int
AS
BEGIN
    DECLARE @Ma_Hoa_Don_Ban int;

    SELECT @Ma_Hoa_Don_Ban = MAX(Ma_Hoa_Don_Ban) FROM HoaDonBan;

    RETURN @Ma_Hoa_Don_Ban;
END


CREATE PROCEDURE ThemSanPhamVaoHoaDonBan
    @Ma_Hoa_Don_Ban int,
    @Ma_San_Pham varchar(10),
    @So_Luong int
AS
BEGIN
    -- Kiểm tra nếu hóa đơn chưa tồn tại, thì tạo mới
    IF NOT EXISTS (SELECT 1 FROM HoaDonBan WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban)
    BEGIN
        INSERT INTO HoaDonBan (Ma_Hoa_Don_Ban, Ngay, SDT, Thanh_Tien)
        VALUES (@Ma_Hoa_Don_Ban, GETDATE(), NULL, 0); 
    END

    -- Tính giá của sản phẩm từ bảng SanPham
    DECLARE @Don_Gia float;
    SELECT @Don_Gia = Don_Gia FROM SanPham WHERE Ma_San_Pham = @Ma_San_Pham;

    -- Tính tổng tiền cho sản phẩm hiện tại
    DECLARE @Tong_Tien float;
    SET @Tong_Tien = @So_Luong * @Don_Gia;

    -- Kiểm tra xem sản phẩm đã tồn tại trong hóa đơn hay chưa
    IF EXISTS (SELECT 1 FROM ChiTietDonBan WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban AND Ma_San_Pham = @Ma_San_Pham)
    BEGIN
        -- Nếu sản phẩm đã tồn tại, cập nhật số lượng và tổng tiền
        UPDATE ChiTietDonBan
        SET So_Luong = So_Luong + @So_Luong,
            Tong_Tien = Tong_Tien + @Tong_Tien
        WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban AND Ma_San_Pham = @Ma_San_Pham;
    END
    ELSE
    BEGIN
        -- Nếu sản phẩm chưa tồn tại, thêm sản phẩm vào chi tiết hóa đơn bán
        INSERT INTO ChiTietDonBan (Ma_Hoa_Don_Ban, Ma_San_Pham, So_Luong, Don_Gia, Tong_Tien)
        VALUES (@Ma_Hoa_Don_Ban, @Ma_San_Pham, @So_Luong, @Don_Gia, @Tong_Tien);
    END

    -- Cập nhật tổng tiền cho hóa đơn bán
    UPDATE HoaDonBan
    SET Thanh_Tien = Thanh_Tien + @Tong_Tien
    WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;
END;
