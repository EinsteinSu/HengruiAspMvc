CREATE TABLE [dbo].[Regions] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [CityId] INT            NOT NULL,
    [Name]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Regions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Areas_dbo.Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[Cities] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CityId]
    ON [dbo].[Regions]([CityId] ASC);

