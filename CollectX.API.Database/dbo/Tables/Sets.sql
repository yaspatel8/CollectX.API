CREATE TABLE [dbo].[Sets] (
    [Id]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50)  NOT NULL,
    [Image]    NVARCHAR (MAX) NOT NULL,
    [CardSize] NVARCHAR (7)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

