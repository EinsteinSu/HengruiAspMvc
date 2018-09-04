CREATE TABLE [dbo].[Papers] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [Zy]         INT NOT NULL,
    [Count]      INT NOT NULL,
    [BackCount]  INT NOT NULL,
    [HftCount]   INT NOT NULL,
    [Czy_Id]     INT NULL,
    [Project_Id] INT NULL,
    CONSTRAINT [PK_dbo.Papers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Papers_dbo.Projects_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Projects] ([Id]),
    CONSTRAINT [FK_dbo.Papers_dbo.Users_Czy_Id] FOREIGN KEY ([Czy_Id]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[Papers]([Project_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Czy_Id]
    ON [dbo].[Papers]([Czy_Id] ASC);

