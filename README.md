# MyProject 
## Project Description: This project is developed using .NET 7 Core and includes a REST API interface. The goal is to provide secure and well-monitored APIs for data management. 
## Key Features - Developed using .NET 7 Core and REST API technologies.
- Stringent validations using the zxcvbn library for password strength.
- The project is divided into three layers (Layers) that use DI (Dependency Injection) to maintain encapsulation.
- Uses Entity Framework ORM with DB First approach. Code First can be run.
- Extensive use of async and await for every function to ensure scalability.
- Data insertion was done in a separate project: webApi_manager. - Documented using Swagger.
- DTO layer to maintain data integrity. - Conversions are done using AutoMapper.
- Configuration files are used to handle environment-specific settings.
- Proper error handling: Server-side errors are caught, emails are sent, and they are logged in a separate file.
- Traffic is monitored in a rating table to analyze the service. - Uses HTTPS protocol for all communications.
- Product prices are retrieved directly from the DB.
- Added a testing project including Unit Tests and Integration Tests.
## Installation `bash git clone https://github.com/user/MyProject.git cd MyProject dotnet restore `
## Running the Project `bash dotnet run ` ## Testing `bash dotnet test ` 
## Using Swagger After running the project, you can access Swagger for API documentation and testing at: ` http://localhost:{PORT}/swagger ``` 
## Contributing This project is open for contributions. You can submit Pull Requests and open Issues on the GitHub page. 
## License This project is protected under copyright laws according to the attached license. Find more information in the LICENSE file.
