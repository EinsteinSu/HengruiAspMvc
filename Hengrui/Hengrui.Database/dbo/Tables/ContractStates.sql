﻿CREATE TABLE [dbo].[ContractStates] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Status]      INT           NOT NULL,
    [Czsj]        DATETIME      NULL,
    [Version]     ROWVERSION    NOT NULL,
    [Description] NVARCHAR (50) NULL,
    [Czy_Id]      INT           NULL,
    [Project_Id]  INT           NULL,
    CONSTRAINT [PK_dbo.ContractStates] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ContractStatus_dbo.Projects_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Projects] ([Id]),
    CONSTRAINT [FK_dbo.ContractStatus_dbo.Users_Czy_Id] FOREIGN KEY ([Czy_Id]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[ContractStates]([Project_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Czy_Id]
    ON [dbo].[ContractStates]([Czy_Id] ASC);

