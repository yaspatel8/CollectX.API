CREATE TABLE [dbo].[Sets] (
    [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50)  NOT NULL,
    [Image]     NVARCHAR (MAX) NOT NULL,
    [CardSize]  NVARCHAR (7)   NOT NULL,
    [CreatedAt] DATETIME       DEFAULT (getutcdate()) NULL,
    [CreatedBy] BIGINT         NULL,
    [UpdatedAt] DATETIME       NULL,
    [UpdatedBy] BIGINT         NULL,
    [IsActive]  BIT            DEFAULT ((1)) NULL,
    [IsDeleted] BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

