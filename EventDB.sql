--Creating a Database

USE master
If EXISTS (SELECT * FROM sys.databases WHERE name = 'EventDB')
DROP DATABASE EventDB
CREATE DATABASE EventDB

USE EventDB

--TABLE CREATION
CREATE TABLE Venue 
(
	VenueID INT PRIMARY KEY NOT NULL, 
	VenueName VARCHAR (250) NOT NULL,
	Location VARCHAR (250) NOT NULL,
	Capacity INT NOT NULL,
	ImageURL text NOT NULL,
);


SELECT * FROM Venue


CREATE TABLE Event_
(
	EventID INT PRIMARY KEY NOT NULL,
	Venue_ID INT NOT NULL REFERENCES Venue(VenueID),
	EventName VARCHAR (250) NOT NULL,
	EventDate date NOT NULL,
	Description VARCHAR (250) NOT NULL,
);


SELECT * FROM Event_


CREATE TABLE Booking
(
	BookingID INT PRIMARY KEY NOT NULL,
	Event_ID INT NOT NULL REFERENCES Event_(EventID),
	Venue_ID INT NOT NULL REFERENCES Venue(VenueID),
	BookingDate date NOT NULL,
	
);


SELECT * FROM Booking



