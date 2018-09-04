CREATE TABLE [dbo].[CustomViews] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (20) NULL,
    [FilterId] INT           NOT NULL,
    [ViewId]   INT           NOT NULL,
    CONSTRAINT [PK_dbo.CustomViews] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.CustomViews_dbo.Filters_FilterId] FOREIGN KEY ([FilterId]) REFERENCES [dbo].[Filters] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.CustomViews_dbo.Views_ViewId] FOREIGN KEY ([ViewId]) REFERENCES [dbo].[Views] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ViewId]
    ON [dbo].[CustomViews]([ViewId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FilterId]
    ON [dbo].[CustomViews]([FilterId] ASC);

