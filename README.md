# SimpleMicroservice

## Introduction

**SimpleMicroservice** is a straightforward .NET microservice application designed to guide interns and students during their 3-week internship. This project illustrates how to effectively structure microservices for development.

## Technologies

This simple API utilizes the following **technologies** and **patterns**:

- **.NET 8**: The framework for developing the API
- **Clean Architecture**: Ensures separation of concerns for maintainability
- **MediatR**: Facilitates the development of domain logic
- **MySQL** and **PostgreSQL**: Used for data storage
- **FluentValidation**: Validates incoming requests
- **FastEndpoints**: Simplifies the creation of endpoints in all services
- **YARP**: A reverse proxy library serving as the API Gateway
- **Docker** and **Docker Compose**: Utilized for containerization and orchestration

## Installation

To get started with the SimpleMicroservice, follow these steps:

1. **Clone the repository**:

   ```bash
   git clone https://github.com/yourusername/SimpleMicroservice.git
   cd SimpleMicroservice

   ```

2. **Install dependencies**:
   ```bash
   dotnet restore
   ```
3. **Build solution**:
   ```bash
   dotnet build
   ```
4. **Run the application**
   ```bash
   docker-compose up
   ```

## Hot to run API

After successfully starting the application, you can access the API at http://localhost:8080

## Sample Endpoints

Here is a list of available endpoints:

- **POST** `/api/auth/register`

  - **Description**: Register a new user.

- **POST** `/api/auth/login`

  - **Description**: Login endpoint that returns access token in JWT format.

- **GET** `/api/products/{productId}`

  - **Description**: Endpoint to retrieve product by passed id. This endpoint is secured and requires JWT token.

- **POST** `/api/products`
  - **Description**: Create a new product. This endpoint is secured and requires JWT token
