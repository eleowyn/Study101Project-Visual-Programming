-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 08, 2024 at 11:06 AM
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
  `user_id` int(11) NOT NULL,
  `usersession` int(11) NOT NULL
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
  `calender_date` date NOT NULL,
  `usersession` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_calender`
--

INSERT INTO `tbl_calender` (`calender_id`, `calender_title`, `calender_content`, `user_id`, `calender_date`, `usersession`) VALUES
(15, 'vispro', 'Sample Content', 1, '2024-10-29', 0),
(16, 'visproo', 'Sample Content', 1, '2024-10-29', 0),
(18, 'presentasi-hci', 'Sample Content', 1, '2024-11-12', 0),
(19, 'presentasi-vispro', 'Sample Content', 2, '2024-11-13', 0),
(21, 'mama pe ultah', 'Sample Content', 2, '2024-11-25', 0),
(22, 'oma pe ultah', 'Sample Content', 1, '2024-11-11', 0),
(24, 'presentasi hci', 'Sample Content', 2, '2024-11-12', 0);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_diary`
--

CREATE TABLE `tbl_diary` (
  `diary_id` int(11) NOT NULL,
  `diary_title` varchar(30) NOT NULL,
  `diary_content` varchar(1000) NOT NULL,
  `user_id` int(11) NOT NULL,
  `diary_date` datetime NOT NULL,
  `usersession` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_diary`
--

INSERT INTO `tbl_diary` (`diary_id`, `diary_title`, `diary_content`, `user_id`, `diary_date`, `usersession`) VALUES
(2, 'presentasi', 'vispro', 1, '2024-10-28 13:57:19', 0),
(4, 'blabla', 'p', 1, '2024-11-06 11:52:28', 0),
(5, 'first diary', 'hiiiiiii my name is elshera dahlan and this is my 99% my project almost done hihi, and please pray for me for the next 6 projects hahaha', 2, '2024-11-08 17:28:39', 0);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_score`
--

CREATE TABLE `tbl_score` (
  `score_id` int(11) NOT NULL,
  `task_name` varchar(255) DEFAULT NULL,
  `score` float DEFAULT NULL,
  `subject_type` varchar(50) DEFAULT NULL,
  `subject_name` varchar(255) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `usersession` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_score`
--

INSERT INTO `tbl_score` (`score_id`, `task_name`, `score`, `subject_type`, `subject_name`, `user_id`, `usersession`) VALUES
(29, 'CRUD', 100, 'Quiz', 'visual programming', 2, 0),
(30, 'CRUD', 100, 'Quiz', 'visual programming', 2, 0),
(31, 'CRUD', 100, 'Quiz', 'visual programming', 2, 0),
(32, 'CRUD', 100, 'Quiz', 'visual programming', 2, 0),
(35, 'project final', 100, 'Project', 'hci', 2, 0),
(36, 'project akhir', 100, 'Final', 'hci', 2, 0),
(37, 'tugas1', 90, 'Assignment', 'hci', 2, 0),
(38, 'individual', 90, 'Final', 'front-end', 2, 0);

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
  `test_score` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `usersession` int(11) NOT NULL,
  `quiz_weight` float NOT NULL,
  `test_weight` float NOT NULL,
  `mid_weight` float NOT NULL,
  `final_weight` float NOT NULL,
  `project_weight` float NOT NULL,
  `assignment_weight` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_subjects`
--

INSERT INTO `tbl_subjects` (`subject_id`, `subject_name`, `subject_type`, `assignment_score`, `quiz_score`, `midterm_score`, `final_score`, `project_score`, `test_score`, `user_id`, `usersession`, `quiz_weight`, `test_weight`, `mid_weight`, `final_weight`, `project_weight`, `assignment_weight`) VALUES
(9, 'visual programming', '', 0, 0, 0, 0, 0, 0, 1, 0, 10, 10, 10, 50, 0, 20),
(10, 'hci', '', 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 50, 0, 50),
(12, 'front-end', '', 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 30, 30, 30);

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
  `task_type` varchar(50) NOT NULL,
  `usersession` int(11) NOT NULL,
  `is_completed` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_task`
--

INSERT INTO `tbl_task` (`task_id`, `task_title`, `task_duedate`, `task_status`, `task_todo`, `user_id`, `task_type`, `usersession`, `is_completed`) VALUES
(12, 'ito pe ultah', '2024-11-18 00:00:00', '', '', 1, '', 0, 0),
(17, 'feffefef', '2024-11-07 00:00:00', '', '', 2, '', 0, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE `tbl_user` (
  `user_id` int(11) NOT NULL,
  `user_name` varchar(30) NOT NULL,
  `user_email` varchar(30) NOT NULL,
  `user_password` varchar(20) NOT NULL,
  `user_username` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`user_id`, `user_name`, `user_email`, `user_password`, `user_username`) VALUES
(1, 'elshera', 'elshera.dahlan@gmail.com', 'elshera18', 'elsherawyn'),
(2, 'a', 'a', 'd', 'a'),
(4, 'elshera dahlan', 'elshera.dahlan@gmail.com', 'el', 'elsherawynn');

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
-- Indexes for table `tbl_score`
--
ALTER TABLE `tbl_score`
  ADD PRIMARY KEY (`score_id`);

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
  MODIFY `calender_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `tbl_diary`
--
ALTER TABLE `tbl_diary`
  MODIFY `diary_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `tbl_score`
--
ALTER TABLE `tbl_score`
  MODIFY `score_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT for table `tbl_subjects`
--
ALTER TABLE `tbl_subjects`
  MODIFY `subject_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `tbl_task`
--
ALTER TABLE `tbl_task`
  MODIFY `task_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `tbl_user`
--
ALTER TABLE `tbl_user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

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
  ADD CONSTRAINT `fk_user_id` FOREIGN KEY (`user_id`) REFERENCES `tbl_user` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
