# Candidate Form Submission API

This project implements a simple API for candidates to submit their forms.
## Features

- **Insert**: Add a new candidate form first name, last name, and email.
- **Search**: Retrieve candidate information by ID or search for candidates within a range of IDs.
- **Delete**: Remove candidate information by ID.

## Requirements

- **.NET 8**: Ensure you have .NET 8 installed on your system.
- **IDE**: Rider (preferable) or Visual Studio.
- **Database**: PostgreSQL.

## Installation

1. Clone the repository to your local machine:
    ```sh
    git clone https://github.com/MirganiMirkurbonov/CandidateApp.git
    ```
2. Navigate to the project directory:
    ```sh
    cd CandidateApp
    ```

## Database Setup

1. Install PostgreSQL and ensure it's running.
2. Create a new database for the project:
    ```sql
    CREATE DATABASE candidate_form_db;
    ```
## Configuration

1. Open the project in your preferred IDE (Rider or Visual Studio).
2. Update the database connection string in the `appsettings.json` file:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=your_db;Username=your_username;Password=your_password"
      }
    }
    ```

## Usage

1. Compile and run the project:
    - In Rider or Visual Studio, build and start the project.
    - Alternatively, you can use the .NET CLI:
      ```sh
      dotnet build
      dotner ef migrations add 'nameOfMigration' // only first time runnning
      dotnet run
      ```

2. The API will be available at `http://localhost:7077`.

3. Use the following endpoints to interact with the API:

    - **Insert a candidate**:
        ```http
        POST /api/candidate/register
        Content-Type: application/json

        {
          "firstName": "John",               // Candidate's first name
          "lastName": "Doe",                 // Candidate's last name
          "phoneNumber": "998941234567",     // Candidate's phone number
          "startTimeInterval": "2024-01-01", // Candidate's available start date
          "endTimeInterval": "2024-01-01",   // Candidate's available end date
          "email": "test@gmail.com",         // Candidate's email address
          "githubProfileUrl": "github.com/your-url", // Candidate's GitHub profile URL
          "linkedinProfileUrl": "linkedin.com",      // Candidate's LinkedIn profile URL
          "comment": "test"                  // Additional comments about the candidate
        }
        ```
