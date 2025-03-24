CREATE TABLE [dbo].[BankAccount] (
    [AccountID]      INT           NOT NULL,
    [BranchNo]       NVARCHAR (50) NOT NULL,
    [AccountNo]      NVARCHAR (50) NOT NULL,
    [BillingAccount] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([AccountID] ASC)
);

