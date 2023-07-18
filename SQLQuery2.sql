
-- Check the current compatibility level
SELECT name, compatibility_level
FROM sys.databases
WHERE name = 'roommeet';

-- Change the compatibility level to SQL Server 2019 (150)
ALTER DATABASE roommeet
SET COMPATIBILITY_LEVEL = 150;

CREATE TABLE Users (
  id INT PRIMARY KEY,
  name VARCHAR(255),
  date_of_birth DATE,
  gender VARCHAR(10),
  email VARCHAR(255) UNIQUE,
  password VARCHAR(255),
  role VARCHAR(20)
);

CREATE TABLE Companies (
  id INT PRIMARY KEY,
  name VARCHAR(255),
  description TEXT,
  email VARCHAR(255),
  logo VARCHAR(MAX),  
  active BIT,
  user_id INT,
  FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE,
);

CREATE TABLE Rooms (
  id INT PRIMARY KEY,
  name VARCHAR(255),
  location VARCHAR(255),
  capacity INT,
  room_description TEXT,
  company_id INT,
  FOREIGN KEY (company_id) REFERENCES Companies(id) ON DELETE CASCADE
);

CREATE TABLE Reservations (
  id INT PRIMARY KEY,
  meeting_date DATE,
  start_time TIME,
  end_time TIME,
  room_id INT,
  number_of_attendees INT,
  meeting_status BIT,
  FOREIGN KEY (room_id) REFERENCES Rooms(id) ON DELETE  CASCADE
);

CREATE TABLE User_Company (
  user_id INT,
  company_id INT,
  FOREIGN KEY (user_id) REFERENCES Users(id) ON DELETE CASCADE,
  FOREIGN KEY (company_id) REFERENCES Companies(id) ON DELETE CASCADE
);

CREATE TABLE Room_Reservation (
  room_id INT,
  reservation_id INT,
  FOREIGN KEY (room_id) REFERENCES Rooms(id) ON DELETE CASCADE,
  FOREIGN KEY (reservation_id) REFERENCES Reservations(id) ON DELETE CASCADE
);

CREATE TABLE Company_Room (
  company_id INT,
  room_id INT,
  FOREIGN KEY (company_id) REFERENCES Companies(id) ON DELETE CASCADE,
  FOREIGN KEY (room_id) REFERENCES Rooms(id) ON DELETE CASCADE
);
