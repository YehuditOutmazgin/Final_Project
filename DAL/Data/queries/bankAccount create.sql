-- Create BankAccount table
CREATE TABLE BankAccount (
    AccountID INT PRIMARY KEY NOT NULL,
    BranchNo NVARCHAR(50) NOT NULL,
    AccountNo NVARCHAR(50) NOT NULL,
    BillingAccount NVARCHAR(50) NOT NULL
);

-- Create Worker table
CREATE TABLE Worker (
    WorkerID INT PRIMARY KEY NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    AccountID INT NOT NULL,
    FOREIGN KEY (AccountID) REFERENCES BankAccount(AccountID)
);