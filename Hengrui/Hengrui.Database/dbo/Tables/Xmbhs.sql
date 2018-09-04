CREATE TABLE [dbo].[Xmbhs] (
    [ProjectId] INT NOT NULL,
    [Year]      INT NOT NULL,
    [Number]    INT NOT NULL,
    CONSTRAINT [PK_dbo.Xmbhs] PRIMARY KEY CLUSTERED ([ProjectId] ASC),
    CONSTRAINT [FK_dbo.Xmbhs_dbo.Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectId]
    ON [dbo].[Xmbhs]([ProjectId] ASC);

