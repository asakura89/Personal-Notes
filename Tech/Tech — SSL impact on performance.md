---
tags:
- Tech
date: 2023-12-09
---

# SSL impact on performance

Enabling SSL (Secure Sockets Layer) on an application can have some impact on CPU and memory utilization, but the extent of this impact can vary based on several factors. 

SSL involves the process of encrypting and decrypting data, which can consume CPU resources. However, modern computers and servers are typically equipped to handle this without major delays¹. In fact, Google reported that on their production frontend machines, SSL/TLS accounted for less than 1% of the CPU load, less than 10 KB of memory per connection, and less than 2% of network overhead¹.

The impact can also depend on the nature of your application. For example, if your application establishes a lot of short-lived connections, the SSL handshake (which is where the more computationally expensive asymmetric cryptography happens) can add significant overhead². On the other hand, for long-lived connections, this overhead is less significant².

It's also worth noting that many modern CPUs offer hardware acceleration for cryptographic tasks, which can help mitigate the impact of enabling SSL¹.

In summary, while enabling SSL can have some impact on CPU and memory utilization, this impact is generally minimal with modern hardware and can be further mitigated with appropriate configuration and optimization strategies. However, the exact impact can vary based on the specifics of your application and infrastructure.

Source: Conversation with Bing, 12/9/2023
(1) Does the HTTPS protocol consume a lot of CPU time?. https://security.stackexchange.com/questions/127028/does-the-https-protocol-consume-a-lot-of-cpu-time.
(2) How much overhead does SSL impose? - Stack Overflow. https://stackoverflow.com/questions/548029/how-much-overhead-does-ssl-impose.
(3) Technical Note: High CPU and memory usage when when SSL deep inspection .... https://community.fortinet.com/t5/FortiGate/Technical-Note-High-CPU-and-memory-usage-when-when-SSL-deep/ta-p/198110.
(4) Resource Utilization – Kemp Support. https://support.kemptechnologies.com/hc/en-us/articles/203127209-Resource-Utilization.
(5) undefined. https://istlsfastyet.com.
