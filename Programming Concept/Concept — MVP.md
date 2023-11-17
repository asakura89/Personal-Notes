---
tags:
- Concept
- Draft
date: 2023-11-11
---

# MVP

<!--

**Introduction**

This document introduces the Model-View-Presenter (MVP) programming model, which is a way of designing and developing software applications. MVP is based on a more general version of the Model-View-Controller (MVC) model, which was first used in Smalltalk, a programming language. MVP helps programmers to separate the different aspects of their applications, such as data management, user interface, and business logic. This makes the applications easier to understand, modify, reuse, and test. MVP also supports different kinds of applications, such as stand-alone, component-based, client/server, and multi-tier. MVP is implemented by Taligent and IBM in their Open Class libraries for C++ and Java.



**MVP Concepts**

MVP consists of six main concepts: Model, View, Selection, Command, Interactor, and Presenter. Each concept represents a question that the programmer needs to answer when creating an application. The questions are:

- Model: What is my data?
- View: How do I display my data?
- Selection: How do I specify my data?
- Command: How do I change my data?[^10^]
- Interactor: How do events map into changes in my data?
- Presenter: How do I put it all together?

The Model is the part of the application that stores and manages the data. The data can be anything, such as numbers, text, images, or sounds. The Model also provides methods to access and modify the data. The Model can be local or remote, persistent or transient, shared or private.

The View is the part of the application that shows the data to the user. The View can be graphical, such as a window, a button, or a chart. The View can also be non-graphical, such as a sound, a vibration, or a valve. The View can have multiple or no presentations of the same data.

The Selection is the part of the application that defines a subset of the data. The Selection can be a single element, a group of elements, or the entire data. The Selection can also be continuous or discontinuous, such as a range, a list, or a pattern. The Selection can be used to highlight, copy, or manipulate the data.

The Command is the part of the application that performs an operation on the data. The Command can be simple or complex, such as adding, deleting, sorting, or calculating. The Command can also be undoable, redoable, scriptable, or distributable. The Command can be applied to different selections of the data.

The Interactor is the part of the application that handles the user input. The Interactor can be a mouse, a keyboard, a pen, a voice, or a sensor. The Interactor can recognize different gestures, events, and actions, such as clicking, dragging, typing, or speaking. The Interactor can map the user input to the appropriate commands for the data.

The Presenter is the part of the application that coordinates the other parts. The Presenter is responsible for creating and connecting the models, views, selections, commands, and interactors. The Presenter also provides the business logic that determines what happens when, such as validating, updating, or notifying. The Presenter can be thin or fat, depending on how much logic is on the client or the server side.


**MVP Frameworks**

MVP is implemented by using object-oriented frameworks, which are reusable software components that provide common functionality and behavior. Taligent and IBM provide different frameworks for each of the MVP concepts, as well as for other aspects of software development, such as components, notifications, and internationalization. The frameworks can be used separately or together, and can be customized by subclassing and overriding their methods. The frameworks also support portability, compatibility, and scalability across different platforms, standards, and architectures.



**MVP Examples**

MVP can be used to create a variety of applications, from simple to complex, from graphical to non-graphical, from stand-alone to distributed. To illustrate the benefits of MVP, the document uses a simple example of a calculator application, and shows how it can be enhanced by using different MVP concepts and frameworks. The document also shows how different client/server architectures can be modeled by using MVP, and how they correspond to popular and familiar solutions, such as file servers, databases, web applications, and distributed objects. The document concludes that MVP is a fundamental and expressive design pattern for applications development.

-->

**References:**

- [mvp.pdf (wildcrest.com)](http://www.wildcrest.com/Potel/Portfolio/mvp.pdf)