CREATE TABLE [dbo].[Sjdws] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (20)  NULL,
    [Address]    NVARCHAR (200) NULL,
    [Sjzz]       NVARCHAR (200) NULL,
    [Project_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Sjdws] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Sjdws_dbo.Projects_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Projects] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[Sjdws]([Project_Id] ASC);

