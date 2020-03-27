
CREATE TABLE Neighborhood (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	NName VARCHAR(55) NOT NULL
);

CREATE TABLE Owner (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	OName VARCHAR(55) NOT NULL,
	Address VARCHAR(255) NOT NULL,
	NeighborhoodId INTEGER NOT NULL,
	Phone VARCHAR(55) NOT NULL,
	CONSTRAINT FK_Owner_Neighborhood FOREIGN KEY(NeighborhoodId) REFERENCES Neighborhood(Id)
);

CREATE TABLE Dog (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	DName VARCHAR(55) NOT NULL,
	OwnerId INTEGER NOT NULL,
	Breed VARCHAR(55) NOT NULL,
	Notes VARCHAR(255) NOT NULL,
	CONSTRAINT FK_Dog_Owner FOREIGN KEY(OwnerId) REFERENCES Owner(Id)
);

CREATE TABLE Walker (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	WName VARCHAR(55) NOT NULL,
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


INSERT INTO Neighborhood(NName) VALUES('Wedgewood Houston');
INSERT INTO Neighborhood(NName) VALUES('East Nashville');
INSERT INTO Neighborhood(NName) VALUES('Hillsboro-West End');
INSERT INTO Neighborhood(NName) VALUES('12 South');

INSERT INTO Owner(OName, Address, NeighborhoodId, Phone) VALUES('Mary', '1506 Elmwood Ave', 4, '585-683-9345');
INSERT INTO Owner(OName, Address, NeighborhoodId, Phone) VALUES('Lizzie', '2706 Acklen Ave', 3, '954-655-5963');
INSERT INTO Owner(OName, Address, NeighborhoodId, Phone) VALUES('Jaci', '510 Woodland St', 2, '615-668-2997');
INSERT INTO Owner(OName, Address, NeighborhoodId, Phone) VALUES('Bryan', '429B Houston St', 1, '281-804-1531');
INSERT INTO Owner(OName, Address, NeighborhoodId, Phone) VALUES('Sam', '2807 22nd Ave S', 3, '615-972-8548');
INSERT INTO Owner(OName, Address, NeighborhoodId, Phone) VALUES('Julie', '2011 Belmont Blvd', 4, '317-224-3281');

INSERT INTO Dog(DName, OwnerId, Breed, Notes) VALUES('Link', 6, 'Jack Russell Terrier', 'Very nervous');
INSERT INTO Dog(DName, OwnerId, Breed, Notes) VALUES('Lady', 5, 'Corgi', 'Loves hotdogs');
INSERT INTO Dog(DName, OwnerId, Breed, Notes) VALUES('Bella', 5, 'Hound Mix', 'High energy');
INSERT INTO Dog(DName, OwnerId, Breed, Notes) VALUES('Genny', 4, 'Aussie Doodle', 'Chases squirrels');
INSERT INTO Dog(DName, OwnerId, Breed, Notes) VALUES('Scout', 3, 'Mini Dachsund', 'Short walks only');
INSERT INTO Dog(DName, OwnerId, Breed, Notes) VALUES('Chloe', 2, 'Cocker Spaniel', 'Poops on sidewalks');
INSERT INTO Dog(DName, OwnerId, Breed, Notes) VALUES('Shane', 2, 'German Shepard', 'No dog parks');
INSERT INTO Dog(DName, OwnerId, Breed, Notes) VALUES('Stitch', 1, 'Labrador Retriever', 'Very affectionate');

INSERT INTO Walker(WName, NeighborhoodId) VALUES('Johnny', 1);
INSERT INTO Walker(WName, NeighborhoodId) VALUES('Sally', 3);
INSERT INTO Walker(WName, NeighborhoodId) VALUES('Amber', 2);
INSERT INTO Walker(WName, NeighborhoodId) VALUES('Anthony', 4);

INSERT INTO Walk(Date, Duration, WalkerId, DogId) VALUES('10/05/2019', 30, 1, 8);
INSERT INTO Walk(Date, Duration, WalkerId, DogId) VALUES('10/06/2019', 25, 2, 7);
INSERT INTO Walk(Date, Duration, WalkerId, DogId) VALUES('10/06/2019', 25, 3, 6) ;
INSERT INTO Walk(Date, Duration, WalkerId, DogId) VALUES('10/07/2019', 34, 4, 5);
INSERT INTO Walk(Date, Duration, WalkerId, DogId) VALUES('10/08/2019', 45, 1, 4);
INSERT INTO Walk(Date, Duration, WalkerId, DogId) VALUES('10/08/2019', 35, 3, 3);

