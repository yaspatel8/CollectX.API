CREATE TABLE [dbo].[USERS] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50)  NOT NULL,
    [LastName]    NVARCHAR (50)  NOT NULL,
    [Email]       NVARCHAR (100) NOT NULL,
    [Password]    NVARCHAR (MAX) NOT NULL,
    [PhoneNumber] NVARCHAR (15)  NULL,
    [Address]     NVARCHAR (MAX) NULL,
    [CreatedAt]   DATETIME       DEFAULT (getutcdate()) NULL,
    [CreatedBy]   BIGINT         NULL,
    [UpdatedAt]   DATETIME       NULL,
    [UpdatedBy]   BIGINT         NULL,
    [IsActive]    BIT            DEFAULT ((1)) NULL,
    [IsDeleted]   BIT            DEFAULT ((0)) NULL,
    [RoleId]      BIGINT         DEFAULT ((1)) NOT NULL,
    [ImagePath]   NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([RoleId]) REFERENCES [dbo].[roles] ([Id]),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([PhoneNumber] ASC)
);

