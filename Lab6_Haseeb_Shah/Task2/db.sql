CREATE DATABASE IF NOT EXISTS University;
CREATE TABLE IF NOT EXISTS Student (
		ID INT auto_increment primary key,
        RegNo INT unique,
        Name VARCHAR(100),
        Section VARCHAR(5),
        Contact VARCHAR(20),
        Address VARCHAR(20)
        );
        
INSERT INTO Student (RegNo, Name, Section, Contact, Address) VALUES 
		(11, "name1", "a", "12345", "Behind market"),
        (12, "name2", "b", "23456", "Beside market"),
        (13, "name3", "a", "34567", "Left of market"),
        (14, "name4", "c", "45678", "Right of market"),
        (15, "name5", "a", "56789", "Top of market");
