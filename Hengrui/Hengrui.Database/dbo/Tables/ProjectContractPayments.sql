CREATE TABLE [dbo].[ProjectContractPayments] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Time]               INT             NOT NULL,
    [Percent]            DECIMAL (18, 2) NOT NULL,
    [Money]              DECIMAL (18, 2) NOT NULL,
    [Fksm]               NVARCHAR (MAX)  NULL,
    [Contract_ProjectId] INT             NULL,
    CONSTRAINT [PK_dbo.ProjectContractPayments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ProjectContractPayments_dbo.Contracts_Contract_ProjectId] FOREIGN KEY ([Contract_ProjectId]) REFERENCES [dbo].[Contracts] ([ProjectId])
);


GO
CREATE NONCLUSTERED INDEX [IX_Contract_ProjectId]
    ON [dbo].[ProjectContractPayments]([Contract_ProjectId] ASC);

