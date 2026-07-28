CREATE TABLE [dbo].[Pockets] (
    [Id]         BIGINT       IDENTITY (1, 1) NOT NULL,
    [PocketSize] NVARCHAR (3) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

