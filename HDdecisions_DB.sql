CREATE DATABASE HDdecisions_DB;

USE [HDdecisions_DB]
GO

/****** Object: Table [dbo].[AuditReportDetails] Script Date: 17-07-2020 17:44:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AuditReportDetails] (
    [Id]             INT      IDENTITY (1, 1) NOT NULL,
    [PersonalInfoId] INT      NOT NULL,
    [BankDetails]    INT      NOT NULL,
    [CaptureDate]    DATETIME NOT NULL
);
/****** Object: Table [dbo].[BankDetails] Script Date: 17-07-2020 17:44:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BankDetails] (
    [Id]                   INT    IDENTITY (1, 1)    NOT NULL,
    [BankName]             NCHAR (50) NULL,
    [CreditcardType]       NCHAR (50) NULL,
    [AnnualPercentageRate] FLOAT (53) NULL
);
/****** Object: Table [dbo].[PersonalInfo] Script Date: 17-07-2020 17:45:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonalInfo] (
    [Id]           INT        IDENTITY (1, 1) NOT NULL,
    [FirstName]    NCHAR (50) NULL,
    [LastName]     NCHAR (50) NULL,
    [DOB]          DATE   NULL,
    [AnnualIncome] FLOAT (53) NULL,
    [BankId]       INT        NULL,
    [Age]          INT        NULL,
    [Lastupdated]  DATETIME   NOT NULL
);

/****** Object: SqlProcedure [dbo].[GetAllApplicantInformation] Script Date: 17-07-2020 17:46:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[GetAllApplicantInformation];


GO
-- =============================================  
-- Author:      Sudhan Radhakrishnan  
-- Create date: 18-July-2021  
-- Description: Get All Applicant Information  
-- ============================================= 

CREATE PROCEDURE GetAllApplicantInformation  
AS
BEGIN
SELECT 
    P.FirstName + ' ' + P.LastName AS FullName,   
    P.[AnnualIncome] as AnnualIncome,
	CASE WHEN B.[BankName] = 'NoBank' 
            THEN 'Age is under 18' 
            ELSE B.[BankName] 
       END AS BankDetails,  
	CASE WHEN P.[Age] IS NULL 
            THEN '100' 
            ELSE P.[Age] 
       END AS Age,	
    P.[Lastupdated] as AttemptDate
	FROM [dbo].[PersonalInfo] P
     INNER JOIN [dbo].[AuditReportDetails] A ON A.[PersonalInfoId] = P.[Id]
	 INNER JOIN [dbo].[BankDetails] B ON B.[Id] = A.[BankDetails]
WHERE P.BankId IS NOT NULL;
END

/****** Object: SqlProcedure [dbo].[InsertAuditReportDetails]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[InsertAuditReportDetails];


GO


-- =============================================  
-- Author:      Sudhan Radhakrishnan  
-- Create date: 18-July-2021  
-- Description: Insert Audit Report Details  
-- =============================================  
Create PROCEDURE InsertAuditReportDetails 
    @PersonalInfoId int,
    @BankDetails int,    
	@Identity int OUT  
As
BEGIN
  --This means the record isn't in AuditReportDetails table already, let's go ahead and add it
  Insert into AuditReportDetails (PersonalInfoId,BankDetails,CaptureDate)   
				   Values (@PersonalInfoId,@BankDetails,GETDATE())  
		  SET @Identity = SCOPE_IDENTITY()
END


/****** Object: SqlProcedure [dbo].[InsertPersonalInfo] Script Date: 17-07-2020 17:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[InsertPersonalInfo];


GO


-- =============================================  
-- Author:      Sudhan Radhakrishnan  
-- Create date: 18-July-2021  
-- Description: To add a new member  in PersonalInfo table 
-- =============================================  
CREATE PROCEDURE InsertPersonalInfo  
    @FirstName varchar(max),
    @LastName varchar(max),
    @DOB DATE,  
	@Age int,	
    @AnnualIncome Float,
	@BankId int,
	@Identity int OUT
  
AS
IF EXISTS (SELECT * FROM PersonalInfo WHERE FirstName =  @FirstName and  LastName = @LastName and DOB = @DOB and AnnualIncome = @AnnualIncome)
BEGIN
  --This means record  exists duplicate
  SET @Identity = -1
END
ELSE
BEGIN
  --This means the record isn't in Table already, let's go ahead and add it
  Insert into PersonalInfo (FirstName,LastName,DOB,AnnualIncome,BankId,Lastupdated,Age)   
				   Values (@FirstName,@LastName,@DOB,@AnnualIncome,@BankId,GETDATE(),@Age)  
		  SET @Identity = SCOPE_IDENTITY()
END

--**************************************** INSERT value into BankDetails**************************************

GO
INSERT INTO [dbo].[BankDetails] (
    [BankName],
    [CreditcardType],
    [AnnualPercentageRate]
)
VALUES
    (
        'NoBank',
       'Under18',
        0
    ),
    (
        'Barclay',
       'BarclayCard',
        10
    ),
    (
        'Vanquis',
        'VanquisVisa',
        20
    );




