-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: store_c
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `stores`
--

DROP TABLE IF EXISTS `stores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stores` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `cnpj` varchar(100) NOT NULL,
  `address` varchar(100) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `stores_unique` (`cnpj`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stores`
--

LOCK TABLES `stores` WRITE;
/*!40000 ALTER TABLE `stores` DISABLE KEYS */;
INSERT INTO `stores` VALUES (8,'GLOBO COMUNICACAO E PARTICIPACOES S/A','27865757000102','R LOPES QUINTAS, JARDIM BOTANICO - RIO DE JANEIRO - RJ','Atividades de televisão aberta'),(9,'SBT ON LINE SYSTEMS LTDA','01909552000260','AVENIDA BRIGADEIRO LUIZ ANTONIO, JARDIM PAULISTA - SAO PAULO - SP','Teste'),(10,'ESTADO DE SAO PAULO','46379400000150','AV MORUMBI, MORUMBI - SAO PAULO - SP','Administração pública em geral'),(11,'MUNICIPIO DE BETIM','18715391000277','RUA PROF. OSVALDO FRANCO, CENTRO - BETIM - MG','Administração pública em geral'),(12,'EMPRESA BRASILEIRA DE PESQUISA AGROPECUARIA','00348003011660','AVENIDA ANDRE TOSELLO, CID. UNIV. ZEFERINO VAZ - CAMPINAS - SP','Pesquisa e desenvolvimento experimental em ciências físicas e naturais'),(13,'EUROFINS DO BRASIL ANALISES DE ALIMENTOS LTDA.','04329668000138','RODOVIA ENGENHEIRO ERMENIO DE OLIVEIRA PENTEADO, TOMBADOURO - INDAIATUBA - SP','Pesquisa e desenvolvimento experimental em ciências físicas e naturais'),(14,'FOR MEDICAL VENDAS E ASSISTENCIA TECNICA LTDA','65591695000179','AV PIERRE SIMON DE LAPLACE, TECHNO PARK - CAMPINAS - SP','Comércio atacadista de máquinas, aparelhos e equipamentos para uso odonto-médico-hospitalar; partes '),(15,'T&E ANALITICA - CENTRO DE PESQUISAS, DESENVOLVIMENTOS, ANALISES E CONSULTORIA QUIMICA, BIOLOGICA E F','04202583000194','RUA LAURO VANNUCCI, JARDIM SANTA CANDIDA - CAMPINAS - SP','Pesquisa e desenvolvimento experimental em ciências físicas e naturais');
/*!40000 ALTER TABLE `stores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'store_c'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-08-20 11:16:03
