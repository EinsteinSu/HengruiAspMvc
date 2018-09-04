CREATE TABLE [dbo].[Htbhs] (
    [ProjectId] INT NOT NULL,
    [Year]      INT NOT NULL,
    [Number]    INT NOT NULL,
    CONSTRAINT [PK_dbo.Htbhs] PRIMARY KEY CLUSTERED ([ProjectId] ASC),
    CONSTRAINT [FK_dbo.Htbhs_dbo.Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectId]
    ON [dbo].[Htbhs]([ProjectId] ASC);

