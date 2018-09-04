CREATE TABLE [dbo].[Projects] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (200) NOT NULL,
    [Xmlb]         INT            NOT NULL,
    [Tzlb]         INT            NOT NULL,
    [Jsdw]         NVARCHAR (200) NOT NULL,
    [Instance]     INT            NOT NULL,
    [CreateTime]   DATETIME       NOT NULL,
    [CreateUserId] INT            NOT NULL,
    [Paused]       BIT            NOT NULL,
    [Deleted]      BIT            NOT NULL,
    [Region_Id]    INT            NULL,
    [Lxr_Name]     NVARCHAR (20)  NULL,
    [Lxr_Phone]    NVARCHAR (20)  NULL,
    [Lxr_Mobile]   NVARCHAR (20)  NULL,
    [Lxr_WeiChat]  NVARCHAR (50)  NULL,
    [Lxr_QQ]       NVARCHAR (20)  NULL,
    [Lxr_Email]    NVARCHAR (100) NULL,
    [Lxr_Address]  NVARCHAR (200) NULL,
    [Wtr_Name]     NVARCHAR (20)  NULL,
    [Wtr_Phone]    NVARCHAR (20)  NULL,
    [Wtr_Mobile]   NVARCHAR (20)  NULL,
    [Wtr_WeiChat]  NVARCHAR (50)  NULL,
    [Wtr_QQ]       NVARCHAR (20)  NULL,
    [Wtr_Email]    NVARCHAR (100) NULL,
    [Wtr_Address]  NVARCHAR (200) NULL,
    CONSTRAINT [PK_dbo.Projects] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Projects_dbo.Areas_Area_Id] FOREIGN KEY ([Region_Id]) REFERENCES [dbo].[Regions] ([Id]),
    CONSTRAINT [FK_dbo.Projects_dbo.Users_CreateUserId] FOREIGN KEY ([CreateUserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Region_Id]
    ON [dbo].[Projects]([Region_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreateUserId]
    ON [dbo].[Projects]([CreateUserId] ASC);

