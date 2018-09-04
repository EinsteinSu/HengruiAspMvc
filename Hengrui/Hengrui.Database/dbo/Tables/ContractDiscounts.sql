CREATE TABLE [dbo].[ContractDiscounts] (
    [ProjectId]   INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.ContractDiscounts] PRIMARY KEY CLUSTERED ([ProjectId] ASC),
    CONSTRAINT [FK_dbo.ContractDiscounts_dbo.Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectId]
    ON [dbo].[ContractDiscounts]([ProjectId] ASC);

