
CREATE TRIGGER TRG_Update_Tinh_Trang_SanPham
ON NguyenLieu
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE SanPham
    SET Tinh_Trang = N'Còn hàng'
    WHERE Ma_San_Pham IN (
        SELECT CT.Ma_San_Pham
        FROM CongThuc CT
        JOIN NguyenLieu NL ON CT.Ma_Nguyen_Lieu = NL.Ma_Nguyen_Lieu
        GROUP BY CT.Ma_San_Pham
        HAVING MIN(
            CASE
                WHEN NL.Don_Vi = 'kg' AND CT.DonVi = 'gram' THEN (NL.So_Luong * 1000.0) / CT.So_Luong
                WHEN NL.Don_Vi = 'lit' AND CT.DonVi = 'ml' THEN (NL.So_Luong * 1000.0) / CT.So_Luong
                ELSE NL.So_Luong * 1.0 / CT.So_Luong
            END
        ) >= 1
    );

    UPDATE SanPham
    SET Tinh_Trang = N'Hết hàng'
    WHERE Ma_San_Pham NOT IN (
        SELECT CT.Ma_San_Pham
        FROM CongThuc CT
        JOIN NguyenLieu NL ON CT.Ma_Nguyen_Lieu = NL.Ma_Nguyen_Lieu
        GROUP BY CT.Ma_San_Pham
        HAVING MIN(
            CASE
                WHEN NL.Don_Vi = 'kg' AND CT.DonVi = 'gram' THEN (NL.So_Luong * 1000.0) / CT.So_Luong
                WHEN NL.Don_Vi = 'lit' AND CT.DonVi = 'ml' THEN (NL.So_Luong * 1000.0) / CT.So_Luong
                ELSE NL.So_Luong * 1.0 / CT.So_Luong
            END
        ) >= 1
    );
END;

------------------------------------------------------------------------------------------------
CREATE TRIGGER UpdateThanhTienHoaDonBan
ON ChiTietDonBan
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Ma_Hoa_Don_Ban INT;

    IF EXISTS(SELECT 1 FROM INSERTED)
        SELECT TOP 1 @Ma_Hoa_Don_Ban = Ma_Hoa_Don_Ban FROM INSERTED;
    ELSE IF EXISTS(SELECT 1 FROM DELETED)
        SELECT TOP 1 @Ma_Hoa_Don_Ban = Ma_Hoa_Don_Ban FROM DELETED;

    DECLARE @NewThanhTien INT;
    SET @NewThanhTien = dbo.TinhTongTienTheoHoaDon(@Ma_Hoa_Don_Ban);

    UPDATE HoaDonBan
    SET Thanh_Tien = @NewThanhTien
    WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;
END;
----------------------------------------------------------------------------------------------
	
CREATE PROCEDURE ThemHoaDonBan
    @Thoi_gian DATE,
    @SDT VARCHAR(10)
AS
BEGIN
    INSERT INTO HoaDonBan (Ngay, SDT, Thanh_Tien)
    VALUES (@Thoi_gian, @SDT, 0);
END;


CREATE PROCEDURE SuaHoaDonBan
    @Ma_Hoa_Don_Ban INT,
    @Thoi_gian DATE,
    @SDT VARCHAR(10)
AS
BEGIN
    UPDATE HoaDonBan
    SET 
        Ngay = @Thoi_gian,
        SDT =  @SDT
    WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;
END;


CREATE PROCEDURE XoaHoaDonBan
    @Ma_Hoa_Don_Ban INT
AS
BEGIN
    DELETE FROM ChiTietDonBan WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;

    DELETE FROM HoaDonBan WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;

    PRINT 'Hóa đơn bán và chi tiết đã được xóa thành công.';
END;


---------------------------------------------------------------------------------
CREATE FUNCTION TinhTongTienTheoHoaDon (@Ma_Hoa_Don_Ban int)
RETURNS INT
AS
BEGIN
    DECLARE @Tong_Tien INT;

    -- Tính tổng tiền của tất cả sản phẩm trong hóa đơn dựa theo mã hóa đơn
    SELECT @Tong_Tien = SUM(Tong_Tien)
    FROM ChiTietDonBan
    WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;

    RETURN ISNULL(@Tong_Tien, 0);
END;


CREATE FUNCTION TimKiemHoaDonBan
(
    @Keyword nvarchar(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM HoaDonBan
    WHERE (SDT LIKE @Keyword) OR (Ma_Hoa_Don_Ban  LIKE @Keyword)
);

------------------------------------------------------------------------------------
/*
CREATE PROCEDURE TaoHoaDonBan
    @Ma_San_Pham varchar(10),
    @So_Luong int
AS
BEGIN

    DECLARE @Ma_Hoa_Don_Ban int;
    DECLARE @Thanh_Tien float;

    -- Tạo hóa đơn bán mới (không cần số điện thoại)
    INSERT INTO HoaDonBan (Ngay, SDT, Thanh_Tien)
    VALUES (GETDATE(), NULL, @Thanh_Tien);

    -- Lấy mã hóa đơn vừa tạo
    SET @Ma_Hoa_Don_Ban = SCOPE_IDENTITY();

    -- Thêm chi tiết hóa đơn bán
    INSERT INTO ChiTietDonBan (Ma_Hoa_Don_Ban, Ma_San_Pham, So_Luong, Tong_Tien)
    VALUES (@Ma_Hoa_Don_Ban, @Ma_San_Pham, @So_Luong, @Thanh_Tien);
    
    PRINT 'Hóa đơn bán đã được tạo thành công với mã hóa đơn: ' + CAST(@Ma_Hoa_Don_Ban AS varchar);
END;
*/
-------------------------------------------------------
CREATE FUNCTION LayThongTinHoaDonBan
    (@Ma_Hoa_Don_Ban INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        sp.Ten_San_Pham as Ten_San_Pham,
        ctdb.So_Luong as So_Luong,
        sp.Don_Gia as Don_Gia,
        ctdb.Tong_Tien as Tong_Tien
    FROM ChiTietDonBan AS ctdb
    JOIN SanPham AS sp ON ctdb.Ma_San_Pham = sp.Ma_San_Pham
    WHERE ctdb.Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban
);

-----------------------------------------------------------
CREATE FUNCTION LayMaSanPham
(
    @Ten_San_Pham NVARCHAR(50)
)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @Ma_San_Pham VARCHAR(10);

    SELECT @Ma_San_Pham = Ma_San_Pham
    FROM SanPham
    WHERE Ten_San_Pham = @Ten_San_Pham;

    RETURN @Ma_San_Pham;
END;


CREATE PROCEDURE ThemSanPhamVaoHoaDonBan
    @Ma_Hoa_Don_Ban int,
    @Ma_San_Pham varchar(10),
    @So_Luong int
AS
BEGIN
	
	IF @So_Luong = 0
    BEGIN
        RAISERROR('Số lượng phải > 0', 16, 1)
        RETURN;
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
        INSERT INTO ChiTietDonBan (Ma_Hoa_Don_Ban, Ma_San_Pham, So_Luong, Tong_Tien)
        VALUES (@Ma_Hoa_Don_Ban, @Ma_San_Pham, @So_Luong, @Tong_Tien);
		
		---Không cần cập nhật tổng tiền cho hóa đơn bán vì đã có trigger UpdateThanhTienHoaDonBan

    END
END;

CREATE PROCEDURE XoaSanPhamTrongCTHD
    @Ma_Hoa_Don_Ban INT,
    @Ma_San_Pham VARCHAR(10)
AS
BEGIN   
    DELETE FROM ChiTietDonBan
    WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban AND Ma_San_Pham = @Ma_San_Pham;
END;


CREATE PROCEDURE SuaChiTietHoaDonBan
    @Ma_Hoa_Don_Ban INT,
    @Ma_San_Pham VARCHAR(10),
    @So_Luong INT
AS
BEGIN
    IF @So_Luong = 0
    BEGIN
        EXEC XoaSanPhamTrongCTHD @Ma_Hoa_Don_Ban, @Ma_San_Pham;
        RETURN;
    END

	DECLARE @Don_Gia float;
    SELECT @Don_Gia = Don_Gia FROM SanPham WHERE Ma_San_Pham = @Ma_San_Pham;

    UPDATE ChiTietDonBan
    SET So_Luong = @So_Luong,
        Tong_Tien = @So_Luong * @Don_Gia
    WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban AND Ma_San_Pham = @Ma_San_Pham;

END;




CREATE FUNCTION TimKiemSanPhamTrongCTHD
    (@Ten_San_Pham NVARCHAR(50), @Ma_Hoa_Don_Ban INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        sp.Ten_San_Pham,
        ctdb.So_Luong,
        sp.Don_Gia,
        ctdb.Tong_Tien
    FROM 
        ChiTietDonBan ctdb
    JOIN 
        SanPham sp ON ctdb.Ma_San_Pham = sp.Ma_San_Pham AND ctdb.Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban
    WHERE 
        sp.Ten_San_Pham LIKE '%' + @Ten_San_Pham + '%'
);








