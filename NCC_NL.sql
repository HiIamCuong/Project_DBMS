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
    @Anh image = NULL  
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM NguyenLieu WHERE Ma_Nguyen_Lieu = @MaNL)
    BEGIN
        INSERT INTO NguyenLieu(Ma_Nguyen_Lieu, Ten_Nguyen_Lieu, Ma_Nha_Cung_Cap, So_Luong, Don_Vi, Don_Gia, Anh)
        VALUES (@MaNL, @TenNL, @MaNCC, @SoLuong, @DonVi, @DonGia, @Anh);
    END
    ELSE
    BEGIN
        RAISERROR('Mã nguyên liệu đã tồn tại!', 16, 1);
    END
END
GO




-- Cập nhật nguyên liệu
CREATE PROCEDURE [dbo].[proc_SuaNguyenLieu]
    @MaNL varchar(10), 
    @TenNL nvarchar(50) = NULL,  
    @SoLuong int = NULL, 
    @DonVi nchar(10) = NULL, 
    @DonGia int = NULL, 
    @MaNCC varchar(10) = NULL, 
    @Anh image = NULL  
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM NguyenLieu WHERE Ma_Nguyen_Lieu = @MaNL)
    BEGIN
        RAISERROR('Nguyên liệu không tồn tại.', 16, 1);
        RETURN;
    END
    UPDATE NguyenLieu
    SET 
        Ten_Nguyen_Lieu = ISNULL(@TenNL, Ten_Nguyen_Lieu),
        So_Luong = ISNULL(@SoLuong, So_Luong),
        Don_Vi = ISNULL(@DonVi, Don_Vi),
        Don_Gia = ISNULL(@DonGia, Don_Gia),
        Ma_Nha_Cung_Cap = ISNULL(@MaNCC, Ma_Nha_Cung_Cap),
        Anh = ISNULL(@Anh, Anh)
    WHERE Ma_Nguyen_Lieu = @MaNL;
END
GO




-- Xóa nguyên liệu
CREATE PROCEDURE [dbo].[proc_XoaNguyenLieu]
    @MaNL varchar(10)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF EXISTS (SELECT 1 FROM ChiTietHoaDonNhap WHERE Ma_Nguyen_Lieu = @MaNL)
        BEGIN
            RAISERROR('Nguyên liệu đang được sử dụng trong các bảng khác và không thể xóa!', 16, 1);
            RETURN;
        END
        
        DELETE FROM NguyenLieu WHERE Ma_Nguyen_Lieu = @MaNL;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @err NVARCHAR(MAX);
        SELECT @err = N'Lỗi khi xóa nguyên liệu: ' + ERROR_MESSAGE();
        RAISERROR(@err, 16, 1);
    END CATCH
END
GO

-- Tìm kiếm qua tên nguyên liệu
CREATE FUNCTION [dbo].[TimKiemBangTenNguyenLieu] 
(
    @NL nvarchar(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM NguyenLieu
    WHERE Ten_Nguyen_Lieu LIKE '%' + @NL + '%'
);
GO
---Trigger về nguyên liệu---
CREATE TRIGGER TRG_Validate_DonVi_NguyenLieu
ON NguyenLieu
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE Don_Vi NOT IN ('kg', 'gram', 'lit', 'ml')
    )
    BEGIN
        -- Gây ra lỗi nếu có đơn vị không hợp lệ
        RAISERROR (N'Chỉ được phép nhập đơn vị "kg", "gram", "lit", hoặc "ml" cho NguyenLieu.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;


--Procedure thêm xóa sửa công thức
CREATE PROCEDURE [dbo].[proc_ThemCongThuc]
	@MaSP varchar(10),
	@MaNL varchar(10),
	@SoLuong int,
	@DonVi nchar(10) 
AS
BEGIN
	INSERT INTO CongThuc(Ma_San_Pham, Ma_Nguyen_Lieu, So_Luong, DonVi)
	VALUES (@MaSP, @MaNL, @SoLuong, @DonVi)
END
GO

CREATE PROCEDURE [dbo].[proc_SuaCongThuc]
    @MaSP varchar(10),
    @MaNL varchar(10),
    @SoLuong int,
    @DonVi nchar(10)
AS
BEGIN
    BEGIN TRY
        UPDATE CongThuc
        SET So_Luong = @SoLuong, DonVi = @DonVi
        WHERE Ma_San_Pham = @MaSP AND Ma_Nguyen_Lieu = @MaNL;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMsg nvarchar(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMsg, 16, 1);
    END CATCH
END
GO

CREATE PROCEDURE [dbo].[proc_XoaCongThuc]
    @MaSP varchar(10),
    @MaNL varchar(10)
AS
BEGIN
    BEGIN TRY
        DELETE FROM CongThuc
        WHERE Ma_San_Pham = @MaSP AND Ma_Nguyen_Lieu = @MaNL;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMsg nvarchar(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMsg, 16, 1);
    END CATCH
END
GO

---Trigger để đúng đơn vị của công thức ---
CREATE TRIGGER trg_SetDonVi
ON CongThuc
AFTER INSERT
AS
BEGIN
    UPDATE c
    SET DonVi = CASE 
                    WHEN i.Ma_Nguyen_Lieu LIKE 'ML%' THEN 'ml'
                    WHEN i.Ma_Nguyen_Lieu LIKE 'GR%' THEN 'gram'
                    ELSE c.DonVi 
                END
    FROM CongThuc c
    INNER JOIN inserted i 
        ON c.Ma_San_Pham = i.Ma_San_Pham
        AND c.Ma_Nguyen_Lieu = i.Ma_Nguyen_Lieu;
END;
