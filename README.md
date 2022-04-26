# ServiceSimulationSystem

Project aim is build service simulation system that has flow of requests which are created by sources. Requests is taken by devices on work, if they are no free devices requests go in buffer, also if new requests haven't come we take requests from buffer.
Type of modeling system is "Special events method" (We move from one event to another simply increasing time).
Special events are: 
* arrive of new request, 
* time of free device,
* end of modeling.

## Technologies
- ASP .NET 6
- C# 10
- AutoMapper

## Architecture 
N-Layer Web API

## Used Design Patterns
1. Factory Pattern (Concrete implementation is chosen by input parameter)
2. Dependency Injection (DI)
