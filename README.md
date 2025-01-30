# Personal_Website_Old_2020_NLayered

This project is an unfinished personal website created in 2020 using **ASP.NET Core**, **Entity Framework Core**, and a **N-layered architecture**. It was designed to serve as both a **portfolio** and a **blog** site. The repository utilizes jQuery for client-side scripting and incorporates **AutoMapper** for object-object mapping between layers.

## Solution Structure

The solution is broken down into multiple projects following a clean separation of concerns, making it modular and easier to maintain:

1. **PersonalWebsite.Data**  
   This project contains the **data access layer**. It manages all interactions with the database using **Entity Framework Core**. Key folders:
   - `Abstract`: Interfaces for repository patterns.
   - `Concrete`: Implementations of data repositories.
   - `Migrations`: Database migrations generated by Entity Framework.

2. **PersonalWebsite.Entities**  
   This project defines the core **entity models** and **DTOs** (Data Transfer Objects) shared across different layers. Key folders:
   - `Concrete`: Contains entity classes representing database tables.
   - `Dtos`: Contains data transfer objects used to expose or receive data between layers.

3. **PersonalWebsite.Mvc**  
   This is the **presentation layer** (the front-end of the application), implemented using **ASP.NET Core MVC**. It handles the views, controllers, and UI logic. Key folders:
   - `Areas`: Segmented areas of the site, such as admin or user sections.
   - `AutoMapper`: Configuration for mapping between entities and view models.
   - `Controllers`: Contains controllers that handle HTTP requests and responses.
   - `Models`: View models and related objects.
   - `Views`: Razor views for rendering HTML content.

4. **PersonalWebsite.Services**  
   The **business logic layer**, which contains services and business rules that interact between the presentation and data layers. Key folders:
   - `Abstract`: Interface definitions for business logic services.
   - `Concrete`: Implementations of service interfaces.
   - `AutoMapper`: AutoMapper profiles for object mappings.
   - `Extensions`: Extension methods used throughout the project.

5. **PersonalWebsite.Shared**  
   A project for shared resources and utilities across different layers. Key folders:
   - `Data`: Common data structures or utilities used across layers.
   - `Entities`: Shared entities across projects.
   - `Utilities`: Utility functions or helper methods.

## Technologies Used

- **ASP.NET Core**: Framework for building the web application.
- **Entity Framework Core**: ORM for database management and interaction.
- **N-Layered Architecture**: Separation of concerns into different projects and layers.
- **AutoMapper**: For object-object mapping between layers.
- **jQuery**: Enhances the front-end by providing client-side functionality and interaction.

## Features (Planned/Partially Implemented)

- **Portfolio Section**: Displays projects and achievements.
- **Blog Section**: Manages blog posts and articles.
