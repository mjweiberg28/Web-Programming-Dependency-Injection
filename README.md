# Web-Programming-Dependency-Injection
Assignment 6 for Bethel University Fall 2019's Web Programming course

This assignment was mostly premade by the professor of the course, Steven Yackel.
However, he gave it to me containing many dependencies and it was my task to
remove those dependencies using dependency injection.

I was given 4 bad service dependencies in the code, of which were contained in:
- MemoryDatabase
  - HobbitController keeps track of a list of hobbits in a database, but it was
  coupled with MemoryDatabase. I updated the controller so it receives an instance
  of an IDatabase in the constructor.
  - I created an IDatabase interface based on the MemoryDatabase class, so there
  would only ever be one instance of MemoryDatabase created for the lifetime of the
  application.
- ConsoleLogger
  - ConsoleLogger is a singleton class, so I created an ILogger interface based on
  the ConsoleLogger class and updated all references to ConsoleLogger to depend on
  and use ILogger instead.
- RequestIdGenerator
  - I created an IRequestIdGenerator interface based on the RequestIdGenerator class
 , so that a new IRequestIdGenerator instance is only created once per request.
  - RequestIdFilter was updated so it depends on an IRequestIdGenerator and uses it
  to add a real request id to the request-id header.
- StopWatchService
  - Updated all references to StopWatchService so that during a request, all
  references share the same instance.
