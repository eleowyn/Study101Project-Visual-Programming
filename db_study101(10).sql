-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 24, 2024 at 10:32 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

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
(22, 'oma pe ultah', 'Sample Content', 1, '2024-11-11', 0),
(25, 'mom\'s birthday', 'Sample Content', 2, '2024-11-25', 0);

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
(3, 'diary pertama', 'testing diary - for visual programming project', 2, '2024-11-06 11:51:35', 0),
(4, 'blabla', 'p', 1, '2024-11-06 11:52:28', 0),
(5, 'test', 'testing project - testing project', 3, '2024-11-18 09:13:05', 0),
(6, 'blabla', 'so gygyof  jfoijfcije', 2, '2024-11-18 12:59:38', 0);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_flashcard`
--

CREATE TABLE `tbl_flashcard` (
  `user_id` int(11) NOT NULL,
  `question` varchar(200) NOT NULL,
  `answer` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_flashcard`
--

INSERT INTO `tbl_flashcard` (`user_id`, `question`, `answer`) VALUES
(2, 'presiden pertama indonesia', 'soekarno');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_score`
--

CREATE TABLE `tbl_score` (
  `score_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL,
  `subject_name` varchar(100) NOT NULL,
  `subject_type` varchar(50) NOT NULL,
  `task_name` varchar(100) NOT NULL,
  `score` decimal(5,2) DEFAULT 0.00,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_score`
--

INSERT INTO `tbl_score` (`score_id`, `subject_id`, `subject_name`, `subject_type`, `task_name`, `score`, `user_id`) VALUES
(11, 7, 'front-end', 'Assignment', 'tugas1', 100.00, 2),
(12, 8, 'hci', 'Assignment', 'tugas1', 100.00, 2),
(13, 8, 'hci', 'Assignment', 'tugas2', 100.00, 2);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_subjects`
--

CREATE TABLE `tbl_subjects` (
  `subject_id` int(11) NOT NULL,
  `subject_name` varchar(100) NOT NULL,
  `user_id` int(11) NOT NULL,
  `assignment_weight` decimal(5,2) DEFAULT 0.00,
  `quiz_weight` decimal(5,2) DEFAULT 0.00,
  `test_weight` decimal(5,2) DEFAULT 0.00,
  `mid_weight` decimal(5,2) DEFAULT 0.00,
  `final_weight` decimal(5,2) DEFAULT 0.00,
  `project_weight` decimal(5,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_subjects`
--

INSERT INTO `tbl_subjects` (`subject_id`, `subject_name`, `user_id`, `assignment_weight`, `quiz_weight`, `test_weight`, `mid_weight`, `final_weight`, `project_weight`) VALUES
(7, 'front-end', 2, 40.00, 0.00, 0.00, 30.00, 30.00, 0.00),
(8, 'hci', 2, 15.00, 15.00, 20.00, 25.00, 25.00, 0.00);

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
  `usersession` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_task`
--

INSERT INTO `tbl_task` (`task_id`, `task_title`, `task_duedate`, `task_status`, `task_todo`, `user_id`, `task_type`, `usersession`) VALUES
(12, 'ito pe ultah', '2024-11-18 00:00:00', '', '', 1, '', 0),
(16, 'presentasi vispro', '2024-11-18 00:00:00', '', '', 2, 'Assignment', 0),
(18, 'presentasi vispro', '2024-11-18 00:00:00', '', '', 3, 'Project', 0),
(19, 'presentasi web-design', '2024-11-18 00:00:00', '', '', 3, 'Project', 0),
(25, 'presentasi', '2024-11-18 00:00:00', '', '', 4, 'Assignment', 0),
(26, 'presentasi web design', '2024-11-24 00:00:00', '', '', 2, 'Exam', 0);

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
(2, 'elshera', 'a', 'a', 'a'),
(3, 'el', 'elsheraa@gmail.com', 'el', 'el'),
(4, 'elshera', 'elshera@gmail.com', 'el', 'lana'),
(5, 'elwyn', 'elshera@gmail.com', 'el', 'elwyn');

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
-- Indexes for table `tbl_flashcard`
--
ALTER TABLE `tbl_flashcard`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `tbl_score`
--
ALTER TABLE `tbl_score`
  ADD PRIMARY KEY (`score_id`),
  ADD KEY `subject_id` (`subject_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `tbl_subjects`
--
ALTER TABLE `tbl_subjects`
  ADD PRIMARY KEY (`subject_id`),
  ADD KEY `user_id` (`user_id`);

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
  MODIFY `calender_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `tbl_diary`
--
ALTER TABLE `tbl_diary`
  MODIFY `diary_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `tbl_flashcard`
--
ALTER TABLE `tbl_flashcard`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_score`
--
ALTER TABLE `tbl_score`
  MODIFY `score_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `tbl_subjects`
--
ALTER TABLE `tbl_subjects`
  MODIFY `subject_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `tbl_task`
--
ALTER TABLE `tbl_task`
  MODIFY `task_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `tbl_user`
--
ALTER TABLE `tbl_user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

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
-- Constraints for table `tbl_score`
--
ALTER TABLE `tbl_score`
  ADD CONSTRAINT `tbl_score_ibfk_1` FOREIGN KEY (`subject_id`) REFERENCES `tbl_subjects` (`subject_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `tbl_score_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `tbl_user` (`user_id`);

--
-- Constraints for table `tbl_subjects`
--
ALTER TABLE `tbl_subjects`
  ADD CONSTRAINT `tbl_subjects_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `tbl_user` (`user_id`);

--
-- Constraints for table `tbl_task`
--
ALTER TABLE `tbl_task`
  ADD CONSTRAINT `fk_user_id` FOREIGN KEY (`user_id`) REFERENCES `tbl_user` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
