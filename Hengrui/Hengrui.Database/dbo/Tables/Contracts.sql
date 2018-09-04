CREATE TABLE [dbo].[Contracts] (
    [ProjectId]          INT             NOT NULL,
    [Qx]                 INT             NOT NULL,
    [Htje]               DECIMAL (18, 2) NOT NULL,
    [Zk]                 NVARCHAR (50)   NULL,
    [Jmje]               DECIMAL (18, 2) NOT NULL,
    [Ysje]               DECIMAL (18, 2) NOT NULL,
    [Discount_ProjectId] INT             NULL,
    [Fr_Name]            NVARCHAR (20)   NULL,
    [Fr_Phone]           NVARCHAR (20)   NULL,
    [Fr_Mobile]          NVARCHAR (20)   NULL,
    [Fr_WeiChat]         NVARCHAR (50)   NULL,
    [Fr_QQ]              NVARCHAR (20)   NULL,
    [Fr_Email]           NVARCHAR (100)  NULL,
    [Fr_Address]         NVARCHAR (200)  NULL,
    CONSTRAINT [PK_dbo.Contracts] PRIMARY KEY CLUSTERED ([ProjectId] ASC),
    CONSTRAINT [FK_dbo.Contracts_dbo.ContractDiscounts_Discount_ProjectId] FOREIGN KEY ([Discount_ProjectId]) REFERENCES [dbo].[ContractDiscounts] ([ProjectId]),
    CONSTRAINT [FK_dbo.Contracts_dbo.Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Discount_ProjectId]
    ON [dbo].[Contracts]([Discount_ProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectId]
    ON [dbo].[Contracts]([ProjectId] ASC);

