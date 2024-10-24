CREATE PROCEDURE [dbo].[proc_ThemNhaCungCap]
	@MaNCC nchar(10),
	@TenNCC nvarchar(50),
	@DiaChi nchar(100),
	@SDT nchar(10)
AS
BEGIN
	INSERT INTO NhaCungCap(Ma_Nha_Cung_Cap, Ten_Nha_Cung_Cap, Dia_Chi, SDT)
	VALUES (@MaNCC, @TenNCC, @DiaChi, @SDT)
END
GO

-- Cập nhật nhà cung cấp
CREATE PROCEDURE [dbo].[proc_SuaNhaCungCap]
	@MaNCC nchar(10),
	@TenNCC nvarchar(50),
	@DiaChi nchar(100),
	@SDT nchar(10)
AS
BEGIN
	BEGIN TRY
		-- Sửa thông tin nhà cung cấp
		UPDATE dbo.NhaCungCap 
		SET Ten_Nha_Cung_Cap = @TenNCC, Dia_Chi = @DiaChi, SDT = @SDT
		WHERE Ma_Nha_Cung_Cap = @MaNCC
	END TRY
	BEGIN CATCH
		DECLARE @err NVARCHAR(MAX)
		SELECT @err = N'Lỗi' + ERROR_MESSAGE()
		RAISERROR(@err, 16, 1)
	END CATCH
END
GO

-- Xóa nhà cung cấp
CREATE PROCEDURE [dbo].[proc_XoaNhaCungCap]
	@MaNCC nchar(10)
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			-- Xoá nhà cung cấp theo @MaNCC trong bảng NhaCungCap
			DELETE FROM dbo.NhaCungCap WHERE NhaCungCap.Ma_Nha_Cung_Cap = @MaNCC
			COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK
			DECLARE @err NVARCHAR(MAX)
			SELECT @err = N'Lỗi' + ERROR_MESSAGE()
			RAISERROR(@err, 16, 1)
		END CATCH
END
GO
-- Tìm kiếm qua mã nhà cung cấp
CREATE FUNCTION [dbo].[TimKiemNCCBangTenNCCVaSDT] 
(
    @TimKiem nvarchar(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM NhaCungCap
    WHERE Ten_Nha_Cung_Cap LIKE @TimKiem
    OR SDT LIKE @TimKiem
);



--#################################################################################3-
-- NGUYÊN LIỆU
-- Thêm nguyên liệu
CREATE PROCEDURE [dbo].[proc_ThemNguyenLieu]
    @MaNL varchar(10),
    @TenNL nvarchar(50),
    @SoLuong int,
    @DonVi nchar(10),
    @DonGia int,
    @MaNCC varchar(10),
    @Anh varchar(100)
AS
BEGIN
    -- Thêm mới nguyên liệu
    INSERT INTO NguyenLieu(Ma_Nguyen_Lieu, Ten_Nguyen_Lieu, Ma_Nha_Cung_Cap, So_Luong, Don_Vi, Don_Gia, Anh)
    VALUES (@MaNL, @TenNL, @MaNCC, @SoLuong, @DonVi, @DonGia, @Anh)
END
GO


-- Cập nhật nguyên liệu
CREATE PROCEDURE [dbo].[proc_SuaNguyenLieu]
    @MaNL varchar(10),
    @TenNL nvarchar(50),
    @SoLuong int,
    @DonVi nchar(10),
    @DonGia int,
    @MaNCC varchar(10),
    @Anh varchar(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        UPDATE NguyenLieu
        SET Ten_Nguyen_Lieu = @TenNL, Ma_Nha_Cung_Cap = @MaNCC, So_Luong = @SoLuong, Don_Vi = @DonVi, Don_Gia = @DonGia, Anh = @Anh
        WHERE Ma_Nguyen_Lieu = @MaNL;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @err NVARCHAR(MAX);
        SELECT @err = N'Lỗi: ' + ERROR_MESSAGE();
        RAISERROR(@err, 16, 1);
    END CATCH
END
GO


-- Xóa nguyên liệu
CREATE PROCEDURE [dbo].[proc_XoaNguyenLieu]
	 @MaNL varchar(10)
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			DELETE FROM dbo.NguyenLieu WHERE NguyenLieu.Ma_Nguyen_Lieu = @MaNL
			COMMIT TRAN
		END TRY
		BEGIN CATCH
			ROLLBACK
			DECLARE @err NVARCHAR(MAX)
			SELECT @err = N'Xóa nguyên liệu không thành công' + ERROR_MESSAGE()
			RAISERROR(@err, 16, 1)
		END CATCH
END
GO
-- Tìm kiếm qua tên nguyên liệu
CREATE FUNCTION [dbo].[TimKiemNCCBangTenNguyenLieu] 
(
    @NL nvarchar(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM NguyenLieu
    WHERE Ten_Nguyen_Lieu LIKE @NL
);