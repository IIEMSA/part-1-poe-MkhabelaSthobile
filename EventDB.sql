--Creating a Database

USE master
If EXISTS (SELECT * FROM sys.databases WHERE name = 'EventDB')
DROP DATABASE EventDB
CREATE DATABASE EventDB

USE EventDB

--TABLE CREATION
CREATE TABLE Venue_ 
(
	VenueID INT PRIMARY KEY NOT NULL, 
	VenueName VARCHAR (250) NOT NULL,
	Location VARCHAR (250) NOT NULL,
	Capacity INT NOT NULL,
	ImageURL text NOT NULL,
);


SELECT * FROM Venue_


CREATE TABLE Event
(
	EventID INT PRIMARY KEY NOT NULL,
	Venue_ID INT NOT NULL REFERENCES Venue_(VenueID),
	EventName VARCHAR (250) NOT NULL,
	EventDate date NOT NULL,
	Description VARCHAR (250) NOT NULL,
);


SELECT * FROM Event


CREATE TABLE Booking_
(
	BookingID INT PRIMARY KEY NOT NULL,
	Event_ID INT NOT NULL REFERENCES Event(EventID),
	Venue_ID INT NOT NULL REFERENCES Venue_(VenueID),
	BookingDate date NOT NULL,
	
);


SELECT * FROM Booking_



