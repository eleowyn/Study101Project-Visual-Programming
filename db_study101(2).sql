-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 24, 2024 at 02:58 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_study101`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_brainhack`
--

CREATE TABLE `tbl_brainhack` (
  `brainhack_id` int(11) NOT NULL,
  `brainhack_pomodoro` time NOT NULL,
  `brainhack_flashcard` varchar(300) NOT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_calender`
--

CREATE TABLE `tbl_calender` (
  `calender_id` int(11) NOT NULL,
  `calender_title` varchar(30) NOT NULL,
  `calender_content` varchar(500) NOT NULL,
  `user_id` int(11) NOT NULL,
  `calender_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_diary`
--

CREATE TABLE `tbl_diary` (
  `diary_id` int(11) NOT NULL,
  `diary_title` varchar(30) NOT NULL,
  `diary_content` varchar(1000) NOT NULL,
  `user_id` int(11) NOT NULL,
  `diary_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_diary`
--

INSERT INTO `tbl_diary` (`diary_id`, `diary_title`, `diary_content`, `user_id`, `diary_date`) VALUES
(1, 'elshera\'s first diary', 'testtt', 1, '2024-10-24 20:32:49');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_scoree`
--

CREATE TABLE `tbl_scoree` (
  `subjectID` int(11) NOT NULL,
  `task_name` int(11) NOT NULL,
  `Score` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_subjects`
--

CREATE TABLE `tbl_subjects` (
  `subject_id` int(11) NOT NULL,
  `subject_name` varchar(30) NOT NULL,
  `subject_type` varchar(30) NOT NULL,
  `assignment_score` int(11) NOT NULL,
  `quiz_score` int(11) NOT NULL,
  `midterm_score` int(11) NOT NULL,
  `final_score` int(11) NOT NULL,
  `project_score` int(11) NOT NULL,
  `test_score` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_task`
--

CREATE TABLE `tbl_task` (
  `task_id` int(11) NOT NULL,
  `task_title` varchar(30) NOT NULL,
  `task_duedate` datetime NOT NULL,
  `task_status` varchar(30) NOT NULL,
  `task_todo` varchar(30) NOT NULL,
  `user_id` int(11) NOT NULL,
  `task_type` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_task`
--

INSERT INTO `tbl_task` (`task_id`, `task_title`, `task_duedate`, `task_status`, `task_todo`, `user_id`, `task_type`) VALUES
(2, 'hci-figma', '2024-10-24 00:00:00', '', '', 1, 'Assignments');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE `tbl_user` (
  `user_id` int(11) NOT NULL,
  `user_name` varchar(30) NOT NULL,
  `usere_email` varchar(30) NOT NULL,
  `user_password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`user_id`, `user_name`, `usere_email`, `user_password`) VALUES
(1, 'elshera', 'elshera.dahlan@gmail.com', 'elshera18'),
(2, 'a', 'a', 'a');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_brainhack`
--
ALTER TABLE `tbl_brainhack`
  ADD PRIMARY KEY (`brainhack_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `tbl_calender`
--
ALTER TABLE `tbl_calender`
  ADD PRIMARY KEY (`calender_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `tbl_diary`
--
ALTER TABLE `tbl_diary`
  ADD PRIMARY KEY (`diary_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `tbl_subjects`
--
ALTER TABLE `tbl_subjects`
  ADD PRIMARY KEY (`subject_id`);

--
-- Indexes for table `tbl_task`
--
ALTER TABLE `tbl_task`
  ADD PRIMARY KEY (`task_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `tbl_user`
--
ALTER TABLE `tbl_user`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_brainhack`
--
ALTER TABLE `tbl_brainhack`
  MODIFY `brainhack_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_calender`
--
ALTER TABLE `tbl_calender`
  MODIFY `calender_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_diary`
--
ALTER TABLE `tbl_diary`
  MODIFY `diary_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tbl_subjects`
--
ALTER TABLE `tbl_subjects`
  MODIFY `subject_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_task`
--
ALTER TABLE `tbl_task`
  MODIFY `task_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_user`
--
ALTER TABLE `tbl_user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbl_brainhack`
--
ALTER TABLE `tbl_brainhack`
  ADD CONSTRAINT `tbl_brainhack_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `tbl_user` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tbl_calender`
--
ALTER TABLE `tbl_calender`
  ADD CONSTRAINT `tbl_calender_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `tbl_user` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tbl_diary`
--
ALTER TABLE `tbl_diary`
  ADD CONSTRAINT `tbl_diary_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `tbl_user` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tbl_task`
--
ALTER TABLE `tbl_task`
  ADD CONSTRAINT `tbl_task_ibfk_1` FOREIGN KEY (`task_id`) REFERENCES `tbl_user` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
