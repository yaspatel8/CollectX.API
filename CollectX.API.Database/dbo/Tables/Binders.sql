CREATE TABLE [dbo].[Binders] (
    [Id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [BinderName] NVARCHAR (50) NOT NULL,
    [ColorId]    BIGINT        NOT NULL,
    [PocketId]   BIGINT        NOT NULL,
    [SetId]      BIGINT        NOT NULL,
    [Sku]        NVARCHAR (50) NOT NULL,
    [IsNFC]      BIT           NOT NULL,
    [CreatedAt]  DATETIME      DEFAULT (getutcdate()) NULL,
    [CreatedBy]  BIGINT        NULL,
    [UpdatedAt]  DATETIME      NULL,
    [UpdatedBy]  BIGINT        NULL,
    [IsActive]   BIT           DEFAULT ((1)) NULL,
    [IsDeleted]  BIT           DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([Id]),
    FOREIGN KEY ([PocketId]) REFERENCES [dbo].[Pockets] ([Id]),
    FOREIGN KEY ([SetId]) REFERENCES [dbo].[Sets] ([Id]),
    UNIQUE NONCLUSTERED ([Sku] ASC)
);

