
# Result Pattern NuGet Package

This NuGet package provides a simple and extensible Result pattern implementation to handle the return of either a successful value or an error. It's designed to improve code readability and manage error handling in a functional style. The Result<TValue, TError> type offers a way to work with two possible outcomes: success (value) or failure (error).

This package will help you handle errors in a clean and structured way, avoiding exceptions for control flow, and using explicit success and error handling.

## Key Features


* Generic Result Type: Allows returning a result with a success value of type TValue or an error of type TError.
* Implicit Conversion: Automatically converts values to a success result or errors to an error result.
* Error Handling: Supports both success and failure result handling using the Match() method, with or without custom success/failure actions.
* Readability: Makes it easier to work with multiple outcomes while avoiding complex try-catch blocks or null checks.

## Instalação

To install the package via NuGet, run the following command in your .NET project:

```bash
  dotnet add package ResultPattern
```
Or use the NuGet Package Manager:
```bash
  Install-Package ResultPattern
```
    
## Usage

## 1 - Returning a Result

```bash
  public Result<int, MyError> DoSomething()
{
    if (operationSucceeded)
    {
        return 42; // Implicitly creates a success result.
    }
    else
    {
        return new Error(System.Net.HttpStatusCode.BadRequest, "Operattion Failed"); // Implicitly creates an error result.
    }
}
```
## 2 - Handling the Result

You can handle the result using the Match() method, which provides two overloads for error and success processing.

Example 1: Default Match
```bash
var result = DoSomething();
return result.Match(); // Will return a `200 OK` with the value, or a `ContentResult` with an error message and status code defined previous.
```

Example 2: Custom Match
```bash
var result = DoSomething();
return result.Match(
    success => Results.Ok(success),
    error => Results.Problem(detail: error.Message, statusCode: (int)error.StatusCode)
);
```

## Contributing
Feel free to submit issues, pull requests, or feature requests to improve this package. Contributions are welcome!

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Author
This package was developed and maintained by Pedro Ventura.