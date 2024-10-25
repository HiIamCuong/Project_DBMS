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