-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jun 06, 2025 at 02:13 AM
-- Server version: 8.3.0
-- PHP Version: 8.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_sirval`
--

-- --------------------------------------------------------

--
-- Table structure for table `asignaciones`
--

DROP TABLE IF EXISTS `asignaciones`;
CREATE TABLE IF NOT EXISTS `asignaciones` (
  `Id_Asignacion` int NOT NULL AUTO_INCREMENT,
  `Id_Alerta` int NOT NULL,
  `Id_Responsable` int NOT NULL,
  `Fecha_Asig` datetime NOT NULL,
  `Estado_Asig` varchar(10) NOT NULL,
  `Observaciones_Asig` varchar(100) NOT NULL,
  `FechaResol_Asig` datetime NOT NULL,
  PRIMARY KEY (`Id_Asignacion`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `dispositivos`
--

DROP TABLE IF EXISTS `dispositivos`;
CREATE TABLE IF NOT EXISTS `dispositivos` (
  `Id_Dispositivo` int NOT NULL AUTO_INCREMENT,
  `Tipo_Disp` varchar(25) NOT NULL,
  `Nombre_Disp` varchar(15) NOT NULL,
  `Ubicacion_Disp` varchar(25) NOT NULL,
  `IP` varchar(15) NOT NULL,
  PRIMARY KEY (`Id_Dispositivo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `registro_alertas`
--

DROP TABLE IF EXISTS `registro_alertas`;
CREATE TABLE IF NOT EXISTS `registro_alertas` (
  `Id_Alerta` int NOT NULL AUTO_INCREMENT,
  `Id_TipoAlerta` int NOT NULL,
  `Id_Dispositivo` int NOT NULL,
  `Severidad` varchar(10) NOT NULL,
  `Detalle_Alerta` varchar(50) NOT NULL,
  `Fecha_Alerta` datetime NOT NULL,
  PRIMARY KEY (`Id_Alerta`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `responsables`
--

DROP TABLE IF EXISTS `responsables`;
CREATE TABLE IF NOT EXISTS `responsables` (
  `Id_Responsable` int NOT NULL AUTO_INCREMENT,
  `Nombre_Resp` varchar(30) NOT NULL,
  `Mail_Resp` varchar(25) NOT NULL,
  `Telefono` varchar(8) NOT NULL,
  PRIMARY KEY (`Id_Responsable`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tipos_alerta`
--

DROP TABLE IF EXISTS `tipos_alerta`;
CREATE TABLE IF NOT EXISTS `tipos_alerta` (
  `Id_TipoAlerta` int NOT NULL AUTO_INCREMENT,
  `Descripcion_TipoAlerta` varchar(25) NOT NULL,
  PRIMARY KEY (`Id_TipoAlerta`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
