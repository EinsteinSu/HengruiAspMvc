CREATE TABLE [dbo].[Departments] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (30)  NOT NULL,
    [Contact_Name]    NVARCHAR (20)  NULL,
    [Contact_Phone]   NVARCHAR (20)  NULL,
    [Contact_Mobile]  NVARCHAR (20)  NULL,
    [Contact_WeiChat] NVARCHAR (50)  NULL,
    [Contact_QQ]      NVARCHAR (20)  NULL,
    [Contact_Email]   NVARCHAR (100) NULL,
    [Contact_Address] NVARCHAR (200) NULL,
    CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED ([Id] ASC)
);

