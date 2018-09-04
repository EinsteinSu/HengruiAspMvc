CREATE TABLE [dbo].[Views] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (20)  NULL,
    [Columns] NVARCHAR (200) NULL,
    [Groups]  NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.Views] PRIMARY KEY CLUSTERED ([Id] ASC)
);

