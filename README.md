# ASP.NET Core MVC Calculator App

This project is a simple calculator web application built from scratch using ASP.NET Core MVC and C#. It demonstrates the journey from setting up a .NET development environment in Visual Studio Code to building and running a working MVC web app.

## What It Does

- Provides a web interface to add or subtract two numbers.
- Uses MVC architecture:  
  - **Model:** (optional, for future enhancements)  
  - **View:** User-friendly web forms for input and result display  
  - **Controller:** Handles calculation logic and form submissions
- Demonstrates clean code, best practices, and job-ready coding techniques[2].

## How It Was Built

- Set up .NET SDK and Visual Studio Code as the development environment[3].
- Used the `dotnet` CLI to scaffold a new MVC project.
- Implemented a custom controller and view for calculator functionality.
- Used Git and GitHub for version control and sharing the project.

## How to Run

1. Clone this repository:
2. Navigate into the project directory:
3. Restore dependencies (if required):
4. Run the application:
5. Open your browser and go to [http://localhost:5298/](http://localhost:5298/) (or the URL shown in your terminal).

## Features

- Add two numbers via the web interface
- Subtract two numbers via the web interface

## Project Structure

- **Controllers/**: Handles user requests and calculator logic
- **Views/**: Contains user interface for input and result display
- **Models/**: (Optional, for future enhancements)

## Future Improvements

- Add multiplication and division features
- Input validation and error handling
- Improved UI/UX design
- Unit tests for controller logic

Feature: Calculation History
Overview
The calculator now includes a calculation history feature. Every time a calculation is performed, the operation and result are saved and displayed in a list below the calculator interface. This helps users keep track of their recent calculations during their session.

How It Works
Each time you perform a calculation (add, subtract, multiply, divide), the operation and result are added to the top of the history list.

The history is stored using session data, so it persists as long as your browser session is active.

The history list appears below the calculator form and updates automatically after each calculation.

Example
If you calculate:

5 + 3 = 8

10 × 2 = 20

Your calculation history will show:

text
10 × 2 = 20
5 + 3 = 8
Benefits
Improved user experience: Users can easily review previous calculations without re-entering data.

Session-based: History is cleared when the browser session ends, keeping data private and relevant.

Technical Notes
The history feature was implemented by updating the MVC model, controller, and view, and by using session storage to persist the list.

This update is tracked in Git with a commit message:
feat: add calculation history feature to calculator
## Author

- Ishit
 # Trigger deployment
