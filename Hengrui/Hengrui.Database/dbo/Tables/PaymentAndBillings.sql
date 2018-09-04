CREATE TABLE [dbo].[PaymentAndBillings] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Payment_IsValid] BIT             NOT NULL,
    [Payment_Amount]  DECIMAL (18, 2) NOT NULL,
    [Payment_Date]    DATETIME        NULL,
    [Billing_IsValid] BIT             NOT NULL,
    [Billing_Amount]  DECIMAL (18, 2) NOT NULL,
    [Billing_Date]    DATETIME        NULL,
    [Project_Id]      INT             NULL,
    CONSTRAINT [PK_dbo.PaymentAndBillings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.PaymentAndBillings_dbo.Projects_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Projects] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[PaymentAndBillings]([Project_Id] ASC);

