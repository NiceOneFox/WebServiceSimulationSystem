# Service Simulation System (Queueing System)

Project aim is build service simulation system that has flow of requests which are created by sources. Requests is taken by devices on work, if they are no free devices requests go in buffer, also if new requests haven't come we take requests from buffer.
Type of modeling system is "Special events method" (We move from one event to another simply increasing time).
Special events are: 
* arrive of new request, 
* time of free device,
* end of modeling.

Results of moddeling represented by:
* Modeling time
* Amount of Generated requests
* Amount of Served requests
* Average probability of Maintenance ( P = N served / N total )
* Bandwidth of System ( A = N served / T modeling )
* Probability of Failure ( P failire of request = N declined / N total )

Input parameters:
* Number of Sources
* Number of Devices
* Buffer capacity
* Amount of requests
* Modeling time (max time)
* BufferType (Type of buffer modeling, FIFO, LIFO etc.)
* DeviceDirector (Type of choosing free device, circle etc.)
* Lambda for devices (amount of flow) parameter for Poissonian flow
* Lambda for sources

## Technologies
### Backend
- ASP .NET 6
- C# 10
- AutoMapper
- FluentValidation
- CORS
- NLog

### For testing
- NUnit
- Moq

### Frontend
- Angular

## Architecture 
N-Layer Web API

## Used Design Patterns
1. Factory Pattern (Concrete implementation is chosen by input parameter)
2. Builder Pattern (For constructing of algorithm)
3. Dependency Injection (DI)

