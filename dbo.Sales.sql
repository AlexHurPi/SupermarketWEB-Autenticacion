CREATE TABLE [dbo].[Sales] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Date]         NVARCHAR (MAX)  NULL,
    [CustomerId]   NVARCHAR (MAX)  NULL,
    [ProductName]  NVARCHAR (MAX)  NULL,
    [Quantity]     INT             NULL,
    [ProductPrice] DECIMAL (15, 2)  NULL,
    [TotalSale]    DECIMAL (15, 2) NULL,
    [PayModeName]  NVARCHAR (MAX)  NULL,
    [Observation]  NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED ([Id] ASC)
);

