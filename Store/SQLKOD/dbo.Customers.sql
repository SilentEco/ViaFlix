CREATE TABLE [dbo].[Customers] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Username]    VARCHAR (50)   NOT NULL,
    [Password]    VARCHAR (50)   NOT NULL,
    [Phonenumber] VARCHAR(50)  NULL,
    [Email]       VARCHAR(MAX)  NOT NULL,
    [Adress]      VARCHAR(50)  NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

