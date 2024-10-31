USE QLTraSua
CREATE TABLE TaiKhoan(
	Ma_Tai_Khoan varchar(10) PRIMARY KEY,
	Mat_Khau varchar(50) 
)

CREATE TABLE ViTri(
	Ma_Vi_Tri varchar(10) PRIMARY KEY,
	Ten_Vi_Tri nvarchar(50) NOT NULL,
	Luong_Co_Dinh int check (Luong_Co_Dinh > 0) NOT NULL
)

CREATE TABLE NhanVien(
	Ma_Nhan_Vien varchar(10) PRIMARY KEY,
	Ten_Nhan_Vien nvarchar(50) NOT NULL,
	Ngay_Sinh date check (DATEDIFF(year, Ngay_Sinh, GETDATE())>=18),
	Gioi_Tinh varchar(3) NOT NULL,
	Dia_Chi nvarchar(100) NOT NULL,
	SDT varchar(10) NOT NULL check (len(SDT)=10),
	Ma_Vi_Tri varchar(10),
    Ma_Tai_Khoan varchar(10),
	Ngay_Tuyen_Dung date check (DATEDIFF(day, Ngay_Tuyen_Dung, GETDATE())>=0) NOT NULL,
	CONSTRAINT KN_NhanVien_ViTri FOREIGN KEY (Ma_Vi_Tri) REFERENCES ViTri(Ma_Vi_Tri),
    CONSTRAINT KN_NhanVien_TaiKhoan FOREIGN KEY (Ma_Tai_Khoan) REFERENCES TaiKhoan(Ma_Tai_Khoan)
)

CREATE TABLE KhachHang(
	Ma_Khach_Hang int IDENTITY(1,1) PRIMARY KEY,
	SDT varchar(10) check (len(SDT)=10) UNIQUE,
	Ten_Khach_Hang nvarchar(50) NOT NULL,
	Ngay_Sinh date check (DATEDIFF(day, Ngay_Sinh, GETDATE())>=0)
)

CREATE TABLE NhaCungCap(
	Ma_Nha_Cung_Cap varchar(10) PRIMARY KEY,
	Ten_Nha_Cung_Cap nvarchar(50) NOT NULL,
	Dia_Chi nvarchar(100) NOT NULL,
	SDT varchar(10) check (len(SDT)=10)
)


CREATE TABLE HoaDonNhap(
	Ma_Hoa_Don_Nhap int IDENTITY(1,1) PRIMARY KEY,
	Ngay_Nhap date check (DATEDIFF(day, Ngay_Nhap, GETDATE())>=0),
	Tong_Tien int check (Tong_Tien>=0) NOT NULL,
	Ma_Nha_Cung_Cap varchar(10),
	Thoi_Gian time NOT NULL,
	CONSTRAINT KN_HoaDonNhap_NCC FOREIGN KEY (Ma_Nha_Cung_Cap) REFERENCES NhaCungCap(Ma_Nha_Cung_Cap)
    ON DELETE SET NULL		
    ON UPDATE CASCADE
)

CREATE TABLE NguyenLieu(
	Ma_Nguyen_Lieu varchar(10) PRIMARY KEY,
	Ten_Nguyen_Lieu nvarchar(50) NOT NULL,
	So_Luong int check (So_Luong>0) NOT NULL,
	Don_Vi varchar(10) NOT NULL,
    Don_Gia int NOT NULL,
    Ma_Nha_Cung_Cap varchar(10),
    Anh image,
    CONSTRAINT KN_HoaDonNhap_NCC2 FOREIGN KEY (Ma_Nha_Cung_Cap) REFERENCES NhaCungCap(Ma_Nha_Cung_Cap),
)

CREATE TABLE ChiTietHoaDonNhap(
	Ma_Hoa_Don_Nhap int,
	Ma_Nguyen_Lieu varchar(10),
	Don_Gia int check (Don_Gia>=0),
	So_Luong int check (So_Luong>0),
	CONSTRAINT KC_ChiTietNhapHang PRIMARY KEY (Ma_Hoa_Don_Nhap, Ma_Nguyen_Lieu),
	CONSTRAINT KN_ChiTietNH_DonNH FOREIGN KEY (Ma_Hoa_Don_Nhap) REFERENCES HoaDonNhap(Ma_Hoa_Don_Nhap),
	CONSTRAINT KN_ChiTietDN_NL FOREIGN KEY (Ma_Nguyen_Lieu) REFERENCES NguyenLieu(Ma_Nguyen_Lieu)
)

CREATE TABLE LoaiSanPham(
	Ma_Loai_San_Pham varchar(10) PRIMARY KEY,
	Ten_Loai_San_Pham nvarchar(50) NOT NULL
)

CREATE TABLE SanPham(
	Ma_San_Pham varchar(10) PRIMARY KEY,
	Ten_San_Pham nvarchar(50) NOT NULL,
	Don_Gia int check (Don_Gia>0),
	Tinh_Trang nchar(10) DEFAULT N'Hết hàng',
	Ma_Loai_San_Pham varchar(10),
	Anh image,
    CONSTRAINT KN_SanPham_LoaiSP FOREIGN KEY (Ma_Loai_San_Pham) REFERENCES LoaiSanPham(Ma_Loai_San_Pham)

)

CREATE TABLE HoaDonBan(
	Ma_Hoa_Don_Ban int IDENTITY(1,1) CONSTRAINT PK_HoaDonBan PRIMARY KEY,
	Ngay date check (DATEDIFF(year, Ngay, GETDATE())>=0),
	SDT varchar(10),
	Thanh_Tien int check (Thanh_Tien>=0)
)

CREATE TABLE ChiTietDonBan(
	Ma_Hoa_Don_Ban int CONSTRAINT FK_ChiTietDB_DB FOREIGN KEY REFERENCES HoaDonBan(Ma_Hoa_Don_Ban),
	Ma_San_Pham varchar(10) CONSTRAINT FK_ChiTietDB_SP FOREIGN KEY REFERENCES SanPham(Ma_San_Pham),
	So_Luong int check (So_Luong>0),
	Tong_Tien float check (Tong_Tien>=0),
	CONSTRAINT PK_ChiTietHD PRIMARY KEY (Ma_Hoa_Don_Ban, Ma_San_Pham)
)

CREATE TABLE CaLamViec(
	Ma_Ca nchar(10),
	Ngay date check (DATEDIFF(day, Ngay, GETDATE())>=0),
	Gio_Bat_Dau time NOT NULL,
	Gio_Ket_Thuc time NOT NULL,
	CONSTRAINT PK_CaLamViec PRIMARY KEY (Ma_Ca)
)

CREATE TABLE BangPhanCa(
	Ma_Ca nchar(10),
	Ma_Nhan_Vien varchar(10),
	CONSTRAINT PK_BangPhanCa PRIMARY KEY (Ma_Ca, Ma_Nhan_Vien),
	CONSTRAINT FK_PhanCa_Ca FOREIGN KEY (Ma_Ca) REFERENCES CaLamViec(Ma_Ca),
	CONSTRAINT FK_PhanCa_NV FOREIGN KEY (Ma_Nhan_Vien) REFERENCES NhanVien(Ma_Nhan_Vien),
)

CREATE TABLE CongThuc(
	Ma_San_Pham varchar(10),
	Ma_Nguyen_Lieu varchar(10),
	So_Luong int check (So_Luong > 0),
	DonVi nchar(10) NOT NULL
	CONSTRAINT PK_CheBien PRIMARY KEY (Ma_San_Pham, Ma_Nguyen_Lieu)
	CONSTRAINT FK_CheBien_SP FOREIGN KEY (Ma_San_Pham) REFERENCES SanPham(Ma_San_Pham),
	CONSTRAINT FK_CheBien_NL FOREIGN KEY (Ma_Nguyen_Lieu) REFERENCES NguyenLieu(Ma_Nguyen_Lieu)
)







INSERT INTO TaiKhoan (Ma_Tai_Khoan, Mat_Khau)
VALUES 
    ('TK001', 'password123'),
    ('TK002', 'admin@2023'),
    ('TK003', 'user456');

INSERT INTO ViTri (Ma_Vi_Tri, Ten_Vi_Tri, Luong_Co_Dinh)
VALUES 
    ('VT001', N'Nhân viên', 5000000),
    ('VT002', N'Quản lý', 8000000),
    ('VT003', N'Bán hàng', 4500000);

INSERT INTO NhanVien (Ma_Nhan_Vien, Ten_Nhan_Vien, Ngay_Sinh, Gioi_Tinh, Dia_Chi, SDT, Ma_Vi_Tri, Ma_Tai_Khoan, Ngay_Tuyen_Dung)
VALUES 
    ('NV001', N'Nguyễn Van A', '1990-05-10', 'Nam', N'Hà Nội', '0123456789', 'VT001', 'TK001', '2023-05-01'),
    ('NV002', N'Trần Thị B', '1995-08-25', 'N?', N'Hồ Chí Minh', '0987654321', 'VT002', 'TK002', '2023-06-01'),
    ('NV003', N'Phạm Van C', '2000-01-15', 'Nam', N'Ðà Nẵng', '0912345678', 'VT003', 'TK003', '2023-07-01');

INSERT INTO KhachHang (SDT, Ten_Khach_Hang, Ngay_Sinh)
VALUES 
    ('0911111111', N'Lê Thị D', '2001-02-10'),
    ('0922222222', N'Hoàng Van E', '1999-04-15'),
    ('0933333333', N'Trần Thị F', '1987-06-20');

INSERT INTO NhaCungCap (Ma_Nha_Cung_Cap, Ten_Nha_Cung_Cap, Dia_Chi, SDT)
VALUES 
    ('NCC001', N'Công ty A', N'Hà Nội', '0123456780'),
    ('NCC002', N'Công ty B', N'Hồ Chí Minh', '0987654320'),
    ('NCC003', N'Công ty C', N'Ðà Nẵng', '0912345670');

INSERT INTO HoaDonNhap (Ngay_Nhap, Tong_Tien, Ma_Nha_Cung_Cap, Thoi_Gian)
VALUES 
    ('2023-08-01', 5000000, 'NCC001', '10:00:00'),
    ('2023-08-10', 3000000, 'NCC002', '15:00:00'),
    ('2023-08-15', 7000000, 'NCC003', '09:00:00');

INSERT INTO NguyenLieu (Ma_Nguyen_Lieu, Ten_Nguyen_Lieu, So_Luong, Don_Vi, Don_Gia, Ma_Nha_Cung_Cap)
VALUES 
    ('NL001', N'Đường', 100, N'kg', 20000, 'NCC001'),
    ('NL002', N'Sữa', 200, N'lit', 30000, 'NCC002'),
    ('NL003', N'Trái cây', 50, N'kg', 50000, 'NCC003');

INSERT INTO ChiTietHoaDonNhap (Ma_Hoa_Don_Nhap, Ma_Nguyen_Lieu, Don_Gia, So_Luong)
VALUES 
    (1, 'NL001', 20000, 10),
    (2, 'NL002', 30000, 5),
    (3, 'NL003', 50000, 7);

INSERT INTO LoaiSanPham (Ma_Loai_San_Pham, Ten_Loai_San_Pham)
VALUES 
    ('LSP001', N'Trà sữa'),
    ('LSP002', N'Ðá xay'),
    ('LSP003', N'Bánh ngọt');

INSERT INTO SanPham (Ma_San_Pham, Ten_San_Pham, Don_Gia, Ma_Loai_San_Pham)
VALUES 
    ('SP001', N'Trà sữa trân châu', 25000, 'LSP001'),
    ('SP002', N'Bánh ngọt chocolate', 15000, 'LSP003'),
    ('SP003', N'Smoothie dâu', 30000, 'LSP002');

INSERT INTO HoaDonBan (Ngay, SDT, Thanh_Tien)
VALUES 
    ('2023-09-01', '0911111111', 50000),
    ('2023-09-05', '0922222222', 75000),
    ('2023-09-10', '0933333333', 45000);

INSERT INTO ChiTietDonBan (Ma_Hoa_Don_Ban, Ma_San_Pham, So_Luong, Tong_Tien)
VALUES 
    (1, 'SP001', 2, 50000),
    (2, 'SP002', 3, 45000),
    (3, 'SP003', 1, 30000);

INSERT INTO CaLamViec (Ma_Ca, Ngay, Gio_Bat_Dau, Gio_Ket_Thuc)
VALUES 
    ('CA001', '2023-08-01', '08:00:00', '12:00:00'),
    ('CA002', '2023-08-02', '13:00:00', '17:00:00'),
    ('CA003', '2023-08-03', '18:00:00', '22:00:00');

INSERT INTO BangPhanCa (Ma_Ca, Ma_Nhan_Vien)
VALUES 
    ('CA001', 'NV001'),
    ('CA002', 'NV002'),
    ('CA003', 'NV003');

INSERT INTO CongThuc (Ma_San_Pham, Ma_Nguyen_Lieu, So_Luong, DonVi)
VALUES 
    ('SP001', 'NL001', 50, N'gram'),
    ('SP001', 'NL002', 100, N'ml'),
    ('SP002', 'NL003', 150, N'gram');


	--Procedure, Funcition, Trigger--
GO
CREATE TRIGGER Xu_Ly_Lap_Nhan_Vien
ON BangPhanCa
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @Ma_Ca nchar(10), @Ma_NV varchar(10);
	SELECT @Ma_Ca=i.Ma_Ca,@Ma_NV=i.Ma_Nhan_Vien FROM inserted i
    IF EXISTS (
        SELECT 1 
        FROM inserted i 
        WHERE NOT EXISTS (
            SELECT 1 
            FROM CaLamViec c 
            WHERE c.Ma_Ca = i.Ma_Ca
        )
    )
    BEGIN
        RAISERROR('Một hoặc nhiều ca làm việc không tồn tại', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM BangPhanCa s
        JOIN inserted i ON s.Ma_Nhan_Vien = i.Ma_Nhan_Vien
        WHERE (i.Ma_Ca=s.Ma_Ca)
    )
    BEGIN
        RAISERROR('Nhân viên dã tồn tại trong ca làm việc này', 16, 1);
        ROLLBACK TRANSACTION;
    END
	ELSE
	BEGIN
        INSERT INTO BangPhanCa(Ma_Ca,Ma_Nhan_Vien)
        VALUES (@Ma_Ca,@Ma_NV);
    END
END;

GO
CREATE TRIGGER Xu_Ly_Ca_Lam_Chong_Cheo
ON CaLamViec
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @start_time TIME, @end_time TIME,@Date DATE,@Schedule_id nchar(10);

    SELECT @start_time = Gio_Bat_Dau, @end_time = Gio_Ket_Thuc, @Date = Ngay, @Schedule_id=Ma_Ca
    FROM inserted;

    IF EXISTS (
        SELECT 1
        FROM CaLamViec
        WHERE (@Date=Ngay AND @start_time <= Gio_Ket_Thuc AND @end_time > Gio_Bat_Dau)
    )
    BEGIN
        RAISERROR('Ca làm bị chồng chéo!', 16, 1);
    END
    ELSE
    BEGIN
        INSERT INTO CaLamViec(Gio_Bat_Dau, Gio_Ket_Thuc,Ngay,Ma_Ca)
        VALUES (@start_time, @end_time, @Date,@Schedule_id);
    END
END;

--Start Quỳnh Procedure, Funcition ################################################################--
Go
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
Go
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
GO
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


--End Procudure, Funtion Quỳnh################################################################n---


--#########################Start QuynhThu##########################################--

GO
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

-----------------------------------------------------------------------------------------------
GO
CREATE TRIGGER TRG_Update_Tinh_Trang_SanPham2
ON CongThuc
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

----------------------------------------------------------------------------------------------
GO
CREATE TRIGGER UpdateThanhTienHoaDonBan
ON ChiTietDonBan
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Ma_Hoa_Don_Ban INT;
    DECLARE @SDT VARCHAR(10);
    DECLARE @Thoi_Gian DATE;
    DECLARE @NewThanhTien INT;

    IF EXISTS(SELECT 1 FROM INSERTED)
        SELECT TOP 1 @Ma_Hoa_Don_Ban = Ma_Hoa_Don_Ban FROM INSERTED;
    ELSE IF EXISTS(SELECT 1 FROM DELETED)
        SELECT TOP 1 @Ma_Hoa_Don_Ban = Ma_Hoa_Don_Ban FROM DELETED;

    SET @NewThanhTien = dbo.TinhTongTienTheoHoaDon(@Ma_Hoa_Don_Ban);

    SELECT @SDT = hdb.SDT, @Thoi_Gian = hdb.Ngay
    FROM HoaDonBan hdb
    WHERE hdb.Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;

    IF dbo.CheckTongTienHoaDon(@SDT, @Thoi_Gian) = 1
    BEGIN
        UPDATE HoaDonBan
        SET Thanh_Tien = @NewThanhTien * 0.9
        WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;
    END
    ELSE
    BEGIN
        UPDATE HoaDonBan
        SET Thanh_Tien = @NewThanhTien
        WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;
    END
END;
	
----------------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE ThemHoaDonBan
    @Thoi_gian DATE,
    @SDT VARCHAR(10)
AS
BEGIN
    INSERT INTO HoaDonBan (Ngay, SDT, Thanh_Tien)
    VALUES (@Thoi_gian, @SDT, 0);
END;

GO
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

GO
CREATE PROCEDURE XoaHoaDonBan
    @Ma_Hoa_Don_Ban INT
AS
BEGIN
    DELETE FROM ChiTietDonBan WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;

    DELETE FROM HoaDonBan WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;

    PRINT 'Hóa đơn bán và chi tiết đã được xóa thành công.';
END;


---------------------------------------------------------------------------------
GO
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

-------------------------------------------------------------------------------------
GO
CREATE FUNCTION CheckTongTienHoaDon
    (@SDT VARCHAR(10), @Ngay DATE)
RETURNS BIT
AS
BEGIN
    DECLARE @Result BIT;
    DECLARE @TotalAmount INT;

    SELECT @TotalAmount = SUM(Thanh_Tien)
    FROM HoaDonBan
    WHERE SDT = @SDT
      AND Ngay < @Ngay;

    IF @TotalAmount >= 1000000
        SET @Result = 1;  
    ELSE
        SET @Result = 0; 

    RETURN @Result;
END;


--------------------------------------------------------------------------------------
GO
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
GO
CREATE PROCEDURE TaoHoaDonBan
    @Ma_San_Pham varchar(10),
    @So_Luong int
AS
BEGIN

    DECLARE @Ma_Hoa_Don_Ban int;
    DECLARE @Thanh_Tien float;

    INSERT INTO HoaDonBan (Ngay, SDT, Thanh_Tien)
    VALUES (GETDATE(), NULL, @Thanh_Tien);

    -- Lấy mã hóa đơn vừa tạo
    SET @Ma_Hoa_Don_Ban = SCOPE_IDENTITY();

    -- Thêm chi tiết hóa đơn bán
    INSERT INTO ChiTietDonBan (Ma_Hoa_Don_Ban, Ma_San_Pham, So_Luong, Tong_Tien)
    VALUES (@Ma_Hoa_Don_Ban, @Ma_San_Pham, @So_Luong, @Thanh_Tien);
    
    PRINT 'Hóa đơn bán đã được tạo thành công với mã hóa đơn: ' + CAST(@Ma_Hoa_Don_Ban AS varchar);
END;

-------------------------------------------------------
GO
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
GO

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

GO
CREATE PROCEDURE XoaSanPhamTrongCTHD
    @Ma_Hoa_Don_Ban INT,
    @Ma_San_Pham VARCHAR(10)
AS
BEGIN   
    DELETE FROM ChiTietDonBan
    WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban AND Ma_San_Pham = @Ma_San_Pham;
END;

GO
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

---------------------------------------------------------------------------------------

GO
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

GO
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


--End Procudure, Funtion Quỳnh Thư################################################################n---

--Begin SyCuong################################################################
GO
CREATE VIEW LichLamViecTuan AS
SELECT 
	NV.Ma_Nhan_Vien,
	NV.Ten_Nhan_Vien,
	CL.Ngay,
	CL.Gio_Bat_Dau,
	CL.Gio_Ket_Thuc,
	CL.Ma_Ca
FROM 
	BangPhanCa BPC
JOIN 
	CaLamViec CL ON BPC.Ma_Ca = CL.Ma_Ca
JOIN 
	NhanVien NV ON BPC.Ma_Nhan_Vien = NV.Ma_Nhan_Vien
--WHERE 
	--DATEDIFF(week, GETDATE(), CL.Ngay) = 0;
GO
CREATE VIEW View_DoanhThuCaLamViec AS
	--SELECT 
		--CL.Ma_Ca,
		--CL.Gio_Bat_Dau,
		--CL.Gio_Ket_Thuc,
		--SUM(HDB.Thanh_Tien) AS Tong_Doanh_Thu
	--FROM 
		--HoaDonBan HDB, BangPhanCa BPC
	--JOIN 
		--CaLamViec CL ON BPC.Ma_Ca = CL.Ma_Ca
	--WHERE 
		-- Kết hợp ngày và giờ của hóa đơn với giờ của ca làm việc
		--CAST(HDB.Ngay AS DATETIME) + CAST(CL.Gio_Bat_Dau AS DATETIME) <= CAST(HDB.Ngay AS DATETIME)
		--AND CAST(HDB.Ngay AS DATETIME) + CAST(CL.Gio_Ket_Thuc AS DATETIME) >= CAST(HDB.Ngay AS DATETIME)
		--HDB.Ngay=BPC.
	--GROUP BY 
		--CL.Ma_Ca, CL.Gio_Bat_Dau, CL.Gio_Ket_Thuc;
	SELECT 
		HDB.Ngay,
		Gio_Bat_Dau,
		Gio_Ket_Thuc,
		SUM(Thanh_Tien) Tong_Doanh_Thu
	FROM 
		HoaDonBan HDB 
	JOIN 
		CaLamViec CL ON CL.Ngay = HDB.Ngay 
	GROUP BY 
		HDB.Ngay,Gio_Bat_Dau,Gio_Ket_Thuc
GO
CREATE PROCEDURE Them_Ca_Lam(@Ma_Ca nchar(10),@Ngay Date,@Gio_Bat_Dau Time,@Gio_Ket_Thuc Time)
AS
BEGIN
	INSERT INTO CaLamViec VALUES(@Ma_Ca,@Ngay,@Gio_Bat_Dau,@Gio_Ket_Thuc)
END
GO
CREATE PROCEDURE Sua_Ca_Lam(@Ma_Ca nchar(10),@Ngay Date,@Gio_Bat_Dau Time,@Gio_Ket_Thuc Time)
AS
BEGIN
	UPDATE CaLamViec
	SET Ngay = @Ngay,Gio_Bat_Dau=@Gio_Bat_Dau,@Gio_Ket_Thuc=@Gio_Ket_Thuc
	WHERE Ma_Ca=@Ma_Ca;
END
GO
CREATE PROCEDURE Xoa_Ca_Lam(@Ma_Ca nchar(10))
AS
BEGIN
	DELETE FROM CaLamViec WHERE Ma_Ca=@Ma_Ca
END
GO
CREATE PROCEDURE Them_Nhan_Vien_Vao_Ca_Lam(@Ma_Ca nchar(10),@Ma_Nhan_Vien nchar(10))
AS
BEGIN
	INSERT INTO BangPhanCa VALUES(@Ma_Ca,@Ma_Nhan_Vien)
END
GO
CREATE PROCEDURE Xoa_Nhan_Vien_Vao_Ca_Lam(@Ma_Ca nchar(10),@Ma_Nhan_Vien nchar(10))
AS
BEGIN
	DELETE FROM BangPhanCa WHERE Ma_Ca=@Ma_Ca AND Ma_Nhan_Vien=@Ma_Nhan_Vien
END
GO
CREATE FUNCTION DoanhThuQuanLy(@Thang INT, @Nam INT)
RETURNS TABLE
AS
RETURN
(
    SELECT * 
    FROM HoaDonBan 
    WHERE MONTH(Ngay) = @Thang AND YEAR(Ngay) = @Nam
);
--END SyCuong##################################################################



-------START ###################### ANH THU ###################################################################
-- Thêm nhân viên --
GO
CREATE PROCEDURE [dbo].[pro_ThemNhanVien]
    @MaNV nchar(10),
    @TenNV nvarchar(50),
    @NgaySinh date,
    @GioiTinh varchar(3),
    @DiaChi nvarchar(100),
    @SDT nvarchar(10),
    @MaViTri varchar(10),
    @MaTaiKhoan varchar(10),
    @NgayTuyenDung date
AS
BEGIN
    -- Bắt đầu transaction
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Thêm mã tài khoản vào bảng TaiKhoan trước
        INSERT INTO TaiKhoan (Ma_Tai_Khoan)
        VALUES (@MaTaiKhoan);
        -- Thêm nhân viên vào bảng NhanVien, với Ma_Tai_Khoan là khóa ngoại
        INSERT INTO NhanVien (Ma_Nhan_Vien, Ten_Nhan_Vien, Ngay_Sinh, Gioi_Tinh, Dia_Chi, SDT, Ma_Vi_Tri, Ma_Tai_Khoan, Ngay_Tuyen_Dung)
        VALUES (@MaNV, @TenNV, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @MaViTri, @MaTaiKhoan, @NgayTuyenDung);

        -- Xác nhận transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback transaction nếu có lỗi
        ROLLBACK TRANSACTION;
        
        -- Trả về thông tin lỗi
        THROW;
    END CATCH
END;
GO
-- Thêm mật khẩu
CREATE PROCEDURE AddPasswordByEmployee
    @Ma_Nhan_Vien VARCHAR(10),
    @Mat_Khau VARCHAR(50)
AS
BEGIN
    DECLARE @Ma_Tai_Khoan VARCHAR(10);

    -- Lấy mã tài khoản của nhân viên
    SELECT @Ma_Tai_Khoan = Ma_Tai_Khoan 
    FROM NhanVien 
    WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien;

    -- Kiểm tra xem mã nhân viên có tồn tại không
    IF @Ma_Tai_Khoan IS NULL
    BEGIN
        PRINT 'Mã nhân viên không tồn tại.';
        RETURN;
    END

    -- Kiểm tra xem tài khoản đã tồn tại chưa
    IF EXISTS (SELECT 1 FROM TaiKhoan WHERE Ma_Tai_Khoan = @Ma_Tai_Khoan)
    BEGIN
        -- Cập nhật mật khẩu
        UPDATE TaiKhoan 
        SET Mat_Khau = @Mat_Khau 
        WHERE Ma_Tai_Khoan = @Ma_Tai_Khoan;
        PRINT 'Cập nhật mật khẩu thành công.';
    END
    ELSE
    BEGIN
        -- Nếu không tồn tại, thêm tài khoản mới
        INSERT INTO TaiKhoan (Ma_Tai_Khoan, Mat_Khau) 
        VALUES (@Ma_Tai_Khoan, @Mat_Khau);
        PRINT 'Thêm tài khoản thành công.';
    END
END
GO
-- Xóa nhân viên --
CREATE PROCEDURE [dbo].[pro_XoaNhanVien]
@MaNV nchar(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM NhanVien WHERE Ma_Nhan_Vien = @MaNV;
            DELETE FROM PhanCa WHERE Ma_Nhan_Vien = @MaNV;
        END TRY
        BEGIN CATCH
            DECLARE @err NVARCHAR(MAX)
            SELECT @err = N'Lỗi ' + ERROR_MESSAGE()
            RAISERROR(@err, 16, 1)
            ROLLBACK TRANSACTION;
            THROW;
        END CATCH   
    COMMIT TRANSACTION;
END;
GO
--*Tìm kiếm nhân viên
CREATE FUNCTION [dbo].[TimKiemNhanVien]
(
	@TimKiem nvarchar(50)
)
RETURNS TABLE
AS
RETURN
(
	SELECT *
	FROM NhanVien
	WHERE Ten_Nhan_Vien LIKE '%' + @TimKiem + '%' OR Ma_Nhan_Vien LIKE '%' + @TimKiem + '%'
);
GO
--- Tìm kiếm khách hàng
CREATE FUNCTION [dbo].[TimKiemKhachHang]
(
	@TimKiem nvarchar(50)
)
RETURNS TABLE
AS
RETURN
(
	SELECT *
	FROM KhachHang
	WHERE Ten_Khach_Hang LIKE '%' + @TimKiem + '%' OR SDT LIKE '%' + @TimKiem + '%'
);
GO
-- *Theo dõi hóa đơn bán --
CREATE PROCEDURE sp_TheoDoiHoaDonBan
    @Thang INT,
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Lấy thông tin hóa đơn bán và chi tiết hóa đơn theo tháng và năm
    SELECT hdb.Ma_Hoa_Don_Ban,
           hdb.Ma_Khach_Hang,
           hdb.Thoi_Gian,
           hdb.Tong_Tien,
           cthdb.Ma_San_Pham,
           cthdb.So_Luong,
           cthdb.Don_Gia
    FROM HoaDonBan hdb
    JOIN ChiTietHoaDonBan cthdb ON hdb.MaHoaDonBan = cthdb.MaHoaDonBan
    WHERE MONTH(hdb.ThoiGian) = @Thang
      AND YEAR(hdb.ThoiGian) = @Nam
    ORDER BY hdb.ThoiGian;
END;
GO
-- *Cập nhật thông tin khách hàng --
CREATE PROCEDURE [dbo].[pro_CapNhatKhachHang]
@MaKH nchar(10),
@TenKH nvarchar(50),
@NgaySinh date,
@SDT nvarchar(50)
AS
BEGIN
    UPDATE KhachHang
    SET Ten_Khach_Hang = @TenKH, Ngay_Sinh = @NgaySinh, SDT = @SDT
    WHERE Ma_Khach_Hang = @MaKH
END;

--- *Một số procedure bổ sung thêm* ---
-- Cập nhật nhân viên
GO
CREATE PROCEDURE [dbo].[pro_CapNhatNhanVien]
@MaNV nchar(10),
@TenNV nvarchar(50),
@NgaySinh date,
@GioiTinh varchar(3),
@DiaChi nvarchar(100),
@SDT nvarchar(10),
@MaViTri varchar(10),
@MaTaiKhoan varchar(10),
@NgayTuyenDung date
AS
BEGIN
    UPDATE NhanVien
    SET Ten_Nhan_Vien = @TenNV, Ngay_Sinh = @NgaySinh, Gioi_Tinh = @GioiTinh, Dia_Chi = @DiaChi, 
    SDT = @SDT, Ma_Vi_Tri = @MaViTri, Ma_Tai_Khoan = @MaTaiKhoan, Ngay_Tuyen_Dung = @NgayTuyenDung
    WHERE Ma_Nhan_Vien = @MaNV
END;
GO
-- Thêm khách hàng
CREATE PROCEDURE [dbo].[pro_ThemKhachHang]
@MaKH nchar(10),
@TenKH nvarchar(50),
@NgaySinh date,
@SDT nvarchar(50)
AS
BEGIN
    INSERT INTO KhachHang (Ma_Khach_Hang, Ten_Khach_Hang, Ngay_Sinh, SDT)
    VALUES (@MaKH, @TenKH, @NgaySinh, @SDT)
END;


---------------------------------------------------------------
---------------------------------------------------------------
-- Các procedure HDN
-- Thêm HDN
GO
CREATE PROCEDURE ThemHoaDonNhap
    @Ngay_Nhap DATE,
    @Tong_Tien INT,
    @Ma_Nha_Cung_Cap NVARCHAR(10),
    @Thoi_Gian TIME
AS
BEGIN
    INSERT INTO HoaDonNhap (Ngay_Nhap, Tong_Tien, Ma_Nha_Cung_Cap, Thoi_Gian)
    VALUES (@Ngay_Nhap, @Tong_Tien, @Ma_Nha_Cung_Cap, @Thoi_Gian);
END;

GO
--- Function lấy mã NCC thông qua Tên NCC
GO
CREATE FUNCTION GetMaNhaCungCap(@Ten_Nha_Cung_Cap NVARCHAR(100))
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @Ma_Nha_Cung_Cap VARCHAR(10);

    -- Tìm mã nhà cung cấp dựa trên tên nhà cung cấp
    SELECT @Ma_Nha_Cung_Cap = Ma_Nha_Cung_Cap 
    FROM NhaCungCap 
    WHERE Ten_Nha_Cung_Cap = @Ten_Nha_Cung_Cap; -- Giả sử cột tên nhà cung cấp là Ten_Nha_Cung_Cap

    RETURN @Ma_Nha_Cung_Cap; -- Trả về mã nhà cung cấp
END;
GO

-- Xóa HDN
CREATE PROCEDURE XoaHoaDonNhap
    @Ma_Hoa_Don_Nhap INT
AS
BEGIN
    DELETE FROM HoaDonNhap
    WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap;
END;

-- Cập nhật HDN
GO
CREATE PROCEDURE CapNhatHoaDonNhap
    @Ma_Hoa_Don_Nhap INT,
    @Ngay_Nhap DATE,
    @Tong_Tien INT,
    @Ma_Nha_Cung_Cap VARCHAR(10),
    @Thoi_Gian TIME
AS
BEGIN
    UPDATE HoaDonNhap
    SET Ngay_Nhap = @Ngay_Nhap,
        Tong_Tien = @Tong_Tien,
        Ma_Nha_Cung_Cap = @Ma_Nha_Cung_Cap,
        Thoi_Gian = @Thoi_Gian
    WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap;
END;

-- Tìm kiếm HDN theo Mã hóa đơn nhập và Mã nhà cung cấp
GO
CREATE FUNCTION [dbo].[TimKiemHDN]
(
	@TimKiem nvarchar(50)
)
RETURNS TABLE
AS
RETURN
(
	SELECT *
	FROM HoaDonNhap
	WHERE Ma_Hoa_Don_Nhap LIKE '%' + @TimKiem + '%' OR Ma_Nha_Cung_Cap LIKE '%' + @TimKiem + '%'
);

GO
-- Thêm Chi Tiết HDN
GO
CREATE PROCEDURE ThemChiTietHoaDonNhap
    @Ma_Hoa_Don_Nhap INT,
    @Ma_Nguyen_Lieu VARCHAR(10),
    @Don_Gia INT,
    @So_Luong INT
AS
BEGIN
    INSERT INTO ChiTietHoaDonNhap (Ma_Hoa_Don_Nhap, Ma_Nguyen_Lieu, Don_Gia, So_Luong)
    VALUES (@Ma_Hoa_Don_Nhap, @Ma_Nguyen_Lieu, @Don_Gia, @So_Luong);
END;
GO
-- Xóa Chi tiết HDN
GO
CREATE PROCEDURE XoaChiTietHoaDonNhap
    @Ma_Hoa_Don_Nhap INT,
    @Ma_Nguyen_Lieu VARCHAR(10)
AS
BEGIN
    DELETE FROM ChiTietHoaDonNhap
    WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap
      AND Ma_Nguyen_Lieu = @Ma_Nguyen_Lieu;
END;
GO

-- Cập nhật Chi tiết HDN
GO
CREATE PROCEDURE SuaChiTietHoaDonNhap
    @Ma_Hoa_Don_Nhap INT,
    @Ma_Nguyen_Lieu VARCHAR(10),
    @Don_Gia INT,
    @So_Luong INT
AS
BEGIN
    UPDATE ChiTietHoaDonNhap
    SET Don_Gia = @Don_Gia,
        So_Luong = @So_Luong
    WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap
      AND Ma_Nguyen_Lieu = @Ma_Nguyen_Lieu;
END;
GO

-- Xuất bill + Cập nhật Nguyên liệu
GO
CREATE PROCEDURE XuatHoaDonNhap
    @Ma_Hoa_Don_Nhap INT
AS
BEGIN
    -- Cập nhật số lượng nguyên liệu trong bảng NguyenLieu dựa trên ChiTietHoaDonNhap
    UPDATE N
    SET N.So_Luong = N.So_Luong + C.So_Luong
    FROM NguyenLieu N
    JOIN ChiTietHoaDonNhap C ON N.Ma_Nguyen_Lieu = C.Ma_Nguyen_Lieu
    WHERE C.Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap;
  
END;
GO
---- Thêm vị trí
GO
CREATE PROCEDURE [dbo].[pro_ThemViTri]
@MaVT varchar(10),
@TenVT nvarchar(50),
@Luong int
AS
BEGIN
    INSERT INTO ViTri (Ma_Vi_Tri, Ten_Vi_Tri, Luong_Co_Dinh)
    VALUES (@MaVT, @TenVT, @Luong)
END;
GO
--- Cập nhật vị trí
GO
CREATE PROCEDURE [dbo].[pro_CapNhatViTri]
@MaVT varchar(10),
@TenVT nvarchar(50),
@Luong int
AS
BEGIN
    UPDATE ViTri
    SET Ten_Vi_Tri = @TenVT, Luong_Co_Dinh = @Luong
    WHERE Ma_Vi_Tri = @MaVT
END;
GO
-- Xóa vị trí
GO
CREATE PROCEDURE [dbo].[pro_XoaViTri]
@MaVT varchar(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
        BEGIN TRY
            DELETE FROM ViTri WHERE Ma_Vi_Tri = @MaVT
        END TRY
        BEGIN CATCH
            DECLARE @err NVARCHAR(MAX)
            SELECT @err = N'Lỗi ' + ERROR_MESSAGE()
            RAISERROR(@err, 16, 1)
            ROLLBACK TRANSACTION;
            THROW;
        END CATCH   
    COMMIT TRANSACTION;
END;

GO

-------END ######################## Anh THU ###################################################################