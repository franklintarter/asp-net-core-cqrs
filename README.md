# asp-net-core-cqrs

A demo app to show an opinionated example of patterns and tools to do CQRS and Domain Driven Design in Asp.Net Core.

Since this is a very simple demo the level of complexity definitely looks like using a bazooka to kill a fly. The purpose is to attempt to use patterns and practices to solve some problems that will eventually grow out of hand in a truly complex app.

- Avoid Duplicate Validation Logic
- Avoid Anemic Domain Models
- Avoid Null Reference Exceptions
- Ensure Domain Objects Always Exist in a Valid State
- Fail Early and Loudly
- Easy To Test Domain Logic in Isolation

## Libraries Used

[Entity Framework Core](https://github.com/aspnet/EntityFrameworkCore)

[Fluent Validations](https://github.com/JeremySkinner/FluentValidation)

[CSharp Functional Extensions](https://github.com/vkhorikov/CSharpFunctionalExtensions)

[MediatR](https://github.com/jbogard/MediatR)

## Contributions

Please feel free to make suggestions or start a discussion about anything related to DDD or CQRS in .Net Core/Asp.Net Core, what are some other good librarys or other patterns that mesh well with CQRS? etc..

## TODO

- Create View Model
- Create Web App Example
