-- phpMyAdmin SQL Dump
-- version 4.9.0.1

--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th3 30, 2020 lúc 08:52 AM
-- Phiên bản máy phục vụ: 10.4.6-MariaDB
-- Phiên bản PHP: 7.1.32

/* SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO"; */

--
-- Cơ sở dữ liệu: `laravel`
--

--
-- Thủ tục
--
/*CREATE  PROCEDURE TAOKH (@`VTENTK` VARCHAR(20), @`VPASS` VARCHAR(20), @`VTENKH` VARCHAR(30), @`VDIACHI` VARCHAR(100), @`VSDT` CHAR(10), @`VEMAIL` VARCHAR(50))  AS
  BEGIN
  SET NOCOUNT ON; 
 INSERT INTO taikhoan VALUES(VTENTK,VPASS,'khach'); 
INSERT INTO khachhang VALUES(NULL,VTENKH,VDIACHI,VSDT,VEMAIL,TENTK); END$$*/


-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `anh`
--

CREATE TABLE anh (
  [MASP] int CHECK ([MASP] > 0)  NOT NULL  IDENTITY(1,1)  ,
  [LINK] varchar(255) NOT NULL
)  ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitiethoadon`
--

CREATE TABLE chitiethoadon (
  [MAHD] int CHECK ([MAHD] > 0) NOT NULL,
  [MASP] int CHECK ([MASP] > 0) NOT NULL,
  [THANHTIEN] int DEFAULT NULL,
  [SOLUONG] int DEFAULT NULL,
  [GIA] int DEFAULT NULL,
  [created_at] datetime2(0) NOT NULL DEFAULT current_timestamp,
  [updated_at] datetime2(0) NOT NULL DEFAULT current_timestamp
)  ;

--
-- Đang đổ dữ liệu cho bảng `chitiethoadon`
--

INSERT INTO chitiethoadon ([MAHD], [MASP], [THANHTIEN], [SOLUONG], [GIA], [created_at], [updated_at]) VALUES
(6, 1, NULL, 1, 5000000, '2019-12-17 06:37:02', '2019-12-17 06:37:02'),
(6, 2, NULL, 2, 1000000, '2019-12-17 06:37:02', '2019-12-17 06:37:02'),
(10, 1, NULL, 2, 5000000, '2019-12-20 21:08:15', '2019-12-20 21:08:15'),
(11, 2, NULL, 2, 1000000, '2019-12-21 22:38:34', '2019-12-21 22:38:34');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `hang`
--

CREATE TABLE hang (
  [MAHANG] int NOT NULL  IDENTITY(1,1)    ,
  [TENHANG] varchar(30) NOT NULL
)  ;

--
-- Đang đổ dữ liệu cho bảng `hang`
--

INSERT INTO hang ([TENHANG]) VALUES
( 'Iphone'),
( 'SamSung '),
( 'Xiaomi'),
( 'Oppo'),
( 'Nokia'),
( 'Realmi'),
( 'Sony'),
( 'LG'),
( 'Lenovo');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `hoadon`
--

CREATE TABLE hoadon (
  [MAHD] int CHECK ([MAHD] > 0) NOT NULL  IDENTITY(1,1),
  [NGAYHD] date NOT NULL,
  [TONGTIEN] int NOT NULL,
  [IDKH] int CHECK ([IDKH] > 0) NOT NULL,
  [GHICHU] varchar(max) DEFAULT NULL,
  [created_at] datetime2(0) NULL DEFAULT current_timestamp,
  [updated_at] datetime2(0) NOT NULL DEFAULT current_timestamp,
  [TINHTRANG] varchar(50) NOT NULL
)  ;
delete from hoadon;
--
-- Đang đổ dữ liệu cho bảng `hoadon`
--

INSERT INTO hoadon ( [NGAYHD], [TONGTIEN], [IDKH], [GHICHU], [created_at], [updated_at], [TINHTRANG]) VALUES
( '2019-12-17', 7000000, 1, 'ok', '2019-12-17 06:37:02', '2019-12-17 06:37:02', 'bom'),
( '2019-12-21', 10000000, 2, 'gfbfx', '2019-12-21 04:03:53', '2019-12-21 04:03:53', ''),
( '2019-12-21', 10000000, 3, 'gfbfx', '2019-12-21 04:04:11', '2019-12-21 04:04:11', ''),
( '2019-12-21', 10000000, 4, 'gfbfx', '2019-12-21 04:04:29', '2019-12-21 04:04:29', ''),
( '2019-12-21', 10000000, 5, 'gfbfx', '2019-12-21 04:08:15', '2019-12-21 04:08:15', 'chưa giao'),
( '2019-12-22', 2000000, 6, 'ok', '2019-12-22 05:38:34', '2019-12-22 05:38:34', 'huy');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khachhang`
--

CREATE TABLE khachhang (
  [ID] int CHECK ([ID] > 0) NOT NULL  IDENTITY(1,1),
  [TEN] varchar(30) DEFAULT NULL,
  [EMAIL] varchar(255) DEFAULT NULL,
  [DIACHI] varchar(255) DEFAULT NULL,
  [SDT] varchar(10) DEFAULT NULL,
  [GHICHU] varchar(max) DEFAULT NULL,
  [created_at] datetime2(0) NOT NULL DEFAULT current_timestamp,
  [updated_at] datetime2(0) NOT NULL DEFAULT current_timestamp
)  ;

--
-- Đang đổ dữ liệu cho bảng `khachhang`
--

INSERT INTO khachhang ( [TEN], [EMAIL], [DIACHI], [SDT], [GHICHU], [created_at], [updated_at]) VALUES
('nguyen my linh', 'kimthao581999@gmail.com', 'khu b', '0377842878', NULL, '2019-12-17 06:37:02', '2019-12-17 06:37:02'),
('nguyen', 'nguyen@gmail.com', 'dia3', '1234567890', NULL, '2019-12-20 21:03:53', '2019-12-20 21:03:53'),
('nguyen', 'nguyen@gmail.com', 'dia3', '1234567890', NULL, '2019-12-20 21:04:11', '2019-12-20 21:04:11'),
('nguyen', 'nguyen@gmail.com', 'dia3', '1234567890', NULL, '2019-12-20 21:04:29', '2019-12-20 21:04:29'),

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `magiamgia`
--

CREATE TABLE magiamgia (
  [MAGIAMGIA] int NOT NULL  IDENTITY(1,1),
  [MASP] int CHECK ([MASP] > 0) NOT NULL,
  [PHANTRAM] int NOT NULL
)  ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `sanpham`
--

CREATE TABLE sanpham (
  [MASP] int CHECK ([MASP] > 0) NOT NULL  IDENTITY(1,1),
  [TENSP] varchar(30) NOT NULL,
  [HANG] int NOT NULL,
  [MOTA] varchar(200) DEFAULT NULL,
  [NAMSX] date DEFAULT NULL,
  [GIA] int DEFAULT NULL,
  [GIAKHUYENMAI] int DEFAULT NULL,
  [ANHDAIDIEN] varchar(150) DEFAULT NULL,
  [MANHINH] varchar(30) DEFAULT NULL,
  [CAMERATRUOC] varchar(30) DEFAULT NULL,
  [CAMERASAU] varchar(30) DEFAULT NULL,
  [RAM] varchar(30) DEFAULT NULL,
  [BONHOTRONG] varchar(30) DEFAULT NULL,
  [CPU] varchar(30) DEFAULT NULL,
  [GPU] varchar(30) DEFAULT NULL,
  [PIN] varchar(30) DEFAULT NULL,
  [OS] varchar(30) DEFAULT NULL,
  [SIM] varchar(30) DEFAULT NULL
)  ;

--
-- Đang đổ dữ liệu cho bảng `sanpham`
--

INSERT INTO sanpham ( [TENSP], [HANG], [MOTA], [NAMSX], [GIA], [GIAKHUYENMAI], [ANHDAIDIEN], [MANHINH], [CAMERATRUOC], [CAMERASAU], [RAM], [BONHOTRONG], [CPU], [GPU], [PIN], [OS], [SIM]) VALUES
( 'Dien thoai di dong thong minh', 1, 'd', NULL, 10000000, 5000000, '6s-plus.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
( 'Dien thoai di dong thong minh', 2, NULL, NULL, 1000000, NULL, '6s-plus-8.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
( 'Dien thoai di dong thong minh', 1, NULL, NULL, 1000000, NULL, '11.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
( 'Dien thoai di dong thong minh', 2, NULL, NULL, 1000000, NULL, '11-den.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),


-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `taikhoan`
--

CREATE TABLE taikhoan (
  [TENTK] varchar(20) NOT NULL  ,
  [PASS] varchar(100) NOT NULL,
  [QUYEN] varchar(20) NOT NULL
)  ;

--
-- Đang đổ dữ liệu cho bảng `taikhoan`
--

INSERT INTO taikhoan ([TENTK], [PASS], [QUYEN]) VALUES
('taikhoan1', '123', 'admin'),
('taikhoan10', '123', 'khach'),
('taikhoan2', '123', 'admin'),
('taikhoan3', '123', 'khach'),
('taikhoan4', '123', 'khach'),
('taikhoan5', '123', 'khach'),
('taikhoan6', '123', 'khach'),
('taikhoan7', '123', 'admin'),
('taikhoan8', '123', 'khach'),
('taikhoan9', '123', 'khach');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `users`
--



CREATE TABLE users (
  [ID] int CHECK ([ID] > 0) NOT NULL  IDENTITY(1,1),
  [FULL_NAME] varchar(30) DEFAULT NULL,
  [ROLE] varchar(30) NOT NULL DEFAULT 'khachhang',
  [DIACHI] varchar(100) DEFAULT NULL,
  [SDT] char(10) DEFAULT NULL,
  [email] varchar(255) DEFAULT NULL,
  [password] varchar(255) NOT NULL,
  [remember_token] varchar(100) DEFAULT NULL,
  [created_at] datetime2(0) NOT NULL DEFAULT current_timestamp,
  [updated_at] datetime2(0) NOT NULL DEFAULT current_timestamp
)  ;

delete users;
--
-- Đang đổ dữ liệu cho bảng `users`
--

INSERT INTO users ([FULL_NAME], [ROLE], [DIACHI], [SDT], [email], [password], [remember_token], [created_at], [updated_at]) VALUES
( 'nguyễn', 'khach', 'khu b', '0377842878', 'thao581999@gmail.com', '$2y$10$TBXBMvPwjQJrfdYsjzoez./Ihk90G5rodeN6qaTGb1Hz3l8JOp.Ji', NULL, '2019-12-07 23:39:19', '2019-12-07 23:39:19'),
( 'Quỳnh', 'khach', '3', '1140000000', 'nguyen@gmail.com', '$2y$10$uDQ1E3eQIcRGCDuRz2cW..bZpdi1.7PTS8iHiU4M4fBK3eoZK5lfy', NULL, '2019-12-20 20:54:53', '2019-12-20 20:54:53');

select *from users;
--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `anh`
--
ALTER TABLE [anh]
  ADD PRIMARY KEY ([MASP],[LINK]);

--
-- Chỉ mục cho bảng `chitiethoadon`
--
ALTER TABLE [chitiethoadon]
  ADD PRIMARY KEY ([MAHD],[MASP]);


--
-- Chỉ mục cho bảng `hang`
--
ALTER TABLE [hang]
  ADD PRIMARY KEY ([MAHANG]);

--
-- Chỉ mục cho bảng `hoadon`
--
ALTER TABLE [hoadon]
  ADD PRIMARY KEY ([MAHD]);


--
-- Chỉ mục cho bảng `khachhang`
--
ALTER TABLE [khachhang]
  ADD PRIMARY KEY ([ID]);

--
-- Chỉ mục cho bảng `magiamgia`
--
ALTER TABLE [magiamgia]
  ADD PRIMARY KEY ([MAGIAMGIA]);


--
-- Chỉ mục cho bảng `sanpham`
--
ALTER TABLE [sanpham]
  ADD PRIMARY KEY ([MASP]);
 

--
-- Chỉ mục cho bảng `taikhoan`
--
ALTER TABLE [taikhoan]
  ADD PRIMARY KEY ([TENTK]);

--
-- Chỉ mục cho bảng `users`
--
ALTER TABLE [users]
  ADD PRIMARY KEY ([ID]);


--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `hang`
--

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `anh`
--
ALTER TABLE [anh]
  ADD CONSTRAINT [FK_ANH_KH] FOREIGN KEY ([MASP]) REFERENCES sanpham ([MASP]);

--
-- Các ràng buộc cho bảng `chitiethoadon`
--
ALTER TABLE [chitiethoadon]

  ADD CONSTRAINT [FK_CTHD_SP] FOREIGN KEY ([MASP]) REFERENCES sanpham ([MASP]);
  
  ALTER TABLE [chitiethoadon]
  ADD CONSTRAINT [FK_CTHD_HD] FOREIGN KEY ([MAHD]) REFERENCES hoadon ([MAHD]);
--
-- Các ràng buộc cho bảng `hoadon`
--
ALTER TABLE [hoadon]
  ADD CONSTRAINT [FK_HD_KH] FOREIGN KEY ([IDKH]) REFERENCES khachhang ([ID]);

--
-- Các ràng buộc cho bảng `magiamgia`
--
ALTER TABLE [magiamgia]
  ADD CONSTRAINT [FK_GIAMGIA_SP] FOREIGN KEY ([MASP]) REFERENCES sanpham ([MASP]);

--
-- Các ràng buộc cho bảng `sanpham`
--
ALTER TABLE [sanpham]
  ADD CONSTRAINT [FK_SP_HANG] FOREIGN KEY ([HANG]) REFERENCES hang ([MAHANG]);
COMMIT;
GO
