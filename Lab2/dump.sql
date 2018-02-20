-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: lab2
-- ------------------------------------------------------
-- Server version	5.5.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;artifactsartifacts
--
-- Table structure for table `artifacts`
--

DROP TABLE IF EXISTS `artifacts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `artifacts` (
  `ArtifactsID` int(11) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Author` varchar(45) DEFAULT NULL,
  `PublicationDate` date DEFAULT NULL,
  `Genre` varchar(45) DEFAULT NULL,
  `Price` int(11) DEFAULT NULL,
  `BatchNum` int(11) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Type` varchar(45) DEFAULT NULL,
  `IsDonated` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `QuantityLost` int(11) DEFAULT NULL,
  PRIMARY KEY (`ArtifactsID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_setartifacts_client = @saved_cs_client */;

--
-- Dumping data for table `artifacts`
--

LOCK TABLES `artifacts` WRITE;
/*!40000 ALTER TABLE `artifacts` DISABLE KEYS */;
INSERT INTO `artifacts` VALUES (1,'Harry Potter','J.K Rowling','2006-02-02','Fiction',50,384021,100,'Book','Yes',5),(2,'A Thousand Splendid Suns','Khaled Hosseini','2009-01-09','Fiction',45,502792,80,'Book','No',12),(3,'NeuroComputing','Zidong Wang','2012-12-12','Computing',30,838371,50,'Journal','No',0),(4,'Computing and Astronomy','David Black','2014-11-12','Computing',35,848341,60,'Journal','No',2),(5,'Kingsman 1','Matthew Vaughn','2016-10-02','Sci-Fi',30,118341,200,'DVD','No',10),(6,'Kingsman 2','Matthew Vaughn','2017-10-10','Sci-Fi',30,118880,300,'DVD','No',20);
/*!40000 ALTER TABLE `artifacts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `issued`
--

DROP TABLE IF EXISTS `issued`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `issued` (
  `ArtifactID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `DateIssued` date DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `IsOwned`  varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`ArtifactID`,`UserID`),
  KEY `F1` (`ArtifactID`),
  KEY `F2` (`UserID`),
  CONSTRAINT `F2` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `F1` FOREIGN KEY (`ArtifactID`) REFERENCES `artifacts` (`ArtifactsID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `issued`
--

LOCK TABLES `issued` WRITE;
/*!40000 ALTER TABLE `issued` DISABLE KEYS */;
INSERT INTO `issued` VALUES (1,1,'2018-02-02',1,'No'),(1,2,'2018-01-01',1,'No');
/*!40000 ALTER TABLE `issued` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `UserID` int(11) NOT NULL auto_increment,
  `Email` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `FineDue` int(11) DEFAULT NULL,
  `FineCollected` int(11) DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `Email_UNIQUE` (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'abc@gmail.com','qwerty',0,20),(2,'xyz@gmail.com','asdfgh',0,0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-02-15  0:07:34
