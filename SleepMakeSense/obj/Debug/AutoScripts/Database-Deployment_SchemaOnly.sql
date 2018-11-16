SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActiveSubscriptions](
	[ActiveID] [uniqueidentifier] NOT NULL,
	[SubscriptionID] [uniqueidentifier] NOT NULL,
	[TotalNotifications] [int] NULL,
	[TotalSuccesses] [int] NOT NULL,
	[TotalFailures] [int] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Name] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ClaimType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClaimValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProviderKey] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RoleId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecurityStamp] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhoneNumber] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FitbitConnected] [bit] NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Batch](
	[BatchID] [uniqueidentifier] NOT NULL,
	[AddedOn] [datetime] NOT NULL,
	[Action] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Item] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Parent] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Param] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BoolParam] [bit] NULL,
	[Content] [image] NULL,
	[Properties] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CachePolicy](
	[CachePolicyID] [uniqueidentifier] NOT NULL,
	[ReportID] [uniqueidentifier] NOT NULL,
	[ExpirationFlags] [int] NOT NULL,
	[CacheExpiration] [int] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalog](
	[ItemID] [uniqueidentifier] NOT NULL,
	[Path] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Name] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ParentID] [uniqueidentifier] NULL,
	[Type] [int] NOT NULL,
	[Content] [image] NULL,
	[Intermediate] [uniqueidentifier] NULL,
	[SnapshotDataID] [uniqueidentifier] NULL,
	[LinkSourceID] [uniqueidentifier] NULL,
	[Property] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Hidden] [bit] NULL,
	[CreatedByID] [uniqueidentifier] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModifiedByID] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[MimeType] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SnapshotLimit] [int] NULL,
	[Parameter] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PolicyID] [uniqueidentifier] NOT NULL,
	[PolicyRoot] [bit] NOT NULL,
	[ExecutionFlag] [int] NOT NULL,
	[ExecutionTime] [datetime] NULL,
	[SubType] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ComponentID] [uniqueidentifier] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChunkData](
	[ChunkID] [uniqueidentifier] NOT NULL,
	[SnapshotDataID] [uniqueidentifier] NOT NULL,
	[ChunkFlags] [tinyint] NULL,
	[ChunkName] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ChunkType] [int] NULL,
	[Version] [smallint] NULL,
	[MimeType] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Content] [image] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChunkSegmentMapping](
	[ChunkId] [uniqueidentifier] NOT NULL,
	[SegmentId] [uniqueidentifier] NOT NULL,
	[StartByte] [bigint] NOT NULL,
	[LogicalByteCount] [int] NOT NULL,
	[ActualByteCount] [int] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigurationInfo](
	[ConfigInfoID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Value] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataSets](
	[ID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[LinkID] [uniqueidentifier] NULL,
	[Name] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataSource](
	[DSID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NULL,
	[SubscriptionID] [uniqueidentifier] NULL,
	[Name] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Extension] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Link] [uniqueidentifier] NULL,
	[CredentialRetrieval] [int] NULL,
	[Prompt] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ConnectionString] [image] NULL,
	[OriginalConnectionString] [image] NULL,
	[OriginalConnectStringExpressionBased] [bit] NULL,
	[UserName] [image] NULL,
	[Password] [image] NULL,
	[Flags] [int] NULL,
	[Version] [int] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DBUpgradeHistory](
	[UpgradeID] [bigint] NOT NULL,
	[DbVersion] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[User] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateTime] [datetime] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventID] [uniqueidentifier] NOT NULL,
	[EventType] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EventData] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TimeEntered] [datetime] NOT NULL,
	[ProcessStart] [datetime] NULL,
	[ProcessHeartbeat] [datetime] NULL,
	[BatchID] [uniqueidentifier] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExecutionLog](
	[InstanceName] [nvarchar](38) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ReportID] [uniqueidentifier] NULL,
	[UserName] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RequestType] [bit] NULL,
	[Format] [nvarchar](26) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Parameters] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TimeStart] [datetime] NOT NULL,
	[TimeEnd] [datetime] NOT NULL,
	[TimeDataRetrieval] [int] NOT NULL,
	[TimeProcessing] [int] NOT NULL,
	[TimeRendering] [int] NOT NULL,
	[Source] [int] NOT NULL,
	[Status] [nvarchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ByteCount] [bigint] NOT NULL,
	[RowCount] [bigint] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExecutionLog2](
	[InstanceName] [nvarchar](38) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ReportPath] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserName] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExecutionId] [nvarchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RequestType] [varchar](12) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Format] [nvarchar](26) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Parameters] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ReportAction] [varchar](21) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TimeStart] [datetime] NOT NULL,
	[TimeEnd] [datetime] NOT NULL,
	[TimeDataRetrieval] [int] NOT NULL,
	[TimeProcessing] [int] NOT NULL,
	[TimeRendering] [int] NOT NULL,
	[Source] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Status] [nvarchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ByteCount] [bigint] NOT NULL,
	[RowCount] [bigint] NOT NULL,
	[AdditionalInfo] [xml] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExecutionLog3](
	[InstanceName] [nvarchar](38) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ItemPath] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserName] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExecutionId] [nvarchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RequestType] [varchar](13) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Format] [nvarchar](26) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Parameters] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ItemAction] [varchar](21) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TimeStart] [datetime] NOT NULL,
	[TimeEnd] [datetime] NOT NULL,
	[TimeDataRetrieval] [int] NOT NULL,
	[TimeProcessing] [int] NOT NULL,
	[TimeRendering] [int] NOT NULL,
	[Source] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Status] [nvarchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ByteCount] [bigint] NOT NULL,
	[RowCount] [bigint] NOT NULL,
	[AdditionalInfo] [xml] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExecutionLogStorage](
	[LogEntryId] [bigint] NOT NULL,
	[InstanceName] [nvarchar](38) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ReportID] [uniqueidentifier] NULL,
	[UserName] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExecutionId] [nvarchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RequestType] [tinyint] NOT NULL,
	[Format] [nvarchar](26) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Parameters] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ReportAction] [tinyint] NULL,
	[TimeStart] [datetime] NOT NULL,
	[TimeEnd] [datetime] NOT NULL,
	[TimeDataRetrieval] [int] NOT NULL,
	[TimeProcessing] [int] NOT NULL,
	[TimeRendering] [int] NOT NULL,
	[Source] [tinyint] NOT NULL,
	[Status] [nvarchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ByteCount] [bigint] NOT NULL,
	[RowCount] [bigint] NOT NULL,
	[AdditionalInfo] [xml] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtendedDataSets](
	[ID] [uniqueidentifier] NOT NULL,
	[LinkID] [uniqueidentifier] NULL,
	[Name] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtendedDataSources](
	[DSID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NULL,
	[SubscriptionID] [uniqueidentifier] NULL,
	[Name] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Extension] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Link] [uniqueidentifier] NULL,
	[CredentialRetrieval] [int] NULL,
	[Prompt] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ConnectionString] [image] NULL,
	[OriginalConnectionString] [image] NULL,
	[OriginalConnectStringExpressionBased] [bit] NULL,
	[UserName] [image] NULL,
	[Password] [image] NULL,
	[Flags] [int] NULL,
	[Version] [int] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[HistoryID] [uniqueidentifier] NOT NULL,
	[ReportID] [uniqueidentifier] NOT NULL,
	[SnapshotDataID] [uniqueidentifier] NOT NULL,
	[SnapshotDate] [datetime] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Keys](
	[MachineName] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InstallationID] [uniqueidentifier] NOT NULL,
	[InstanceName] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Client] [int] NOT NULL,
	[PublicKey] [image] NULL,
	[SymmetricKey] [image] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelDrill](
	[ModelDrillID] [uniqueidentifier] NOT NULL,
	[ModelID] [uniqueidentifier] NOT NULL,
	[ReportID] [uniqueidentifier] NOT NULL,
	[ModelItemID] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Type] [tinyint] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelItemPolicy](
	[ID] [uniqueidentifier] NOT NULL,
	[CatalogItemID] [uniqueidentifier] NOT NULL,
	[ModelItemID] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PolicyID] [uniqueidentifier] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelPerspective](
	[ID] [uniqueidentifier] NOT NULL,
	[ModelID] [uniqueidentifier] NOT NULL,
	[PerspectiveID] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PerspectiveName] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PerspectiveDescription] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[NotificationID] [uniqueidentifier] NOT NULL,
	[SubscriptionID] [uniqueidentifier] NOT NULL,
	[ActivationID] [uniqueidentifier] NULL,
	[ReportID] [uniqueidentifier] NOT NULL,
	[SnapShotDate] [datetime] NULL,
	[ExtensionSettings] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Locale] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Parameters] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProcessStart] [datetime] NULL,
	[NotificationEntered] [datetime] NOT NULL,
	[ProcessAfter] [datetime] NULL,
	[Attempt] [int] NULL,
	[SubscriptionLastRunTime] [datetime] NOT NULL,
	[DeliveryExtension] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SubscriptionOwnerID] [uniqueidentifier] NOT NULL,
	[IsDataDriven] [bit] NOT NULL,
	[BatchID] [uniqueidentifier] NULL,
	[ProcessHeartbeat] [datetime] NULL,
	[Version] [int] NOT NULL,
	[ReportZone] [int] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policies](
	[PolicyID] [uniqueidentifier] NOT NULL,
	[PolicyFlag] [tinyint] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PolicyUserRole](
	[ID] [uniqueidentifier] NOT NULL,
	[RoleID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[PolicyID] [uniqueidentifier] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportSchedule](
	[ScheduleID] [uniqueidentifier] NOT NULL,
	[ReportID] [uniqueidentifier] NOT NULL,
	[SubscriptionID] [uniqueidentifier] NULL,
	[ReportAction] [int] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TaskMask] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RoleFlags] [tinyint] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RunningJobs](
	[JobID] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[ComputerName] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RequestName] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RequestPath] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Description] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Timeout] [int] NOT NULL,
	[JobAction] [smallint] NOT NULL,
	[JobType] [smallint] NOT NULL,
	[JobStatus] [smallint] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[Flags] [int] NOT NULL,
	[NextRunTime] [datetime] NULL,
	[LastRunTime] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[RecurrenceType] [int] NULL,
	[MinutesInterval] [int] NULL,
	[DaysInterval] [int] NULL,
	[WeeksInterval] [int] NULL,
	[DaysOfWeek] [int] NULL,
	[DaysOfMonth] [int] NULL,
	[Month] [int] NULL,
	[MonthlyWeek] [int] NULL,
	[State] [int] NULL,
	[LastRunStatus] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ScheduledRunTimeout] [int] NULL,
	[CreatedById] [uniqueidentifier] NOT NULL,
	[EventType] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EventData] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Type] [int] NOT NULL,
	[ConsistancyCheck] [datetime] NULL,
	[Path] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecData](
	[SecDataID] [uniqueidentifier] NOT NULL,
	[PolicyID] [uniqueidentifier] NOT NULL,
	[AuthType] [int] NOT NULL,
	[XmlDescription] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[NtSecDescPrimary] [image] NOT NULL,
	[NtSecDescSecondary] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Segment](
	[SegmentId] [uniqueidentifier] NOT NULL,
	[Content] [varbinary](max) NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SegmentedChunk](
	[ChunkId] [uniqueidentifier] NOT NULL,
	[SnapshotDataId] [uniqueidentifier] NOT NULL,
	[ChunkFlags] [tinyint] NOT NULL,
	[ChunkName] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ChunkType] [int] NOT NULL,
	[Version] [smallint] NOT NULL,
	[MimeType] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SegmentedChunkId] [bigint] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServerParametersInstance](
	[ServerParametersID] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ParentID] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Path] [nvarchar](425) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[Timeout] [int] NOT NULL,
	[Expiration] [datetime] NOT NULL,
	[ParametersValues] [image] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServerUpgradeHistory](
	[UpgradeID] [bigint] NOT NULL,
	[ServerVersion] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[User] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateTime] [datetime] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SnapshotData](
	[SnapshotDataID] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ParamsHash] [int] NULL,
	[QueryParams] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EffectiveParams] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DependsOnUser] [bit] NULL,
	[PermanentRefcount] [int] NOT NULL,
	[TransientRefcount] [int] NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[PageCount] [int] NULL,
	[HasDocMap] [bit] NULL,
	[PaginationMode] [smallint] NULL,
	[ProcessingFlags] [int] NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscriptions](
	[SubscriptionID] [uniqueidentifier] NOT NULL,
	[OwnerID] [uniqueidentifier] NOT NULL,
	[Report_OID] [uniqueidentifier] NOT NULL,
	[Locale] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[InactiveFlags] [int] NOT NULL,
	[ExtensionSettings] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ModifiedByID] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[Description] [nvarchar](512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastStatus] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EventType] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MatchData] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastRunTime] [datetime] NULL,
	[Parameters] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DataSettings] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DeliveryExtension] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Version] [int] NOT NULL,
	[ReportZone] [int] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionsBeingDeleted](
	[SubscriptionID] [uniqueidentifier] NOT NULL,
	[CreationDate] [datetime] NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TokenManagements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TokenType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ExpiresIn] [int] NOT NULL,
	[RefreshToken] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AspNetUserId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserId] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_TokenManagements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UniqueURLs](
	[Id] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[URL] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VaildTo] [datetime] NOT NULL,
	[Valid] [bit] NOT NULL,
	[EntryId] [int] NOT NULL,
 CONSTRAINT [PK_UniqueURLs] PRIMARY KEY CLUSTERED 
(
	[EntryId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UpgradeInfo](
	[Item] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Status] [nvarchar](512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userdatas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Steps] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MinutesAsleep] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateStamp] [datetime] NOT NULL,
	[Water] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Distance] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MinutesSedentary] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MinutesVeryActive] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AwakeningsCount] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TimeEnteredBed] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Weight] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MinutesAwake] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TimeInBed] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MinutesToFallAsleep] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MinutesAfterWakeup] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CaloriesIn] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CaloriesOut] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MinutesLightlyActive] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MinutesFairlyActive] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ActivityCalories] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BMI] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fat] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SleepEfficiency] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WakeUpFreshness] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Coffee] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CoffeeTime] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Alcohol] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Mood] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Stress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Tiredness] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Dream] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DigitalDev] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Light] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NapDuration] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NapTime] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SocialActivity] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DinnerTime] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AmbientTemp] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AmbientHumd] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExerciseTime] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BodyTemp] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Hormone] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FitbitData] [bit] NOT NULL,
	[DiaryData] [bit] NOT NULL,
	[AspNetUserId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Userdatas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserQuestions](
	[PresentInStudy] [bit] NOT NULL,
	[Question1] [bit] NULL,
	[Question2] [bit] NULL,
	[Question3] [bit] NULL,
	[Question4] [bit] NULL,
	[Question5] [bit] NULL,
	[Question6] [bit] NULL,
	[Question7] [bit] NULL,
	[Question8] [bit] NULL,
	[Question9] [bit] NULL,
	[Question10] [bit] NULL,
	[Question11] [bit] NULL,
	[Question12] [bit] NULL,
	[Question13] [bit] NULL,
	[Question14] [bit] NULL,
	[Question15] [bit] NULL,
	[Question16] [bit] NULL,
	[Question17] [bit] NULL,
	[Question18] [bit] NULL,
	[Question19] [bit] NULL,
	[Question20] [bit] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AspNetUserId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_UserQuestions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [uniqueidentifier] NOT NULL,
	[Sid] [varbinary](85) NULL,
	[UserType] [int] NOT NULL,
	[AuthType] [int] NOT NULL,
	[UserName] [nvarchar](260) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[Id] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Token] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TokenType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RequestTime] [datetime] NOT NULL,
	[ExpiresIn] [int] NOT NULL,
	[RefreshToken] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AspNetUserId] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_PADDING ON

GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
SET ANSI_PADDING ON

GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [IX_FK_AspNetUserUserdata] ON [dbo].[Userdatas]
(
	[AspNetUserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[TokenManagements]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokenManagement] FOREIGN KEY([AspNetUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[TokenManagements] CHECK CONSTRAINT [FK_AspNetUserTokenManagement]
GO
ALTER TABLE [dbo].[UserQuestions]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserUserdata] FOREIGN KEY([AspNetUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserQuestions] CHECK CONSTRAINT [FK_AspNetUserUserdata]
GO
