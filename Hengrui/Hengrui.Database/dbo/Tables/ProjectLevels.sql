CREATE TABLE [dbo].[ProjectLevels] (
    [ProjectId]   INT            NOT NULL,
    [Level]       INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Czy_Id]      INT            NULL,
    CONSTRAINT [PK_dbo.ProjectLevels] PRIMARY KEY CLUSTERED ([ProjectId] ASC),
    CONSTRAINT [FK_dbo.Emergencies_dbo.Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id]),
    CONSTRAINT [FK_dbo.Emergencies_dbo.Users_Czy_Id] FOREIGN KEY ([Czy_Id]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Czy_Id]
    ON [dbo].[ProjectLevels]([Czy_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectId]
    ON [dbo].[ProjectLevels]([ProjectId] ASC);

