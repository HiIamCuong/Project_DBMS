USE QLTraSua
--*TẠO BẢNG*--
--Bảng tài khoản
CREATE TABLE TaiKhoan(
	Ma_Tai_Khoan varchar(10) PRIMARY KEY,
	Mat_Khau varchar(50) NOT NULL
)

-- Bảng vị trí
CREATE TABLE ViTri(
	Ma_Vi_Tri varchar(10) PRIMARY KEY,
	Ten_Vi_Tri nvarchar(50) NOT NULL,
	Luong_Co_Dinh int check (Luong_Co_Dinh > 0) NOT NULL
)

-- Bảng nhân viên
CREATE TABLE NhanVien(
	Ma_Nhan_Vien varchar(10) PRIMARY KEY,
	Ten_Nhan_Vien nvarchar(50) NOT NULL,
	Ngay_Sinh date check (DATEDIFF(year, Ngay_Sinh, GETDATE())>=18),
	Gioi_Tinh varchar(3) NOT NULL,
	Dia_Chi nvarchar(100) NOT NULL,
	SDT varchar(50) NOT NULL check (len(SDT)=10),
	Ma_Vi_Tri varchar(10),
    Ma_Tai_Khoan varchar(10),
	Ngay_Tuyen_Dung date check (DATEDIFF(day, Ngay_Tuyen_Dung, GETDATE())>=0) NOT NULL,
	CONSTRAINT KN_NhanVien_ViTri FOREIGN KEY (Ma_Vi_Tri) REFERENCES ViTri(Ma_Vi_Tri),
    CONSTRAINT KN_NhanVien_TaiKhoan FOREIGN KEY (Ma_Tai_Khoan) REFERENCES TaiKhoan(Ma_Tai_Khoan)
)

-- Bảng khách hàng
CREATE TABLE KhachHang(
	Ma_Khach_Hang varchar(10) PRIMARY KEY,
	SDT varchar(50) check (len(SDT)=10) UNIQUE,
	Ten_Khach_Hang nvarchar(50) NOT NULL,
	Ngay_Sinh date check (DATEDIFF(day, Ngay_Sinh, GETDATE())>=0)
)

-- Bảng nhà cung cấp
CREATE TABLE NhaCungCap(
	Ma_Nha_Cung_Cap varchar(10) PRIMARY KEY,
	Ten_Nha_Cung_Cap nvarchar(50) NOT NULL,
	Dia_Chi nvarchar(100) NOT NULL,
	SDT varchar(50) check (len(SDT)=10)
)

-- Bảng hóa đơn nhập
CREATE TABLE HoaDonNhap(
	Ma_Hoa_Don_Nhap varchar(10) PRIMARY KEY,
	Ngay_Nhap date check (DATEDIFF(day, Ngay_Nhap, GETDATE())>=0),
	Tong_Tien int check (Tong_Tien>=0) NOT NULL,
	Ma_Nha_Cung_Cap varchar(10),
	Thoi_Gian time NOT NULL,
	CONSTRAINT KN_HoaDonNhap_NCC FOREIGN KEY (Ma_Nha_Cung_Cap) REFERENCES NhaCungCap(Ma_Nha_Cung_Cap),
)

-- Bảng nguyên liệu
CREATE TABLE NguyenLieu(
	Ma_Nguyen_Lieu varchar(10) PRIMARY KEY,
	Ten_Nguyen_Lieu nvarchar(50) NOT NULL,
	So_Luong int check (So_Luong>0) NOT NULL,
	Don_Vi varchar(10) NOT NULL,
    Don_Gia int NOT NULL,
    Ma_Nha_Cung_Cap varchar(10),
    Anh varchar(100),
    CONSTRAINT KN_HoaDonNhap_NCC2 FOREIGN KEY (Ma_Nha_Cung_Cap) REFERENCES NhaCungCap(Ma_Nha_Cung_Cap),
)

-- Bảng chi tiết đơn nhập
CREATE TABLE ChiTietHoaDonNhap(
	Ma_Hoa_Don_Nhap varchar(10),
	Ma_Nguyen_Lieu varchar(10),
	Don_Gia int check (Don_Gia>=0),
	So_Luong int check (So_Luong>0),
	Don_Vi nchar(10) NOT NULL,
	CONSTRAINT KC_ChiTietNhapHang PRIMARY KEY (Ma_Hoa_Don_Nhap, Ma_Nguyen_Lieu),
	CONSTRAINT KN_ChiTietNH_DonNH FOREIGN KEY (Ma_Hoa_Don_Nhap) REFERENCES HoaDonNhap(Ma_Hoa_Don_Nhap),
	CONSTRAINT KN_ChiTietDN_NL FOREIGN KEY (Ma_Nguyen_Lieu) REFERENCES NguyenLieu(Ma_Nguyen_Lieu)
)

-- Bảng loại sản phẩm
CREATE TABLE LoaiSanPham(
	Ma_Loai_San_Pham varchar(10) PRIMARY KEY,
	Ten_Loai_San_Pham nvarchar(50) NOT NULL
)

-- Bảng sản phẩm
CREATE TABLE SanPham(
	Ma_San_Pham varchar(10) PRIMARY KEY,
	Ten_San_Pham nvarchar(50) NOT NULL,
	Don_Gia int check (Don_Gia>0),
	Tinh_Trang nchar(10) DEFAULT N'Hết hàng',
	Ma_Loai_San_Pham varchar(10),
    CONSTRAINT KN_SanPham_LoaiSP FOREIGN KEY (Ma_Loai_San_Pham) REFERENCES LoaiSanPham(Ma_Loai_San_Pham)

)

-- Bảng hóa đơn
CREATE TABLE HoaDonBan(
	Ma_Hoa_Don_Ban varchar(10) CONSTRAINT PK_HoaDonBan PRIMARY KEY,
	Ngay date check (DATEDIFF(year, Ngay, GETDATE())>=0),
	SDT varchar(50) CONSTRAINT FK_HoaDon_KH FOREIGN KEY REFERENCES KhachHang(SDT),
	Thanh_Tien int check (Thanh_Tien>=0),
)

-- Bảng chi tiết đơn bán
CREATE TABLE ChiTietDonBan(
	Ma_Hoa_Don_Ban varchar(10) CONSTRAINT FK_ChiTietDB_DB FOREIGN KEY REFERENCES HoaDonBan(Ma_Hoa_Don_Ban),
	Ma_San_Pham varchar(10) CONSTRAINT FK_ChiTietDB_SP FOREIGN KEY REFERENCES SanPham(Ma_San_Pham),
	So_Luong int check (So_Luong>0),
	Don_Gia float check (Don_Gia>=0),
	Tong_Tien float check (Tong_Tien>=0),
	CONSTRAINT PK_ChiTietHD PRIMARY KEY (Ma_Hoa_Don_Ban, Ma_San_Pham)
)

-- Bảng ca làm việc
CREATE TABLE CaLamViec(
	Ma_Ca nchar(10),
	Ngay date check (DATEDIFF(day, Ngay, GETDATE())>=0),
	Gio_Bat_Dau time NOT NULL,
	Gio_Ket_Thuc time NOT NULL,
	CONSTRAINT PK_CaLamViec PRIMARY KEY (Ma_Ca)
)

-- Bảng phân ca làm cho nhân viên
CREATE TABLE BangPhanCa(
	Ma_Ca nchar(10),
	Ma_Nhan_Vien varchar(10),
	CONSTRAINT PK_BangPhanCa PRIMARY KEY (Ma_Ca, Ma_Nhan_Vien),
	CONSTRAINT FK_PhanCa_Ca FOREIGN KEY (Ma_Ca) REFERENCES CaLamViec(Ma_Ca),
	CONSTRAINT FK_PhanCa_NV FOREIGN KEY (Ma_Nhan_Vien) REFERENCES NhanVien(Ma_Nhan_Vien),
)

-- Bảng công thức
CREATE TABLE CongThuc(
	Ma_San_Pham varchar(10),
	Ma_Nguyen_Lieu varchar(10),
	So_Luong int check (So_Luong > 0),
	DonVi nchar(10) NOT NULL
	CONSTRAINT PK_CheBien PRIMARY KEY (Ma_San_Pham, Ma_Nguyen_Lieu)
	CONSTRAINT FK_CheBien_SP FOREIGN KEY (Ma_San_Pham) REFERENCES SanPham(Ma_San_Pham),
	CONSTRAINT FK_CheBien_NL FOREIGN KEY (Ma_Nguyen_Lieu) REFERENCES NguyenLieu(Ma_Nguyen_Lieu)
)

--*TRIGGER*--
GO
CREATE TRIGGER TRG_Update_Tinh_Trang_SanPham
ON NguyenLieu
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Cập nhật tất cả các sản phẩm có nguyên liệu đủ số lượng trong kho
    UPDATE SanPham
    SET Tinh_Trang = N'Còn hàng'
    WHERE Ma_San_Pham IN (
        SELECT CT.Ma_San_Pham
        FROM CongThuc CT
        JOIN NguyenLieu NL ON CT.Ma_Nguyen_Lieu = NL.Ma_Nguyen_Lieu
        GROUP BY CT.Ma_San_Pham
        HAVING MIN(NL.So_Luong / CT.So_Luong) >= 1 -- Đủ nguyên liệu cho tất cả các thành phần của sản phẩm
    );

    -- Cập nhật tất cả các sản phẩm không đủ nguyên liệu trong kho
    UPDATE SanPham
    SET Tinh_Trang = N'Hết hàng'
    WHERE Ma_San_Pham NOT IN (
        SELECT CT.Ma_San_Pham
        FROM CongThuc CT
        JOIN NguyenLieu NL ON CT.Ma_Nguyen_Lieu = NL.Ma_Nguyen_Lieu
        GROUP BY CT.Ma_San_Pham
        HAVING MIN(NL.So_Luong / CT.So_Luong) >= 1 -- Đủ nguyên liệu cho tất cả các thành phần của sản phẩm
    );
END

GO
CREATE TRIGGER Xu_Ly_Lap_Nhan_Vien
ON BangPhanCa
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @CaLam nchar(10), @NhanVien varchar(10);
	SELECT @CaLam = Ma_Ca, @NhanVien=Ma_Nhan_Vien
    FROM inserted;
    -- Kiểm tra các ca làm việc chồng chéo
    IF EXISTS (
        SELECT 1
        FROM BangPhanCa s
        JOIN inserted i ON s.Ma_Nhan_Vien = i.Ma_Nhan_Vien
        WHERE (i.Ma_Ca=s.Ma_Ca)
    )
    BEGIN
        -- Nếu có ca chồng chéo, trả về thông báo lỗi
        RAISERROR('Nhân viên đã tồn tại trong ca làm việc này', 16, 1);
        ROLLBACK TRANSACTION;
    END
	ELSE
	BEGIN
        INSERT INTO BangPhanCa(Ma_Ca,Ma_Nhan_Vien)
        VALUES (@CaLam,@NhanVien);
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

--Check trigger

UPDATE NguyenLieu
SET So_Luong = 100000000
WHERE Ma_Nguyen_Lieu = 'NL003' OR Ma_Nguyen_Lieu = 'NL001' OR Ma_Nguyen_Lieu = 'NL002';


--Thêm dữ liệu
INSERT INTO TaiKhoan (Ma_Tai_Khoan, Mat_Khau) 
VALUES 
('TK001', 'password123'),
('TK002', 'password456'),
('TK003', 'password789');

INSERT INTO ViTri (Ma_Vi_Tri, Ten_Vi_Tri, Luong_Co_Dinh) 
VALUES 
('VT001', N'Quản lý', 20000000),
('VT002', N'Nhân viên pha chế', 8000000),
('VT003', N'Nhân viên phục vụ', 6000000);

INSERT INTO NhanVien (Ma_Nhan_Vien, Ten_Nhan_Vien, Ngay_Sinh, Gioi_Tinh, Dia_Chi, SDT, Ma_Vi_Tri, Ma_Tai_Khoan, Ngay_Tuyen_Dung) 
VALUES 
('NV001', N'Trần Văn A', '1990-05-15', 'Nam', N'123 Đường A, TP HCM', '0912345678', 'VT001', 'TK001', '2020-01-10'),
('NV002', N'Nguyễn Thị B', '1995-11-20', 'Nữ', N'456 Đường B, TP HCM', '0923456789', 'VT002', 'TK002', '2021-02-15'),
('NV003', N'Lê Văn C', '1998-03-12', 'Nam', N'789 Đường C, TP HCM', '0934567890', 'VT003', 'TK003', '2022-03-01');

INSERT INTO KhachHang (Ma_Khach_Hang, SDT, Ten_Khach_Hang, Ngay_Sinh) 
VALUES 
('KH001', '0911123456', N'Phạm Văn D', '1995-07-10'),
('KH002', '0922234567', N'Tran Thị E', '1992-08-12'),
('KH003', '0933345678', N'Nguyen Văn F', '1988-01-20');

INSERT INTO NhaCungCap (Ma_Nha_Cung_Cap, Ten_Nha_Cung_Cap, Dia_Chi, SDT) 
VALUES 
('NCC001', N'Công ty Nguyên liệu A', N'789 Đường C, TP HCM', '0911223344'),
('NCC002', N'Công ty Nguyên liệu B', N'456 Đường B, Hà Nội', '0911334455');

INSERT INTO HoaDonNhap (Ma_Hoa_Don_Nhap, Ngay_Nhap, Tong_Tien, Ma_Nha_Cung_Cap, Thoi_Gian) 
VALUES 
('HDN001', '2024-10-01', 5000000, 'NCC001', '08:00:00'),
('HDN002', '2024-10-02', 3000000, 'NCC002', '09:30:00');

INSERT INTO NguyenLieu (Ma_Nguyen_Lieu, Ten_Nguyen_Lieu, So_Luong, Don_Vi, Don_Gia, Ma_Nha_Cung_Cap, Anh) 
VALUES 
('NL001', N'Trà đen', 100, 'Kg', 50000, 'NCC001', 'tra_den.png'),
('NL002', N'Sữa đặc', 50, 'Lít', 20000, 'NCC002', 'sua_dac.png'),
('NL003', N'Trà xanh', 80, 'Kg', 55000, 'NCC001', 'tra_xanh.png'),
('NL004', N'Sữa tươi', 100, 'Lít', 18000, 'NCC002', 'sua_tuoi.png'),
('NL005', N'Trân châu đen', 150, 'Kg', 40000, 'NCC001', 'tran_chau.png'),
('NL006', N'Siro dâu', 60, 'Lít', 22000, 'NCC002', 'siro_dau.png'),
('NL007', N'Siro matcha', 40, 'Lít', 30000, 'NCC001', 'siro_matcha.png'),
('NL008', N'Siro bơ', 50, 'Lít', 32000, 'NCC002', 'siro_bo.png'),
('NL009', N'Trà nhài', 90, 'Kg', 57000, 'NCC001', 'tra_nhai.png');

INSERT INTO ChiTietHoaDonNhap (Ma_Hoa_Don_Nhap, Ma_Nguyen_Lieu, Don_Gia, So_Luong, Don_Vi) 
VALUES 
('HDN001', 'NL001', 50000, 50, 'Kg'),
('HDN002', 'NL002', 20000, 30, 'Lít');

INSERT INTO LoaiSanPham (Ma_Loai_San_Pham, Ten_Loai_San_Pham) 
VALUES 
('LSP001', N'Trà sữa'),
('LSP002', N'Sinh tố');

INSERT INTO SanPham (Ma_San_Pham, Ten_San_Pham, Don_Gia, Tinh_Trang, Ma_Loai_San_Pham) 
VALUES 
('SP001', N'Trà sữa trân châu', 35000, N'Còn hàng', 'LSP001'),
('SP002', N'Sinh tố xoài', 40000, N'Hết hàng', 'LSP002'),
('SP003', N'Trà sữa matcha', 38000, N'Còn hàng', 'LSP001'),
('SP004', N'Sinh tố dâu', 45000, N'Hết hàng', 'LSP002'),
('SP005', N'Trà sữa hương nhài', 36000, N'Còn hàng', 'LSP001'),
('SP006', N'Sinh tố bơ', 42000, N'Còn hàng', 'LSP002');


INSERT INTO HoaDonBan (Ma_Hoa_Don_Ban, Ngay, SDT, Thanh_Tien) 
VALUES 
('HDB001', '2024-10-02', '0911123456', 70000),
('HDB002', '2024-10-03', '0922234567', 80000);

INSERT INTO ChiTietDonBan (Ma_Hoa_Don_Ban, Ma_San_Pham, So_Luong, Don_Gia, Tong_Tien) 
VALUES 
('HDB001', 'SP001', 2, 35000, 70000),
('HDB002', 'SP002', 2, 40000, 80000);

INSERT INTO CaLamViec (Ma_Ca, Ngay, Gio_Bat_Dau, Gio_Ket_Thuc) 
VALUES 
('CA001', '2024-10-01', '08:00:00', '12:00:00'),
('CA002', '2024-10-01', '13:00:00', '16:00:00'),
('CA003', '2024-10-01', '13:00:00', '16:00:00');

INSERT INTO BangPhanCa (Ma_Ca, Ma_Nhan_Vien) 
VALUES 
('CA001', 'NV001'),
('CA002', 'NV002');

INSERT INTO CongThuc (Ma_San_Pham, Ma_Nguyen_Lieu, So_Luong, DonVi) 
VALUES 
-- Công thức cho Trà sữa trân châu
('SP001', 'NL001', 500, 'g'), -- Trà đen
('SP001', 'NL002', 200, 'ml'), -- Sữa đặc
('SP001', 'NL005', 100, 'g'), -- Trân châu đen

-- Công thức cho Trà sữa matcha
('SP003', 'NL003', 300, 'g'), -- Trà xanh
('SP003', 'NL002', 200, 'ml'), -- Sữa đặc
('SP003', 'NL007', 50, 'ml'), -- Siro matcha

-- Công thức cho Trà sữa hương nhài
('SP005', 'NL009', 400, 'g'), -- Trà nhài
('SP005', 'NL004', 250, 'ml'), -- Sữa tươi

-- Công thức cho Sinh tố dâu
('SP004', 'NL006', 150, 'ml'), -- Siro dâu
('SP004', 'NL004', 300, 'ml'), -- Sữa tươi

-- Công thức cho Sinh tố bơ
('SP006', 'NL008', 200, 'ml'), -- Siro bơ
('SP006', 'NL004', 300, 'ml'); -- Sữa tươi

-- *Tạo Procedure --
--- Quản lý nhân sự(procedure(thêm, xóa bảng Nhân viên, cập nhật lương thưởng cho nhân viên (Trigger)))
--- Theo dõi hóa đơn bán (hóa đơn bán sẽ 1 procedure (hiển thị chi tiết hóa đơn bán đó)) (procedure (để phân theo tháng)) 
--- Cập nhật thông tin khách hàng thân thiết(procedure(thêm hàng vào bảng khách hàng))) 


-- *Quản lý nhân sự -- 
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
    INSERT INTO NhanVien (Ma_Nhan_Vien, Ten_Nhan_Vien, Ngay_Sinh, Gioi_Tinh, Dia_Chi, SDT, Ma_Vi_Tri, Ma_Tai_Khoan, Ngay_Tuyen_Dung)
    VALUES (@MaNV, @TenNV, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @MaViTri, @MaTaiKhoan, @NgayTuyenDung)
END;

-- Xóa nhân viên --
GO
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

-- *Theo dõi hóa đơn bán --
GO
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

-- *Cập nhật thông tin khách hàng --
GO
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

-- Thêm khách hàng
GO
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













--Test
SELECT * FROM HoaDonNhap WHERE Ma_Hoa_Don_Nhap = 'HDN001';

---------------------------------------------------------------------------------------
INSERT INTO HoaDonNhap (Ma_Hoa_Don_Nhap, Ngay_Nhap, Tong_Tien, Ma_Nha_Cung_Cap, Thoi_Gian)
VALUES ('HDN001', '2024-09-01', 500000, 'NCC001', '08:00');
--Procedure (Cập nhật chi tiết hóa đơn nhập)
---------------------------------------------------------------------------------------
INSERT INTO NguyenLieu (Ma_Nguyen_Lieu, Ten_Nguyen_Lieu, So_Luong, Don_Vi, Don_Gia, Ma_Nha_Cung_Cap)
VALUES ('NL001', N'Đường', 5000, 'gram', 20000, 'NCC001');
--Procedure (Nhập, Sủa, Cập nhật thông tin nguyên liệu)
GO
CREATE PROCEDURE QuanLyHoaDonNhap
    @Ma_Hoa_Don_Nhap varchar(10),
    @Ngay_Nhap date,
    @Tong_Tien int,
    @Ma_Nha_Cung_Cap varchar(10),
    @Thoi_Gian time,
    @Ma_Nguyen_Lieu varchar(10),
    @So_Luong int,
    @Don_Gia int,
    @Don_Vi varchar(10)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM HoaDonNhap WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap)
    BEGIN
        INSERT INTO HoaDonNhap (Ma_Hoa_Don_Nhap, Ngay_Nhap, Tong_Tien, Ma_Nha_Cung_Cap, Thoi_Gian)
        VALUES (@Ma_Hoa_Don_Nhap, @Ngay_Nhap, @Tong_Tien, @Ma_Nha_Cung_Cap, @Thoi_Gian);
    END
    ELSE
    BEGIN
        UPDATE HoaDonNhap
        SET Ngay_Nhap = @Ngay_Nhap,
            Tong_Tien = @Tong_Tien,
            Ma_Nha_Cung_Cap = @Ma_Nha_Cung_Cap,
            Thoi_Gian = @Thoi_Gian
        WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap;
    END

    IF NOT EXISTS (SELECT 1 FROM ChiTietHoaDonNhap WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap AND Ma_Nguyen_Lieu = @Ma_Nguyen_Lieu)
    BEGIN
        INSERT INTO ChiTietHoaDonNhap (Ma_Hoa_Don_Nhap, Ma_Nguyen_Lieu, Don_Gia, So_Luong, Don_Vi)
        VALUES (@Ma_Hoa_Don_Nhap, @Ma_Nguyen_Lieu, @Don_Gia, @So_Luong, @Don_Vi);
    END
    ELSE
    BEGIN
        UPDATE ChiTietHoaDonNhap
        SET So_Luong = @So_Luong,
            Don_Gia = @Don_Gia,
            Don_Vi = @Don_Vi
        WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap AND Ma_Nguyen_Lieu = @Ma_Nguyen_Lieu;
    END

    UPDATE NguyenLieu
    SET So_Luong = So_Luong + @So_Luong
    WHERE Ma_Nguyen_Lieu = @Ma_Nguyen_Lieu;
    
    UPDATE HoaDonNhap
    SET Tong_Tien = Tong_Tien + (@So_Luong * @Don_Gia)
    WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap;
END;

-- Kiểm tra lại dữ liệu sau khi cập nhật
INSERT INTO NguyenLieu (Ma_Nguyen_Lieu, Ten_Nguyen_Lieu, So_Luong, Don_Vi, Don_Gia, Ma_Nha_Cung_Cap)
VALUES ('NL001', N'Đường', 5000, 'gram', 20000, 'NCC001');
--Test
SELECT * FROM NguyenLieu WHERE Ma_Nguyen_Lieu = 'NL001';

---------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------









GO
CREATE PROCEDURE CapNhatHoaDonNhap
    @Ma_Hoa_Don_Nhap varchar(10),
    @Ngay_Nhap date,
    @Tong_Tien int,
    @Ma_Nha_Cung_Cap varchar(10),
    @Thoi_Gian time
AS
BEGIN
    -- Kiểm tra nếu mã hóa đơn nhập tồn tại
    IF EXISTS (SELECT 1 FROM HoaDonNhap WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap)
		BEGIN
			-- Cập nhật thông tin hóa đơn nhập
			UPDATE HoaDonNhap
			SET Ngay_Nhap = @Ngay_Nhap,
				Tong_Tien = @Tong_Tien,
				Ma_Nha_Cung_Cap = @Ma_Nha_Cung_Cap,
				Thoi_Gian = @Thoi_Gian
			WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap;
        
			PRINT N'Hóa đơn nhập đã được cập nhật thành công.';
		END
    ELSE
		BEGIN
			PRINT N'Không tìm thấy hóa đơn nhập với mã này.';
		END
END;

GO
CREATE FUNCTION TinhTongTienNguyenLieuNhap(@Ma_Hoa_Don_Nhap VARCHAR(10))
RETURNS INT
AS
BEGIN
    DECLARE @TongTien INT;
    SELECT @TongTien = SUM(Don_Gia * So_Luong)
    FROM ChiTietHoaDonNhap
    WHERE Ma_Hoa_Don_Nhap = @Ma_Hoa_Don_Nhap;

    -- Trả về tổng tiền nguyên liệu nhập
    RETURN ISNULL(@TongTien, 0);
END;


GO
-- Tạo function tính tổng tiền của tất cả các sản phẩm theo mã hóa đơn
CREATE FUNCTION TinhTongTienTheoHoaDon (
    @Ma_Hoa_Don_Ban varchar(10)
)
RETURNS FLOAT
AS
BEGIN
    DECLARE @Tong_Tien FLOAT;

    -- Tính tổng tiền của tất cả sản phẩm trong hóa đơn dựa theo mã hóa đơn
    SELECT @Tong_Tien = SUM(Tong_Tien)
    FROM ChiTietDonBan
    WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban;

    -- Trả về tổng tiền
    RETURN ISNULL(@Tong_Tien, 0);
END;




GO
-- Tạo procedure thêm sản phẩm vào hóa đơn bán
CREATE PROCEDURE ThemSanPhamVaoHoaDonBan
    @Ma_Hoa_Don_Ban varchar(10),
    @Ma_San_Pham varchar(10),
    @So_Luong int,
    @Don_Gia float,
    @SDT varchar(10) 
AS
BEGIN
    -- Kiểm tra nếu hóa đơn chưa tồn tại, thì tạo mới
    IF NOT EXISTS (SELECT 1 FROM HoaDonBan WHERE Ma_Hoa_Don_Ban = @Ma_Hoa_Don_Ban)
    BEGIN
        INSERT INTO HoaDonBan (Ma_Hoa_Don_Ban, Ngay, SDT, Thanh_Tien)
        VALUES (@Ma_Hoa_Don_Ban, GETDATE(), @SDT, 0);
    END

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










GO
CREATE PROCEDURE UpdateNhanVien
    @Ma_Nhan_Vien varchar(10),
    @Ten_Nhan_Vien nvarchar(50) = NULL,
    @Ngay_Sinh date = NULL,
    @Gioi_Tinh varchar(3) = NULL,
    @Dia_Chi nvarchar(100) = NULL,
    @SDT varchar(10) = NULL,
    @Ma_Vi_Tri varchar(10) = NULL,
    @Ma_Tai_Khoan varchar(10) = NULL,
    @Ngay_Tuyen_Dung date = NULL
AS
BEGIN
    -- Kiểm tra xem nhân viên có tồn tại hay không
    IF EXISTS (SELECT 1 FROM NhanVien WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien)
    BEGIN
        UPDATE NhanVien
        SET 
            Ten_Nhan_Vien = COALESCE(@Ten_Nhan_Vien, Ten_Nhan_Vien),
            Ngay_Sinh = COALESCE(@Ngay_Sinh, Ngay_Sinh),
            Gioi_Tinh = COALESCE(@Gioi_Tinh, Gioi_Tinh),
            Dia_Chi = COALESCE(@Dia_Chi, Dia_Chi),
            SDT = COALESCE(@SDT, SDT),
            Ma_Vi_Tri = COALESCE(@Ma_Vi_Tri, Ma_Vi_Tri),
            Ma_Tai_Khoan = COALESCE(@Ma_Tai_Khoan, Ma_Tai_Khoan),            
            Ngay_Tuyen_Dung = COALESCE(@Ngay_Tuyen_Dung, Ngay_Tuyen_Dung)
        WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien;
    END
    ELSE
    BEGIN
        RAISERROR('Nhân viên không tồn tại', 16, 1);
    END
END
GO
CREATE PROCEDURE ThemNguyenLieu
    @Ma_Nguyen_Lieu varchar(10),
    @Ten_Nguyen_Lieu nvarchar(50),
    @So_Luong int,
    @Don_Vi varchar(10),
    @Don_Gia int,
    @Ma_Nha_Cung_Cap varchar(10),
    @Anh nvarchar(100) = NULL -- Tùy chọn nếu có ảnh
AS
BEGIN
    -- Kiểm tra nếu nguyên liệu đã tồn tại
    IF EXISTS (SELECT 1 FROM NguyenLieu WHERE Ma_Nguyen_Lieu = @Ma_Nguyen_Lieu)
    BEGIN
        -- Nguyên liệu đã tồn tại, thông báo lỗi
        RAISERROR('Nguyên liệu với mã %s đã tồn tại.', 16, 1, @Ma_Nguyen_Lieu);
        RETURN;
    END
    
    -- Thêm nguyên liệu mới vào bảng NguyenLieu
    INSERT INTO NguyenLieu (Ma_Nguyen_Lieu, Ten_Nguyen_Lieu, So_Luong, Don_Vi, Don_Gia, Ma_Nha_Cung_Cap, Anh)
    VALUES (@Ma_Nguyen_Lieu, @Ten_Nguyen_Lieu, @So_Luong, @Don_Vi, @Don_Gia, @Ma_Nha_Cung_Cap, @Anh);

    -- Thông báo thành công
    PRINT 'Đã thêm nguyên liệu thành công.';
END;









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


--Xem lịch làm việc chung của cửa hàng trong tuần
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
WHERE 
	DATEDIFF(week, GETDATE(), CL.Ngay) = 0; 


--Tạo View hiện lên bằng hàm tính tổng doanh thu 
GO
CREATE VIEW View_DoanhThuCaLamViec AS
	SELECT 
		CL.Ma_Ca,
		CL.Gio_Bat_Dau,
		CL.Gio_Ket_Thuc,
		SUM(HDB.Thanh_Tien) AS Tong_Doanh_Thu
	FROM 
		HoaDonBan HDB, BangPhanCa BPC
	JOIN 
		CaLamViec CL ON BPC.Ma_Ca = CL.Ma_Ca
	WHERE 
		-- Kết hợp ngày và giờ của hóa đơn với giờ của ca làm việc
		CAST(HDB.Ngay AS DATETIME) + CAST(CL.Gio_Bat_Dau AS DATETIME) <= CAST(HDB.Ngay AS DATETIME)
		AND CAST(HDB.Ngay AS DATETIME) + CAST(CL.Gio_Ket_Thuc AS DATETIME) >= CAST(HDB.Ngay AS DATETIME)
	GROUP BY 
		CL.Ma_Ca, CL.Gio_Bat_Dau, CL.Gio_Ket_Thuc;
