

### How to test the Apis 
- Use Postman/browser to run the following GET end points
```
    #all Api have the following Url pattern 
        http://domain-name.com/api/calculator/operation/comma-delimted-numbers

    # Below Api end points are available
    http://domain/api/calculator/add/1.7,0.9,2,6.8
    http://domain/api/calculator/subtract/1.7,0.9,2,6.8
    http://domain/api/calculator/multiply/1.7,0.9,2,6.8
    http://domain/api/calculator/divide/1.7,0.9,2,6.8

    # health-check
    http://domain/api/calculator

    # Response schema 
    {
        "result": "1.8888888888888888",
        "status": "Success/Error"
        "message": "some message"
    }
        null values are suppressed. 
```


### Application design 
- Application code is structured in typical .Net Web Api project structure
    - /Domain - contains the business logic(i.e calculations) and model classes
    - /Controllers - Host the API endpoints that invoke appropriate commands
    - /Commands - contain the commands for invocation
    - /Handlers - contain the command handlers which handle pre/post validation,data mapping and trigger the calculations in the Domain     
- Influenced by CQRS coding pattern. Refactored original code by applying Single Responsibility Principal and Dependency injection where possible. 
- Test Driven Development (Test first) 
    -/Calculator.Api.Tests - Contains the Unit Test cases for domain logic
- Serverless architecture
- Containerized app using Docker

### Tech stack and libraries used  
- .Net core web Api, xUnit with Fluent assertions for testing  
- Docker for containerization 
- AWS ECR for image repository and AWS Fargate cluster for running containers
- custom domain mapped to AWS Fargate container IP address

### Possible options or improvements
- Deploy as AWS Api Gateway - for simpler serverless deployment without containers 
- Command/Query using MediatR 
- Add JsonApi to use standardized schema for request/response instead of custom Json
- more usage of Dependency Injection to make the classes loosely coupled
- Handler can be refactored to share common code. 
- Automated Integration and component tests

### Notes 

- Suppress null attributes in serialized JSON
- Make ILogger available from dependency injection   
```
    # added following code to ConfigureServices(IServiceCollection services) method

    services.AddControllers()
                .AddJsonOptions( options => 
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.WriteIndented = true;
                });   // Global json serialization options
            services.AddLogging(); // Added to enable ILogger  
```

- double.NaN and double.infinity values are not allowed types in Json serialization
```
    # created string version of Result attribute and _Result used for application logic

        [JsonIgnore]
        public double _Result { get; set; }
        public string Result => _Result.ToString(); 
```

- Docker error while dotnet build - "suitable entry point with static Main not found" 

```
    Solution:
        Move the Dockerfile from Caclulator.Api folder to parent repo folder i.e butterly-coding-challenge 
```