USE [Peatonales]
GO

/****** Object:  Table [dbo].[SpecialPublications]    Script Date: 06/21/2017 12:55:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SpecialPublications](
	[idspecialpublication] [bigint] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](300) NOT NULL,
	[description] [nvarchar](500) NULL,
	[photo] [nvarchar](500) NOT NULL,
	[termscondition] [nvarchar](1000) NULL,
	[state] [int] NOT NULL,
	[maxquantity] [int] NULL,
	[visiblecondition] [nvarchar](100) NULL,
	[initialdate] [datetime] NOT NULL,
	[finaldate] [datetime] NOT NULL,
	[idbusiness] [bigint] NOT NULL,
	[idpublicationcategory] [bigint] NOT NULL,
	[clicks] [bigint] NULL,
	[position] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idspecialpublication] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SpecialPublications]  WITH CHECK ADD FOREIGN KEY([idbusiness])
REFERENCES [dbo].[Businesses] ([idbusiness])
GO

ALTER TABLE [dbo].[SpecialPublications]  WITH CHECK ADD FOREIGN KEY([idpublicationcategory])
REFERENCES [dbo].[PublicationCategories] ([idpublicationcategory])
GO


USE [Peatonales]
GO

/****** Object:  Table [dbo].[SpecialPublicationBCTags]    Script Date: 06/21/2017 12:55:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SpecialPublicationBCTags](
	[idspecialpublicationbctag] [bigint] IDENTITY(1,1) NOT NULL,
	[idspecialpublication] [bigint] NOT NULL,
	[idbusinessconfigurationtag] [bigint] NOT NULL,
	[state] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idspecialpublicationbctag] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SpecialPublicationBCTags]  WITH CHECK ADD  CONSTRAINT [FK__SpecialPu__idbus__74643BF9] FOREIGN KEY([idbusinessconfigurationtag])
REFERENCES [dbo].[BusinessConfigurationTags] ([idbusinessconfigurationtag])
GO

ALTER TABLE [dbo].[SpecialPublicationBCTags] CHECK CONSTRAINT [FK__SpecialPu__idbus__74643BF9]
GO

ALTER TABLE [dbo].[SpecialPublicationBCTags]  WITH CHECK ADD  CONSTRAINT [FK_SpecialPublicationBCTags_SpecialPublications] FOREIGN KEY([idspecialpublication])
REFERENCES [dbo].[SpecialPublications] ([idspecialpublication])
GO

ALTER TABLE [dbo].[SpecialPublicationBCTags] CHECK CONSTRAINT [FK_SpecialPublicationBCTags_SpecialPublications]
GO

USE [Peatonales]
GO

/****** Object:  Table [dbo].[SpecialPublicationServiceConsumes]    Script Date: 06/21/2017 12:56:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SpecialPublicationServiceConsumes](
	[idspecialpublicationserviceconsume] [bigint] IDENTITY(1,1) NOT NULL,
	[idserviceconsume] [bigint] NOT NULL,
	[idspecialpublication] [bigint] NOT NULL,
	[state] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idspecialpublicationserviceconsume] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SpecialPublicationServiceConsumes]  WITH CHECK ADD FOREIGN KEY([idserviceconsume])
REFERENCES [dbo].[ServiceConsumes] ([idserviceconsume])
GO

USE [Peatonales]
GO

/****** Object:  Table [dbo].[Banners]    Script Date: 06/21/2017 12:59:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Banners](
	[idbanner] [bigint] IDENTITY(1,1) NOT NULL,
	[state] [int] NOT NULL,
	[idbusiness] [bigint] NOT NULL,
	[creationdate] [datetime] NOT NULL,
	[finaldate] [datetime] NOT NULL,
	[typebanner] [int] NOT NULL,
 CONSTRAINT [PK_Banners] PRIMARY KEY CLUSTERED 
(
	[idbanner] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Banners]  WITH CHECK ADD  CONSTRAINT [FK_Banners_Businesses] FOREIGN KEY([idbusiness])
REFERENCES [dbo].[Businesses] ([idbusiness])
GO

ALTER TABLE [dbo].[Banners] CHECK CONSTRAINT [FK_Banners_Businesses]
GO

USE [Peatonales]
GO

/****** Object:  Table [dbo].[BannerImgs]    Script Date: 06/21/2017 12:59:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BannerImgs](
	[idbannerimg] [bigint] IDENTITY(1,1) NOT NULL,
	[bannerimg] [nvarchar](500) NOT NULL,
	[bannerlink] [nvarchar](100) NOT NULL,
	[state] [int] NOT NULL,
	[idbanner] [bigint] NOT NULL,
	[coordx] [int] NULL,
	[coordy] [int] NULL,
	[height] [int] NULL,
	[width] [int] NULL,
 CONSTRAINT [PK_BannerImgs] PRIMARY KEY CLUSTERED 
(
	[idbannerimg] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BannerImgs]  WITH CHECK ADD  CONSTRAINT [FK_BannerImgs_Banners] FOREIGN KEY([idbanner])
REFERENCES [dbo].[Banners] ([idbanner])
GO

ALTER TABLE [dbo].[BannerImgs] CHECK CONSTRAINT [FK_BannerImgs_Banners]
GO

