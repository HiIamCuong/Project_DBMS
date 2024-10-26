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
    CONSTRAINT KN_HoaDonNhap_NCC2 FOREIGN KEY (Ma_Nha_Cung_Cap) REFERENCES NhaCungCap(Ma_Nha_Cung_Cap)
	ON DELETE SET NULL		
    ON UPDATE CASCADE
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
	Tinh_Trang nchar(10) DEFAULT N'H?t hàng',
	Ma_Loai_San_Pham varchar(10),
	Anh image,
    CONSTRAINT KN_SanPham_LoaiSP FOREIGN KEY (Ma_Loai_San_Pham) REFERENCES LoaiSanPham(Ma_Loai_San_Pham)

)

CREATE TABLE HoaDonBan(
	Ma_Hoa_Don_Ban int IDENTITY(1,1) CONSTRAINT PK_HoaDonBan PRIMARY KEY,
	Ngay date check (DATEDIFF(year, Ngay, GETDATE())>=0),
	SDT varchar(10) CONSTRAINT FK_HoaDon_KH FOREIGN KEY REFERENCES KhachHang(SDT),
	Thanh_Tien int check (Thanh_Tien>=0),
)

CREATE TABLE ChiTietDonBan(
	Ma_Hoa_Don_Ban int CONSTRAINT FK_ChiTietDB_DB FOREIGN KEY REFERENCES HoaDonBan(Ma_Hoa_Don_Ban),
	Ma_San_Pham varchar(10) CONSTRAINT FK_ChiTietDB_SP FOREIGN KEY REFERENCES SanPham(Ma_San_Pham),
	So_Luong int check (So_Luong>0),
	Don_Gia float check (Don_Gia>=0),
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

INSERT INTO ChiTietDonBan (Ma_Hoa_Don_Ban, Ma_San_Pham, So_Luong, Don_Gia, Tong_Tien)
VALUES 
    (1, 'SP001', 2, 25000, 50000),
    (2, 'SP002', 3, 15000, 45000),
    (3, 'SP003', 1, 30000, 30000);

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
FOR INSERT
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
        RAISERROR('M?t ho?c nhi?u ca làm vi?c không t?n t?i', 16, 1);
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
        HAVING MIN(NL.So_Luong / CT.So_Luong) >= 1
    );
    UPDATE SanPham
    SET Tinh_Trang = N'Hết hàng'
    WHERE Ma_San_Pham NOT IN (
        SELECT CT.Ma_San_Pham
        FROM CongThuc CT
        JOIN NguyenLieu NL ON CT.Ma_Nguyen_Lieu = NL.Ma_Nguyen_Lieu
        GROUP BY CT.Ma_San_Pham
        HAVING MIN(NL.So_Luong / CT.So_Luong) >= 1
    );
END;
GO
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


GO
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

