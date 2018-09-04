CREATE TABLE [dbo].[Branches] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (20)  NOT NULL,
    [ContactUserId]   INT            NOT NULL,
    [Contact_Name]    NVARCHAR (20)  NULL,
    [Contact_Phone]   NVARCHAR (20)  NULL,
    [Contact_Mobile]  NVARCHAR (20)  NULL,
    [Contact_WeiChat] NVARCHAR (50)  NULL,
    [Contact_QQ]      NVARCHAR (20)  NULL,
    [Contact_Email]   NVARCHAR (100) NULL,
    [Contact_Address] NVARCHAR (200) NULL,
    [Acronym]         NVARCHAR (5)   NULL,
    [CityId]          INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.Branches] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Branches_dbo.Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[Cities] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Branches_dbo.Users_ContactUserId] FOREIGN KEY ([ContactUserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CityId]
    ON [dbo].[Branches]([CityId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ContactUserId]
    ON [dbo].[Branches]([ContactUserId] ASC);

