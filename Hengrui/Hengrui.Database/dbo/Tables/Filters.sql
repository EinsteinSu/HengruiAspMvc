CREATE TABLE [dbo].[Filters] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (20)  NULL,
    [Script]     NVARCHAR (100) NULL,
    [Parameters] NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.Filters] PRIMARY KEY CLUSTERED ([Id] ASC)
);

