create database QLThuVien;
Go
use QLThuVien;
Go
create table TAIKHOAN(
ID nvarchar(10) primary key,
TaiKhoan nvarchar(10),
MatKhau nvarchar(10),
ThoiGianBatDau nvarchar(10),
ThoiGianKetThuc nvarchar(10),
TenNhanVien nvarchar(10)
)
Go
create table NGUOIDUNG(
MaDG nvarchar(5) primary key,
TenNguoiDung nvarchar(45),
Username nvarchar(10),
Passw nvarchar(10),
SoDienThoai nvarchar(10),
DiaChi nvarchar(20),
Email nvarchar(20),
NgaySinh date,
VaiTro nvarchar(15),
GioiTinh nvarchar(5)
)
Go
create table LICHSU(
MaTH nvarchar(5) primary key,
TenSach nvarchar(20),
NgayMuon date,
MaDG nvarchar(5),
constraint fk1 foreign key (MaDG) references NGUOIDUNG(MaDG)
)

Go
create table SACH(
MaSach nvarchar(5) primary key,
TenSach nvarchar(20),
TacGia nvarchar(20),
NhaXuatBan nvarchar(20),
NamXuatBan int,
NgonNgu nvarchar(15),
TheLoai nvarchar(20),
AnhBia nvarchar(15),
SoLuongConLai int,
GiaTien int
)
Go
create table DANHSACHMUONTRA(
MaDG nvarchar(5),
MaSach nvarchar(5),
MaPhieu nvarchar(5),
GhiChu nvarchar(255)
constraint pk primary key(MaDG, MaSach, MaPhieu),
SoLuong int,
NgayMuon date,
NgayTra date,
constraint fk2 foreign key (MaDG) references NGUOIDUNG(MaDG),
constraint fk3 foreign key(MaSach) references SACH(MaSach)
)
select * from TAIKHOAN
select * from NGUOIDUNG
select * from LICHSU
select * from SACH
select * from DANHSACHMUONTRA

