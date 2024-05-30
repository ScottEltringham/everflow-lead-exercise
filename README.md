# CalorieWise

A .NET Core application with a Blazor UI to help users plan and review their meals based on a calorie-controlled diet where each day permits not more than 1800 calories.

## Table of Contents

- [About the Project](#about-the-project)
- [Getting Started](#getting-started)
- [Bugs and Limitations](#bugs-and-limitations)

## About the Project

### Overview

Everflow invites candidates for the Lead Developer role to undertake a technical exercise where you can illustrate your passion for Engineering Excellence.

### Objective

The objective is to demonstrate how to apply Engineering Excellence practices in a Product-led environment where software is delivered to Agile norms. The focus is on the processes followed, thought processes within the implementation, and providing confidence to users in the software products built.

### Deliverables

Build a new Product that allows users to plan and review their meals based on a calorie-controlled diet where each day permits not more than 1800 calories. The goal is not necessarily a completed software package but a demonstration of key engineering concerns within a balanced timeframe of two to three days.

## Getting Started

Instructions on setting up the project locally.

### Installation

1. Clone the repository
    ```sh
    git clone https://github.com/ScottEltringham/everflow-lead-exercise.git
    ```
2. Navigate to the project directory
    ```sh
    cd everflow-lead-exercise
    ```
3. Restore dependencies
    ```sh
    dotnet restore
    ```
4. Build the project
    ```sh
    dotnet build
    ```
5. Run the project
    ```sh
    dotnet run
    ```

## Bugs and Limitations

- **Bug:** Can't test more than one class at a time within the integration test project. You can test all methods within 1 class at a time
- **Limitation:** The user interface is currently missing the ability to add meals, although the endpoints within the API Project have been created and tests written.

Project Link: [https://github.com/ScottEltringham/everflow-lead-exercise](https://github.com/ScottEltringham/everflow-lead-exercise)
