CREATE TABLE [dbo].[Cities] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Cities] PRIMARY KEY CLUSTERED ([Id] ASC)
);

