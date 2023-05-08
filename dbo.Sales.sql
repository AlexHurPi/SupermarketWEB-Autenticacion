CREATE TABLE [dbo].[Sales] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Date]         NVARCHAR (MAX)  NOT NULL,
    [CustomerId]   NVARCHAR (MAX)  NULL,
    [ProductName]  NVARCHAR (MAX)  NULL,
    [Quantity]     INT             NOT NULL,
    [ProductPrice] NVARCHAR (MAX)  NULL,
    [TotalSale]    DECIMAL (15, 2) NOT NULL,
    [PayModeName]  NVARCHAR (MAX)  NULL,
    [Observation]  NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED ([Id] ASC)
);

