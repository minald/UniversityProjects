--DROP TABLE Games; DROP TABLE TournamentPlayers; DROP TABLE Tournaments; DROP TABLE Players; 
/*
SELECT * FROM Players; 
SELECT * FROM Tournaments; 
SELECT * FROM TournamentPlayers; 
SELECT * FROM Games; 
*/

CREATE TABLE Players ( 
	Id NUMBER NOT NULL PRIMARY KEY, 
	LastName VARCHAR2(100) NOT NULL, 
	FirstName VARCHAR2(100) NOT NULL, 
	MiddleName VARCHAR2(100), 
	Rating NUMBER NOT NULL CHECK (Rating BETWEEN 1000 AND 4000), 
	BirthDate DATE NOT NULL CHECK (BirthDate > TO_DATE('01-01-1920', 'dd-mm-yyyy')), 
	ClubEntryDate DATE NOT NULL CHECK (ClubEntryDate > TO_DATE('01-01-2000', 'dd-mm-yyyy')), 
	AnnualMemberPayment VARCHAR2(5) NOT NULL CHECK (AnnualMemberPayment IN ('true', 'false')), 
	ClubMemberDiscount NUMBER NOT NULL CHECK (ClubMemberDiscount BETWEEN 0 AND 100) 
); 

CREATE TABLE Tournaments ( 
	Id NUMBER NOT NULL PRIMARY KEY, 
	Name VARCHAR2(100) NOT NULL UNIQUE, 
	StartDate DATE NOT NULL CHECK (StartDate > TO_DATE('01-01-1920', 'dd-mm-yyyy')), 
	EndDate DATE NOT NULL CHECK (EndDate > TO_DATE('01-01-1920', 'dd-mm-yyyy')), 
	RegistrationFee NUMBER, 
	TournamentSystem VARCHAR2(100) NOT NULL CHECK(TournamentSystem IN('One round-robin', 'Double round-robin', 'Swiss', 'Olympic', 'Match'))
); 

CREATE TABLE TournamentPlayers ( 
	Id NUMBER NOT NULL PRIMARY KEY, 
	TournamentId NUMBER NOT NULL, 
	PlayerId NUMBER NOT NULL, 
	Prize NUMBER,
	CONSTRAINT FK_TournamentPlayers_Tournaments FOREIGN KEY (TournamentId) REFERENCES Tournaments(Id), 
	CONSTRAINT FK_TournamentPlayers_Players FOREIGN KEY (PlayerId) REFERENCES Players(Id) 
); 

CREATE TABLE Games ( 
	Id NUMBER NOT NULL PRIMARY KEY, 
	TournamentId NUMBER NOT NULL, 
	GameDate DATE NOT NULL CHECK (GameDate > TO_DATE('01-01-1920', 'dd-mm-yyyy')), 
	WhitePlayerId NUMBER NOT NULL, 
	BlackPlayerId NUMBER NOT NULL, 
	Result VARCHAR2(10) NOT NULL CHECK (Result IN ('1-0', '0.5-0.5', '0-1', '+--', '--+', '0.5-0', '0-0.5', '0-0')), 
	Debute VARCHAR2(100) NOT NULL CHECK(Debute IN('Open Game', 'Four Knights Game', 'Philidor Defense', 'Kings Gambit', 'Center Game', 
		'Sicilian Defense', 'French Defense', 'Caro–Kann Defense', 'Queens Gambit', 'Modern Benoni', 'Catalan Opening', 'English Opening')), 
	Moves NUMBER NOT NULL CHECK (Moves < 6000), 
	CONSTRAINT FK_Games_Players_White FOREIGN KEY (WhitePlayerId) REFERENCES Players(Id), 
	CONSTRAINT FK_Games_Players_Black FOREIGN KEY (BlackPlayerId) REFERENCES Players(Id), 
	CONSTRAINT FK_Games_Tournaments FOREIGN KEY (TournamentId) REFERENCES Tournaments(Id) 
); 

INSERT INTO Players VALUES (1, 'Carlsen', 'Magnus', 'Sven Een', 2839, TO_DATE('30-11-1990', 'dd-mm-yyyy'), TO_DATE('02-01-2000', 'dd-mm-yyyy'), 'true', 0); 
INSERT INTO Players VALUES (2, 'Caruana', 'Fabiano', 'Luigi', 2827, TO_DATE('30-07-1992', 'dd-mm-yyyy'), TO_DATE('01-02-2000', 'dd-mm-yyyy'), 'true', 0); 
INSERT INTO Players VALUES (3, 'Mamedyarov', 'Shakhriyar', 'Gamid ogly', 2820, TO_DATE('12-04-1985', 'dd-mm-yyyy'), TO_DATE('01-03-2000', 'dd-mm-yyyy'), 'true', 0); 
INSERT INTO Players VALUES (4, 'Ding', 'Liren', null, 2804, TO_DATE('24-10-1992', 'dd-mm-yyyy'), TO_DATE('01-04-2000', 'dd-mm-yyyy'), 'true', 0); 
INSERT INTO Players VALUES (5, 'Vachier-Lagrave', 'Maxime', null, 2780, TO_DATE('21-10-1990', 'dd-mm-yyyy'), TO_DATE('01-05-2000', 'dd-mm-yyyy'), 'true', 10); 
INSERT INTO Players VALUES (6, 'Aronian', 'Levon', 'Grigorievich', 2780, TO_DATE('06-10-1982', 'dd-mm-yyyy'), TO_DATE('01-06-2000', 'dd-mm-yyyy'), 'true', 0); 
INSERT INTO Players VALUES (7, 'Giri', 'Anish', 'Kumar', 2780, TO_DATE('28-06-1994', 'dd-mm-yyyy'), TO_DATE('01-07-2000', 'dd-mm-yyyy'), 'true', 0); 
INSERT INTO Players VALUES (8, 'Kramnik', 'Vladimir', 'Borisovich', 2779, TO_DATE('25-06-1975', 'dd-mm-yyyy'), TO_DATE('01-08-2000', 'dd-mm-yyyy'), 'true', 20); 
INSERT INTO Players VALUES (9, 'So', 'Wesley', 'Barbasa', 2776, TO_DATE('09-11-1993', 'dd-mm-yyyy'), TO_DATE('01-09-2000', 'dd-mm-yyyy'), 'true', 0); 
INSERT INTO Players VALUES (10, 'Anand', 'Viswanathan', null, 2771, TO_DATE('11-12-1969', 'dd-mm-yyyy'), TO_DATE('01-10-2000', 'dd-mm-yyyy'), 'false', 0);
INSERT INTO Players VALUES (11, 'Grischuk', 'Alexander', 'Igorevich', 2769, TO_DATE('31-10-1983', 'dd-mm-yyyy'), TO_DATE('01-11-2000', 'dd-mm-yyyy'), 'true', 0); 
INSERT INTO Players VALUES (12, 'Yu', 'Yangyi', null, 2765, TO_DATE('08-06-1994', 'dd-mm-yyyy'), TO_DATE('01-12-2000', 'dd-mm-yyyy'), 'false', 0); 
INSERT INTO Players VALUES (13, 'Nakamura', 'Hikaru', null, 2763, TO_DATE('09-12-1987', 'dd-mm-yyyy'), TO_DATE('01-01-2001', 'dd-mm-yyyy'), 'true', 0); 
INSERT INTO Players VALUES (14, 'Karjakin', 'Sergey', 'Aleksandrovich', 2760, TO_DATE('12-01-1990', 'dd-mm-yyyy'), TO_DATE('01-02-2001', 'dd-mm-yyyy'), 'true', 0); 
INSERT INTO Players VALUES (15, 'Nepomniachtchi', 'Ian', 'Aleksandrovich', 2759, TO_DATE('14-07-1990', 'dd-mm-yyyy'), TO_DATE('01-03-2001', 'dd-mm-yyyy'), 'true', 0); 
INSERT INTO Players VALUES (16, 'Svidler', 'Peter', 'Veniaminovich', 2756, TO_DATE('17-06-1976', 'dd-mm-yyyy'), TO_DATE('01-04-2001', 'dd-mm-yyyy'), 'true', 0); 

INSERT INTO Tournaments VALUES (1, 'Candidates Tournament 2018', TO_DATE('10-03-2018', 'dd-mm-yyyy'), TO_DATE('28-03-2018', 'dd-mm-yyyy'), 0, 'Double round-robin'); 
INSERT INTO Tournaments VALUES (2, 'Chess World Cup 2017', TO_DATE('02-09-2017', 'dd-mm-yyyy'), TO_DATE('27-09-2017', 'dd-mm-yyyy'), 1000, 'Olympic'); 

INSERT INTO TournamentPlayers VALUES (1, 1, 2, 95000); 
INSERT INTO TournamentPlayers VALUES (2, 1, 3, 88000); 
INSERT INTO TournamentPlayers VALUES (3, 1, 4, 55000); 
INSERT INTO TournamentPlayers VALUES (4, 1, 6, 17000); 
INSERT INTO TournamentPlayers VALUES (5, 1, 8, 40000); 
INSERT INTO TournamentPlayers VALUES (6, 1, 9, 22000); 
INSERT INTO TournamentPlayers VALUES (7, 1, 11, 28000);
INSERT INTO TournamentPlayers VALUES (8, 1, 14, 75000);
INSERT INTO TournamentPlayers VALUES (9, 2, 1, 16000); 
INSERT INTO TournamentPlayers VALUES (10, 2, 2, 16000); 
INSERT INTO TournamentPlayers VALUES (11, 2, 3, 10000); 
INSERT INTO TournamentPlayers VALUES (12, 2, 4, 80000); 
INSERT INTO TournamentPlayers VALUES (13, 2, 5, 50000); 
INSERT INTO TournamentPlayers VALUES (14, 2, 6, 120000); 
INSERT INTO TournamentPlayers VALUES (15, 2, 7, 25000); 
INSERT INTO TournamentPlayers VALUES (16, 2, 8, 16000); 
INSERT INTO TournamentPlayers VALUES (17, 2, 9, 50000); 
INSERT INTO TournamentPlayers VALUES (18, 2, 10, 10000); 
INSERT INTO TournamentPlayers VALUES (19, 2, 11, 25000);
INSERT INTO TournamentPlayers VALUES (20, 2, 12, 10000);
INSERT INTO TournamentPlayers VALUES (21, 2, 13, 16000); 
INSERT INTO TournamentPlayers VALUES (22, 2, 14, 10000); 
INSERT INTO TournamentPlayers VALUES (23, 2, 15, 16000); 
INSERT INTO TournamentPlayers VALUES (24, 2, 16, 35000);  

INSERT INTO Games VALUES (1, 1, TO_DATE('10-03-2018', 'dd-mm-yyyy'), 8, 11, '1-0', 'English Opening', 62);
INSERT INTO Games VALUES (2, 1, TO_DATE('10-03-2018', 'dd-mm-yyyy'), 14, 3, '0-1', 'Catalan Opening', 59);
INSERT INTO Games VALUES (3, 1, TO_DATE('10-03-2018', 'dd-mm-yyyy'), 6, 4, '0.5-0.5', 'Catalan Opening', 26);
INSERT INTO Games VALUES (4, 1, TO_DATE('10-03-2018', 'dd-mm-yyyy'), 2, 9, '1-0', 'Four Knights Game', 57); 
INSERT INTO Games VALUES (5, 1, TO_DATE('11-03-2018', 'dd-mm-yyyy'), 11, 9, '1-0', 'Caro–Kann Defense', 32); 
INSERT INTO Games VALUES (6, 1, TO_DATE('11-03-2018', 'dd-mm-yyyy'), 4, 2, '0.5-0.5', 'French Defense', 78); 
INSERT INTO Games VALUES (7, 1, TO_DATE('11-03-2018', 'dd-mm-yyyy'), 3, 6, '0.5-0.5', 'Sicilian Defense', 29);
INSERT INTO Games VALUES (8, 1, TO_DATE('11-03-2018', 'dd-mm-yyyy'), 8, 14, '0.5-0.5', 'Modern Benoni', 81);
INSERT INTO Games VALUES (9, 1, TO_DATE('12-03-2018', 'dd-mm-yyyy'), 14, 11, '0.5-0.5', 'French Defense', 49);
INSERT INTO Games VALUES (10, 1, TO_DATE('12-03-2018', 'dd-mm-yyyy'), 6, 8, '0-1', 'Kings Gambit', 58);
INSERT INTO Games VALUES (11, 1, TO_DATE('12-03-2018', 'dd-mm-yyyy'), 2, 3, '0.5-0.5', 'Philidor Defense', 40);
INSERT INTO Games VALUES (12, 1, TO_DATE('12-03-2018', 'dd-mm-yyyy'), 9, 4, '0.5-0.5', 'English Opening', 22);
INSERT INTO Games VALUES (13, 1, TO_DATE('13-03-2018', 'dd-mm-yyyy'), 11, 4, '0.5-0.5', 'French Defense', 34);
INSERT INTO Games VALUES (14, 1, TO_DATE('13-03-2018', 'dd-mm-yyyy'), 3, 9, '0.5-0.5', 'Queens Gambit', 76);
INSERT INTO Games VALUES (15, 1, TO_DATE('13-03-2018', 'dd-mm-yyyy'), 8, 2, '0-1', 'Sicilian Defense', 58);
INSERT INTO Games VALUES (16, 1, TO_DATE('13-03-2018', 'dd-mm-yyyy'), 14, 6, '0-1', 'Modern Benoni', 68);
INSERT INTO Games VALUES (17, 1, TO_DATE('14-03-2018', 'dd-mm-yyyy'), 6, 11, '0.5-0.5', 'Center Game', 21);
INSERT INTO Games VALUES (18, 1, TO_DATE('14-03-2018', 'dd-mm-yyyy'), 2, 14, '0.5-0.5', 'Sicilian Defense', 46);
INSERT INTO Games VALUES (19, 1, TO_DATE('14-03-2018', 'dd-mm-yyyy'), 9, 8, '0.5-0.5', 'Kings Gambit', 31);
INSERT INTO Games VALUES (20, 1, TO_DATE('14-03-2018', 'dd-mm-yyyy'), 4, 3, '0.5-0.5', 'Queens Gambit', 38);
