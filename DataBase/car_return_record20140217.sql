USE CarMgt;
GO

/****** Object:  Table [dbo].[car_return_record]    Script Date: 02/17/2014 14:59:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[car_return_record](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](26) NOT NULL,
	[Car_Number] [varchar](26) NOT NULL,
	[Source_Code] [varchar](26) NOT NULL,
	[Return_Time] [datetime] NOT NULL,
	[Mileage_End] [int] NOT NULL,
	[User_Time_Number] [int] NOT NULL,
	[Kilometer] [int] NOT NULL,
	[Cost] [decimal](18, 0) NOT NULL,
	[Car_Status] [int] NOT NULL,
 CONSTRAINT [PK_car_return_record] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用车时长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'car_return_record', @level2type=N'COLUMN',@level2name=N'User_Time_Number'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行驶公里' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'car_return_record', @level2type=N'COLUMN',@level2name=N'Kilometer'
GO

ALTER TABLE [dbo].[car_return_record] ADD  CONSTRAINT [DF_car_return_record_Mileage_End]  DEFAULT ((0)) FOR [Mileage_End]
GO

ALTER TABLE [dbo].[car_return_record] ADD  CONSTRAINT [DF_car_return_record_User_Time_Number]  DEFAULT ((0)) FOR [User_Time_Number]
GO

ALTER TABLE [dbo].[car_return_record] ADD  CONSTRAINT [DF_car_return_record_Killomit]  DEFAULT ((0)) FOR [Kilometer]
GO

ALTER TABLE [dbo].[car_return_record] ADD  CONSTRAINT [DF_car_return_record_Cost]  DEFAULT ((0)) FOR [Cost]
GO

ALTER TABLE [dbo].[car_return_record] ADD  CONSTRAINT [DF_car_return_record_Car_Status]  DEFAULT ((0)) FOR [Car_Status]
GO

