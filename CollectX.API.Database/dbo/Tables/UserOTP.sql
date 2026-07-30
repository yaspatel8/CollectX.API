CREATE TABLE [dbo].[UserOTP] (
    [OTPId]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [UserId]         BIGINT        NOT NULL,
    [OTPCode]        NVARCHAR (10) NOT NULL,
    [ExpirationTime] DATETIME      NOT NULL,
    [IsUsed]         BIT           DEFAULT ((0)) NOT NULL,
    [usedon]         DATETIME      NULL,
    [CreatedAt]      DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([OTPId] ASC),
    CONSTRAINT [FK_UserOTP_UserS] FOREIGN KEY ([UserId]) REFERENCES [dbo].[USERS] ([Id])
);

