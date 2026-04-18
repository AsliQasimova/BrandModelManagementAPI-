-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: brand_db
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `brands`
--

DROP TABLE IF EXISTS `brands`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brands` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brands`
--

LOCK TABLES `brands` WRITE;
/*!40000 ALTER TABLE `brands` DISABLE KEYS */;
INSERT INTO `brands` VALUES (1,'Apple'),(2,'Samsung'),(3,'Xiaomi'),(4,'Huawei');
/*!40000 ALTER TABLE `brands` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `features`
--

DROP TABLE IF EXISTS `features`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `features` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Camera` varchar(50) DEFAULT NULL,
  `Storage` varchar(50) DEFAULT NULL,
  `Ram` varchar(50) DEFAULT NULL,
  `ModelID` int DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `ModelID` (`ModelID`),
  CONSTRAINT `features_ibfk_1` FOREIGN KEY (`ModelID`) REFERENCES `models` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `features`
--

LOCK TABLES `features` WRITE;
/*!40000 ALTER TABLE `features` DISABLE KEYS */;
INSERT INTO `features` VALUES (1,'12MP','128GB','6GB',1,0),(2,'12MP','256GB','4GB',2,0),(3,'50MP','256GB','8GB',3,0),(4,'32MP','128GB','6GB',4,0),(5,'108MP','256GB','12GB',5,0),(6,'50MP','128GB','8GB',6,0),(7,'48MP','256GB','8GB',7,1);
/*!40000 ALTER TABLE `features` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `models`
--

DROP TABLE IF EXISTS `models`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `models` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `Quantity` int NOT NULL DEFAULT '0',
  `BrandID` int DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `BrandID` (`BrandID`),
  CONSTRAINT `models_ibfk_1` FOREIGN KEY (`BrandID`) REFERENCES `brands` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `models`
--

LOCK TABLES `models` WRITE;
/*!40000 ALTER TABLE `models` DISABLE KEYS */;
INSERT INTO `models` VALUES (1,'iPhone 14',1200.00,14,1,0),(2,'iPhone 13',999.99,18,1,0),(3,'Galaxy S23',900.00,12,2,0),(4,'Galaxy A53',400.00,33,2,0),(5,'Xiaomi 12',700.00,16,3,0),(6,'Huawei P50',650.00,19,4,0),(7,'iPhone 15',1200.00,10,1,1);
/*!40000 ALTER TABLE `models` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pricehistories`
--

DROP TABLE IF EXISTS `pricehistories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pricehistories` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `ModelID` int NOT NULL,
  `OldPrice` decimal(10,2) NOT NULL,
  `NewPrice` decimal(10,2) NOT NULL,
  `ChangedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_PriceHistory_Model` (`ModelID`),
  CONSTRAINT `FK_PriceHistory_Model` FOREIGN KEY (`ModelID`) REFERENCES `models` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pricehistories`
--

LOCK TABLES `pricehistories` WRITE;
/*!40000 ALTER TABLE `pricehistories` DISABLE KEYS */;
INSERT INTO `pricehistories` VALUES (1,3,1000.00,900.00,'2026-03-03 21:02:37'),(2,4,450.00,500.00,'2026-03-06 14:57:34'),(3,4,500.00,400.00,'2026-03-06 14:58:11');
/*!40000 ALTER TABLE `pricehistories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales`
--

DROP TABLE IF EXISTS `sales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sales` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `ModelID` int NOT NULL,
  `SoldPrice` decimal(10,2) NOT NULL,
  `SoldAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_Sale_Model` (`ModelID`),
  CONSTRAINT `FK_Sale_Model` FOREIGN KEY (`ModelID`) REFERENCES `models` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales`
--

LOCK TABLES `sales` WRITE;
/*!40000 ALTER TABLE `sales` DISABLE KEYS */;
INSERT INTO `sales` VALUES (1,6,650.00,'2026-03-04 15:47:26'),(2,6,650.00,'2026-03-04 15:47:51'),(3,5,700.00,'2026-03-04 15:52:19'),(4,6,650.00,'2026-03-04 15:53:01'),(5,6,650.00,'2026-03-04 15:53:02'),(6,6,650.00,'2026-03-04 15:53:02'),(7,6,650.00,'2026-03-04 15:53:03'),(8,6,650.00,'2026-03-04 15:53:03'),(9,6,650.00,'2026-03-04 15:53:04'),(10,6,650.00,'2026-03-04 15:53:04'),(11,6,650.00,'2026-03-04 15:53:04'),(12,4,450.00,'2026-03-06 14:56:08'),(13,2,999.99,'2026-03-06 14:56:13'),(14,1,1200.00,'2026-03-06 14:56:18'),(15,5,700.00,'2026-03-06 14:56:23'),(16,6,650.00,'2026-03-06 14:56:27'),(17,4,400.00,'2026-03-09 11:46:23');
/*!40000 ALTER TABLE `sales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stockmovements`
--

DROP TABLE IF EXISTS `stockmovements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stockmovements` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `ModelID` int NOT NULL,
  `QuantityChanged` int NOT NULL,
  `MovementType` varchar(20) NOT NULL,
  `ChangedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_StockMovement_Model` (`ModelID`),
  CONSTRAINT `FK_StockMovement_Model` FOREIGN KEY (`ModelID`) REFERENCES `models` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stockmovements`
--

LOCK TABLES `stockmovements` WRITE;
/*!40000 ALTER TABLE `stockmovements` DISABLE KEYS */;
INSERT INTO `stockmovements` VALUES (1,6,20,'RESTOCK','0001-01-01 00:00:00'),(2,4,10,'RESTOCK','2026-03-06 14:55:26'),(3,4,-1,'SALE','2026-03-06 14:56:08'),(4,2,-1,'SALE','2026-03-06 14:56:13'),(5,1,-1,'SALE','2026-03-06 14:56:18'),(6,5,-1,'SALE','2026-03-06 14:56:23'),(7,6,-1,'SALE','2026-03-06 14:56:27'),(8,4,-1,'SALE','2026-03-09 11:46:23');
/*!40000 ALTER TABLE `stockmovements` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-18 15:29:32
