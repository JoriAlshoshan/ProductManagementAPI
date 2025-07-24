# ProductManagementAPI
A clean and lightweight ASP.NET Core Web API for managing product data with full CRUD operations, Swagger documentation, and custom middleware for logging, profiling, and rate limiting.

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

## Product Schema

The product entity includes basic properties such as ID, Name, and other relevant product details.

## Additional Information

- The project uses Swagger UI for API documentation and testing, accessible at:  
  `https://localhost:7124/swagger/index.html`

- The database used is SQL Server, managed through SQL Server Management Studio.

- Custom Filters and Middlewares are implemented for logging, action tracking, request profiling, and rate limiting.

---

## Filters

- **LogActivityFilter**: Logs detailed information before and after executing controller actions, including action name, controller, and input arguments. It supports both synchronous and asynchronous execution to ensure comprehensive logging.

- **LogSensitiveActionAttribute**: A simple action filter that flags execution of sensitive actions for debugging or auditing purposes.

---

## Middlewares

- **ProfilingMiddleware**: Measures and logs the time taken to process each HTTP request, helping to monitor performance.

- **RateLimitingMiddleware**: Controls the rate of incoming requests by limiting the number of requests processed within a specified time window to prevent abuse.

---

## How to Use

1. Clone the repository and open the project in Visual Studio.  
2. Update the connection string in `appsettings.json` according to your database setup.  
3. Run the project.  
4. Access the Swagger UI to test the API via a browser.  
5. You can also use tools like Postman to test the endpoints.

---

## Project Purpose

To demonstrate how to build a simple API using ASP.NET Core Web API with full CRUD support and interactive documentation via Swagger, enhanced with logging, action tracking, performance profiling, and rate limiting features.

---

© 2025 Jori Alshoshan
