-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 12, 2022 at 08:26 PM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 8.0.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `don2loot`
--

-- --------------------------------------------------------

--
-- Table structure for table `chest`
--

CREATE TABLE `chest` (
  `chestName` char(60) NOT NULL,
  `chestPrice` int(11) NOT NULL,
  `rarityTypeDrop1` int(11) NOT NULL,
  `rarityTypeDrop2` int(11) NOT NULL,
  `rarityTypeDrop3` int(11) NOT NULL,
  `rarityTypeDrop4` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `reward`
--

CREATE TABLE `reward` (
  `rewardId` int(11) NOT NULL,
  `isUnlocked` tinyint(1) NOT NULL,
  `rewardImage` blob NOT NULL,
  `rewardRarity` char(50) NOT NULL,
  `chestName` char(60) NOT NULL,
  `rewardName` char(30) NOT NULL,
  `userEmail` char(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `task`
--

CREATE TABLE `task` (
  `taskId` int(11) NOT NULL,
  `taskName` char(60) NOT NULL,
  `taskDescription` char(255) NOT NULL,
  `taskDeadline` date NOT NULL,
  `isFinished` tinyint(1) NOT NULL,
  `userEmail` char(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `userName` char(50) NOT NULL,
  `userSignature` blob NOT NULL,
  `userStreak` int(11) NOT NULL,
  `userCoins` int(11) NOT NULL,
  `userEmail` char(60) NOT NULL DEFAULT 'new value'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `chest`
--
ALTER TABLE `chest`
  ADD PRIMARY KEY (`chestName`);

--
-- Indexes for table `reward`
--
ALTER TABLE `reward`
  ADD PRIMARY KEY (`rewardId`),
  ADD KEY `chestName` (`chestName`),
  ADD KEY `userEmail` (`userEmail`);

--
-- Indexes for table `task`
--
ALTER TABLE `task`
  ADD PRIMARY KEY (`taskId`),
  ADD KEY `userEmail` (`userEmail`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userEmail`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `task`
--
ALTER TABLE `task`
  MODIFY `taskId` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `reward`
--
ALTER TABLE `reward`
  ADD CONSTRAINT `reward_ibfk_1` FOREIGN KEY (`chestName`) REFERENCES `chest` (`chestName`),
  ADD CONSTRAINT `reward_ibfk_2` FOREIGN KEY (`userEmail`) REFERENCES `user` (`userEmail`);

--
-- Constraints for table `task`
--
ALTER TABLE `task`
  ADD CONSTRAINT `task_ibfk_1` FOREIGN KEY (`userEmail`) REFERENCES `user` (`userEmail`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
