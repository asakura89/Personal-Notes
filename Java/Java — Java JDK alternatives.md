---
tags:
- Java
- License
- Alternative
date: 2022-07-28
---

# Java JDK alternatives

## List of alternative

- [Microsoft Build of OpenJDK](https://www.microsoft.com/openjdk)
- [OpenJDK](https://openjdk.org/)
- [AdoptOpenJDK - Open source, prebuilt OpenJDK binaries](https://adoptopenjdk.net/) (available with HotSpot VM and Eclipse OpenJ9 VM options)
- [Eclipse Temurin | Adoptium](https://adoptium.net/temurin/)
- [Azul Zulu Builds of OpenJDK](https://www.azul.com/downloads/?package=jdk#download-openjdk)
- [IBM Semeru Runtime (OpenJDK with Eclipse OpenJ9) - Resources and Tools - IBM Developer](https://developer.ibm.com/languages/java/semeru-runtimes/downloads/), [Explore options for downloading IBM Semeru Runtimes - IBM Developer](https://developer.ibm.com/articles/explore-options-for-downloading-ibm-semeru-runtimes/), [OpenJDK and IBM Runtimes for Business | IBM](https://www.ibm.com/cloud/support-for-runtimes)



## MSFT Build of OpenJDK

Microsoft Build of OpenJDK is one of no-cost alternatives to the Java runtime.



### Use HotSpot VM

While focused on cloud implementation for Azure, Microsoft Build of OpenJDK still using HotSpot VM. Other cloud-optimized VM as alternatives are:

- [GraalVM](https://www.graalvm.org/) from Oracle
- [Eclipse OpenJ9](https://www.eclipse.org/openj9/) from IBM originally and open-sourced to Eclipse Foundation
- [Azul Zulu Prime Builds of OpenJDK - Azul](https://www.azul.com/products/components/azul-zulu-prime-builds-of-openjdk/) from Azul (this is paid service and only available to Azul Platform Prime subscribers)



### JDK only

JRE must be manually built by using CI/CD pipeline provided.

References:

- [Will you provide a JRE? · Discussion #6 · microsoft/openjdk](https://github.com/microsoft/openjdk/discussions/6)



### No JavaFX support

But you can use OpenJFX from Oracle OpenJDK.

References:

- [Add JavaFX support in Microsoft OpenJDK? · Discussion #286 · microsoft/openjdk](https://github.com/microsoft/openjdk/discussions/286)
- [openjdk/jfx: JavaFX mainline development](https://github.com/openjdk/jfx)



### Differences between other OpenJDKs

At this time it will be mostly the same as others. But MSFT will focus for delivering the runtime for Azure and ARM architecture (this will includes Windows on ARM, Apple silicon, and Linux ARM).

There will be improvements in the future, but not all of those will be accepted upstream (Oracle OpenJDK). But differences will be marked clearly and released as part of MSFT Build of OpenJDK.

References:

- [What&#39;s so special about the Microsoft builds of OpenJDK? · Discussion #158 · microsoft/openjdk](https://github.com/microsoft/openjdk/discussions/158)
- [What&#39;s the difference between this and AdoptOpenJDK for users and developers? · Discussion #15 · microsoft/openjdk](https://github.com/microsoft/openjdk/discussions/15)
- [Question regarding OpenJ9 and Microsoft Differences · Discussion #54 · microsoft/openjdk](https://github.com/microsoft/openjdk/discussions/54)

