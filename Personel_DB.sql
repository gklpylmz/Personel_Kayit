USE [Personel_DB]
GO
/****** Object:  Table [dbo].[Tbl_Hesap]    Script Date: 3.04.2023 03:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Hesap](
	[kullaniciAd] [varchar](20) NOT NULL,
	[kullaniciSifre] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Personel]    Script Date: 3.04.2023 03:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Personel](
	[Perid] [smallint] IDENTITY(1,1) NOT NULL,
	[perAd] [varchar](20) NULL,
	[perSoyad] [varchar](20) NULL,
	[perSehir] [varchar](13) NULL,
	[perMaas] [smallint] NULL,
	[perDurum] [bit] NULL,
	[perMeslek] [varchar](15) NULL
) ON [PRIMARY]
GO
