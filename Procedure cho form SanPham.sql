CREATE PROCEDURE ThemSanPham
    @Ma_San_Pham varchar(10),
    @Ten_San_Pham nvarchar(50),
    @Don_Gia int,
    @Tinh_Trang nchar(10) = N'Hết hàng',
    @Ma_Loai_San_Pham varchar(10),
    @Anh image = NULL -- Assuming you will pass image data here
AS
BEGIN
    -- Kiểm tra xem mã sản phẩm đã tồn tại hay chưa
    IF NOT EXISTS (SELECT 1 FROM SanPham WHERE Ma_San_Pham = @Ma_San_Pham)
    BEGIN
        -- Thêm sản phẩm mới vào bảng
        INSERT INTO SanPham (Ma_San_Pham, Ten_San_Pham, Don_Gia, Tinh_Trang, Ma_Loai_San_Pham, Anh)
        VALUES (@Ma_San_Pham, @Ten_San_Pham, @Don_Gia, @Tinh_Trang, @Ma_Loai_San_Pham, @Anh);
    END
    ELSE
    BEGIN
        RAISERROR('Mã sản phẩm đã tồn tại!', 16, 1);
    END
END;


GO

CREATE PROCEDURE XoaSanPham
    @Ma_San_Pham varchar(10)
AS
BEGIN
    -- Biến lưu số lượng tham chiếu tới sản phẩm
    DECLARE @CountChiTietDonBan INT;
    DECLARE @CountCongThuc INT;

    -- Kiểm tra sản phẩm có tồn tại không
    IF EXISTS (SELECT 1 FROM SanPham WHERE Ma_San_Pham = @Ma_San_Pham)
    BEGIN
        -- Kiểm tra xem sản phẩm có được tham chiếu trong bảng ChiTietDonBan không
        SELECT @CountChiTietDonBan = COUNT(*) FROM ChiTietDonBan WHERE Ma_San_Pham = @Ma_San_Pham;

        -- Kiểm tra xem sản phẩm có được tham chiếu trong bảng CongThuc không
        SELECT @CountCongThuc = COUNT(*) FROM CongThuc WHERE Ma_San_Pham = @Ma_San_Pham;

        -- Nếu sản phẩm không tồn tại trong bất kỳ bảng tham chiếu nào, tiến hành xóa
        IF @CountChiTietDonBan = 0 AND @CountCongThuc = 0
        BEGIN
            -- Xóa sản phẩm
            DELETE FROM SanPham WHERE Ma_San_Pham = @Ma_San_Pham;

            PRINT 'Sản phẩm đã được xóa thành công.';
        END
        ELSE
        BEGIN
            -- Nếu sản phẩm tồn tại trong các bảng khác, báo lỗi
            RAISERROR('Sản phẩm đang được sử dụng trong các bảng khác và không thể xóa!', 16, 1);
        END
    END
    ELSE
    BEGIN
        -- Nếu sản phẩm không tồn tại, báo lỗi
        RAISERROR('Sản phẩm không tồn tại!', 16, 1);
    END
END;

GO

CREATE PROCEDURE SuaSanPham
    @Ma_San_Pham VARCHAR(10),        
    @Ten_San_Pham NVARCHAR(50) = NULL, 
    @Don_Gia INT = NULL,             
    @Tinh_Trang NCHAR(10) = NULL,    
    @Ma_Loai_San_Pham VARCHAR(10) = NULL, 
    @Anh IMAGE = NULL                
AS
BEGIN
    -- Kiểm tra sản phẩm có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM SanPham WHERE Ma_San_Pham = @Ma_San_Pham)
    BEGIN
        RAISERROR('Sản phẩm không tồn tại.', 16, 1);
        RETURN;
    END
   
    UPDATE SanPham
    SET 
        Ten_San_Pham = ISNULL(@Ten_San_Pham, Ten_San_Pham),
        Don_Gia = ISNULL(@Don_Gia, Don_Gia),
        Tinh_Trang = ISNULL(@Tinh_Trang, Tinh_Trang),
        Ma_Loai_San_Pham = ISNULL(@Ma_Loai_San_Pham, Ma_Loai_San_Pham),
        Anh = ISNULL(@Anh, Anh)
    WHERE Ma_San_Pham = @Ma_San_Pham;
END;

GO

CREATE FUNCTION TimKiemSanPham
    (@Ten_San_Pham NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM SanPham
    WHERE Ten_San_Pham LIKE '%' + @Ten_San_Pham + '%'
);

