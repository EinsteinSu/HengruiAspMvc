CREATE TABLE [dbo].[Users] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (20)  NOT NULL,
    [Gender]          INT            NOT NULL,
    [Password]        NVARCHAR (MAX) NULL,
    [Type]            INT            NOT NULL,
    [BirthDate]       DATETIME       NULL,
    [Deleted]         BIT            NOT NULL,
    [DepartmentId]    INT            NULL,
    [Zy]              INT            NULL,
    [Roles]           NVARCHAR (50)  NULL,
    [Discriminator]   NVARCHAR (128) NOT NULL,
    [Contact_Name]    NVARCHAR (20)  NULL,
    [Contact_Phone]   NVARCHAR (20)  NULL,
    [Contact_Mobile]  NVARCHAR (20)  NULL,
    [Contact_WeiChat] NVARCHAR (50)  NULL,
    [Contact_QQ]      NVARCHAR (20)  NULL,
    [Contact_Email]   NVARCHAR (100) NULL,
    [Contact_Address] NVARCHAR (200) NULL,
    [OriginalId]      NVARCHAR (50)  NULL,
    [Szdw]            NVARCHAR (200) NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Users_dbo.Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_DepartmentId]
    ON [dbo].[Users]([DepartmentId] ASC);

