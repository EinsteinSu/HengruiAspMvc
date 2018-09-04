CREATE TABLE [dbo].[Gcgks] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Xh]         INT            NOT NULL,
    [Dh]         NVARCHAR (300) NULL,
    [Jgxs]       NVARCHAR (100) NULL,
    [Jzcs]       NVARCHAR (20)  NULL,
    [Jzgd]       NVARCHAR (20)  NULL,
    [Nhdj]       NVARCHAR (20)  NULL,
    [Wxxfl]      NVARCHAR (20)  NULL,
    [Gcgk_Id]    INT            NULL,
    [Jzfl_Id]    INT            NULL,
    [Project_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Gcgks] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Gcgks_dbo.Gcgks_Gcgk_Id] FOREIGN KEY ([Gcgk_Id]) REFERENCES [dbo].[Gcgks] ([Id]),
    CONSTRAINT [FK_dbo.Gcgks_dbo.Jzfls_Jzfl_Id] FOREIGN KEY ([Jzfl_Id]) REFERENCES [dbo].[Jzfls] ([Id]),
    CONSTRAINT [FK_dbo.Gcgks_dbo.Projects_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Projects] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[Gcgks]([Project_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Jzfl_Id]
    ON [dbo].[Gcgks]([Jzfl_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Gcgk_Id]
    ON [dbo].[Gcgks]([Gcgk_Id] ASC);

