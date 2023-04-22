IF DB_ID ( 'BigBankDB') IS NOT NULL
BEGIN 
SELECT 'Warning: The data base is already created' AS 'Message'
END 
ELSE
BEGIN
	CREATE DATABASE BigBankDB
END	
IF OBJECT_ID('UsersLegal','U') IS NOT NULL
	DROP TABLE UsersLegal
GO
CREATE TABLE UsersLegal
	( userID uniqueidentifier DEFAULT NEWID() NOT NULL,
	  FirstName nvarchar(64) NOT NULL,
	  LastName nvarchar(64) NOT NULL,
	  personalCode varchar(13) NOT NULL, 
	  birthDate date NOT NULL,
	  County nvarchar(64) NOT NULL,
	  City nvarchar(64) NOT NULL,
	  HomeAddress nvarchar(64) NOT NULL,
	  mail varchar(64) NOT NULL,  
	  phone varchar(10) NOT NULL,

	  [password] nvarchar(100) NOT NULL,



	  CONSTRAINT PK_Users PRIMARY KEY (userID),
	  CONSTRAINT UC_PCode UNIQUE (personalCode),
	  CONSTRAINT UC_MailLegal UNIQUE (mail),
	  CONSTRAINT CK_MailLegal CHECK (mail LIKE '%_@__%.__%')
	  )

IF OBJECT_ID('CAENs','U') IS NOT NULL
	DROP TABLE CAENs
GO
CREATE TABLE CAENs
	(
			id int PRIMARY KEY NOT NULL,
			aDescription nvarchar(64) NOT NULL

	)

IF OBJECT_ID('UsersJuridical','U') IS NOT NULL
	DROP TABLE UsersJuridical
GO
CREATE TABLE UsersJuridical
	(
		userID uniqueidentifier   DEFAULT NEWID() NOT NULL,
		CompanyName nvarchar(64) NOT NULL UNIQUE,
		RegisterCode varchar(64) NOT NULL UNIQUE,   
		County nvarchar(64) NOT NULL,
		City nvarchar(64) NOT NULL,
		OfficeAddress nvarchar(64) NOT NULL,
		mail varchar(64) NOT NULL UNIQUE,  
	    phone varchar(10) NOT NULL UNIQUE,
		CAEN int NOT NULL		--foreign key

		[password] nvarchar(100) NOT NULL,

		CONSTRAINT PK_JUsers PRIMARY KEY (userID),
		CONSTRAINT CK_Mail CHECK (mail LIKE '%_@__%.__%'),
		CONSTRAINT FK_CAEN FOREIGN KEY(CAEN)
		REFERENCES CAENs(id)
	)


IF OBJECT_ID('Currencies','U') IS NOT NULL
	DROP TABLE Currencies
CREATE TABLE Currencies
	(
		ID int IDENTITY(1,1) PRIMARY KEY,
		abbrev varchar(16) NOT NULL
	)
IF OBJECT_ID('CurrentAccount','U') IS NOT NULL 
	DROP TABLE CurrentAccount
GO
CREATE TABLE CurrentAccount
	(
		IBAN varchar(64) NOT NULL PRIMARY KEY,
		UserID uniqueidentifier NULL,
		CompanyID uniqueidentifier NULL,
		currency int NOT NULL,

		CONSTRAINT FK_User FOREIGN KEY (UserID)
		REFERENCES UsersLegal(userID),
		CONSTRAINT FK_Company FOREIGN KEY (CompanyID)
		REFERENCES UsersJuridical(userID),
		CONSTRAINT FK_Currency FOREIGN KEY(currency)
		REFERENCES Currencies(ID)

	)


IF OBJECT_ID('DepositTypes','U') IS NOT NULL
	DROP TABLE DepositTypes
GO
CREATE TABLE DepositTypes
	(
		ID int NOT NULL PRIMARY KEY,
		dName nvarchar(64) NOT NULL,
		noMonths int NOT NULL,
		intRate decimal(5,4) NOT NULL
	)


IF OBJECT_ID('Deposits','U') IS NOT NULL
	DROP TABLE Deposits
GO
CREATE TABLE Deposits
	(
		IBAN varchar(64) NOT NULL PRIMARY KEY,
		UserID uniqueidentifier NULL FOREIGN KEY
		REFERENCES UsersLegal(userID),
		CompanyID uniqueidentifier NULL FOREIGN KEY
		REFERENCES UsersJuridical(userID),
		currency INT NOT NULL FOREIGN KEY
		REFERENCES Currencies(ID),
		depositType INT NOT NULL FOREIGN KEY
		REFERENCES DepositTypes(ID),
		creationDate date NOT NULL


	)

IF OBJECT_ID('Transactions','U') IS NOT NULL
	DROP TABLE Transactions
GO
	CREATE TABLE Transactions
	(
		ID int NOT NULL PRIMARY KEY,
		srcIBAN varchar(64) NOT NULL FOREIGN KEY
		REFERENCES CurrentAccount(IBAN),
		destIBAN varchar(64) NOT NULL FOREIGN KEY
		REFERENCES CurrentAccount(IBAN),
		amount money NOT NULL,
		currency int NOT NULL FOREIGN KEY
		REFERENCES currencies(ID),
		tranDate date NOT NULL,
		tDescription nvarchar(64),
	

	)

IF OBJECT_ID('Loans','U') IS NOT NULL
	DROP TABLE Loans
GO
	CREATE TABLE Loans
	(
		ID int NOT NULL PRIMARY KEY,
		accountIBAN varchar(64) NOT NULL FOREIGN KEY
		REFERENCES CurrentAccount(IBAN),
		loanDate date NOT NULL,
		noMonths int NOT NULL,
		intRate decimal(5,4) NOT NULL,
		amount money NOT NULL,
		currency int NOT NULL FOREIGN KEY
		REFERENCES Currencies(ID)


	)

IF OBJECT_ID('LoanPays','U') IS NOT NULL
	DROP TABLE LoanPays
GO
	CREATE TABLE LoanPays
	(
		ID int NOT NULL PRIMARY KEY,
		loanID int NOT NULL FOREIGN KEY
		REFERENCES Loans(id),
		payIBAN varchar(64) NOT NULL FOREIGN KEY
		REFERENCES CurrentAccount(IBAN),
		pAmount money NOT NULL,
		payDate date NOT NULL

	)

IF OBJECT_ID('TR_IDs','TR') IS NOT NULL
	DROP TRIGGER TR_IDs
GO
CREATE TRIGGER TR_IDs
ON CurrentAccount 
AFTER INSERT,UPDATE
AS 
BEGIN
IF @@ROWCOUNT=0 RETURN;
SET NOCOUNT ON;
IF EXISTS( SELECT * 
		   FROM Inserted
		   WHERE (UserID IS NULL AND CompanyID IS NULL)
			OR (UserID IS NOT NULL AND CompanyID IS NOT NULL)
			)
BEGIN
	THROW 5000,'One of the fields userid and companyid must be null!!',0;
END
END

