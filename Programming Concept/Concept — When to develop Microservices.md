---
tags:
- Research
- Concept
date: 2023-12-17
---

# When to develop Microservices

## TL;DR

Ketika developer-nya udah aware kalo develop microservices bukan nambah keren tapi nambah complexity



## The Long Read

Here are the key considerations for when to develop microservices:

- **Organizational Clarity**: When a company seeks to have independent development teams with minimal blockers, microservices can offer a structure where teams own the full development cycle, reducing dependencies on other teams.
- **Technical Modularity**: If the goal is to create small, independently deployable modules with well-defined interfaces, microservices can provide the necessary architecture to support this modularity.
- **System Scalability**: Microservices are beneficial when the system needs to scale in response to changing loads, as they allow for identifying and resolving bottlenecks at the individual service level¹[1].
- **Integration Simplicity**: When there's a need for a common architectural backplane with clear integration and communication conventions, microservices can simplify the process of connecting different parts of a system²[2].

These points suggest that microservices are suitable when an organization aims for a modular, scalable, and integrated system with clear team responsibilities.


_The key is to establish that common architectural backplane with well-understood integration and communication conventions, whatever you want or need it to be._

_Microservices make it easier to identify scaling bottlenecks and then resolve those bottlenecks at a per-microservice level._


**References:**

- [You Want Modules, Not Microservices (newardassociates.com)](https://blogs.newardassociates.com/blog/2023/you-want-modules-not-microservices.html)


Please be aware of this

Debugging microservices can be challenging due to their distributed architecture. However, there are several best practices that can help you with setting up a proper debugging workflow for your microservices application 1. One of the best practices is to generate a unique ID for each request to trace microservices 1. Here are the steps to follow:

1. Implement microservices logging.
2. Complement logging with crash reporting.
3. Generate a unique ID for each request to trace microservices.
4. Prepare each microservice for accepting and storing request IDs.
5. Create and implement your own logging patterns.
6. Use a logging framework.
7. Store all your logs in a single database.
8. Consider time-series databases (TSDBs).
9. Use an application performance monitoring tool.

The simplest solution is to generate a unique “correlation” ID that will follow all requests. There are several ways to implement this solution. For example, an “edge” service that initiates interactions with all internal microservices can generate the ID. Alternatively, microservices can generate the ID on any call that does not have an ID 1.

- https://raygun.com/blog/best-practices-microservices/
- https://stackify.com/microservice-logging/
- https://medium.com/@scokmen/debugging-microservices-part-ii-the-correlation-identifier-552f9016afcd