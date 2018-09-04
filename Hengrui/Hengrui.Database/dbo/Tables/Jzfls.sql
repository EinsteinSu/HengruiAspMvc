CREATE TABLE [dbo].[Jzfls] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [PId]         INT            NOT NULL,
    [Name]        NVARCHAR (20)  NULL,
    [DisplayName] NVARCHAR (100) NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Jzfls] PRIMARY KEY CLUSTERED ([Id] ASC)
);

