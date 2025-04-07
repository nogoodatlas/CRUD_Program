-- --------------------------------------------------------------------------------
-- Name: Bob Nields 
 
-- Abstract: FlyMe2theMoon
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbFlyMe2theMoon;     
SET NOCOUNT ON;  

-- --------------------------------------------------------------------------------
--						Problem #10
-- --------------------------------------------------------------------------------

-- Drop Table Statements
IF OBJECT_ID ('TPilotFlights')			IS NOT NULL DROP TABLE TPilotFlights
IF OBJECT_ID ('TAttendantFlights')		IS NOT NULL DROP TABLE TAttendantFlights
IF OBJECT_ID ('TFlightPassengers')		IS NOT NULL DROP TABLE TFlightPassengers
IF OBJECT_ID ('TMaintenanceMaintenanceWorkers')			IS NOT NULL DROP TABLE TMaintenanceMaintenanceWorkers

IF OBJECT_ID ('TPassengers')			IS NOT NULL DROP TABLE TPassengers
IF OBJECT_ID ('TPilots')				IS NOT NULL DROP TABLE TPilots
IF OBJECT_ID ('TAttendants')			IS NOT NULL DROP TABLE TAttendants
IF OBJECT_ID ('TMaintenanceWorkers')	IS NOT NULL DROP TABLE TMaintenanceWorkers

IF OBJECT_ID ('TFlights')				IS NOT NULL DROP TABLE TFlights
IF OBJECT_ID ('TMaintenances')			IS NOT NULL DROP TABLE TMaintenances
IF OBJECT_ID ('TPlanes')				IS NOT NULL DROP TABLE TPlanes
IF OBJECT_ID ('TPlaneTypes')			IS NOT NULL DROP TABLE TPlaneTypes
IF OBJECT_ID ('TPilotRoles')			IS NOT NULL DROP TABLE TPilotRoles
IF OBJECT_ID ('TAirports')				IS NOT NULL DROP TABLE TAirports
IF OBJECT_ID ('TStates')				IS NOT NULL DROP TABLE TStates

-- --------------------------------------------------------------------------------
--	Step #1 : Create table 
-- --------------------------------------------------------------------------------

CREATE TABLE TPassengers
(
	 intPassengerID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strAddress				VARCHAR(255)	NOT NULL
	,strCity				VARCHAR(255)	NOT NULL
	,intStateID				INTEGER			NOT NULL
	,strZip					VARCHAR(255)	NOT NULL
	,strPhoneNumber			VARCHAR(255)	NOT NULL
	,strEmail				VARCHAR(255)	NOT NULL
	,CONSTRAINT TPassengers_PK PRIMARY KEY ( intPassengerID )
)


CREATE TABLE TPilots
(
	 intPilotID				INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfLicense		DATETIME		NOT NULL
	,intPilotRoleID			INTEGER			NOT NULL

	,CONSTRAINT TPilots_PK PRIMARY KEY ( intPilotID )
)


CREATE TABLE TAttendants
(
	 intAttendantID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,CONSTRAINT TAttendants_PK PRIMARY KEY ( intAttendantID )
)


CREATE TABLE TMaintenanceWorkers
(
	 intMaintenanceWorkerID	INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfCertification	DATETIME		NOT NULL
	,CONSTRAINT TMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceWorkerID )
)


CREATE TABLE TStates
(
	 intStateID			INTEGER			NOT NULL
	,strState			VARCHAR(255)	NOT NULL
	,CONSTRAINT TStates_PK PRIMARY KEY ( intStateID )
)


CREATE TABLE TFlights
(
	 intFlightID			INTEGER			NOT NULL
	,strFlightNumber		VARCHAR(255)	NOT NULL
	,dtmFlightDate			DATETIME		NOT NULL
	,dtmTimeofDeparture		TIME			NOT NULL
	,dtmTimeOfLanding		TIME			NOT NULL
	,intFromAirportID		INTEGER			NOT NULL
	,intToAirportID			INTEGER			NOT NULL
	,intMilesFlown			INTEGER			NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TFlights_PK PRIMARY KEY ( intFlightID )
)


CREATE TABLE TMaintenances
(
	 intMaintenanceID		INTEGER			NOT NULL
	,strWorkCompleted		VARCHAR(8000)	NOT NULL
	,dtmMaintenanceDate		DATETIME		NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TMaintenances_PK PRIMARY KEY ( intMaintenanceID )
)


CREATE TABLE TPlanes
(
	 intPlaneID				INTEGER			NOT NULL
	,strPlaneNumber			VARCHAR(255)	NOT NULL
	,intPlaneTypeID			INTEGER			NOT NULL
	,CONSTRAINT TPlanes_PK PRIMARY KEY ( intPlaneID )
)


CREATE TABLE TPlaneTypes	
(
	 intPlaneTypeID			INTEGER			NOT NULL
	,strPlaneType			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPlaneTypes_PK PRIMARY KEY ( intPlaneTypeID )
)


CREATE TABLE TPilotRoles	
(
	 intPilotRoleID			INTEGER			NOT NULL
	,strPilotRole			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPilotRoles_PK PRIMARY KEY ( intPilotRoleID )
)


CREATE TABLE TAirports
(
	 intAirportID			INTEGER			NOT NULL
	,strAirportCity			VARCHAR(255)	NOT NULL
	,strAirportCode			VARCHAR(255)	NOT NULL
	,CONSTRAINT TAirports_PK PRIMARY KEY ( intAirportID )
)


CREATE TABLE TPilotFlights
(
	 intPilotFlightID		INTEGER			NOT NULL
	,intPilotID				INTEGER			NOT NULL
	,intFlightID			INTEGER			NOT NULL
	,CONSTRAINT TPilotFlights_PK PRIMARY KEY ( intPilotFlightID )
)


CREATE TABLE TAttendantFlights
(
	 intAttendantFlightID		INTEGER			NOT NULL
	,intAttendantID				INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,CONSTRAINT TAttendantFlights_PK PRIMARY KEY ( intAttendantFlightID )
)


CREATE TABLE TFlightPassengers
(
	 intFlightPassengerID		INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,intPassengerID				INTEGER			NOT NULL
	,strSeat					VARCHAR(255)	NOT NULL
	,CONSTRAINT TFlightPassengers_PK PRIMARY KEY ( intFlightPassengerID )
)


CREATE TABLE TMaintenanceMaintenanceWorkers
(
	 intMaintenanceMaintenanceWorkerID		INTEGER			NOT NULL
	,intMaintenanceID						INTEGER			NOT NULL
	,intMaintenanceWorkerID					INTEGER			NOT NULL
	,intHours								INTEGER			NOT NULL
	,CONSTRAINT TMaintenanceMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceMaintenanceWorkerID )
)

-- --------------------------------------------------------------------------------
--	Step #2 : Establish Referential Integrity 
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column
-- -	-----							------						---------
-- 1	TPassengers						TStates						intStateID	
-- 2	TFlightPassenger				TPassengers					intPassengerID
-- 3	TFlights						TPlanes						intPlaneID
-- 4	TFlights						TAirports					intFromAiportID
-- 5	TFlights						TAirports					intToAiportID
-- 6	TPilotFlights					TFlights					intFlightID
-- 7	TAttendantFlights				TFlights					intFlightID
-- 8	TPilotFlights					TPilots						intPilotID
-- 9	TAttendantFlights				TAttendants					intAttendantID
-- 10	TPilots							TPilotRoles					intPilotRoleID
-- 11	TPlanes							TPlaneTypes					intPlaneTypeID
-- 12	TMaintenances					TPlanes						intPlaneID
-- 13	TMaintenanceMaintenanceWorkers	TMaintenance				intMaintenanceID
-- 14	TMaintenanceMaintenanceWorkers	TMaintenanceWorker			intMaintenanceWorkerID
-- 15	TFlightPassenger				TFlights					intFlightID

--1
ALTER TABLE TPassengers ADD CONSTRAINT TPassengers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID ) ON DELETE CASCADE

--2
ALTER TABLE TFlightPassengers ADD CONSTRAINT TPFlightPassengers_TPassengers_FK 
FOREIGN KEY ( intPassengerID ) REFERENCES TPassengers ( intPassengerID )

--3
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes ( intPlaneID )

--4
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TFromAirports_FK 
FOREIGN KEY ( intFromAirportID ) REFERENCES TAirports ( intAirportID )

--5
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TToAirports_FK 
FOREIGN KEY ( intToAirportID ) REFERENCES TAirports ( intAirportID )

--6
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID )  

--7
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) 

--8
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TPilots_FK 
FOREIGN KEY ( intPilotID ) REFERENCES TPilots (intPilotID ) 

--9
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TAttendants_FK 
FOREIGN KEY ( intAttendantID ) REFERENCES TAttendants (intAttendantID ) ON DELETE CASCADE

--10
ALTER TABLE TPilots	 ADD CONSTRAINT TPilots_TPilotRoles_FK 
FOREIGN KEY ( intPilotRoleID ) REFERENCES TPilotRoles (intPilotRoleID ) ON DELETE CASCADE

--11
ALTER TABLE TPlanes	 ADD CONSTRAINT TPlanes_TPlaneTypes_FK 
FOREIGN KEY ( intPlaneTypeID ) REFERENCES TPlaneTypes (intPlaneTypeID )  

--12
ALTER TABLE TMaintenances	 ADD CONSTRAINT TMaintenances_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes (intPlaneID )  

--13
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenances_FK 
FOREIGN KEY ( intMaintenanceID ) REFERENCES TMaintenances (intMaintenanceID ) 

--14
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenanceWorkers_FK 
FOREIGN KEY ( intMaintenanceWorkerID ) REFERENCES TMaintenanceWorkers (intMaintenanceWorkerID ) 

--15
ALTER TABLE TFlightPassengers	 ADD CONSTRAINT TFlightPassengers_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) 

-- --------------------------------------------------------------------------------
--	Step #3 : Add Data - INSERTS
-- --------------------------------------------------------------------------------
INSERT INTO TStates( intStateID, strState)
VALUES				(1, 'Ohio')
				   ,(2, 'Kentucky')
				   ,(3, 'Indiana')


INSERT INTO TPilotRoles( intPilotRoleID, strPilotRole)
VALUES				(1, 'Co-Pilot')
				   ,(2, 'Captain')

				
INSERT INTO TPlaneTypes( intPlaneTypeID, strPlaneType)
VALUES				(1, 'Airbus A350')
				   ,(2, 'Boeing 747-8')
				   ,(3, 'Boeing 767-300F')


INSERT INTO TPlanes( intPlaneID, strPlaneNumber, intPlaneTypeID)
VALUES				(1, '4X887G', 1)
				   ,(2, '5HT78F', 2)
				   ,(3, '5TYY65', 2)
				   ,(4, '4UR522', 1)
				   ,(5, '6OP3PK', 3)
				   ,(6, '67TYHH', 3)


INSERT INTO TAirports( intAirportID, strAirportCity, strAirportCode)
VALUES				(1, 'Cincinnati', 'CVG')
				   ,(2, 'Miami', 'MIA')
				   ,(3, 'Ft. Meyer', 'RSW')
				   ,(4, 'Louisville',  'SDF')
				   ,(5, 'Denver', 'DEN')
				   ,(6, 'Orlando', 'MCO' )


INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail)
VALUES				  (1, 'Knelly', 'Nervious', '321 Elm St.', 'Cincinnati', 1, '45201', '5135553333', 'nnelly@gmail.com')
					 ,(2, 'Orville', 'Waite', '987 Oak St.', 'Cleveland', 1, '45218', '5135556333', 'owright@gmail.com')
					 ,(3, 'Eileen', 'Awnewe', '1569 Windisch Rd.', 'Dayton', 1, '45069', '5135555333', 'eonewe1@yahoo.com')
					 ,(4, 'Bob', 'Eninocean', '44561 Oak Ave.', 'Florence', 2, '45246', '8596663333', 'bobenocean@gmail.com')
					 ,(5, 'Ware', 'Hyjeked', '44881 Pine Ave.', 'Aurora', 3, '45546', '2825553333', 'Hyjekedohmy@gmail.com')
					 ,(6, 'Kay', 'Oss', '4484 Bushfield Ave.', 'Lawrenceburg', 3, '45546', '2825553333', 'wehavekayoss@gmail.com')


INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)
VALUES				  (1, 'Tip', 'Seenow', '12121', '1/1/2015', '1/1/2099', '12/1/2014', 1)
					 ,(2, 'Ima', 'Soring', '13322', '1/1/2016', '1/1/2099', '12/1/2015', 1)
					 ,(3, 'Hugh', 'Encharge', '16666', '1/1/2017', '1/1/2099', '12/1/2016', 2)
					 ,(4, 'Iwanna', 'Knapp', '17676', '1/1/2014', '1/1/2015', '12/1/2013', 1)
					 ,(5, 'Rose', 'Ennair', '19909', '1/1/2012', '1/1/2099', '12/1/2011', 2)


INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)
VALUES				  (1, 'Miller', 'Tyme', '22121', '1/1/2015', '1/1/2099')
					 ,(2, 'Sherley', 'Ujest', '23322', '1/1/2016', '1/1/2099')
					 ,(3, 'Buhh', 'Biy', '26666', '1/1/2017', '1/1/2099')
					 ,(4, 'Myles', 'Amanie', '27676', '1/1/2014', '1/1/2015')
					 ,(5, 'Walker', 'Toexet', '29909', '1/1/2012', '1/1/2099')


INSERT INTO TMaintenanceWorkers (intMaintenanceWorkerID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateOfCertification)
VALUES				  (1, 'Gressy', 'Nuckles', '32121', '1/1/2015', '1/1/2099', '12/1/2014')
					 ,(2, 'Bolt', 'Izamiss', '33322', '1/1/2016', '1/1/2099', '12/1/2015')
					 ,(3, 'Sharon', 'Urphood', '36666', '1/1/2017', '1/1/2099','12/1/2016')
					 ,(4, 'Ides', 'Racrozed', '37676', '1/1/2014', '1/1/2015','12/1/2013')
					

INSERT INTO TMaintenances (intMaintenanceID, strWorkCompleted, dtmMaintenanceDate, intPlaneID)
VALUES				  (1, 'Fixed Wing', '1/1/2022', 1)
					 ,(2, 'Repaired Flat Tire', '3/1/2022', 2)
					 ,(3, 'Added Wiper Fluid', '4/1/2022', 3)
					 ,(4, 'Tightened Engine to Wing', '5/1/2022', 2)
					 ,(5, '100,000 mile checkup', '3/10/2022', 4)
					 ,(6, 'Replaced Loose Door', '4/10/2022', 6)
					 ,(7, 'Trapped Raccoon in Cargo Hold', '5/1/2022', 6)


INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)
VALUES				  (1, '4/1/2022', '111', '10:00:00', '12:00:00', 1, 2, 1200, 2)
					 ,(2, '4/4/2022', '222','13:00:00', '15:00:00', 1, 3, 1000, 2)
					 ,(3, '4/5/2022', '333','15:00:00', '17:00:00', 1, 5, 1200, 3)
					 ,(4, '4/16/2022','444', '10:00:00', '12:00:00', 4, 6, 1100, 3)
					 ,(5, '3/14/2022','555', '18:00:00', '20:00:00', 2, 1, 1200, 3)
					 ,(6, '3/21/2022','666', '19:00:00', '21:00:00', 3, 1, 1000, 1)
					 ,(7, '3/11/2022', '777','20:00:00', '22:00:00', 3, 6, 1400, 4)
					 ,(8, '3/17/2022', '888','09:00:00', '11:00:00', 6, 4, 1100, 5)
					 ,(9, '4/19/2022', '999','08:00:00', '10:00:00', 4, 2, 1000, 6)
					 ,(10, '4/22/2022', '091','10:00:00', '12:00:00', 2, 1, 1200, 6)


INSERT INTO TPilotFlights ( intPilotFlightID, intPilotID, intFlightID)
VALUES				 ( 1, 1, 2 )
					,( 2, 1, 3 )
					,( 3, 3, 3 )
					,( 4, 3, 2 )
					,( 5, 5, 1 )
					,( 6, 2, 1 )
					,( 7, 3, 4 )
					,( 8, 2, 4 )
					,( 9, 2, 5 )
					,( 10, 3, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )


INSERT INTO TAttendantFlights ( intAttendantFlightID, intAttendantID, intFlightID)
VALUES				( 1, 1, 2 )
					,( 2, 2, 3 )
					,( 3, 3, 3 )
					,( 4, 4, 2 )
					,( 5, 5, 1 )
					,( 6, 1, 1 )
					,( 7, 2, 4 )
					,( 8, 3, 4 )
					,( 9, 4, 5 )
					,( 10, 5, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )
					

INSERT INTO TFlightPassengers ( intFlightPassengerID, intFlightID, intPassengerID, strSeat)
VALUES				 ( 1, 1, 1, '1A')
					,( 2, 1, 2, '2A' )
					,( 3, 1, 3, '1B' )
					,( 4, 1, 4, '1C' )
					,( 5, 1, 5, '1D' )
					,( 6, 2, 5, '1A' )
					,( 7, 2, 4, '2A' )
					,( 8, 2, 3, '1B' )
					,( 9, 3, 1, '1B' )
					,( 10, 3, 2, '2A' )
					,( 11, 3, 3, '1B' )
					,( 12, 3, 4, '1C' )
					,( 13, 3, 5, '1D' )
					,( 14, 4, 2, '1A' )
					,( 15, 4, 3, '1B' )
					,( 16, 4, 4, '1C' )
					,( 17, 4, 5, '1D' )
					,( 18, 5, 1, '1A' )
					,( 19, 5, 2, '2A' )
					,( 20, 5, 3, '1B' )
					,( 21, 5, 4, '2B' )
					,( 22, 6, 1, '1A' )
					,( 23, 6, 2, '2A' )
					,( 24, 6, 3, '3A' )
					

INSERT INTO TMaintenanceMaintenanceWorkers ( intMaintenanceMaintenanceWorkerID, intMaintenanceID, intMaintenanceWorkerID, intHours)
VALUES				 ( 1, 2, 1, 2 )
					,( 2, 4, 1, 3 )
					,( 3, 2, 3, 4 )
					,( 4, 1, 4, 2 )
					,( 5, 3, 4, 2 )
					,( 6, 4, 3, 5 )
					,( 7, 5, 1, 7 )
					,( 8, 6, 1, 2 )
					,( 9, 7, 3, 4 )
					,( 10, 4, 4, 1 )
					,( 11, 3, 3, 4 )
					,( 12, 7, 3, 8 )


-- --------------------------------------------------------------------------------
--	Query #1: List all flights for each passenger. Show Passenger First Name 
--	and Last Name. Show Flight Number and Date. Sort by Passenger Last Name ascending
--	JOIN
-- --------------------------------------------------------------------------------

SELECT
	 TP.strFirstName
	,TP.strLastName
	,TF.strFlightNumber
	,TF.dtmFlightDate
FROM
	TPassengers AS TP JOIN TFlightPassengers AS TFP
	ON TP.intPassengerID = TFP.intPassengerID
	JOIN TFlights AS TF
	ON TF.intFlightID = TFP.intFlightID
ORDER BY
	TP.strLastName ASC

-- --------------------------------------------------------------------------------
--	Query #2: List all flights for a passenger �Ware Hyjeked�. Show Flight 
--	Number and Flight Date. Sort by Flight Date, descending
--	JOIN
-- --------------------------------------------------------------------------------

SELECT
	 TP.strFirstName
	,TP.strLastName
	,TF.strFlightNumber
	,TF.dtmFlightDate
FROM
	TPassengers AS TP JOIN TFlightPassengers AS TFP
	ON TP.intPassengerID = TFP.intPassengerID
	JOIN TFlights AS TF
	ON TF.intFlightID = TFP.intFlightID
WHERE
	TP.intPassengerID = 5
ORDER BY
	TF.dtmFlightDate DESC

-- --------------------------------------------------------------------------------
--	Query #3: List all passengers that have taken a flight with FlyMe2theMoon.  
--	Show Passenger First Name and Last Name only. Only show passenger once.
--	JOIN, DISTINCT
-- --------------------------------------------------------------------------------

SELECT DISTINCT
	 TP.strFirstName
	,TP.strLastName
FROM	
	TPassengers AS TP JOIN TFlightPassengers AS TFP
	ON TP.intPassengerID = TFP.intPassengerID
	JOIN TFlights As TF
	ON TF.intFlightID = TFP.intFlightID

-- --------------------------------------------------------------------------------
--	Query #4: Show only passengers in the database who have not taken a flight. 
--	Show Passenger First Name and Last Name
--	SUBQUERY
-- --------------------------------------------------------------------------------

SELECT
	 TP.strFirstName
	,TP.strLastName
FROM 
	TPassengers As TP
WHERE TP.intPassengerID NOT IN 
(SELECT
	TP.intPassengerID
FROM	
TPassengers AS TP JOIN TFlightPassengers AS TFP
ON TP.intPassengerID = TFP.intPassengerID
JOIN TFlights As TF
ON TF.intFlightID = TFP.intFlightID)
	

-- --------------------------------------------------------------------------------
--	Query #5: Show only planes that have not had any maintenance completed. 
--	Show All Plane information
--	SUBQUERY
-- --------------------------------------------------------------------------------

SELECT
	 TP.intPlaneID
	,TP.strPlaneNumber
	,TPT.strPlaneType
FROM 
	TPlanes AS TP JOIN TPlaneTypes AS TPT
	ON TP.intPlaneTypeID = TPT.intPlaneTypeID
WHERE TP.intPlaneID NOT IN
(SELECT
	TP.intPlaneID
FROM
	TPlanes AS TP JOIN TPlaneTypes AS TPT
	ON TP.intPlaneTypeID = TPT.intPlaneTypeID
	JOIN TMaintenances AS TM
	ON TM.intPlaneID = TP.intPlaneID)

-- --------------------------------------------------------------------------------
--	Query #6: Show total number of flights for each pilot. If the pilot has ZERO, 
--	show them too. Show Pilot first name and last name and total flight
--	COUNT, ISNULL
-- --------------------------------------------------------------------------------

SELECT
	 TP.strFirstName
	,TP.strLastName
	,ISNULL(COUNT(TPF.intPilotID), 0) AS TotalFlights
FROM
	TPilots AS TP LEFT JOIN TPilotFlights AS TPF
	ON TP.intPilotID = TPF.intPilotID
GROUP BY
	TP.strFirstName, TP.strLastName

-- --------------------------------------------------------------------------------
--	Query #7: Show total number of hours of maintenance performed on each plane.  
--	Show all plane information and hours
--	SUM
-- --------------------------------------------------------------------------------

SELECT
	 TPT.strPlaneType
	,TP.strPlaneNumber
	,SUM(TMMW.intHours) AS TotalHoursWorked
FROM 
	TPlanes AS TP JOIN TMaintenances AS TM
	ON TP.intPlaneID = TM.intPlaneID
	JOIN TPlaneTypes AS TPT
	ON TPT.intPlaneTypeID = TP.intPlaneTypeID
	JOIN TMaintenanceMaintenanceWorkers AS TMMW
	ON TMMW.intMaintenanceID = TM.intMaintenanceID
GROUP BY
	TP.strPlaneNumber, TPT.strPlaneType

-- --------------------------------------------------------------------------------
--	Query #8: Show total flight miles for each passenger who have flown over 
--	5000 miles in total. Show Passenger first name and last name and Total Miles.  
--	Sort by Total Miles, descending
--	SUM, HAVING
-- --------------------------------------------------------------------------------

SELECT
	 TP.strFirstName
	,TP.strLastName
	,SUM(TF.intMilesFlown) AS TotalMilesFlown
FROM
	TPassengers AS TP JOIN TFlightPassengers AS TFP
	ON TP.intPassengerID = TFP.intPassengerID
	JOIN TFlights AS TF
	ON TF.intFlightID = TFP.intFlightID
GROUP BY
	TP.strFirstName, TP.strLastName
HAVING
	SUM(TF.intMilesFlown) > 5000
ORDER BY
	TotalMilesFlown DESC

-- --------------------------------------------------------------------------------
--	Query #9: Show the passenger(s) that have flown the most miles. Show 
--	Passenger first name and last name and Total Miles
--	SUM
-- --------------------------------------------------------------------------------

SELECT TOP 1
	 TP.strFirstName
	,TP.strLastName
	,SUM(TF.intMilesFlown) AS TotalMilesFlown
FROM
	TPassengers AS TP JOIN TFlightPassengers AS TFP
	ON TP.intPassengerID = TFP.intPassengerID
	JOIN TFlights AS TF
	ON TF.intFlightID = TFP.intFlightID
GROUP BY
	TP.strFirstName, TP.strLastName

-- --------------------------------------------------------------------------------
--	Query #10: Show average flight miles for each Pilot during the April, 2022
--	AVG, JOIN, WHERE
-- --------------------------------------------------------------------------------

SELECT
	 TP.strFirstName
	,TP.strLastName
	,AVG(TF.intMilesFlown) AS AVGMilesFlown
FROM
	TPilots AS TP JOIN TPilotFlights AS TPF
	ON TP.intPilotID = TPF.intPilotID
	JOIN TFlights AS TF
	ON TF.intFlightID = TPF.intFlightID
WHERE
-- How do I specify what month and/or year I want to focus on?
	MONTH(TF.dtmFlightDate) = MONTH(TF.dtmFlightDate)
GROUP BY
	TP.strFirstName, TP.strLastName

-- --------------------------------------------------------------------------------
--	Query #11: Show all Boeing 767-300F that have been worked on by Maintenance 
--	Worker �Gressy Nuckles�
--	JOIN, WHERE
-- --------------------------------------------------------------------------------

SELECT
	 TP.strPlaneNumber
	,TM.dtmMaintenanceDate
FROM
	TPlanes AS TP JOIN TMaintenances AS TM
	ON TP.intPlaneID = TM.intPlaneID
	JOIN TMaintenanceMaintenanceWorkers AS TMMW
	ON TMMW.intMaintenanceID = TM.intMaintenanceID
	JOIN TMaintenanceWorkers AS TMW
	ON TMW.intMaintenanceWorkerID = TMMW.intMaintenanceWorkerID
WHERE
	TP.intPlaneTypeID = 3
and TMW.intMaintenanceWorkerID = 1


-- --------------------------------------------------------------------------------
--	Query #12: Show all Passengers that have taken a flight where Pilot �Ima Soring� 
--	and Attendant �Sherley Ujest� were on the same flight. Show Passenger First 
--	Name and Last Name. Show Flight Number and Date
--	JOIN, WHERE
-- --------------------------------------------------------------------------------

SELECT
	 TP.strFirstName
	,TP.strLastName
	,TF.strFlightNumber
	,TF.dtmFlightDate
FROM
	TPassengers AS TP JOIN TFlightPassengers AS TFP
	ON TP.intPassengerID = TFP.intPassengerID
	JOIN TFlights AS TF
	ON TF.intFlightID = TFP.intFlightID
	JOIN TAttendantFlights AS TAF
	ON TAF.intFlightID = TF.intFlightID
	JOIN TAttendants AS TA
	ON TA.intAttendantID = TAF.intAttendantID
	JOIN TPilotFlights AS TPF
	ON TPF.intFlightID = TF.intFlightID
	JOIN TPilots AS TPi
	ON TPi.intPilotID = TPF.intPilotID
WHERE
	TA.strLastName = 'Ujest'
and TPi.strLastName = 'Soring'

-- --------------------------------------------------------------------------------
--	Query #13: Show Attendants and their total flights(only if more than 1) where 
--	they originated out of CVG airport during April, 2022. Show Attendant First 
--	Name and Last Name and Total Flights. Sort by Total Flights descending
--	COUNT, HAVING, WHERE
-- --------------------------------------------------------------------------------

SELECT
	 TA.strFirstName
	,TA.strLastName
	,COUNT(TAF.intFlightID) AS TotalFlights
FROM
	TAttendants AS TA JOIN TAttendantFlights AS TAF
	ON TA.intAttendantID = TAF.intAttendantID
	JOIN TFlights AS TF
	ON TF.intFlightID = TAF.intFlightID
	JOIN TAirports AS TAP
	ON TAP.intAirportID = TF.intFromAirportID
WHERE
	TAP.strAirportCode = 'CVG'
-- How do I specify what month and/or year I want to focus on?
and MONTH(TF.dtmFlightDate) = MONTH(TF.dtmFlightDate)
GROUP BY
	TA.strFirstName, TA.strLastName
ORDER BY
	TotalFlights DESC

-- --------------------------------------------------------------------------------
--	Query #14: Show all Passengers that have NOT taken a flight where Pilot 
--	�Ima Soring� and Attendant �Sherley Ujest� were on the same flight. 
--	Show Passenger First Name and Last Name
--	SUBQUERY, JOIN
-- --------------------------------------------------------------------------------

SELECT
	 TP.strFirstName
	,TP.strLastName
	,TF.strFlightNumber
FROM
	TPassengers AS TP JOIN TFlightPassengers AS TFP
	ON TP.intPassengerID = TFP.intPassengerID
	JOIN TFlights AS TF
	ON TF.intFlightID = TFP.intFlightID
WHERE 
	TF.intFlightID NOT IN
(SELECT
	TF.intFlightID
FROM
	TPassengers AS TP JOIN TFlightPassengers AS TFP
	ON TP.intPassengerID = TFP.intPassengerID
	JOIN TFlights AS TF
	ON TF.intFlightID = TFP.intFlightID
	JOIN TAttendantFlights AS TAF
	ON TAF.intFlightID = TF.intFlightID
	JOIN TAttendants AS TA
	ON TA.intAttendantID = TAF.intAttendantID
	JOIN TPilotFlights AS TPF
	ON TPF.intFlightID = TF.intFlightID
	JOIN TPilots AS TPi
	ON TPi.intPilotID = TPF.intPilotID
WHERE
	TA.strLastName = 'Ujest'
and TPi.strLastName = 'Soring')

-- --------------------------------------------------------------------------------
--	Query #15: Show total number of times Pilot �Tip Seenow� has flown  Boeing 747-B
--	COUNT, JOIN
-- --------------------------------------------------------------------------------

SELECT
	COUNT(TPF.intPilotID) AS TimesFlown
FROM 
	TFlights AS TF JOIN TPilotFlights AS TPF
	ON TF.intFlightID = TPF.intFlightID
	JOIN TPilots AS TP
	ON TP.intPilotID = TPF.intPilotID
	JOIN TPlanes As TPl
	ON TPl.intPlaneID = TF.intPlaneID
WHERE
	TPl.intPlaneTypeID = 2
and TP.intPilotID = 1

-- --------------------------------------------------------------------------------
--	Query #16: Show all Passengers that live on a street with the work �Oak� in it
--	LIKE
-- --------------------------------------------------------------------------------

SELECT
	 TP.strFirstName
	,TP.strLastName
	,TP.strAddress
FROM
	TPassengers AS TP
WHERE
	TP.strAddress LIKE '%Oak%'


