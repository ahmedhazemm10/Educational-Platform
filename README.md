# 🎓 Educational Platform API

A comprehensive, secure, and scalable backend system for an Educational Platform built with **ASP.NET Core**. This API manages courses, lessons, student enrollments, and features an automated examination system with real-time grading.

## 🚀 Key Features

- **User Management:** Secure Register/Login using ASP.NET Core Identity.
- **Role-Based Access Control (RBAC):** Distinct permissions for **Admins** (Content Creators) and **Students**.
- **Course Management:** Full CRUD operations for Courses and Lessons.
- **Examination System:** - Admins can create exams with multiple-choice questions.
  - Automated grading logic upon student submission.
- **Enrollment System:** Students can enroll/unenroll in specific courses.
- **Profile & Tracking:** Students can track their grades and enrolled courses.
- **Standardized Responses:** All API responses follow a consistent `GeneralResponse<T>` format.

## 🛠️ Tech Stack

- **Framework:** .NET 8 / ASP.NET Core Web API
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Security:** JWT (JSON Web Tokens) & ASP.NET Identity
- **Patterns:** Repository Pattern & Service Layer Architecture
- **Documentation:** Swagger UI (OpenAPI)

## 🏗️ Database Schema

The system relies on a relational database designed for high integrity:
- **Users/Students**: Identity-managed accounts.
- **Courses/Lessons**: Core educational content.
- **Exams/Questions/Options**: The assessment engine.
- **Grades/Enrollments**: Tracking progress and participation.