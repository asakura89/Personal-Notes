---
tags:
- Powershell
- Directory
date: 2022-09-04
---

# List Directory

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

please help on generating powershell script with .net code to monitor website downtime

Certainly! Here's an example PowerShell script that uses .NET code to monitor website downtime:

```
# Define website URL to monitor
$websiteUrl = "http://example.com"

# Define timeout value in milliseconds
$timeout = 5000

# Create a new .NET object to handle HTTP requests
$request = [System.Net.WebRequest]::Create($websiteUrl)

# Set the request timeout value
$request.Timeout = $timeout

# Try to get the response from the website
try {
    $response = $request.GetResponse()
    Write-Output "Website is up and running"
} catch [System.Net.WebException] {
    $response = $_.Exception.Response
    if ($response -ne $null) {
        Write-Output "Website is down with status code $($response.StatusCode)"
    } else {
        Write-Output "Website is down with an unknown error"
    }
} finally {
    # Dispose of the response object
    if ($response -ne $null) {
        $response.Dispose()
    }
}

```


This script first defines the website URL to monitor and a timeout value in milliseconds. It then creates a new .NET object to handle HTTP requests and sets the request timeout value. The script then attempts to get a response from the website using the `GetResponse()` method. If the website is up and running, the script outputs a message indicating that. If the website is down, the script catches the `WebException` thrown by the `GetResponse()` method and outputs a message indicating the status code or an unknown error. Finally, the script disposes of the response object to free up system resources.

You can save this script in a PowerShell file (with a .ps1 extension) and run it from the PowerShell command prompt or the PowerShell ISE. You can also schedule it to run at regular intervals using Windows Task Scheduler or another scheduling tool.

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

can you update to utilize scheduler code so it can check the website every 3 mins

Sure, here's an updated version of the PowerShell script that utilizes the Windows Task Scheduler to run the website monitoring code every 3 minutes:

```
# Define website URL to monitor
$websiteUrl = "http://example.com"

# Define timeout value in milliseconds
$timeout = 5000

# Create a new .NET object to handle HTTP requests
$request = [System.Net.WebRequest]::Create($websiteUrl)

# Set the request timeout value
$request.Timeout = $timeout

# Try to get the response from the website
try {
    $response = $request.GetResponse()
    Write-Output "Website is up and running"
} catch [System.Net.WebException] {
    $response = $_.Exception.Response
    if ($response -ne $null) {
        Write-Output "Website is down with status code $($response.StatusCode)"
    } else {
        Write-Output "Website is down with an unknown error"
    }
} finally {
    # Dispose of the response object
    if ($response -ne $null) {
        $response.Dispose()
    }
}

# Create a new task to run the script every 3 minutes
$action = New-ScheduledTaskAction -Execute "powershell.exe" -Argument "-File `"$PSCommandPath`""
$trigger = New-ScheduledTaskTrigger -Once -At (Get-Date).AddMinutes(3) -RepetitionInterval (New-TimeSpan -Minutes 3) -RepetitionDuration ([System.TimeSpan]::MaxValue)
$settings = New-ScheduledTaskSettingsSet -AllowStartIfOnBatteries -DontStopIfGoingOnBattery
Register-ScheduledTask -TaskName "Website Monitor" -Action $action -Trigger $trigger -Settings $settings -Description "Monitors website downtime every 3 minutes."

```

This script first defines the website URL to monitor and a timeout value in milliseconds, as in the previous version. It then creates a new .NET object to handle HTTP requests and sets the request timeout value, also as before. The script then attempts to get a response from the website using the `GetResponse()` method, as in the previous version, and outputs a message indicating whether the website is up or down.

After the monitoring code, the script creates a new task to run the script every 3 minutes using the `Register-ScheduledTask` cmdlet. The task is defined with an action that executes the PowerShell script file, a trigger that runs the task once and then repeats every 3 minutes indefinitely, and settings that allow the task to start and continue running even if the computer is on battery power. The task is also given a description for reference.

You can save this script in a PowerShell file (with a .ps1 extension) and run it from the PowerShell command prompt or the PowerShell ISE. The script will create a new scheduled task named "Website Monitor" that runs the script every 3 minutes. You can modify the website URL and timeout value as needed for your monitoring needs.

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

is this scheduled task cmdlet register the script on windows task scheduler or it has its own?

Yes, the `Register-ScheduledTask` cmdlet creates a new task in the Windows Task Scheduler. The task will appear in the Task Scheduler Library under the name you specify with the `-TaskName` parameter.

You can view, modify, or delete the task using the Task Scheduler GUI or the `Get-ScheduledTask`, `Set-ScheduledTask`, and `Unregister-ScheduledTask` cmdlets.

Note that the PowerShell script must be run with administrator privileges in order to create or modify tasks in the Task Scheduler.

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

I see
is there any way to put the scheduler code as powershell .net code instead? so it doesn't have any relation to the OS

Yes, it is possible to create a scheduled task in PowerShell using .NET code instead of the `Register-ScheduledTask` cmdlet. Here's an example of how you can do it:

```
# Define website URL to monitor
$websiteUrl = "http://example.com"

# Define timeout value in milliseconds
$timeout = 5000

# Create a new .NET object to handle HTTP requests
$request = [System.Net.WebRequest]::Create($websiteUrl)

# Set the request timeout value
$request.Timeout = $timeout

# Try to get the response from the website
try {
    $response = $request.GetResponse()
    Write-Output "Website is up and running"
} catch [System.Net.WebException] {
    $response = $_.Exception.Response
    if ($response -ne $null) {
        Write-Output "Website is down with status code $($response.StatusCode)"
    } else {
        Write-Output "Website is down with an unknown error"
    }
} finally {
    # Dispose of the response object
    if ($response -ne $null) {
        $response.Dispose()
    }
}

# Create a new scheduled task to run the script every 3 minutes
$taskName = "Website Monitor"
$taskDescription = "Monitors website downtime every 3 minutes."
$taskAction = New-Object -ComObject "WScript.Shell"
$taskAction.Executable = "powershell.exe"
$taskAction.Arguments = "-File `"$PSCommandPath`""
$taskTrigger = New-ScheduledTaskTrigger -Once -At (Get-Date).AddMinutes(3) -RepetitionInterval (New-TimeSpan -Minutes 3) -RepetitionDuration ([System.TimeSpan]::MaxValue)
$taskSettings = New-ScheduledTaskSettingsSet -AllowStartIfOnBatteries -DontStopIfGoingOnBattery
$task = New-ScheduledTask -Action $taskAction -Trigger $taskTrigger -Settings $taskSettings
$task.Triggers[0].Id = $task.Triggers[0].InstanceId.ToString()
$task.RegistrationInfo.Description = $taskDescription
$task.Principal.RunLevel = [Microsoft.Win32.TaskScheduler.TaskRunLevel]::Highest
$task.Register($taskName)

```

This script creates a new scheduled task to run the PowerShell script every 3 minutes using .NET code instead of the `Register-ScheduledTask` cmdlet.

The script first defines the website URL and timeout value, creates a .NET object to handle HTTP requests, and attempts to get a response from the website, as in the previous examples.

The script then creates a new scheduled task object using the `New-ScheduledTask` cmdlet and sets its properties using .NET code. The task object is given a name and description, an action that executes the PowerShell script file, a trigger that runs the task every 3 minutes, and settings that allow the task to start and continue running even if the computer is on battery power.

The task object is then registered with the Task Scheduler using the `Register()` method, which adds it to the Task Scheduler Library.

You can modify the website URL and timeout value as needed for your monitoring needs. You can also modify the task name, description, and other properties as needed.

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

sorry, that's not it what I meant. what I want is avoid to register to Task Scheduler Library. so the task is powershell .net process instead of windows task

I see, in that case, you can use the `Start-Sleep` cmdlet to wait for 3 minutes between each run of the script. Here's an updated version of the script that runs indefinitely and monitors the website every 3 minutes:

```
# Define website URL to monitor
$websiteUrl = "http://example.com"

# Define timeout value in milliseconds
$timeout = 5000

# Create a new .NET object to handle HTTP requests
$request = [System.Net.WebRequest]::Create($websiteUrl)

# Set the request timeout value
$request.Timeout = $timeout

# Run the monitoring loop indefinitely
while ($true) {
    # Try to get the response from the website
    try {
        $response = $request.GetResponse()
        Write-Output "Website is up and running"
    } catch [System.Net.WebException] {
        $response = $_.Exception.Response
        if ($response -ne $null) {
            Write-Output "Website is down with status code $($response.StatusCode)"
        } else {
            Write-Output "Website is down with an unknown error"
        }
    } finally {
        # Dispose of the response object
        if ($response -ne $null) {
            $response.Dispose()
        }
    }

    # Wait for 3 minutes before running the next iteration
    Start-Sleep -Seconds 180
}

```

This script uses a `while` loop to run the monitoring code indefinitely. Inside the loop, the script attempts to get a response from the website as before, and then waits for 3 minutes using the `Start-Sleep` cmdlet before running the next iteration of the loop.

You can modify the website URL and timeout value as needed for your monitoring needs.

![](data:image/svg+xml,%3csvg%20xmlns=%27http://www.w3.org/2000/svg%27%20version=%271.1%27%20width=%2730%27%20height=%2730%27/%3e)![break through](https://chat.openai.com/_next/image?url=https%3A%2F%2Flh3.googleusercontent.com%2Fa%2FAGNmyxZvoea9ARtaIZmeU3HIF212f5XZJmas3VX5my-6%3Ds96-c&w=64&q=75)

aahhh. so I can use that technique. thanks!

You're welcome! I'm glad that I could help. If you have any other questions or need further assistance, just let me know.

