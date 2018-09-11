/*
 Navicat Premium Data Transfer

 Source Server         : 棱镜物流服务器
 Source Server Type    : SQL Server
 Source Server Version : 12002000
 Source Host           : 47.98.154.197
 Source Database       : TMS_ADMIN
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 12002000
 File Encoding         : utf-8

 Date: 08/20/2018 11:38:07 AM
*/

-- ----------------------------
--  Table structure for GPS_USER
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID('[dbo].[GPS_USER]') AND type IN ('U'))
	DROP TABLE [dbo].[GPS_USER]
GO
CREATE TABLE [dbo].[GPS_USER] (
	[USER_ID] nvarchar(64) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[USER_NAME] nvarchar(64) COLLATE Chinese_PRC_CI_AS NULL,
	[USER_SHORTNAME] nvarchar(32) COLLATE Chinese_PRC_CI_AS NULL,
	[USER_CODE] nvarchar(64) COLLATE Chinese_PRC_CI_AS NULL,
	[USER_BALANCE] decimal(16,2) NULL,
	[USER_ADD_P] nvarchar(64) COLLATE Chinese_PRC_CI_AS NULL,
	[USER_ADD_C] nvarchar(64) COLLATE Chinese_PRC_CI_AS NULL,
	[USER_ADD_D] nvarchar(max) COLLATE Chinese_PRC_CI_AS NULL,
	[USER_CON] nvarchar(32) COLLATE Chinese_PRC_CI_AS NULL,
	[USER_CON_TEL] nvarchar(32) COLLATE Chinese_PRC_CI_AS NULL,
	[USER_CON_EMAIL] nvarchar(64) COLLATE Chinese_PRC_CI_AS NULL,
	[USER_STATUS] nvarchar(8) COLLATE Chinese_PRC_CI_AS NULL,
	[EDI_STATUS] nvarchar(8) COLLATE Chinese_PRC_CI_AS NULL,
	[ADD_TIME] datetime NULL
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

-- ----------------------------
--  Table structure for GPS_CHARGE
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID('[dbo].[GPS_CHARGE]') AND type IN ('U'))
	DROP TABLE [dbo].[GPS_CHARGE]
GO
CREATE TABLE [dbo].[GPS_CHARGE] (
	[ID] nvarchar(64) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[USER_ID] nvarchar(64) COLLATE Chinese_PRC_CI_AS NULL,
	[GPS_EDI_TYPE] nvarchar(32) COLLATE Chinese_PRC_CI_AS NULL,
	[GPS_EDI_STATUS] nvarchar(8) COLLATE Chinese_PRC_CI_AS NULL,
	[GPS_EDI_TIME] datetime NULL,
	[GPS_EDI_VIHICLE] nvarchar(8) COLLATE Chinese_PRC_CI_AS NULL,
	[GPS_EDI_CHARGE] decimal(16,2) NULL,
	[GPS_EDI_ID] nvarchar(32) COLLATE Chinese_PRC_CI_AS NULL
)
ON [PRIMARY]
GO

-- ----------------------------
--  Table structure for GPS_EDI
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID('[dbo].[GPS_EDI]') AND type IN ('U'))
	DROP TABLE [dbo].[GPS_EDI]
GO
CREATE TABLE [dbo].[GPS_EDI] (
	[ID] nvarchar(64) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[USER_ID] nvarchar(64) COLLATE Chinese_PRC_CI_AS NULL,
	[GPS_EDI_TYPE] nvarchar(32) COLLATE Chinese_PRC_CI_AS NULL,
	[GPS_EDI_STATUS] nvarchar(8) COLLATE Chinese_PRC_CI_AS NULL,
	[GPS_EDI_TIME] datetime NULL,
	[GPS_EDI_VIHICLE] nvarchar(8) COLLATE Chinese_PRC_CI_AS NULL,
	[GPS_EDI_CHARGE] decimal(16,2) NULL,
	[GPS_EDI_ID] nvarchar(32) COLLATE Chinese_PRC_CI_AS NULL
)
ON [PRIMARY]
GO

-- ----------------------------
--  Table structure for VIHICLE_DATA
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID('[dbo].[VIHICLE_DATA]') AND type IN ('U'))
	DROP TABLE [dbo].[VIHICLE_DATA]
GO
CREATE TABLE [dbo].[VIHICLE_DATA] (
	[ID] nvarchar(64) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[GPS_EDI_VIHICLE] nvarchar(8) COLLATE Chinese_PRC_CI_AS NULL,
	[FROM_EDI] nvarchar(16) COLLATE Chinese_PRC_CI_AS NULL,
	[FROM_USER] nvarchar(64) COLLATE Chinese_PRC_CI_AS NULL,
	[EDI_TIMES] datetime NULL,
	[EDI_UPDATE] datetime NULL
)
ON [PRIMARY]
GO

-- ----------------------------
--  Table structure for VIHICLE_P_P
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID('[dbo].[VIHICLE_P_P]') AND type IN ('U'))
	DROP TABLE [dbo].[VIHICLE_P_P]
GO
CREATE TABLE [dbo].[VIHICLE_P_P] (
	[ID] nvarchar(64) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[GPS_EDI_VIHICLE] nvarchar(8) COLLATE Chinese_PRC_CI_AS NULL,
	[VIHICLE_P_P_P] nvarchar(16) COLLATE Chinese_PRC_CI_AS NULL,
	[VIHICLE_P_P_C] nvarchar(16) COLLATE Chinese_PRC_CI_AS NULL,
	[VIHICLE_P_P_C1] nvarchar(32) COLLATE Chinese_PRC_CI_AS NULL,
	[VIHICLE_P_P_D] nvarchar(max) COLLATE Chinese_PRC_CI_AS NULL,
	[VIHICLE_P_P_T] datetime NULL,
	[VIHICLE_LAT] decimal(16,0) NULL,
	[VIHICLE_LON] decimal(16,0) NULL
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO


-- ----------------------------
--  Primary key structure for table GPS_USER
-- ----------------------------
ALTER TABLE [dbo].[GPS_USER] ADD
	CONSTRAINT [PK__GPS_USER__F3BEEBFFD03554F0] PRIMARY KEY CLUSTERED ([USER_ID]) 
	WITH (PAD_INDEX = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON)
	ON [default]
GO

-- ----------------------------
--  Primary key structure for table GPS_CHARGE
-- ----------------------------
ALTER TABLE [dbo].[GPS_CHARGE] ADD
	CONSTRAINT [PK__GPS_CHAR__3214EC2763BEBDE9] PRIMARY KEY CLUSTERED ([ID]) 
	WITH (PAD_INDEX = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON)
	ON [default]
GO

-- ----------------------------
--  Primary key structure for table GPS_EDI
-- ----------------------------
ALTER TABLE [dbo].[GPS_EDI] ADD
	CONSTRAINT [PK__GPS_CHAR__3214EC27A72C08F0] PRIMARY KEY CLUSTERED ([ID]) 
	WITH (PAD_INDEX = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON)
	ON [default]
GO

-- ----------------------------
--  Primary key structure for table VIHICLE_DATA
-- ----------------------------
ALTER TABLE [dbo].[VIHICLE_DATA] ADD
	CONSTRAINT [PK__VIHICLE___3214EC2757A8C905] PRIMARY KEY CLUSTERED ([ID]) 
	WITH (PAD_INDEX = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON)
	ON [default]
GO

-- ----------------------------
--  Primary key structure for table VIHICLE_P_P
-- ----------------------------
ALTER TABLE [dbo].[VIHICLE_P_P] ADD
	CONSTRAINT [PK__VIHICLE___3214EC27862BCCCC] PRIMARY KEY CLUSTERED ([ID]) 
	WITH (PAD_INDEX = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON)
	ON [default]
GO

-- ----------------------------
--  Options for table GPS_USER
-- ----------------------------
ALTER TABLE [dbo].[GPS_USER] SET (LOCK_ESCALATION = TABLE)
GO

-- ----------------------------
--  Options for table GPS_CHARGE
-- ----------------------------
ALTER TABLE [dbo].[GPS_CHARGE] SET (LOCK_ESCALATION = TABLE)
GO

-- ----------------------------
--  Options for table GPS_EDI
-- ----------------------------
ALTER TABLE [dbo].[GPS_EDI] SET (LOCK_ESCALATION = TABLE)
GO

-- ----------------------------
--  Options for table VIHICLE_DATA
-- ----------------------------
ALTER TABLE [dbo].[VIHICLE_DATA] SET (LOCK_ESCALATION = TABLE)
GO

-- ----------------------------
--  Options for table VIHICLE_P_P
-- ----------------------------
ALTER TABLE [dbo].[VIHICLE_P_P] SET (LOCK_ESCALATION = TABLE)
GO

