CREATE TABLE [dbo].[OwnerLogins] (
    [ProjectId] INT            NOT NULL,
    [UserName]  NVARCHAR (20)  NOT NULL,
    [Password]  NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_dbo.OwnerLogins] PRIMARY KEY CLUSTERED ([ProjectId] ASC),
    CONSTRAINT [FK_dbo.OwnerLogins_dbo.Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectId]
    ON [dbo].[OwnerLogins]([ProjectId] ASC);

