---
tags:
- Research
- Learn
- Draft
date: 2023-02-26
---

# Troubleshooting Code

Debugging is an act to track down programming errors

1. Code tracing
2. Diagnostics
3. Instrumentation
4. Profiling



## Code tracing

1. Write trace information (tracing the code)
    1.1. A form of logging
    1.2. Used for debugging purposes
    1.3. Output information at runtime
    1.4. Information stored in trace logs (refer to: [Concept — Logging](/Programming%20Concept/Concept%20%E2%80%94%20Logging.md))

2. Diagnose errors
    2.1. Code defensively recover from errors
    2.2. Add logging code to error handlers
    2.3. Triggered by error condition in the application

3. Measure app performance
    3.1. App performance
    3.2. Determine general app trends
    3.3. Disk reads, CPU consumption, Memory consumption, Db reads, etc
    3.4. Integrate with Windows perf counters
        3.4.1. Memory use, active threads, etc
        3.4.2. Add some standard perf counters to the app
        3.4.3. Windows monitor all counters in running app
        3.4.4. Use performance Monitor to show results

4. Profile code construct
    4.1. Shows how fast your code runs
    4.2. Shows whether code ran (code coverage)
    4.3. You should profile every method in every code line



## Instrumentation

1. Analyze app while runing
2. App binaries modified with diagnostics code
3. Intrumentation shipped with final binaries



## Debug (High level debugging)

1. Use debug symbols or source map files
2. Use remote debugging
3. Use crash dumps information



## Defect categories

1. Syntax errors
2. Unhandled runtime exceptions
3. Calculation errors
4. Timing issues, needs to wait some time
5. Performance issues
6. Component version mismatch
7. User interface errors



## Visual Studio (Low level debugging)

### Analyze logic flow

1. Use breakpoints
2. Use conditional breakpoints
3. Use Call-stack (optional to breakpoints step-through)



### Analyze variable/data values

1. Use Watch window
2. Use Locals window
3. Use Data visualizer



### Analyze performance and hidden logic flow

1. Use Diagnostic tools

