
DROP TABLE Item
drop table PromotionGroup
drop table itemgroup;
drop table Guest;

Guest


CREATE TABLE Item(
	ItemID INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Price MONEY NOT NULL,
)


create table PromotionGroup(
	PromotionGroupID INT IDENTITY(1,1) PRIMARY KEY,
	GroupName NVARCHAR(40), 
	CreatedDate DATETIME,
)


create table ItemGroup(
	ItemGroupID INT IDENTITY(1,1) PRIMARY KEY,
	ItemID INT FOREIGN KEY REFERENCES Item(itemID),
	PromotionGroupID INT FOREIGN KEY REFERENCES PromotionGroup(PromotionGroupID)
)


create table Guest(
	guestID INT IDENTITY(1,1) PRIMARY KEY,
	groupID INT,
	userEmail NVARCHAR(80),
	firstName NVARCHAR(80),
	lastName NVARCHAR(80),
	signedInDate DATETIME,
	expiringDate DATETIME,

)