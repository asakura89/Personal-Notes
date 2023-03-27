---
tags:
- CSharp
- C#
date: 2020-06-28
---

# Type dari string

generate me .net code from scratch that can act as simple service bus

Sure, here's an example of how you can create a simple service bus in .NET using C# and the built-in messaging library, `System.Messaging`:

using System;
using System.Messaging;

namespace SimpleServiceBus
{
public class ServiceBus
{
private readonly string queueName;
private readonly MessageQueue messageQueue;

```
public ServiceBus(string queueName)
    {
        this.queueName = queueName;

        // Create a new message queue if it doesn't exist
        if (!MessageQueue.Exists(queueName))
        {
            messageQueue = MessageQueue.Create(queueName);
        }
        else
        {
            messageQueue = new MessageQueue(queueName);
        }

        // Set the formatter to JSON to enable serialization of custom objects
        messageQueue.Formatter = new JsonMessageFormatter();
    }

    public void SendMessage(object messageBody)
    {
        // Create a new message and set its body
        Message message = new Message(messageBody);

        // Send the message to the queue
        messageQueue.Send(message);
    }

    public object ReceiveMessage()
    {
        // Receive the next message from the queue
        Message message = messageQueue.Receive();

        // Deserialize the message body
        return message.Body;
    }
}
```

}

In this example, we define a `ServiceBus` class that can send and receive messages from a specified message queue. The constructor of the `ServiceBus` class creates a new message queue with the specified name if it doesn't already exist, and sets the formatter to `JsonMessageFormatter` to enable serialization of custom objects

in the messages.

The `SendMessage` method creates a new `Message` object with the specified `messageBody`, and sends it to the message queue using the `Send` method of the `MessageQueue` class.

The `ReceiveMessage` method receives the next message from the message queue using the `Receive` method of the `MessageQueue` class, and deserializes its body using the `Body` property of the `Message` class.

Here's an example of how you can use the `ServiceBus` class to send and receive messages:

using System;

namespace SimpleServiceBus
{
class Program
{
static void Main(string[] args)
{
// Create a new service bus with the queue name "MyQueue"
ServiceBus serviceBus = new ServiceBus("MyQueue");

```
// Send a message to the queue
        serviceBus.SendMessage(new { Name = "John", Age = 30 });

        // Receive the next message from the queue
        var message = serviceBus.ReceiveMessage();

        // Print the message body
        Console.WriteLine(message); // Output: { Name = "John", Age = 30 }
    }
}
```

}


In this example, we create a new `ServiceBus` object with the queue name "MyQueue", and send a message to the queue using the `SendMessage` method with an anonymous object containing the name and age of a person.

We then receive the next message from the queue using the `ReceiveMessage` method, and print its body to the console using the `Console.WriteLine` method.

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

what is storage used for built-in messaging library?

The built-in messaging library in .NET, `System.Messaging`, uses Microsoft Message Queuing (MSMQ) as the storage mechanism for messages.

MSMQ is a message queue implementation developed by Microsoft that allows applications to send and receive messages to and from each other asynchronously. It provides reliable message delivery and supports transactional messaging, which ensures that messages are processed atomically and consistently.

When using `System.Messaging`, messages are stored in MSMQ queues, which can be local or remote. Queues are created and managed by the operating system, and can be accessed by multiple applications running on the same or different machines.

The `System.Messaging` library provides a set of classes for sending and receiving messages to and from MSMQ queues, and supports various messaging patterns such as point-to-point, publish-subscribe, and request-reply. It also supports message filtering and priority, and allows for custom message formatters to be used for serialization and deserialization of message bodies.

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

is there any alternative storage than msmq?

Yes, there are alternative storage options available for message queuing in .NET other than MSMQ. Here are a few options:

1. RabbitMQ: RabbitMQ is a popular open-source message broker that implements the Advanced Message Queuing Protocol (AMQP). It supports multiple messaging patterns such as point-to-point, publish-subscribe, and request-reply, and provides features such as message routing, message acknowledgements, and message persistence.
2. Apache Kafka: Apache Kafka is a distributed streaming platform that can be used for messaging, data processing, and real-time analytics. It uses a publish-subscribe model and supports high-throughput, low-latency messaging, and message replay.
3. Azure Service Bus: Azure Service Bus is a cloud-based message broker service provided by Microsoft. It supports multiple messaging patterns such as point-to-point, publish-subscribe, and request-reply, and provides features such as message routing, message ordering, and message sessions.
4. Redis: Redis is an open-source, in-memory data structure store that can be used as a message broker. It supports publish-subscribe messaging, and provides features such as message persistence and message expiration.

These alternatives offer different features and benefits compared to MSMQ, so choosing the right one depends on the specific requirements of your application.

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

can I use traditional ms sql server?

Yes, it is possible to use Microsoft SQL Server as a storage mechanism for messaging in .NET, although it may not be the most efficient or scalable solution for high-throughput messaging scenarios.

One way to use SQL Server for messaging is to create a table to store the messages, and use SQL commands to insert, update, and retrieve messages from the table. This approach can work well for low to medium volume messaging, but may not be performant for high-volume messaging due to the overhead of the SQL Server database engine and the limitations of the database locking and transaction model.

Another way to use SQL Server for messaging is to use a message broker or message queue implementation that is built on top of SQL Server, such as SQL Server Service Broker or NServiceBus with SQL Server transport. These solutions provide a more efficient and scalable way to handle messaging with SQL Server, by leveraging its built-in features such as transactions, concurrency control, and query optimization.

However, it's worth noting that these solutions can be more complex to set up and maintain than MSMQ or other message brokers, and may require additional licensing or infrastructure costs for SQL Server. Therefore, it's important to evaluate the trade-offs between the different messaging solutions and choose the one that best meets the requirements of your application.

