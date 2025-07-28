# ProductManagementAPI

A clean and lightweight ASP.NET Core Web API for managing product data with full CRUD operations, Swagger documentation, and custom middleware for logging, profiling, and rate limiting.

---

## API Endpoints

- **GET /Products**  
  Retrieves a list of all products.

- **POST /Products**  
  Creates a new product.

- **PUT /Products**  
  Updates an existing product.

- **GET /Products/{id}**  
  Retrieves details of a product by its ID.

- **DELETE /Products/{id}**  
  Deletes a product by its ID.

---

## Product Schema

The product entity includes basic properties such as ID, Name, and other relevant product details.

---

## Authentication and Authorization

The API implements authentication and authorization features to secure endpoints. You can test these using tools like Postman.

---

## Additional Features

- Swagger UI for API documentation and testing:  
  Accessible at `https://localhost:7124/swagger/index.html` when the project is running locally.

- SQL Server is used as the database, managed through SQL Server Management Studio.

- Custom Filters and Middlewares implemented:  
  - **Filters:**  
    - `LogActivityFilter`: Logs detailed information before and after controller actions.  
    - `LogSensitiveActionAttribute`: Flags sensitive actions for auditing.  
  - **Middlewares:**  
    - `ProfilingMiddleware`: Logs time taken for each HTTP request.  
    - `RateLimitingMiddleware`: Controls request rate to prevent abuse.

---

## How to Use

1. Clone the repository and open the project in Visual Studio.  
2. Update the connection string in `appsettings.json` according to your database setup.  
3. Run the project.  
4. Access Swagger UI to test the API via a browser.  
   
   > **Note:**  
   > The Swagger UI link works only when you run the project locally on your machine:  
   > `https://localhost:7124/swagger/index.html`  
   > To access the API documentation, make sure the project is running and accessible at this address.

5. Use tools like Postman to test authentication and authorization flows.

---

## Project Purpose

This project is developed for **educational purposes** to demonstrate how to build a simple yet well-structured ASP.NET Core Web API with full CRUD support, secured endpoints, and advanced features like logging and rate limiting.

---

© 2025 Jori Alshoshan
