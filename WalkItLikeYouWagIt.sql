
CREATE TABLE Neighborhood (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(55) NOT NULL
);

CREATE TABLE Owner (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(55) NOT NULL,
	Address VARCHAR(255) NOT NULL,
	NeighborhoodId INTEGER NOT NULL,
	Phone VARCHAR(55) NOT NULL,
	CONSTRAINT FK_Owner_Neighborhood FOREIGN KEY(NeighborhoodId) REFERENCES Neighborhood(Id)
);

CREATE TABLE Dog (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(55) NOT NULL,
	OwnerId INTEGER NOT NULL,
	Breed VARCHAR(55) NOT NULL,
	Notes VARCHAR(255) NOT NULL,
	CONSTRAINT FK_Dog_Owner FOREIGN KEY(OwnerId) REFERENCES Owner(Id)
);

CREATE TABLE Walker (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(55) NOT NULL,
	NeighborhoodId INTEGER NOT NULL
	CONSTRAINT FK_Walker_Neighborhood FOREIGN KEY(NeighborhoodId) REFERENCES Neighborhood(Id)
);

CREATE TABLE Walk (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	Date datetime NOT NULL,
	Duration INTEGER NOT NULL,
	WalkerId INTEGER NOT NULL,
	DogId INTEGER NOT NULL,
	CONSTRAINT FK_Walk_Dog FOREIGN KEY(DogId) REFERENCES Dog(Id),
	CONSTRAINT FK_Walk_Walker FOREIGN KEY(WalkerId) REFERENCES Walker(Id),
);


INSERT INTO Neighborhood(Name) VALUES('Wedgewood Houston');
INSERT INTO Neighborhood(Name) VALUES('East Nashville');
INSERT INTO Neighborhood(Name) VALUES('Hillsboro-West End');
INSERT INTO Neighborhood(Name) VALUES('12 South');

INSERT INTO Owner(Name, Address, NeighborhoodId, Phone) VALUES();
INSERT INTO Owner(Name, Address, NeighborhoodId, Phone) VALUES();
INSERT INTO Owner(Name, Address, NeighborhoodId, Phone) VALUES();
INSERT INTO Owner(Name, Address, NeighborhoodId, Phone) VALUES();
INSERT INTO Owner(Name, Address, NeighborhoodId, Phone) VALUES();
INSERT INTO Owner(Name, Address, NeighborhoodId, Phone) VALUES();

INSERT INTO Dog(Name, OwnerId, Breed, Notes) VALUES();
INSERT INTO Dog(Name, OwnerId, Breed, Notes) VALUES();
INSERT INTO Dog(Name, OwnerId, Breed, Notes) VALUES();
INSERT INTO Dog(Name, OwnerId, Breed, Notes) VALUES();
INSERT INTO Dog(Name, OwnerId, Breed, Notes) VALUES();
INSERT INTO Dog(Name, OwnerId, Breed, Notes) VALUES();
INSERT INTO Dog(Name, OwnerId, Breed, Notes) VALUES();
INSERT INTO Dog(Name, OwnerId, Breed, Notes) VALUES();

INSERT INTO Walker(Name, NeighborhoodId) VALUES();
INSERT INTO Walker(Name, NeighborhoodId) VALUES();
INSERT INTO Walker(Name, NeighborhoodId) VALUES();
INSERT INTO Walker(Name, NeighborhoodId) VALUES();

INSERT INTO Walk(Date, Duration, WalkerId, DogId);
INSERT INTO Walk(Date, Duration, WalkerId, DogId);
INSERT INTO Walk(Date, Duration, WalkerId, DogId);
INSERT INTO Walk(Date, Duration, WalkerId, DogId);
INSERT INTO Walk(Date, Duration, WalkerId, DogId);
INSERT INTO Walk(Date, Duration, WalkerId, DogId);
