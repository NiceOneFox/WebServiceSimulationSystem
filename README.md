# ServiceSimulationSystem

Project aim is build service simulation system that has flow of requests which are created by sources. Requests is taken by devices on work, if they are no free devices requests go in buffer, also if new requests haven't come we take requests from buffer.


## Technologies
- ASP .NET 6
- C# 10

## Architecture 
N-Layer Web API

## Used Design Patterns
1. Factory Pattern (Concrete implementation chose by input parameter and provided by IoC)
2. Dependency Injection (DI)
