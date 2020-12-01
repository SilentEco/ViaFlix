CREATE TABLE [dbo].[Sales] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Date]       DATETIME2 (7) NOT NULL,
    [CustomerId] INT           NULL,
    [MovieId]    INT           NULL,
    CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sales_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]),
    CONSTRAINT [FK_Sales_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movies] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Sales_CustomerId]
    ON [dbo].[Sales]([CustomerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Sales_MovieId]
    ON [dbo].[Sales]([MovieId] ASC);

