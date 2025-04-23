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
IF OBJECT_ID ('TMaintenanceMaintenanceWorkers')	IS NOT NULL DROP TABLE TMaintenanceMaintenanceWorkers

IF OBJECT_ID ('TEmployees')				IS NOT NULL DROP TABLE TEmployees
IF OBJECT_ID ('TPassengers')			IS NOT NULL DROP TABLE TPassengers
IF OBJECT_ID ('TPilots')				IS NOT NULL DROP TABLE TPilots
IF OBJECT_ID ('TAttendants')			IS NOT NULL DROP TABLE TAttendants
IF OBJECT_ID ('TMaintenanceWorkers')	IS NOT NULL DROP TABLE TMaintenanceWorkers

IF OBJECT_ID ('TEmployeeRoles')			IS NOT NULL DROP TABLE TEmployeeRoles
IF OBJECT_ID ('TFlights')				IS NOT NULL DROP TABLE TFlights
IF OBJECT_ID ('TMaintenances')			IS NOT NULL DROP TABLE TMaintenances
IF OBJECT_ID ('TPlanes')				IS NOT NULL DROP TABLE TPlanes
IF OBJECT_ID ('TPlaneTypes')			IS NOT NULL DROP TABLE TPlaneTypes
IF OBJECT_ID ('TPilotRoles')			IS NOT NULL DROP TABLE TPilotRoles
IF OBJECT_ID ('TAirports')				IS NOT NULL DROP TABLE TAirports
IF OBJECT_ID ('TStates')				IS NOT NULL DROP TABLE TStates

-- --------------------------------------------------------------------------------
--						Drop Stored Procedures
-- --------------------------------------------------------------------------------
-- -----------------------------------
--	Customers/Passengers
-- -----------------------------------
IF OBJECT_ID ('uspCreateCustomer')		IS NOT NULL DROP PROCEDURE uspCreateCustomer
IF OBJECT_ID ('uspDeleteCustomer')		IS NOT NULL DROP PROCEDURE uspDeleteCustomer
IF OBJECT_ID ('uspUpdateCustomer')		IS NOT NULL DROP PROCEDURE uspUpdateCustomer

IF OBJECT_ID ('uspCustomerPastFlights')		IS NOT NULL DROP PROCEDURE uspCustomerPastFlights
IF OBJECT_ID ('uspCustomerPastMiles')		IS NOT NULL DROP PROCEDURE uspCustomerPastMiles
IF OBJECT_ID ('uspCustomerFutureFlights')	IS NOT NULL DROP PROCEDURE uspCustomerFutureFlights
IF OBJECT_ID ('uspCustomerFutureMiles')		IS NOT NULL DROP PROCEDURE uspCustomerFutureMiles

-- -----------------------------------
--	Employees (Pilots, Attendants, Admin)
-- -----------------------------------
IF OBJECT_ID ('uspEmployeeLogin')		IS NOT NULL DROP PROCEDURE uspEmployeeLogin

-- -----------------------------------
--	Pilots
-- -----------------------------------
IF OBJECT_ID ('uspCreatePilot')			IS NOT NULL DROP PROCEDURE uspCreatePilot
IF OBJECT_ID ('uspDeletePilot')			IS NOT NULL DROP PROCEDURE uspDeletePilot
IF OBJECT_ID ('uspUpdatePilot')			IS NOT NULL DROP PROCEDURE uspUpdatePilot

IF OBJECT_ID ('uspPilotPastFlights')	IS NOT NULL DROP PROCEDURE uspPilotPastFlights
IF OBJECT_ID ('uspPilotPastMiles')		IS NOT NULL DROP PROCEDURE uspPilotPastMiles
IF OBJECT_ID ('uspPilotFutureFlights')	IS NOT NULL DROP PROCEDURE uspPilotFutureFlights
IF OBJECT_ID ('uspPilotFutureMiles')	IS NOT NULL DROP PROCEDURE uspPilotFutureMiles

-- -----------------------------------
--	Attendants
-- -----------------------------------
IF OBJECT_ID ('uspCreateAttendant')		IS NOT NULL DROP PROCEDURE uspCreateAttendant
IF OBJECT_ID ('uspDeleteAttendant')		IS NOT NULL DROP PROCEDURE uspDeleteAttendant
IF OBJECT_ID ('uspUpdateAttendant')		IS NOT NULL DROP PROCEDURE uspUpdateAttendant

IF OBJECT_ID ('uspAttendantPastFlights')	IS NOT NULL DROP PROCEDURE uspAttendantPastFlights
IF OBJECT_ID ('uspAttendantPastMiles')		IS NOT NULL DROP PROCEDURE uspAttendantPastMiles
IF OBJECT_ID ('uspAttendantFutureFlights')	IS NOT NULL DROP PROCEDURE uspAttendantFutureFlights
IF OBJECT_ID ('uspAttendantFutureMiles')	IS NOT NULL DROP PROCEDURE uspAttendantFutureMiles

-- --------------------------------------------------------------------------------
--	Step #1 : Create table 
-- --------------------------------------------------------------------------------
CREATE TABLE TPassengers
(
	 intPassengerID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,dtmDOB					DATETIME		NOT NULL
	,strAddress				VARCHAR(255)	NOT NULL
	,strCity				VARCHAR(255)	NOT NULL
	,intStateID				INTEGER			NOT NULL
	,strZip					VARCHAR(255)	NOT NULL
	,strLoginID				VARCHAR(255)	NOT NULL
	,strPassword			VARCHAR(255)	NOT NULL
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

CREATE TABLE TEmployeeRoles
(
	 intEmployeeRoleID		INTEGER			NOT NULL
	,strEmployeeRole		VARCHAR(50)		NOT NULL
	,CONSTRAINT TEmployeeRole_PK PRIMARY KEY ( intEmployeeRoleID )
)

CREATE TABLE TEmployees
(
	 intEmployeeID			INTEGER			NOT NULL
	,strLoginID				VARCHAR(255)	NOT NULL
	,strPassword			VARCHAR(255)	NOT NULL
	,intEmployeeRoleID		INTEGER			NOT NULL
	,intEmployeeNum			INTEGER			NOT NULL
	,CONSTRAINT TEmployees_PF PRIMARY KEY ( intEmployeeID )
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
	,dtmTimeofDeparture		TIME			
	,dtmTimeOfLanding		TIME			
	,intFromAirportID		INTEGER			NOT NULL
	,intToAirportID			INTEGER			NOT NULL
	,intMilesFlown			INTEGER			
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
-- 16	TEmployees						TEmployeeRoleID				intEmployeeRoleID

--1
ALTER TABLE TPassengers ADD CONSTRAINT TPassengers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID ) ON DELETE CASCADE

--2
ALTER TABLE TFlightPassengers ADD CONSTRAINT TPFlightPassengers_TPassengers_FK 
FOREIGN KEY ( intPassengerID ) REFERENCES TPassengers ( intPassengerID )

--3
ALTER TABLE TFlights ADD CONSTRAINT TFlights_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes ( intPlaneID )

--4
ALTER TABLE TFlights ADD CONSTRAINT TFlights_TFromAirports_FK 
FOREIGN KEY ( intFromAirportID ) REFERENCES TAirports ( intAirportID )

--5
ALTER TABLE TFlights ADD CONSTRAINT TFlights_TToAirports_FK 
FOREIGN KEY ( intToAirportID ) REFERENCES TAirports ( intAirportID )

--6
ALTER TABLE TPilotFlights ADD CONSTRAINT TPilotFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID )  

--7
ALTER TABLE TAttendantFlights ADD CONSTRAINT TAttendantFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) 

--8
ALTER TABLE TPilotFlights ADD CONSTRAINT TPilotFlights_TPilots_FK 
FOREIGN KEY ( intPilotID ) REFERENCES TPilots (intPilotID ) ON DELETE CASCADE

--9
ALTER TABLE TAttendantFlights ADD CONSTRAINT TAttendantFlights_TAttendants_FK 
FOREIGN KEY ( intAttendantID ) REFERENCES TAttendants (intAttendantID ) ON DELETE CASCADE

--10
ALTER TABLE TPilots	ADD CONSTRAINT TPilots_TPilotRoles_FK 
FOREIGN KEY ( intPilotRoleID ) REFERENCES TPilotRoles (intPilotRoleID )

--11
ALTER TABLE TPlanes	ADD CONSTRAINT TPlanes_TPlaneTypes_FK 
FOREIGN KEY ( intPlaneTypeID ) REFERENCES TPlaneTypes (intPlaneTypeID )  

--12
ALTER TABLE TMaintenances ADD CONSTRAINT TMaintenances_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes (intPlaneID )  

--13
ALTER TABLE TMaintenanceMaintenanceWorkers ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenances_FK 
FOREIGN KEY ( intMaintenanceID ) REFERENCES TMaintenances (intMaintenanceID ) 

--14
ALTER TABLE TMaintenanceMaintenanceWorkers ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenanceWorkers_FK 
FOREIGN KEY ( intMaintenanceWorkerID ) REFERENCES TMaintenanceWorkers (intMaintenanceWorkerID ) 

--15
ALTER TABLE TFlightPassengers ADD CONSTRAINT TFlightPassengers_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) 

--16
ALTER TABLE TEmployees ADD CONSTRAINT TEmployees_TEmployeeRoles_FK
FOREIGN KEY ( intEmployeeRoleID ) REFERENCES TEmployeeRoles ( intEmployeeRoleID )


-- --------------------------------------------------------------------------------
--	Step #3 : Add Data - INSERTS
-- --------------------------------------------------------------------------------
INSERT INTO TStates (intStateID, strState)
VALUES				(1, 'Ohio')
				   ,(2, 'Kentucky')
				   ,(3, 'Indiana')


INSERT INTO TPilotRoles (intPilotRoleID, strPilotRole)
VALUES				(1, 'Co-Pilot')
				   ,(2, 'Captain')


INSERT INTO TEmployeeRoles (intEmployeeRoleID, strEmployeeRole)
VALUES		 (1, 'Pilot')
			,(2, 'Attendant')
			,(3, 'Admin')

				
INSERT INTO TPlaneTypes (intPlaneTypeID, strPlaneType)
VALUES		 (1, 'Airbus A350')
			,(2, 'Boeing 747-8')
			,(3, 'Boeing 767-300F')


INSERT INTO TPlanes (intPlaneID, strPlaneNumber, intPlaneTypeID)
VALUES				(1, '4X887G', 1)
				   ,(2, '5HT78F', 2)
				   ,(3, '5TYY65', 2)
				   ,(4, '4UR522', 1)
				   ,(5, '6OP3PK', 3)
				   ,(6, '67TYHH', 3)


INSERT INTO TAirports ( intAirportID, strAirportCity, strAirportCode)
VALUES				(1, 'Cincinnati', 'CVG')
				   ,(2, 'Miami', 'MIA')
				   ,(3, 'Ft. Meyer', 'RSW')
				   ,(4, 'Louisville', 'SDF')
				   ,(5, 'Denver', 'DEN')
				   ,(6, 'Orlando', 'MCO')


INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, dtmDOB, strAddress, strCity, intStateID, strZip, strLoginID, strPassword, strPhoneNumber, strEmail)
VALUES				  (1, 'Knelly', 'Nervious', '06/15/1982', '321 Elm St.', 'Cincinnati', 1, '45201', 'nnelly', 'soNervousRN', '5135553333', 'nnelly@gmail.com')
					 ,(2, 'Orville', 'Waite', '09/22/1998', '987 Oak St.', 'Cleveland', 1, '45218', 'owright', 'flightBros!', '5135556333', 'owright@gmail.com')
					 ,(3, 'Eileen', 'Awnewe', '12/05/1990', '1569 Windisch Rd.', 'Dayton', 1, '45069', 'eonewe1', 'eiSeeYou_', '5135555333', 'eonewe1@yahoo.com')
					 ,(4, 'Bob', 'Eninocean', '03/10/1985', '44561 Oak Ave.', 'Florence', 2, '45246', 'bobenocean', 'bobbin_away!', '8596663333', 'bobenocean@gmail.com')
					 ,(5, 'Ware', 'Hyjeked', '07/18/2000', '44881 Pine Ave.', 'Aurora', 3, '45546', 'hyjekedohmy', 'goindown!', '2825553333', 'Hyjekedohmy@gmail.com')
					 ,(6, 'Kay', 'Oss', '04/04/1990', '4484 Bushfield Ave.', 'Lawrenceburg', 3, '45546', 'wehavekayoss', 'kayotic_good', '2825553333', 'wehavekayoss@gmail.com')


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


INSERT INTO TEmployees (intEmployeeID, strLoginID, strPassword, intEmployeeRoleID, intEmployeeNum)
VALUES				 (1, 'admin', 'admin', 3, 1)
					,(2, 'roennair', 'imflyin', 1, 5)
					,(3, 'watoexet', 'emergency!', 2, 5)
					,(4, 'iwknapp', 'honkshoo', 1, 4)
					,(5, 'myamanie', 'wow_sofar', 2, 4)
					,(6, 'tiseenow', 'gettin_tipsy', 1, 1)
					,(7, 'mityme', 'wedrankin', 2, 1)
					,(8, 'imsoring', 'flyinnn', 1, 2)
					,(9, 'shujest', 'hahasofunny', 2, 2)
					,(10, 'huencharge', 'notme!', 1, 3)
					,(11, 'bubiy', 'adiosamigo', 2, 3)
					

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
					 ,(11, '4/16/2025','321', NULL, NULL, 4, 6, 1100, 3)
					 ,(12, '7/14/2025','123', NULL, NULL, 2, 1, 1200, 4)
					 ,(13, '3/21/2026','246', NULL, NULL, 3, 1, 1000, 1)


INSERT INTO TPilotFlights (intPilotFlightID, intPilotID, intFlightID)
VALUES				 (1, 1, 2)
					,(2, 1, 3)
					,(3, 3, 3)
					,(4, 3, 2)
					,(5, 5, 1)
					,(6, 2, 1)
					,(7, 3, 4)
					,(8, 2, 4)
					,(9, 2, 5)
					,(10, 3, 5)
					,(11, 5, 6)
					,(12, 1, 6)


INSERT INTO TAttendantFlights (intAttendantFlightID, intAttendantID, intFlightID)
VALUES				 (1, 1, 2)
					,(2, 2, 3)
					,(3, 3, 3)
					,(4, 4, 2)
					,(5, 5, 1)
					,(6, 1, 1)
					,(7, 2, 4)
					,(8, 3, 4)
					,(9, 4, 5)
					,(10, 5, 5)
					,(11, 5, 6)
					,(12, 1, 6)
					

INSERT INTO TFlightPassengers (intFlightPassengerID, intFlightID, intPassengerID, strSeat)
VALUES				 (1, 1, 1, '1A')
					,(2, 1, 2, '2A')
					,(3, 1, 3, '1B')
					,(4, 1, 4, '1C')
					,(5, 1, 5, '1D')
					,(6, 2, 5, '1A')
					,(7, 2, 4, '2A')
					,(8, 2, 3, '1B')
					,(9, 3, 1, '1B')
					,(10, 3, 2, '2A')
					,(11, 3, 3, '1B')
					,(12, 3, 4, '1C')
					,(13, 3, 5, '1D')
					,(14, 4, 2, '1A')
					,(15, 4, 3, '1B')
					,(16, 4, 4, '1C')
					,(17, 4, 5, '1D')
					,(18, 5, 1, '1A')
					,(19, 5, 2, '2A')
					,(20, 5, 3, '1B')
					,(21, 5, 4, '2B')
					,(22, 6, 1, '1A')
					,(23, 6, 2, '2A')
					,(24, 6, 3, '3A')
					

INSERT INTO TMaintenanceMaintenanceWorkers (intMaintenanceMaintenanceWorkerID, intMaintenanceID, intMaintenanceWorkerID, intHours)
VALUES				 (1, 2, 1, 2)
					,(2, 4, 1, 3)
					,(3, 2, 3, 4)
					,(4, 1, 4, 2)
					,(5, 3, 4, 2)
					,(6, 4, 3, 5)
					,(7, 5, 1, 7)
					,(8, 6, 1, 2)
					,(9, 7, 3, 4)
					,(10, 4, 4, 1)
					,(11, 3, 3, 4)
					,(12, 7, 3, 8)


SELECT * FROM TEmployees
SELECT * FROM TAttendants
-- ----------------------
--	PASSENGERS
-- ----------------------
-- --------------------------------------------------------------------------------
--	Create Procedure for CreateCustomer (inserts new passenger data into TPassengers)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspCreateCustomer
	 @intPassengerID	AS INTEGER OUTPUT
	,@strFirstName		AS VARCHAR(255)
	,@strLastName		AS VARCHAR(255)
	,@dtmDOB			AS DATETIME
	,@strAddress		AS VARCHAR(255)
	,@strCity			AS VARCHAR(255)
	,@intStateID		AS INTEGER		
	,@strZip			AS VARCHAR(255)
	,@strLoginID		AS VARCHAR(255)
	,@strPassword		AS VARCHAR(255)
	,@strPhoneNumber	AS VARCHAR(255)
	,@strEmail			AS VARCHAR(255)
AS
SET XACT_ABORT ON	-- Terminate and rollback entire transaction on error
BEGIN TRANSACTION
	
	SELECT @intPassengerID = MAX(intPassengerID) + 1
	FROM TPassengers

	SELECT @intPassengerID = COALESCE(@intPassengerID, 1) -- first ID is 1 if table is empty

	INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, dtmDOB, strAddress, strCity, intStateID, strZip, strLoginID, strPassword, strPhoneNumber, strEmail)
	VALUES		(@intPassengerID, @strFirstName, @strLastName, @dtmDOB, @strAddress, @strCity, @intStateID, @strZip, @strLoginID, @strPassword, @strPhoneNumber, @strEmail)

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for DeleteCustomer (deletes selected passenger from TPassengers)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspDeleteCustomer
	@intPassengerID		AS INTEGER
AS
SET XACT_ABORT ON
BEGIN TRANSACTION

	DELETE FROM TPassengers
	WHERE intPassengerID = @intPassengerID

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for UpdateCustomer (updates passenger data in TPassengers)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspUpdateCustomer
     @intPassengerID	AS INTEGER
	,@strFirstName		AS VARCHAR(255)
	,@strLastName		AS VARCHAR(255)
	,@dtmDOB			AS DATETIME
	,@strAddress		AS VARCHAR(255)
	,@strCity			AS VARCHAR(255)
	,@intStateID		AS INTEGER
	,@strZip			AS VARCHAR(20)
	,@strLoginID		AS VARCHAR(255)
	,@strPassword		AS VARCHAR(255)
	,@strPhoneNumber	AS VARCHAR(20)
	,@strEmail			AS VARCHAR(255)
AS
BEGIN TRANSACTION

	UPDATE TPassengers 
	SET	 strFirstName = @strFirstName
		,strLastName = @strLastName
		,dtmDOB = @dtmDOB
		,strAddress = @strAddress
		,strCity = @strCity
		,intStateID = @intStateID
		,strZip = @strZip
		,strLoginID = @strLoginID
		,strPassword = @strPassword
		,strPhoneNumber = @strPhoneNumber
		,strEmail = @strEmail
	WHERE TPassengers.intPassengerID = @intPassengerID

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for CustomerPastFlights (displays past flight data for passenger)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspCustomerPastFlights
     @intPassengerID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT DISTINCT 
		 TF.dtmFlightDate
		,TF.strFlightNumber
		,TF.dtmTimeofDeparture
		,TF.dtmTimeofLanding
		,TF.intMilesFlown
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intFromAirportID) AS DepartureCity
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intToAirportID) AS ArrivalCity
		,(SELECT strPlaneNumber FROM TPlanes WHERE intPlaneID = TF.intPlaneID) AS PlaneNum
	FROM TFlights AS TF JOIN TFlightPassengers AS TFP
		 ON TF.intFlightID = TFP.intFlightID
		 JOIN TPassengers AS TP ON TP.intPassengerID = TFP.intPassengerID
	WHERE TFP.intPassengerID = @intPassengerID AND TF.dtmFlightDate <= GETDATE() 
	ORDER BY TF.dtmFlightDate

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for CustomerPastMiles (displays total past flight miles for passenger)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspCustomerPastMiles
	@intPassengerID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT ISNULL(SUM(TF.intMilesFlown), 0) AS TotalMiles
	FROM TFlights AS TF JOIN TFlightPassengers AS TFP
		 ON TF.intFlightID = TFP.intFlightID
		 JOIN TPassengers AS TP ON TP.intPassengerID = TFP.intPassengerID
	WHERE TFP.intPassengerID = @intPassengerID AND TF.dtmFlightDate <= GETDATE()

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for CustomerFutureFlights (displays future flight data for passenger)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspCustomerFutureFlights
     @intPassengerID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT DISTINCT 
		 TF.dtmFlightDate
		,TF.strFlightNumber
		,TF.dtmTimeofDeparture
		,TF.dtmTimeofLanding
		,TF.intMilesFlown
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intFromAirportID) AS DepartureCity
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intToAirportID) AS ArrivalCity
		,(SELECT strPlaneNumber FROM TPlanes WHERE intPlaneID = TF.intPlaneID) AS PlaneNum
	FROM TFlights AS TF JOIN TFlightPassengers AS TFP
		 ON TF.intFlightID = TFP.intFlightID
		 JOIN TPassengers AS TP ON TP.intPassengerID = TFP.intPassengerID
	WHERE TFP.intPassengerID = @intPassengerID AND TF.dtmFlightDate >= GETDATE() 
	ORDER BY TF.dtmFlightDate

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for CustomerFutureMiles (displays total future flight miles for passenger)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspCustomerFutureMiles
	@intPassengerID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT ISNULL(SUM(TF.intMilesFlown), 0) AS TotalMiles
	FROM TFlights AS TF JOIN TFlightPassengers AS TFP
		 ON TF.intFlightID = TFP.intFlightID
		 JOIN TPassengers AS TP ON TP.intPassengerID = TFP.intPassengerID
	WHERE TFP.intPassengerID = @intPassengerID AND TF.dtmFlightDate >= GETDATE()

COMMIT TRANSACTION
GO


-- ----------------------
--	PILOTS
-- ----------------------
-- --------------------------------------------------------------------------------
--	Create Procedure for CreatePilot (inserts new pilot data into TPilots)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspCreatePilot
	 @intEmployeeID		AS INTEGER OUTPUT
	,@intEmployeeRoleID	AS INTEGER OUTPUT  -- has a default value
	,@intPilotID		AS INTEGER OUTPUT
	,@strFirstName		AS VARCHAR(255)
	,@strLastName		AS VARCHAR(255)
	,@strLoginID		AS VARCHAR(30)
	,@strPassword		AS VARCHAR(30)
	,@strEmployeeID		AS VARCHAR(255)
	,@dtmDateOfHire		AS DATETIME	
	,@dtmDateOfTermination AS DATETIME
	,@dtmDateOfLicense	AS DATETIME	
	,@intPilotRoleID	AS INTEGER		
AS
SET XACT_ABORT ON	-- Terminate and rollback entire transaction on error
BEGIN TRANSACTION

-- Inserts values into TPilots
	SELECT @intPilotID = MAX(intPilotID) + 1
	FROM TPilots

	SELECT @intPilotID = COALESCE(@intPilotID, 1) -- first ID is 1 if table is empty

	INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)
	VALUES		(@intPilotID, @strFirstName, @strLastName, @strEmployeeID, @dtmDateOfHire, @dtmDateOfTermination, @dtmDateOfLicense, @intPilotRoleID)

-- Inserts values into TEmployee
	SELECT @intEmployeeID = MAX(intEmployeeID) + 1
	FROM TEmployees

	SELECT @intEmployeeID = COALESCE(@intEmployeeID, 1) -- first ID is 1 if table is empty

	SET @intEmployeeRoleID = 1 -- employee role is set to 1 (pilot) by default

	INSERT INTO TEmployees (intEmployeeID, strLoginID, strPassword, intEmployeeRoleID, intEmployeeNum)
	VALUES		(@intEmployeeID, @strLoginID, @strPassword, @intEmployeeRoleID, @intPilotID)

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for DeletePilot (deletes selected pilot from TPilots)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspDeletePilot
	@intPilotID		AS INTEGER
AS
SET XACT_ABORT ON
BEGIN TRANSACTION

	DELETE FROM TPilots
	WHERE intPilotID = @intPilotID

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for UpdatePilot (updates pilot data in TPilots)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspUpdatePilot
	 @intEmployeeID		AS INTEGER
    ,@intPilotID		AS INTEGER
	,@strFirstName		AS VARCHAR(255)
	,@strLastName		AS VARCHAR(255)
	,@strLoginID		AS VARCHAR(30)
	,@strPassword		AS VARCHAR(30)
	,@strEmployeeID		AS VARCHAR(10)
	,@dtmDateofHire		AS DATETIME
	,@dtmDateofTermination AS DATETIME
	,@dtmDateofLicense	AS DATETIME
	,@intPilotRoleID	AS INTEGER
AS
BEGIN TRANSACTION

	UPDATE TPilots 
	SET	 strFirstName = @strFirstName
		,strLastName = @strLastName
		,strEmployeeID = @strEmployeeID
		,dtmDateofHire = @dtmDateofHire
		,dtmDateofTermination = @dtmDateofTermination
		,dtmDateofLicense = @dtmDateofLicense
		,intPilotRoleID = @intPilotRoleID
	WHERE TPilots.intPilotID = @intPilotID

	UPDATE TEmployees
	SET	 strLoginID = @strLoginID
		,strPassword = @strPassword
	WHERE intEmployeeNum = @intPilotID
	AND intEmployeeID = @intEmployeeID

COMMIT TRANSACTION
GO

EXECUTE uspUpdatePilot 6, 1, 'Tip', 'Seenow', 'tiseenow', 'seenow', '12121', '1/1/2015', '1/1/2099', '12/1/2014', 1
-- --------------------------------------------------------------------------------
--	Create Procedure for PilotPastFlights (displays past flight data for pilot)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspPilotPastFlights
     @intPilotID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT DISTINCT 
		 TF.dtmFlightDate
		,TF.strFlightNumber
		,TF.dtmTimeofDeparture
		,TF.dtmTimeofLanding
		,TF.intMilesFlown
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intFromAirportID) AS DepartureCity
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intToAirportID) AS ArrivalCity
		,(SELECT strPlaneNumber FROM TPlanes WHERE intPlaneID = TF.intPlaneID) AS PlaneNum
	FROM TFlights AS TF JOIN TPilotFlights AS TPF
		 ON TF.intFlightID = TPF.intFlightID
		 JOIN TPilots AS TP ON TP.intPilotID = TPF.intPilotID
	WHERE TPF.intPilotID = @intPilotID AND TF.dtmFlightDate <= GETDATE() 
	ORDER BY TF.dtmFlightDate

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for PilotPastMiles (displays total past flight miles for pilot)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspPilotPastMiles
	@intPilotID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT ISNULL(SUM(TF.intMilesFlown), 0) AS TotalMiles
	FROM TFlights AS TF JOIN TPilotFlights AS TPF
		 ON TF.intFlightID = TPF.intFlightID
		 JOIN TPilots AS TP ON TP.intPilotID = TPF.intPilotID
	WHERE TPF.intPilotID = @intPilotID AND TF.dtmFlightDate <= GETDATE() 

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for PilotFutureFlights (displays future flight data for pilot)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspPilotFutureFlights
     @intPilotID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT DISTINCT 
		 TF.dtmFlightDate
		,TF.strFlightNumber
		,TF.dtmTimeofDeparture
		,TF.dtmTimeofLanding
		,TF.intMilesFlown
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intFromAirportID) AS DepartureCity
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intToAirportID) AS ArrivalCity
		,(SELECT strPlaneNumber FROM TPlanes WHERE intPlaneID = TF.intPlaneID) AS PlaneNum
	FROM TFlights AS TF JOIN TPilotFlights AS TPF
		 ON TF.intFlightID = TPF.intFlightID
		 JOIN TPilots AS TP ON TP.intPilotID = TPF.intPilotID
	WHERE TPF.intPilotID = @intPilotID AND TF.dtmFlightDate >= GETDATE() 
	ORDER BY TF.dtmFlightDate

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for PilotFutureMiles (displays total future flight miles for pilot)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspPilotFutureMiles
	@intPilotID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT ISNULL(SUM(TF.intMilesFlown), 0) AS TotalMiles
	FROM TFlights AS TF JOIN TPilotFlights AS TPF
		 ON TF.intFlightID = TPF.intFlightID
		 JOIN TPilots AS TP ON TP.intPilotID = TPF.intPilotID
	WHERE TPF.intPilotID = @intPilotID AND TF.dtmFlightDate >= GETDATE() 

COMMIT TRANSACTION
GO


-- ----------------------
--	ATTENDANTS
-- ----------------------
-- --------------------------------------------------------------------------------
--	Create Procedure for CreateAttendant (inserts new attendant data into TAttendants)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspCreateAttendant
	 @intEmployeeID		AS INTEGER OUTPUT
	,@intEmployeeRoleID	AS INTEGER OUTPUT  -- has a default value
	,@intAttendantID	AS INTEGER OUTPUT
	,@strFirstName		AS VARCHAR(255)
	,@strLastName		AS VARCHAR(255)
	,@strLoginID		AS VARCHAR(30)
	,@strPassword		AS VARCHAR(30)
	,@strEmployeeID		AS VARCHAR(255)
	,@dtmDateOfHire		AS DATETIME	
	,@dtmDateOfTermination AS DATETIME	
AS
SET XACT_ABORT ON	-- Terminate and rollback entire transaction on error
BEGIN TRANSACTION

-- Inserts values into TAttendants
	SELECT @intAttendantID = MAX(intAttendantID) + 1
	FROM TAttendants

	SELECT @intAttendantID = COALESCE(@intAttendantID, 1) -- first ID is 1 if table is empty

	INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)
	VALUES		(@intAttendantID, @strFirstName, @strLastName, @strEmployeeID, @dtmDateOfHire, @dtmDateOfTermination)

-- Inserts values into TEmployees
	SELECT @intEmployeeID = MAX(intEmployeeID) + 1
	FROM TEmployees

	SELECT @intEmployeeID = COALESCE(@intEmployeeID, 1) -- first ID is 1 if table is empty

	SET @intEmployeeRoleID = 2 -- employee role is set to 2 (attendant) by default

	INSERT INTO TEmployees (intEmployeeID, strLoginID, strPassword, intEmployeeRoleID, intEmployeeNum)
	VALUES		(@intEmployeeID, @strLoginID, @strPassword, @intEmployeeRoleID, @intAttendantID)

COMMIT TRANSACTION
GO

SELECT MAX(intAttendantID) AS MaxAttendant, MAX(intEmployeeID) AS MaxEmployee
FROM TAttendants, TEmployees
-- --------------------------------------------------------------------------------
--	Create Procedure for DeleteAttendant (deletes selected attendant from TAttendants)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspDeleteAttendant
	@intAttendantID		AS INTEGER
AS
SET XACT_ABORT ON
BEGIN TRANSACTION

	DELETE FROM TAttendants
	WHERE intAttendantID = @intAttendantID

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for UpdateAttendant (updates attendant data in TAttendants)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspUpdateAttendant
     @intEmployeeID		AS INTEGER
	,@intAttendantID	AS INTEGER
	,@strFirstName		AS VARCHAR(255)
	,@strLastName		AS VARCHAR(255)
	,@strLoginID		AS VARCHAR(30)
	,@strPassword		AS VARCHAR(30)
	,@strEmployeeID		AS VARCHAR(10)
	,@dtmDateofHire		AS DATETIME
	,@dtmDateofTermination AS DATETIME
AS
BEGIN TRANSACTION

	UPDATE TAttendants 
	SET  strFirstName = @strFirstName
		,strLastName = @strLastName
		,strEmployeeID = @strEmployeeID
		,dtmDateofHire = @dtmDateofHire
		,dtmDateofTermination = @dtmDateofTermination
	WHERE TAttendants.intAttendantID = @intAttendantID

	UPDATE TEmployees
	SET	 strLoginID = @strLoginID
		,strPassword = @strPassword
	WHERE intEmployeeNum = @intAttendantID
	AND intEmployeeID = @intEmployeeID

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for AttendantPastFlights (displays past flight data for attendant)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspAttendantPastFlights
     @intAttendantID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT DISTINCT 
		 TF.dtmFlightDate
		,TF.strFlightNumber
		,TF.dtmTimeofDeparture
		,TF.dtmTimeofLanding
		,TF.intMilesFlown
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intFromAirportID) AS DepartureCity
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intToAirportID) AS ArrivalCity
		,(SELECT strPlaneNumber FROM TPlanes WHERE intPlaneID = TF.intPlaneID) AS PlaneNum
	FROM TFlights AS TF JOIN TAttendantFlights AS TAF
		 ON TF.intFlightID = TAF.intFlightID
		 JOIN TAttendants AS TA ON TA.intAttendantID = TAF.intAttendantID
	WHERE TAF.intAttendantID = @intAttendantID AND TF.dtmFlightDate <= GETDATE() 
	ORDER BY TF.dtmFlightDate

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for AttendantPastMiles (displays total past flight miles for attendant)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspAttendantPastMiles
	@intAttendantID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT ISNULL(SUM(TF.intMilesFlown), 0) AS TotalMiles
	FROM TFlights AS TF JOIN TAttendantFlights AS TAF
		 ON TF.intFlightID = TAF.intFlightID
		 JOIN TAttendants AS TA ON TA.intAttendantID = TAF.intAttendantID
	WHERE TAF.intAttendantID = @intAttendantID AND TF.dtmFlightDate <= GETDATE() 

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for AttendantFutureFlights (displays future flight data for attendant)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspAttendantFutureFlights
     @intAttendantID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT DISTINCT 
		 TF.dtmFlightDate
		,TF.strFlightNumber
		,TF.dtmTimeofDeparture
		,TF.dtmTimeofLanding
		,TF.intMilesFlown
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intFromAirportID) AS DepartureCity
		,(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intToAirportID) AS ArrivalCity
		,(SELECT strPlaneNumber FROM TPlanes WHERE intPlaneID = TF.intPlaneID) AS PlaneNum
	FROM TFlights AS TF JOIN TAttendantFlights AS TAF
		 ON TF.intFlightID = TAF.intFlightID
		 JOIN TAttendants AS TA ON TA.intAttendantID = TAF.intAttendantID
	WHERE TAF.intAttendantID = @intAttendantID AND TF.dtmFlightDate >= GETDATE() 
	ORDER BY TF.dtmFlightDate

COMMIT TRANSACTION
GO

-- --------------------------------------------------------------------------------
--	Create Procedure for AttendantFutureMiles (displays total future flight miles for attendant)
-- --------------------------------------------------------------------------------
GO
CREATE PROCEDURE uspAttendantFutureMiles
	@intAttendantID AS INTEGER
AS
BEGIN TRANSACTION

	SELECT ISNULL(SUM(TF.intMilesFlown), 0) AS TotalMiles
	FROM TFlights AS TF JOIN TAttendantFlights AS TAF
		 ON TF.intFlightID = TAF.intFlightID
		 JOIN TAttendants AS TA ON TA.intAttendantID = TAF.intAttendantID
	WHERE TAF.intAttendantID = @intAttendantID AND TF.dtmFlightDate >= GETDATE() 

COMMIT TRANSACTION
GO


GO
CREATE PROCEDURE uspEmployeeLogin
	 @intEmployeeID	AS INTEGER OUTPUT
	,@strLoginID	AS VARCHAR(30)
	,@strPassword	AS VARCHAR(30)
AS
BEGIN TRANSACTION	-- ask bob if I can look up how to do try/excepts, or ask for guidance on validation
	BEGIN TRY
		SELECT @intEmployeeID = intEmployeeID
		FROM TEmployees
		WHERE strLoginID = @strLoginID
		AND strPassword = @strPassword
	END TRY

	BEGIN CATCH
		SELECT ERROR_NUMBER() AS ErrorNumber, 
			   ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
	

COMMIT TRANSACTION
GO

DECLARE @intEmployeeID AS INTEGER
EXECUTE uspEmployeeLogin 0, 'swoyak', 'password'