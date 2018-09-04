CREATE TABLE [dbo].[UserPhotoes] (
    [UserId] INT             NOT NULL,
    [Photo]  VARBINARY (MAX) NULL,
    CONSTRAINT [PK_dbo.UserPhotoes] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_dbo.UserPhotoes_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[UserPhotoes]([UserId] ASC);

