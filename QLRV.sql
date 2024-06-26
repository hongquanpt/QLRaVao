USE [QuanLyRaVao]
GO
/****** Object:  Table [dbo].[CANBO_DUYET]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CANBO_DUYET](
	[MaCB] [int] NOT NULL,
	[MaCTDS] [int] NOT NULL,
	[ThoiGianDuyet] [datetime] NULL,
	[GhiChu] [nvarchar](200) NULL,
	[NguoiSua] [int] NULL,
	[ThoiGianSua] [datetime] NULL,
	[MaCB_D] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CANBO_DUYET_1] PRIMARY KEY CLUSTERED 
(
	[MaCB_D] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CAPBAC]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAPBAC](
	[MaCapBac] [int] IDENTITY(1,1) NOT NULL,
	[CapBac] [nvarchar](100) NULL,
	[KyHieu] [varchar](10) NULL,
 CONSTRAINT [PK__CAPBAC__2190882555388719] PRIMARY KEY CLUSTERED 
(
	[MaCapBac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETDANHSACH]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETDANHSACH](
	[HinhThucRN] [int] NOT NULL,
	[MaHocVien] [int] NOT NULL,
	[LyDo] [nvarchar](100) NOT NULL,
	[DiaDiem] [nvarchar](100) NOT NULL,
	[ThoiGianRa] [datetime] NOT NULL,
	[ThoiGianVao] [datetime] NOT NULL,
	[GhiChu] [nvarchar](200) NULL,
	[NguoiSua] [int] NULL,
	[ThoiGianSua] [datetime] NULL,
	[TinhTrang] [int] NULL,
	[MaCTDS] [int] NOT NULL,
 CONSTRAINT [PK_CHITIETDANHSACH] PRIMARY KEY CLUSTERED 
(
	[MaCTDS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETDANHSACH_GIAYTO]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETDANHSACH_GIAYTO](
	[MaGiayTo] [int] NOT NULL,
	[MaCTDS] [int] NOT NULL,
	[ThoiGianLay] [datetime] NULL,
	[ThoiGianTra] [datetime] NULL,
	[GhiChu] [nvarchar](200) NULL,
	[Khoa] [bit] NULL,
	[NguoiSua] [int] NULL,
	[ThoiGianSua] [datetime] NULL,
 CONSTRAINT [PK_CHITIETDANHSACH_GIAYTO] PRIMARY KEY CLUSTERED 
(
	[MaGiayTo] ASC,
	[MaCTDS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHUCVU]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCVU](
	[MaCV] [int] IDENTITY(1,1) NOT NULL,
	[TenCV] [nvarchar](100) NOT NULL,
	[KyHieu] [varchar](10) NULL,
 CONSTRAINT [PK__CHUCVU__27258E76911495C4] PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONVI]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONVI](
	[MaDV] [int] IDENTITY(1,1) NOT NULL,
	[Cap] [smallint] NOT NULL,
	[TenDV] [nvarchar](100) NOT NULL,
	[Xoa] [bit] NULL,
	[NguoiSua] [int] NULL,
	[ThoiGianSua] [datetime] NULL,
 CONSTRAINT [PK__DONVI__272586574A583AC5] PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GIAYTO]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIAYTO](
	[MaGiayTo] [int] IDENTITY(1,1) NOT NULL,
	[Loai] [bit] NOT NULL,
	[SoGiay] [int] NOT NULL,
	[TinhTrang] [bit] NOT NULL,
	[GhiChu] [nvarchar](200) NULL,
	[NguoiSua] [int] NULL,
	[ThoiGianSua] [datetime] NULL,
	[MaDV] [int] NULL,
 CONSTRAINT [PK__GIAYTO__D6796CCAC9630EC7] PRIMARY KEY CLUSTERED 
(
	[MaGiayTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHOM]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOM](
	[MaNhom] [int] NOT NULL,
	[TenNhom] [nvarchar](200) NULL,
 CONSTRAINT [PK_NhomQuyen] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHOM_QUYEN]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOM_QUYEN](
	[MaQuyen] [int] NOT NULL,
	[MaNhom] [int] NOT NULL,
	[GhiChu] [nchar](10) NULL,
 CONSTRAINT [PK_NHOM_QUYEN] PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC,
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUANNHAN]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUANNHAN](
	[MaQN] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[TonTai] [bit] NOT NULL,
	[NguoiSua] [int] NULL,
	[ThoiGianSua] [datetime] NULL,
	[MaCV] [int] NULL,
	[MaDV] [int] NULL,
	[MaCapBac] [int] NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__QUANNHAN__2725F8505224FF05] PRIMARY KEY CLUSTERED 
(
	[MaQN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUYEN]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUYEN](
	[MaQuyen] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](200) NOT NULL,
	[ActionName] [nvarchar](200) NULL,
	[ControllerName] [nvarchar](200) NULL,
 CONSTRAINT [PK__QUYEN__1D4B7ED4BB695527] PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RANGOAI]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RANGOAI](
	[MaRN] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGianRa] [datetime] NULL,
	[ThoiGianVao] [datetime] NULL,
	[GhiChu] [nvarchar](200) NULL,
	[Khoa] [bit] NULL,
	[NguoiSua] [int] NULL,
	[ThoiGianSua] [datetime] NULL,
	[MaGiayTo] [int] NOT NULL,
	[MaCTDS] [int] NOT NULL,
 CONSTRAINT [PK__RANGOAI__2725F7B10BFB0930] PRIMARY KEY CLUSTERED 
(
	[MaRN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TDN] [varchar](20) NOT NULL,
	[MatKhau] [varchar](200) NOT NULL,
	[Khoa] [bit] NULL,
	[MaQN] [int] NULL,
	[MaNhom] [int] NULL,
 CONSTRAINT [PK__TAIKHOAN__AD7C652900ACF0BB] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VIPHAM]    Script Date: 12/12/2023 2:29:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VIPHAM](
	[MaVP] [int] IDENTITY(1,1) NOT NULL,
	[MoTa] [nvarchar](200) NOT NULL,
	[Loai] [bit] NOT NULL,
	[ThoiGian] [date] NULL,
	[GhiChu] [nvarchar](200) NULL,
	[Khoa] [bit] NULL,
	[NguoiSua] [int] NULL,
	[ThoiGianSua] [datetime] NULL,
	[MaHV] [int] NOT NULL,
 CONSTRAINT [PK__VIPHAM__2725103A438B065C] PRIMARY KEY CLUSTERED 
(
	[MaVP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CANBO_DUYET] ON 

INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (91, 1, CAST(N'2023-12-12T07:42:10.987' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 8)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (91, 3, CAST(N'2023-12-12T07:42:13.203' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 9)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (91, 2, CAST(N'2023-12-12T07:42:14.873' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 10)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (91, 4, CAST(N'2023-12-12T07:42:36.770' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 11)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (91, 5, CAST(N'2023-12-12T07:42:38.247' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 12)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (92, 1, CAST(N'2023-12-12T08:37:48.787' AS DateTime), N'Phê duyệt tiểu đoàn', NULL, NULL, 13)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (92, 2, CAST(N'2023-12-12T08:37:51.937' AS DateTime), N'Phê duyệt tiểu đoàn', NULL, NULL, 14)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (92, 3, CAST(N'2023-12-12T08:37:54.247' AS DateTime), N'Phê duyệt tiểu đoàn', NULL, NULL, 15)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (91, 6, CAST(N'2023-12-12T08:41:45.570' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 16)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (91, 7, CAST(N'2023-12-12T08:43:40.957' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 17)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (91, 8, CAST(N'2023-12-12T08:43:40.957' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 18)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (92, 4, CAST(N'2023-12-12T08:54:50.883' AS DateTime), N'Phê duyệt tiểu đoàn', NULL, NULL, 19)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (92, 5, CAST(N'2023-12-12T08:54:50.977' AS DateTime), N'Từ chối tiểu đoàn', NULL, NULL, 20)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (92, 6, CAST(N'2023-12-12T08:54:50.977' AS DateTime), N'Phê duyệt tiểu đoàn', NULL, NULL, 21)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (92, 7, CAST(N'2023-12-12T08:54:50.977' AS DateTime), N'Phê duyệt tiểu đoàn', NULL, NULL, 22)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (92, 8, CAST(N'2023-12-12T08:54:50.977' AS DateTime), N'Phê duyệt tiểu đoàn', NULL, NULL, 23)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (76, 9, CAST(N'2023-12-12T13:10:11.813' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 24)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (76, 10, CAST(N'2023-12-12T13:38:23.857' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 25)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (76, 11, CAST(N'2023-12-12T13:38:23.947' AS DateTime), N'Từ chối đại đội', NULL, NULL, 26)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (76, 12, CAST(N'2023-12-12T13:38:23.950' AS DateTime), N'Từ chối đại đội', NULL, NULL, 27)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (76, 13, CAST(N'2023-12-12T13:38:23.950' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 28)
INSERT [dbo].[CANBO_DUYET] ([MaCB], [MaCTDS], [ThoiGianDuyet], [GhiChu], [NguoiSua], [ThoiGianSua], [MaCB_D]) VALUES (76, 14, CAST(N'2023-12-12T13:38:23.957' AS DateTime), N'Phê duyệt đại đội', NULL, NULL, 29)
SET IDENTITY_INSERT [dbo].[CANBO_DUYET] OFF
GO
SET IDENTITY_INSERT [dbo].[CAPBAC] ON 

INSERT [dbo].[CAPBAC] ([MaCapBac], [CapBac], [KyHieu]) VALUES (1, N'Binh nhất', N'B2')
INSERT [dbo].[CAPBAC] ([MaCapBac], [CapBac], [KyHieu]) VALUES (2, N'Binh nhì', N'B1')
INSERT [dbo].[CAPBAC] ([MaCapBac], [CapBac], [KyHieu]) VALUES (3, N'Hạ sỹ', N'H1')
INSERT [dbo].[CAPBAC] ([MaCapBac], [CapBac], [KyHieu]) VALUES (4, N'Trung Sỹ', N'H2')
INSERT [dbo].[CAPBAC] ([MaCapBac], [CapBac], [KyHieu]) VALUES (5, N'Thượng Sỹ', N'H3')
INSERT [dbo].[CAPBAC] ([MaCapBac], [CapBac], [KyHieu]) VALUES (6, N'Thiếu Tá', N'1//')
INSERT [dbo].[CAPBAC] ([MaCapBac], [CapBac], [KyHieu]) VALUES (7, N'Trung Tá', N'2//')
INSERT [dbo].[CAPBAC] ([MaCapBac], [CapBac], [KyHieu]) VALUES (8, N'Thượng Tá', N'3//')
SET IDENTITY_INSERT [dbo].[CAPBAC] OFF
GO
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (1, 1, N'Thăm gia đình', N'Phú Thọ', CAST(N'2023-11-25T12:34:56.000' AS DateTime), CAST(N'2023-11-25T12:34:56.000' AS DateTime), NULL, NULL, NULL, 4, 1)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (2, 2, N'Mua đồ', N'Hà Nội', CAST(N'2023-11-25T09:00:00.000' AS DateTime), CAST(N'2023-11-25T20:00:00.000' AS DateTime), NULL, NULL, NULL, 4, 2)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (1, 3, N'Thăm gia đình', N'Lạng Sơn', CAST(N'2023-12-22T08:34:00.000' AS DateTime), CAST(N'2023-12-23T08:34:00.000' AS DateTime), NULL, NULL, NULL, 3, 3)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (2, 40, N'Thăm em', N'Hà Nội', CAST(N'2023-12-05T02:13:00.000' AS DateTime), CAST(N'2023-12-05T07:18:00.000' AS DateTime), NULL, NULL, NULL, 3, 4)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (1, 12, N'Thăm gia đình', N'Thái Bình', CAST(N'2023-12-12T07:01:00.000' AS DateTime), CAST(N'2023-12-14T20:00:00.000' AS DateTime), NULL, NULL, NULL, 0, 5)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (2, 11, N'Mua đồ', N'Hưng Yên', CAST(N'2023-12-20T08:41:00.000' AS DateTime), CAST(N'2023-12-20T20:41:00.000' AS DateTime), NULL, NULL, NULL, 3, 6)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (2, 22, N'Thăm bạn ốm', N'Bệnh viện 354', CAST(N'2023-12-13T08:43:00.000' AS DateTime), CAST(N'2023-12-13T20:30:00.000' AS DateTime), NULL, NULL, NULL, 3, 7)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (2, 22, N'Thăm bạn ốm', N'Bệnh viện 354', CAST(N'2023-12-13T08:43:00.000' AS DateTime), CAST(N'2023-12-13T20:30:00.000' AS DateTime), NULL, NULL, NULL, 3, 8)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (1, 20, N'Thăm gia đình', N'Quảng Ngãi', CAST(N'2023-12-12T09:08:00.000' AS DateTime), CAST(N'2023-12-14T21:08:00.000' AS DateTime), NULL, NULL, NULL, 2, 9)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (2, 83, N'Thăm người yêu', N'Vũng Tàu', CAST(N'2023-12-27T01:08:00.000' AS DateTime), CAST(N'2023-12-29T13:08:00.000' AS DateTime), NULL, NULL, NULL, 2, 10)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (1, 9, N'Thăm gia đình', N'Bình Định', CAST(N'2023-12-22T01:09:00.000' AS DateTime), CAST(N'2023-12-29T13:09:00.000' AS DateTime), NULL, NULL, NULL, 0, 11)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (1, 12, N'Thăm gia đình', N'Thái Bình', CAST(N'2023-12-14T04:10:00.000' AS DateTime), CAST(N'2023-12-17T13:10:00.000' AS DateTime), NULL, NULL, NULL, 0, 12)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (2, 24, N'Mua đồ', N'Hà Nội', CAST(N'2023-12-12T01:11:00.000' AS DateTime), CAST(N'2023-12-28T13:12:00.000' AS DateTime), NULL, NULL, NULL, 2, 13)
INSERT [dbo].[CHITIETDANHSACH] ([HinhThucRN], [MaHocVien], [LyDo], [DiaDiem], [ThoiGianRa], [ThoiGianVao], [GhiChu], [NguoiSua], [ThoiGianSua], [TinhTrang], [MaCTDS]) VALUES (1, 5, N'Thăm gia đình', N'Thái Bình', CAST(N'2023-12-12T01:38:00.000' AS DateTime), CAST(N'2023-12-13T16:38:00.000' AS DateTime), NULL, NULL, NULL, 2, 14)
GO
INSERT [dbo].[CHITIETDANHSACH_GIAYTO] ([MaGiayTo], [MaCTDS], [ThoiGianLay], [ThoiGianTra], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua]) VALUES (5, 1, CAST(N'2023-12-12T12:47:00.000' AS DateTime), CAST(N'2023-12-12T12:47:00.000' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[CHITIETDANHSACH_GIAYTO] ([MaGiayTo], [MaCTDS], [ThoiGianLay], [ThoiGianTra], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua]) VALUES (7, 2, CAST(N'2023-12-12T12:47:00.000' AS DateTime), CAST(N'2023-12-12T12:47:00.000' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[CHITIETDANHSACH_GIAYTO] ([MaGiayTo], [MaCTDS], [ThoiGianLay], [ThoiGianTra], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua]) VALUES (9, 7, CAST(N'2023-12-12T13:39:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[CHITIETDANHSACH_GIAYTO] ([MaGiayTo], [MaCTDS], [ThoiGianLay], [ThoiGianTra], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua]) VALUES (10, 6, CAST(N'2023-12-12T13:10:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[CHITIETDANHSACH_GIAYTO] ([MaGiayTo], [MaCTDS], [ThoiGianLay], [ThoiGianTra], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua]) VALUES (14, 3, CAST(N'2023-12-12T12:47:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[CHITIETDANHSACH_GIAYTO] ([MaGiayTo], [MaCTDS], [ThoiGianLay], [ThoiGianTra], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua]) VALUES (15, 4, CAST(N'2023-12-12T12:49:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[CHUCVU] ON 

INSERT [dbo].[CHUCVU] ([MaCV], [TenCV], [KyHieu]) VALUES (1, N'Học viên', N'HV')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV], [KyHieu]) VALUES (2, N'Lớp trưởng', N'LT')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV], [KyHieu]) VALUES (3, N'Đại đội trưởng', N'ct')
INSERT [dbo].[CHUCVU] ([MaCV], [TenCV], [KyHieu]) VALUES (4, N'Tiểu đoàn trưởng', N'dt')
SET IDENTITY_INSERT [dbo].[CHUCVU] OFF
GO
SET IDENTITY_INSERT [dbo].[DONVI] ON 

INSERT [dbo].[DONVI] ([MaDV], [Cap], [TenDV], [Xoa], [NguoiSua], [ThoiGianSua]) VALUES (1, 1, N'C155', 0, NULL, NULL)
INSERT [dbo].[DONVI] ([MaDV], [Cap], [TenDV], [Xoa], [NguoiSua], [ThoiGianSua]) VALUES (2, 1, N'C156', 0, NULL, NULL)
INSERT [dbo].[DONVI] ([MaDV], [Cap], [TenDV], [Xoa], [NguoiSua], [ThoiGianSua]) VALUES (3, 1, N'C157', 0, NULL, NULL)
INSERT [dbo].[DONVI] ([MaDV], [Cap], [TenDV], [Xoa], [NguoiSua], [ThoiGianSua]) VALUES (4, 1, N'C158', 0, NULL, NULL)
INSERT [dbo].[DONVI] ([MaDV], [Cap], [TenDV], [Xoa], [NguoiSua], [ThoiGianSua]) VALUES (5, 2, N'd1', 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[DONVI] OFF
GO
SET IDENTITY_INSERT [dbo].[GIAYTO] ON 

INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (1, 1, 1, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (2, 1, 2, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (3, 1, 3, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (4, 1, 4, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (5, 1, 5, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (6, 1, 6, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (7, 1, 7, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (8, 1, 8, 0, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (9, 1, 9, 0, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (10, 1, 10, 0, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (11, 1, 11, 0, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (12, 1, 12, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (13, 1, 13, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (14, 1, 14, 0, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (15, 1, 15, 0, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (16, 1, 16, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (17, 1, 17, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (18, 1, 18, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (19, 1, 19, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (20, 1, 20, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (21, 1, 21, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (22, 1, 22, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (23, 1, 23, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (24, 1, 24, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (25, 1, 25, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (26, 1, 26, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (27, 1, 27, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (28, 1, 28, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (29, 1, 29, 1, N'Giấy ra vào', NULL, NULL, 2)
INSERT [dbo].[GIAYTO] ([MaGiayTo], [Loai], [SoGiay], [TinhTrang], [GhiChu], [NguoiSua], [ThoiGianSua], [MaDV]) VALUES (30, 1, 30, 1, N'Giấy ra vào', NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[GIAYTO] OFF
GO
INSERT [dbo].[NHOM] ([MaNhom], [TenNhom]) VALUES (1, N'Admin')
INSERT [dbo].[NHOM] ([MaNhom], [TenNhom]) VALUES (2, N'Đại đội ')
INSERT [dbo].[NHOM] ([MaNhom], [TenNhom]) VALUES (3, N'Tiểu đoàn')
INSERT [dbo].[NHOM] ([MaNhom], [TenNhom]) VALUES (4, N'Vệ binh')
INSERT [dbo].[NHOM] ([MaNhom], [TenNhom]) VALUES (5, N'Văn phòng')
GO
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (1, 1, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (1, 3, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (2, 1, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (3, 1, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (4, 1, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (4, 2, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (4, 3, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (4, 5, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (5, 1, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (5, 2, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (5, 3, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (6, 1, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (6, 4, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (6, 5, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (7, 1, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (7, 2, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (7, 3, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (8, 1, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (9, 1, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (9, 4, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (10, 1, NULL)
INSERT [dbo].[NHOM_QUYEN] ([MaQuyen], [MaNhom], [GhiChu]) VALUES (10, 2, NULL)
GO
SET IDENTITY_INSERT [dbo].[QUANNHAN] ON 

INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (1, N'Phạm Nguyễn Tất Thắng', 1, NULL, NULL, 1, 2, 5, N'Thái Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (2, N'Hà Đức Ngọc', 1, NULL, NULL, 1, 2, 5, N'Yến Bái')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (3, N'Nguyễn Lê Trung Hiếu', 1, NULL, NULL, 2, 2, 5, N'Lạng Sơn')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (4, N'Nguyễn Thị Hà Phương', 1, NULL, NULL, 1, 2, 5, N'Thanh Hóa')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (5, N'Nghiêm Văn Tiến', 1, NULL, NULL, 1, 2, 4, N'Hà Nội')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (6, N'Bùi Minh Đức', 1, NULL, NULL, 1, 2, 4, N'Hà Nội')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (7, N'Nguyễn Thị Hải Vân', 1, NULL, NULL, 1, 2, 5, N'Thái Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (8, N'Trần Thị Ngọc Khánh', 1, NULL, NULL, 1, 2, 5, N'Phú Thọ')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (9, N'Mai Thị Hạnh Trang', 1, NULL, NULL, 1, 2, 5, N'Bình Định')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (10, N'Phạm Ngọc Anh Dũng', 1, NULL, NULL, 1, 2, 4, N'Thanh Hóa')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (11, N'Nguyễn Tấn Quý', 1, NULL, NULL, 1, 2, 4, N'Bến Tre')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (12, N'Nguyễn Hoàng Nam', 1, NULL, NULL, 1, 2, 5, N'Thái Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (13, N'Trịnh Viết Tài', 1, NULL, NULL, 1, 2, 3, N'Thanh Hóa')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (14, N'Nguyễn Hữu Đức An', 1, NULL, NULL, 1, 2, 5, N'Nghệ An')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (15, N'Bùi Quốc Khánh', 1, NULL, NULL, 1, 2, 3, N'Thái Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (16, N'Nguyễn Khôi Nguyên', 1, NULL, NULL, 1, 2, 5, N'Thái Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (17, N'Nguyễn Đức Cường', 1, NULL, NULL, 1, 2, 5, N'Hà Nội')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (18, N'Phạm Thanh Tùng', 1, NULL, NULL, 1, 2, 5, N'Nam Định')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (19, N'Trần Minh Đức', 1, NULL, NULL, 2, 2, 5, N'Thái Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (20, N'Lê Thị Mỹ Duyên', 1, NULL, NULL, 1, 2, 4, N'Quảng Ngãi')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (21, N'Nguyễn Anh Nam', 1, NULL, NULL, 1, 2, 5, N'Hà Nội')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (22, N'Dương Thành Nam', 1, NULL, NULL, 1, 2, 4, N'Nghệ An')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (23, N'Nguyễn Văn Nghĩa', 1, NULL, NULL, 1, 2, 5, N'Hà Nội')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (24, N'Nguyễn Gia Hiếu', 1, NULL, NULL, 1, 2, 5, N'Nghệ An')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (25, N'Nguyễn Quang Phong', 1, NULL, NULL, 1, 2, 5, N'Quảng Trị')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (26, N'Quách Việt Tùng', 1, NULL, NULL, 1, 2, 5, N'Ninh Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (27, N'Dương Quang Minh', 1, NULL, NULL, 1, 2, 5, N'Hà Nội')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (28, N'Phạm Đức Minh', 1, NULL, NULL, 1, 2, 5, N'Nam Định')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (29, N'Nguyễn Đức Hiếu', 1, NULL, NULL, 1, 2, 4, N'Hải Dương')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (30, N'Hà Huy Hoàng', 1, NULL, NULL, 1, 2, 4, N'Cao Bằng')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (31, N'Nguyễn Duy Phương', 1, NULL, NULL, 1, 2, 4, N'Thái Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (32, N'Đỗ Nguyên Phương', 1, NULL, NULL, 1, 2, 5, N'Vĩnh Phúc')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (33, N'Lê Hữu Hiển', 1, NULL, NULL, 1, 2, 5, N'Nghệ An')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (34, N'Nguyễn Ngọc Hiếu', 1, NULL, NULL, 1, 2, 5, N'Thanh Hóa')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (35, N'Sùng Thị Út', 1, NULL, NULL, 1, 2, 4, N'Tuyên Quang')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (36, N'Hà Thùy Linh', 1, NULL, NULL, 1, 2, 5, N'Thanh Hóa')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (37, N'Bùi Bích Phương', 1, NULL, NULL, 1, 2, 5, N'Thanh Hóa')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (38, N'Lê Thị Nhi', 1, NULL, NULL, 1, 2, 5, N'Thanh Hóa')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (39, N'Nguyễn Thị Phượng Hằng', 1, NULL, NULL, 1, 2, 5, N'Đồng Tháp')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (40, N'Nguyễn Minh Hiếu', 1, NULL, NULL, 2, 2, 5, N'Nam Định')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (41, N'Đoàn Mạnh Tân', 1, NULL, NULL, 1, 2, 5, N'Hà Tĩnh')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (42, N'Đinh Đoàn Xuân Phương', 1, NULL, NULL, 1, 2, 5, N'Quảng Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (43, N'Lý Bích Ngọc', 1, NULL, NULL, 1, 2, 5, N'Cao Bằng')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (44, N'Hoàng Mỹ Linh', 1, NULL, NULL, 1, 2, 5, N'Huế')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (45, N'Đào Thị Kim Yến', 1, NULL, NULL, 1, 2, 5, N'Hải Phòng')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (46, N'Nguyễn Thị Thu Huyền', 1, NULL, NULL, 1, 2, 5, N'Hà Tĩnh')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (47, N'Vũ Lê Huyền', 1, NULL, NULL, 1, 2, 5, N'Thanh Hóa')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (48, N'Dương Đình Nhật Linh', 1, NULL, NULL, 1, 2, 5, N'Hà Tĩnh')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (49, N'Phạm Công Nguyên', 1, NULL, NULL, 1, 2, 5, N'Hải Phòng')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (50, N'Lê Đức Mạnh', 1, NULL, NULL, 1, 2, 4, N'Hưng Yên')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (51, N'Nguyễn Đức Minh', 1, NULL, NULL, 1, 2, 5, N'Quảng Nam')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (52, N'Trang Đăng Khoa', 1, NULL, NULL, 1, 2, 3, N'Kiên Giang')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (53, N'Trần Quốc Bảo', 1, NULL, NULL, 1, 2, 5, N'Hà Tĩnh')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (54, N'Nguyễn Sỹ Huy Hoàng', 1, NULL, NULL, 1, 2, 5, N'Thanh Hóa')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (55, N'Nguyễn Minh Dương', 1, NULL, NULL, 1, 2, 5, N'Yên Bái')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (56, N'Nguyễn Phúc Đẳng', 1, NULL, NULL, 1, 2, 5, N'Hà Nam')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (57, N'Nguyễn Minh Đức', 1, NULL, NULL, 1, 2, 5, N'Nam Định')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (58, N'Nguyễn Thiện Nhân', 1, NULL, NULL, 1, 2, 3, N'Quảng Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (59, N'Nguyễn Văn Hưng', 1, NULL, NULL, 1, 2, 4, N'Hà Tĩnh')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (60, N'Trần Quốc Huy', 1, NULL, NULL, 1, 2, 3, N'Hà Tĩnh')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (61, N'Chu Mạnh Hùng', 1, NULL, NULL, 1, 2, 3, N'Lạng Sơn')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (62, N'Hà Thị Ngọc Phương', 1, NULL, NULL, 1, 2, 4, N'Thanh Hóa')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (63, N'Hoàng Trung Nguyên', 1, NULL, NULL, 2, 2, 5, N'Nam Định')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (64, N'Bùi Ngọc An', 1, NULL, NULL, 1, 2, 3, N'Lào Cai')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (65, N'Phan Thị Hồng Thắm', 1, NULL, NULL, 1, 2, 5, N'Nghệ An')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (66, N'Nguyễn Bá Nam', 1, NULL, NULL, 1, 2, 4, N'Thái Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (67, N'Đỗ Phan Nhật Anh', 1, NULL, NULL, 1, 2, 3, N'Sóc Trăng')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (68, N'Nguyễn Quang Cường', 1, NULL, NULL, 2, 2, 4, N'Hà Nội')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (69, N'Trần Nhật Hiếu', 1, NULL, NULL, 1, 2, 3, N'Gia Lai')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (70, N'Nguyễn Thảo Anh', 1, NULL, NULL, 1, 2, 5, N'Hòa Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (71, N'Trần Thị Thanh Thoại', 1, NULL, NULL, 1, 2, 5, N'Long An')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (72, N'Vũ Duy Anh', 1, NULL, NULL, 1, 2, 5, N'Nghệ An')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (73, N'Ngô Anh Vũ', 1, NULL, NULL, 1, 2, 4, N'Bắc Giang')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (74, N'Vũ Văn Biển', 1, NULL, NULL, 1, 2, 4, N'Vĩnh Phúc')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (75, N'Nguyễn Thanh Hiếu', 1, NULL, NULL, 1, 2, 3, N'Nghệ An')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (76, N'Nguyễn Hồng Quân', 1, NULL, NULL, 1, 2, 5, N'Phú Thọ')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (77, N'Tạ Văn Nhật', 1, NULL, NULL, 1, 2, 4, N'Hải Phòng')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (78, N'Nguyễn Thúy Quỳnh', 1, NULL, NULL, 1, 2, 5, N'Hà Nội')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (79, N'Nguyễn Thế Anh', 1, NULL, NULL, 2, 2, 5, N'Bắc Ninh')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (80, N'Phan Đinh Minh Ngọc', 1, NULL, NULL, 1, 2, 5, N'Sóc Trăng')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (81, N'Võ Quốc Huy', 1, NULL, NULL, 1, 2, 5, N'Quảng Ngãi')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (82, N'Đặng Hoàng Việt', 1, NULL, NULL, 2, 2, 3, N'Hà Nội')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (83, N'Đàm Thị Thu Mai', 1, NULL, NULL, 1, 2, 5, N'Cao Bằng')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (84, N'Trần Quốc Dũng', 1, NULL, NULL, 1, 2, 3, N'Hà Tĩnh')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (85, N'Nguyễn Bảo Ngọc', 1, NULL, NULL, 1, 2, 4, N'Phú Thọ')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (86, N'Nguyễn Đặng Diệp Anh', 1, NULL, NULL, 1, 2, 5, N'Nam Định')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (87, N'Nguyễn Mạnh Dũng', 1, NULL, NULL, 1, 2, 3, N'Thái Bình')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (88, N'Đỗ Đức Phúc', 1, NULL, NULL, 1, 2, 5, N'Gia Lai')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (89, N'Nguyễn Thu Phương', 1, NULL, NULL, 1, 2, 5, N'Hà Tĩnh')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (91, N'Bùi Xuân Long', 1, NULL, NULL, 3, 2, 6, N'Hải Dương')
INSERT [dbo].[QUANNHAN] ([MaQN], [HoTen], [TonTai], [NguoiSua], [ThoiGianSua], [MaCV], [MaDV], [MaCapBac], [DiaChi]) VALUES (92, N'Vũ Văn Mùi', 1, NULL, NULL, 4, 5, 8, N'Hà Nội')
SET IDENTITY_INSERT [dbo].[QUANNHAN] OFF
GO
SET IDENTITY_INSERT [dbo].[QUYEN] ON 

INSERT [dbo].[QUYEN] ([MaQuyen], [Ten], [ActionName], [ControllerName]) VALUES (1, N'Quản lý đơn vị', N'QuanLyDonVi', N'Admin')
INSERT [dbo].[QUYEN] ([MaQuyen], [Ten], [ActionName], [ControllerName]) VALUES (2, N'Quản lý cấp bậc', N'QuanLyCapBac', N'Admin')
INSERT [dbo].[QUYEN] ([MaQuyen], [Ten], [ActionName], [ControllerName]) VALUES (3, N'Quản lý Chức vụ', N'QuanLyChucVu', N'Admin')
INSERT [dbo].[QUYEN] ([MaQuyen], [Ten], [ActionName], [ControllerName]) VALUES (4, N'Quản lý giấy tờ', N'QuanLyGiayTo', N'Admin')
INSERT [dbo].[QUYEN] ([MaQuyen], [Ten], [ActionName], [ControllerName]) VALUES (5, N'Quản lý quân nhân', N'QuanLyQuanNhan', N'Admin')
INSERT [dbo].[QUYEN] ([MaQuyen], [Ten], [ActionName], [ControllerName]) VALUES (6, N'Quản lý vi phạm', N'QuanLyViPham', N'Admin')
INSERT [dbo].[QUYEN] ([MaQuyen], [Ten], [ActionName], [ControllerName]) VALUES (7, N'Quản lý danh sách ra ngoài', N'QuanLyDanhSach', N'Admin')
INSERT [dbo].[QUYEN] ([MaQuyen], [Ten], [ActionName], [ControllerName]) VALUES (8, N'Quản lý tài khoản', N'QuanLyTK', N'Admin')
INSERT [dbo].[QUYEN] ([MaQuyen], [Ten], [ActionName], [ControllerName]) VALUES (9, N'Quản lý danh sách qua cổng', N'QuanLyDSGT', N'Admin')
INSERT [dbo].[QUYEN] ([MaQuyen], [Ten], [ActionName], [ControllerName]) VALUES (10, N'Lịch sử ra ngoài', N'LichSu', N'Admin')
SET IDENTITY_INSERT [dbo].[QUYEN] OFF
GO
SET IDENTITY_INSERT [dbo].[RANGOAI] ON 

INSERT [dbo].[RANGOAI] ([MaRN], [ThoiGianRa], [ThoiGianVao], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaGiayTo], [MaCTDS]) VALUES (8, CAST(N'2023-12-12T12:47:35.000' AS DateTime), CAST(N'2023-12-12T12:47:41.070' AS DateTime), NULL, NULL, NULL, NULL, 7, 2)
INSERT [dbo].[RANGOAI] ([MaRN], [ThoiGianRa], [ThoiGianVao], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaGiayTo], [MaCTDS]) VALUES (9, CAST(N'2023-12-12T13:52:57.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 9, 7)
INSERT [dbo].[RANGOAI] ([MaRN], [ThoiGianRa], [ThoiGianVao], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaGiayTo], [MaCTDS]) VALUES (10, CAST(N'2023-12-12T13:53:12.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 10, 6)
SET IDENTITY_INSERT [dbo].[RANGOAI] OFF
GO
SET IDENTITY_INSERT [dbo].[TAIKHOAN] ON 

INSERT [dbo].[TAIKHOAN] ([MaTaiKhoan], [TDN], [MatKhau], [Khoa], [MaQN], [MaNhom]) VALUES (1, N'admin', N'c4ca4238a0b923820dcc509a6f75849b', 0, 76, 1)
INSERT [dbo].[TAIKHOAN] ([MaTaiKhoan], [TDN], [MatKhau], [Khoa], [MaQN], [MaNhom]) VALUES (2, N'daidoi', N'c4ca4238a0b923820dcc509a6f75849b', 0, 91, 2)
INSERT [dbo].[TAIKHOAN] ([MaTaiKhoan], [TDN], [MatKhau], [Khoa], [MaQN], [MaNhom]) VALUES (3, N'tieudoan', N'c4ca4238a0b923820dcc509a6f75849b', 0, 92, 3)
INSERT [dbo].[TAIKHOAN] ([MaTaiKhoan], [TDN], [MatKhau], [Khoa], [MaQN], [MaNhom]) VALUES (4, N'vanphong', N'c4ca4238a0b923820dcc509a6f75849b', 0, 1, 5)
INSERT [dbo].[TAIKHOAN] ([MaTaiKhoan], [TDN], [MatKhau], [Khoa], [MaQN], [MaNhom]) VALUES (5, N'vebinh', N'c4ca4238a0b923820dcc509a6f75849b', 0, 1, 4)
SET IDENTITY_INSERT [dbo].[TAIKHOAN] OFF
GO
SET IDENTITY_INSERT [dbo].[VIPHAM] ON 

INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (1, N'Mang đồ ăn chín qua cổng', 1, CAST(N'2023-10-16' AS Date), NULL, 0, NULL, NULL, 3)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (2, N'Chăn xấu', 0, CAST(N'2023-10-17' AS Date), N'd kiểm tra NVVS', 1, NULL, NULL, 7)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (3, N'Ngủ gật', 0, CAST(N'2023-10-19' AS Date), N'Giờ tự ôn', 0, NULL, NULL, 15)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (4, N'Mất giấy ra vào', 1, CAST(N'2023-10-18' AS Date), N'Không rõ thời gian mất', 0, NULL, NULL, 23)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (5, N'Giày sai vị trí', 0, CAST(N'2023-10-18' AS Date), N'd kiểm tra NVVS', 0, NULL, NULL, 28)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (6, N'Không buộc dây giày', 0, CAST(N'2023-10-15' AS Date), N'Gác sai tác phong', 0, NULL, NULL, 30)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (7, N'Nói chuyện khi gác', 0, CAST(N'2023-10-18' AS Date), N'Bị chỉ huy d nhắc nhở', 0, NULL, NULL, 32)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (8, N'Mặc đồ dân bên trong áo bông', 1, CAST(N'2023-10-24' AS Date), N'Sai tác phong qua cổng', 0, NULL, NULL, 34)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (9, N'Vào muộn giờ quy định', 1, CAST(N'2023-10-18' AS Date), N'Vi phạm thời gian ra vào cổng', 0, NULL, NULL, 37)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (10, N'Ngủ gật', 0, CAST(N'2023-10-18' AS Date), N'Trên lớp môn HCTC', 0, NULL, NULL, 39)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (11, N'Tập trung chậm', 0, CAST(N'2023-10-18' AS Date), N'Giờ thể dục sáng', 0, NULL, NULL, 44)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (12, N'Cầu thang bẩn', 0, CAST(N'2023-10-21' AS Date), N'Lớp chưa quét cầu thang', 0, NULL, NULL, 49)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (13, N'Tập trung chậm', 0, CAST(N'2023-10-18' AS Date), N'Giờ thể dục sáng', 0, NULL, NULL, 44)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (14, N'Chăn xấu', 0, CAST(N'2023-10-18' AS Date), N'd kiểm tra NVVS', 0, NULL, NULL, 55)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (15, N'Phản bẩn', 0, CAST(N'2023-10-21' AS Date), N'd kiểm tra NVVS', 0, NULL, NULL, 61)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (16, N'Tập trung chậm', 0, CAST(N'2023-10-26' AS Date), N'Giờ đi học', 0, NULL, NULL, 68)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (17, N'Tập trung chậm', 0, CAST(N'2023-10-18' AS Date), N'Giờ ăn cơm', 0, NULL, NULL, 72)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (18, N'Tập trung chậm', 0, CAST(N'2023-10-18' AS Date), N'Giờ thể dục sáng', 0, NULL, NULL, 73)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (19, N'Tập trung chậm', 0, CAST(N'2023-10-18' AS Date), N'Giờ thể dục sáng', 0, NULL, NULL, 77)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (20, N'Chăn xấu', 0, CAST(N'2023-10-17' AS Date), N'd kiểm tra NVVS', 1, NULL, NULL, 85)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (21, N'Nói chuyện khi gác', 0, CAST(N'2023-10-18' AS Date), N'Bị chỉ huy d nhắc nhở', 0, NULL, NULL, 87)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (22, N'Ngủ gật', 0, CAST(N'2023-10-18' AS Date), N'Trên lớp môn HCTC', 0, NULL, NULL, 89)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (23, N'Ngủ gật', 0, CAST(N'2023-10-19' AS Date), N'Giờ tự ôn', 0, NULL, NULL, 45)
INSERT [dbo].[VIPHAM] ([MaVP], [MoTa], [Loai], [ThoiGian], [GhiChu], [Khoa], [NguoiSua], [ThoiGianSua], [MaHV]) VALUES (24, N'Phản bẩn', 0, CAST(N'2023-10-21' AS Date), N'd kiểm tra NVVS', 0, NULL, NULL, 52)
SET IDENTITY_INSERT [dbo].[VIPHAM] OFF
GO
ALTER TABLE [dbo].[CANBO_DUYET]  WITH CHECK ADD  CONSTRAINT [FK__CANBO_DUYE__MaCB__398D8EEE] FOREIGN KEY([MaCB])
REFERENCES [dbo].[QUANNHAN] ([MaQN])
GO
ALTER TABLE [dbo].[CANBO_DUYET] CHECK CONSTRAINT [FK__CANBO_DUYE__MaCB__398D8EEE]
GO
ALTER TABLE [dbo].[CANBO_DUYET]  WITH CHECK ADD  CONSTRAINT [FK_CANBO_DUYET_CHITIETDANHSACH] FOREIGN KEY([MaCTDS])
REFERENCES [dbo].[CHITIETDANHSACH] ([MaCTDS])
GO
ALTER TABLE [dbo].[CANBO_DUYET] CHECK CONSTRAINT [FK_CANBO_DUYET_CHITIETDANHSACH]
GO
ALTER TABLE [dbo].[CHITIETDANHSACH]  WITH CHECK ADD  CONSTRAINT [FK__CHITIETDA__MaHoc__3B75D760] FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[QUANNHAN] ([MaQN])
GO
ALTER TABLE [dbo].[CHITIETDANHSACH] CHECK CONSTRAINT [FK__CHITIETDA__MaHoc__3B75D760]
GO
ALTER TABLE [dbo].[CHITIETDANHSACH_GIAYTO]  WITH CHECK ADD  CONSTRAINT [FK__CHITIETDA__MaGia__3D5E1FD2] FOREIGN KEY([MaGiayTo])
REFERENCES [dbo].[GIAYTO] ([MaGiayTo])
GO
ALTER TABLE [dbo].[CHITIETDANHSACH_GIAYTO] CHECK CONSTRAINT [FK__CHITIETDA__MaGia__3D5E1FD2]
GO
ALTER TABLE [dbo].[CHITIETDANHSACH_GIAYTO]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDANHSACH_GIAYTO_CHITIETDANHSACH] FOREIGN KEY([MaCTDS])
REFERENCES [dbo].[CHITIETDANHSACH] ([MaCTDS])
GO
ALTER TABLE [dbo].[CHITIETDANHSACH_GIAYTO] CHECK CONSTRAINT [FK_CHITIETDANHSACH_GIAYTO_CHITIETDANHSACH]
GO
ALTER TABLE [dbo].[GIAYTO]  WITH CHECK ADD  CONSTRAINT [FK__GIAYTO__MaDV__403A8C7D] FOREIGN KEY([MaDV])
REFERENCES [dbo].[DONVI] ([MaDV])
GO
ALTER TABLE [dbo].[GIAYTO] CHECK CONSTRAINT [FK__GIAYTO__MaDV__403A8C7D]
GO
ALTER TABLE [dbo].[NHOM_QUYEN]  WITH CHECK ADD  CONSTRAINT [FK_NHOM_QUYEN_NHOM] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[NHOM] ([MaNhom])
GO
ALTER TABLE [dbo].[NHOM_QUYEN] CHECK CONSTRAINT [FK_NHOM_QUYEN_NHOM]
GO
ALTER TABLE [dbo].[NHOM_QUYEN]  WITH CHECK ADD  CONSTRAINT [FK_NHOM_QUYEN_QUYEN] FOREIGN KEY([MaQuyen])
REFERENCES [dbo].[QUYEN] ([MaQuyen])
GO
ALTER TABLE [dbo].[NHOM_QUYEN] CHECK CONSTRAINT [FK_NHOM_QUYEN_QUYEN]
GO
ALTER TABLE [dbo].[QUANNHAN]  WITH CHECK ADD  CONSTRAINT [FK__QUANNHAN__MaCapB__412EB0B6] FOREIGN KEY([MaCapBac])
REFERENCES [dbo].[CAPBAC] ([MaCapBac])
GO
ALTER TABLE [dbo].[QUANNHAN] CHECK CONSTRAINT [FK__QUANNHAN__MaCapB__412EB0B6]
GO
ALTER TABLE [dbo].[QUANNHAN]  WITH CHECK ADD  CONSTRAINT [FK__QUANNHAN__MaCV__4222D4EF] FOREIGN KEY([MaCV])
REFERENCES [dbo].[CHUCVU] ([MaCV])
GO
ALTER TABLE [dbo].[QUANNHAN] CHECK CONSTRAINT [FK__QUANNHAN__MaCV__4222D4EF]
GO
ALTER TABLE [dbo].[QUANNHAN]  WITH CHECK ADD  CONSTRAINT [FK__QUANNHAN__MaDV__4316F928] FOREIGN KEY([MaDV])
REFERENCES [dbo].[DONVI] ([MaDV])
GO
ALTER TABLE [dbo].[QUANNHAN] CHECK CONSTRAINT [FK__QUANNHAN__MaDV__4316F928]
GO
ALTER TABLE [dbo].[RANGOAI]  WITH CHECK ADD  CONSTRAINT [FK__RANGOAI__MaGiayT__44FF419A] FOREIGN KEY([MaGiayTo])
REFERENCES [dbo].[GIAYTO] ([MaGiayTo])
GO
ALTER TABLE [dbo].[RANGOAI] CHECK CONSTRAINT [FK__RANGOAI__MaGiayT__44FF419A]
GO
ALTER TABLE [dbo].[RANGOAI]  WITH CHECK ADD  CONSTRAINT [FK_RANGOAI_CHITIETDANHSACH] FOREIGN KEY([MaCTDS])
REFERENCES [dbo].[CHITIETDANHSACH] ([MaCTDS])
GO
ALTER TABLE [dbo].[RANGOAI] CHECK CONSTRAINT [FK_RANGOAI_CHITIETDANHSACH]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK__TAIKHOAN__MaQN__46E78A0C] FOREIGN KEY([MaQN])
REFERENCES [dbo].[QUANNHAN] ([MaQN])
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK__TAIKHOAN__MaQN__46E78A0C]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TAIKHOAN_NHOM] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[NHOM] ([MaNhom])
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK_TAIKHOAN_NHOM]
GO
ALTER TABLE [dbo].[VIPHAM]  WITH CHECK ADD  CONSTRAINT [FK__VIPHAM__MaHV__49C3F6B7] FOREIGN KEY([MaHV])
REFERENCES [dbo].[QUANNHAN] ([MaQN])
GO
ALTER TABLE [dbo].[VIPHAM] CHECK CONSTRAINT [FK__VIPHAM__MaHV__49C3F6B7]
GO
