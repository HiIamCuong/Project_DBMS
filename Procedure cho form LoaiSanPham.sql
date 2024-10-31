GO
CREATE PROCEDURE ThemLoaiSanPham
    @Ma_Loai_San_Pham VARCHAR(10),          
    @Ten_Loai_San_Pham NVARCHAR(255)      

AS
BEGIN
    IF EXISTS (SELECT 1 FROM LoaiSanPham WHERE Ma_Loai_San_Pham = @Ma_Loai_San_Pham)
    BEGIN
        RAISERROR('Mã loại sản phẩm đã tồn tại.', 16, 1);
        RETURN;
    END

    -- Kiểm tra nếu tên loại sản phẩm đã tồn tại
    IF EXISTS (SELECT 1 FROM LoaiSanPham WHERE Ten_Loai_San_Pham = @Ten_Loai_San_Pham)
    BEGIN
        RAISERROR('Tên loại sản phẩm này đã tồn tại.', 16, 1);
        RETURN;
    END

    -- Thêm loại sản phẩm mới
    INSERT INTO LoaiSanPham (Ma_Loai_San_Pham, Ten_Loai_San_Pham)
    VALUES (@Ma_Loai_San_Pham, @Ten_Loai_San_Pham);

END;

GO

CREATE PROCEDURE SuaLoaiSanPham
    @Ma_Loai_San_Pham VARCHAR(10),        
    @Ten_Loai_San_Pham NVARCHAR(255)    
AS
BEGIN
    -- Kiểm tra mã loại sản phẩm có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM LoaiSanPham WHERE Ma_Loai_San_Pham = @Ma_Loai_San_Pham)
    BEGIN
        RAISERROR('Mã loại sản phẩm không tồn tại.', 16, 1);
        RETURN;
    END

    -- Kiểm tra nếu tên loại sản phẩm mới đã tồn tại
    IF EXISTS (SELECT 1 FROM LoaiSanPham WHERE Ten_Loai_San_Pham = @Ten_Loai_San_Pham AND Ma_Loai_San_Pham != @Ma_Loai_San_Pham)
    BEGIN
        RAISERROR('Tên loại sản phẩm mới đã tồn tại.', 16, 1);
        RETURN;
    END

    -- Cập nhật tên loại sản phẩm
    UPDATE LoaiSanPham
    SET Ten_Loai_San_Pham = @Ten_Loai_San_Pham
    WHERE Ma_Loai_San_Pham = @Ma_Loai_San_Pham;

    PRINT 'Sửa loại sản phẩm thành công.';
END;

GO 

CREATE PROCEDURE XoaLoaiSanPham
    @Ma_Loai_San_Pham VARCHAR(10)  
AS
BEGIN
    -- Kiểm tra nếu mã loại sản phẩm không tồn tại
    IF NOT EXISTS (SELECT 1 FROM LoaiSanPham WHERE Ma_Loai_San_Pham = @Ma_Loai_San_Pham)
    BEGIN
        RAISERROR(N'Mã loại sản phẩm không tồn tại.', 16, 1);
        RETURN;
    END

    -- Kiểm tra nếu mã loại sản phẩm có được tham chiếu ở các bảng khác
    IF EXISTS (SELECT 1 FROM SanPham WHERE Ma_Loai_San_Pham = @Ma_Loai_San_Pham)
    BEGIN
        RAISERROR(N'Mã loại sản phẩm đang được sử dụng ở bảng khác.', 16, 1);
        RETURN;
    END

    DELETE FROM LoaiSanPham
    WHERE Ma_Loai_San_Pham = @Ma_Loai_San_Pham;

    PRINT N'Xóa loại sản phẩm thành công.';
END;

GO

CREATE FUNCTION TimKiemLoaiSanPham
    (@Ten_Loai_San_Pham NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM LoaiSanPham
    WHERE Ten_Loai_San_Pham LIKE '%' + @Ten_Loai_San_Pham + '%'
);

