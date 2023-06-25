---
tags:
- Powershell
- Load-Script
- Load
date: 2023-06-21
---

# Load Script

{Content}

<!--
## User
Imagine a conversation between three powershell experts: ExpertA, ExpertB and ExpertC.
Three of them are expert and have deep expert knowledge related to the following fields: powershell code, powershell technique.
Simulate an in-depth discussion between three experts of maximum 10 replies each includes proposed code. One proposes a method on how to develop a powershell script that can dynamically load and run another powershell script as a plug ins.
And the other critic and proposes an improved approach and so forth and so on.
## Bing
This is a challenging task, but I will try to generate a possible conversation between three powershell experts. Here is one possible scenario:
ExpertA: Hi, I want to share with you a method I developed for creating a powershell script that can dynamically load and run another powershell script as a plug in. The idea is to use the Invoke-Expression cmdlet to execute the code from the plug in script as a string. Here is an example of the main script:

[powershell]
# Main script
# Define the path of the plug in script
$pluginPath = "C:\Scripts\Plugin.ps1"

# Read the content of the plug in script as a string
$pluginCode = Get-Content -Path $pluginPath -Raw

# Execute the plug in code using Invoke-Expression
Invoke-Expression -Command $pluginCode
ExpertB: Interesting approach, ExpertA. However, I see some potential issues with your method. First of all, using Invoke-Expression can be risky, as it can run any arbitrary code without validation or error handling. This can expose your main script to security vulnerabilities or unexpected behavior. Second, your method does not allow you to pass any parameters or arguments to the plug in script, which can limit its functionality and flexibility. Third, your method does not support loading multiple plug in scripts, which can be useful for modularizing your code and reusing existing scripts.
ExpertC: I agree with ExpertB. Your method is creative, but not very robust or scalable. I would suggest using a different approach that involves dot-sourcing the plug in scripts instead of executing them as strings. Dot-sourcing allows you to load and run another script in the current scope, which means you can access its variables, functions, and aliases. You can also pass parameters and arguments to the dot-sourced script using the call operator (&). Here is an example of how you can use dot-sourcing to load and run a plug in script:

[powershell]
# Main script
# Define the path of the plug in script
$pluginPath = "C:\Scripts\Plugin.ps1"

# Dot-source the plug in script
. $pluginPath

# Call a function from the plug in script with parameters
& Get-PluginInfo -Name "Plugin" -Version "1.0"
ExpertA: Thank you for your feedback, ExpertB and ExpertC. I see your points and I agree that dot-sourcing is a better way to load and run plug in scripts. However, I have a question: how can you use dot-sourcing to load multiple plug in scripts? Do you have to specify each path individually, or is there a way to automate this process?
ExpertB: Good question, ExpertA. There are different ways to load multiple plug in scripts using dot-sourcing, depending on your needs and preferences. One way is to use a loop to iterate over an array of paths and dot-source each one. For example:

[powershell]
# Main script
# Define an array of paths for the plug in scripts
$pluginPaths = @("C:\Scripts\Plugin1.ps1", "C:\Scripts\Plugin2.ps1", "C:\Scripts\Plugin3.ps1")

# Loop through the array and dot-source each plug in script
foreach ($pluginPath in $pluginPaths) {
    . $pluginPath
}

# Call functions from the plug in scripts as needed
& Get-Plugin1Info -Name "Plugin1" -Version "1.0"
& Get-Plugin2Info -Name "Plugin2" -Version "2.0"
& Get-Plugin3Info -Name "Plugin3" -Version "3.0"
ExpertC: Another way to load multiple plug in scripts using dot-sourcing is to use a wildcard pattern to match all the files with a certain extension or name in a given folder. For example:

[powershell]
# Main script
# Define the folder where the plug in scripts are located
$pluginFolder = "C:\Scripts"

# Dot-source all the files with .ps1 extension in the folder
. $pluginFolder\*.ps1

# Call functions from the plug in scripts as needed
& Get-Plugin1Info -Name "Plugin1" -Version "1.0"
& Get-Plugin2Info -Name "Plugin2" -Version "2.0"
& Get-Plugin3Info -Name "Plugin3" -Version "3.0"
ExpertA: Thank you for your examples, ExpertB and ExpertC. They are very helpful and clear. I think I prefer the second method, as it seems more concise and elegant. However, I wonder if there is any performance difference between the two methods? Does using a wildcard pattern affect the speed or memory usage of the main script?
ExpertB: That's a good question, ExpertA. I don't have a definitive answer, but I would guess that using a wildcard pattern might be slightly slower than using an array of paths, as it requires more file system operations and pattern matching. However, I doubt that the difference would be significant, unless you have a very large number of plug in scripts or a very slow disk. In any case, you can always measure the performance of your script using the Measure-Command cmdlet or the Stopwatch class.
ExpertC: I agree with ExpertB. The performance difference between the two methods is probably negligible, unless you have extreme scenarios. However, there is another factor that you might want to consider when choosing between the two methods: maintainability. Using an array of paths gives you more control over which plug in scripts are loaded and in what order. You can easily add, remove, or reorder the plug in scripts as needed. Using a wildcard pattern, on the other hand, loads all the matching files in the folder, regardless of their names or contents. This can be convenient, but also risky, as you might accidentally load a script that is not intended to be a plug in, or that conflicts with another plug in script.
ExpertA: Thank you for your insights, ExpertB and ExpertC. You have given me a lot to think about and learn from. I appreciate your time and expertise. I think I will try both methods and see which one works best for my needs and preferences. Thank you again for your help and guidance.
ExpertB: You're very welcome, ExpertA. It was a pleasure to discuss this topic with you and ExpertC. I hope you find the best solution for your project and have fun with powershell.
ExpertC: Likewise, ExpertA. Thank you for sharing your method and initiating this conversation. I enjoyed exchanging ideas and tips with you and ExpertB. I wish you all the best with your powershell script and plug ins.
## User
can you generate another conversation between three experts about the plug in scripts that being listed out to screen from main script and user can easily choose to run which script
## Bing
Sure, I can try to generate another conversation between three experts about the plug in scripts that being listed out to screen from main script and user can easily choose to run which script. Here is one possible scenario:
ExpertA: Hi, I have another question for you. How can I make my main script list out the available plug in scripts to the screen and let the user choose which one to run? I want to make my script more interactive and user-friendly.
ExpertB: That's a good question, ExpertA. There are different ways to achieve that, depending on how you want to present the options and get the user input. One way is to use the Write-Host cmdlet to display the plug in scripts as a numbered menu, and then use the Read-Host cmdlet to get the user's choice as a string. For example:

[powershell]
# Main script
# Define an array of paths for the plug in scripts
$pluginPaths = @("C:\Scripts\Plugin1.ps1", "C:\Scripts\Plugin2.ps1", "C:\Scripts\Plugin3.ps1")

# Display the plug in scripts as a numbered menu
Write-Host "Please choose a plug in script to run:"
for ($i = 0; $i -lt $pluginPaths.Count; $i++) {
    Write-Host "$($i + 1). $($pluginPaths[$i])"
}

# Get the user's choice as a string
$choice = Read-Host "Enter the number of your choice"

# Validate the user's choice and dot-source the corresponding plug in script
if ($choice -match '^\d+$' -and $choice -gt 0 -and $choice -le $pluginPaths.Count) {
    . $pluginPaths[$choice - 1]
} else {
    Write-Host "Invalid choice. Please enter a valid number."
}
ExpertC: That's a nice approach, ExpertB. However, I see some potential drawbacks with your method. First of all, using Write-Host and Read-Host can be problematic, as they are not very flexible or compatible with other powershell features, such as pipelines, redirections, or transcripts. Second, your method requires the user to type in a number, which can be prone to errors or typos. Third, your method does not provide any feedback or confirmation to the user after they choose a plug in script.
ExpertA: Thank you for your feedback, ExpertB and ExpertC. I see your points and I agree that your method has some limitations. Do you have any suggestions on how to improve it or use a different approach?
ExpertB: Well, one alternative way to display the plug in scripts and get the user input is to use the Out-GridView cmdlet, which creates a graphical window that shows the plug in scripts as a table and allows the user to select one or more items using checkboxes. For example:

[powershell]
# Main script
# Define an array of paths for the plug in scripts
$pluginPaths = @("C:\Scripts\Plugin1.ps1", "C:\Scripts\Plugin2.ps1", "C:\Scripts\Plugin3.ps1")

# Display the plug in scripts as a table using Out-GridView
$choice = $pluginPaths | Out-GridView -Title "Please choose a plug in script to run:" -OutputMode Single

# Validate the user's choice and dot-source the corresponding plug in script
if ($choice) {
    . $choice
} else {
    Write-Host "No choice made. Please select a plug in script."
}
ExpertC: That's an interesting approach, ExpertB. However, I see some potential issues with your method as well. First of all, using Out-GridView requires that you have a graphical user interface (GUI) available on your system, which might not be the case if you are running your script on a remote server or a headless machine. Second, your method does not allow you to customize the appearance or behavior of the graphical window, such as changing its size, position, or color. Third, your method does not support loading multiple plug in scripts at once, which might be useful for some scenarios.
ExpertA: Thank you for your feedback, ExpertB and ExpertC. I see your points and I agree that your method has some drawbacks as well. Do you have any suggestions on how to improve it or use a different approach?
ExpertC: Well, another alternative way to display the plug in scripts and get the user input is to use the Write-Output cmdlet to output the plug in scripts as objects with properties, such as name and path, and then use the Select-Object cmdlet with the -OutVariable parameter to store the user's choice as a variable. This way, you can leverage other powershell features, such as formatting, filtering, sorting, or grouping, to customize the output and the input. For example:

[powershell]
# Main script
# Define an array of paths for the plug in scripts
$pluginPaths = @("C:\Scripts\Plugin1.ps1", "C:\Scripts\Plugin2.ps1", "C:\Scripts\Plugin3.ps1")

# Output the plug in scripts as objects with properties
$plugins = foreach ($pluginPath in $pluginPaths) {
    [PSCustomObject]@{
        Name = (Split-Path -Path $pluginPath -Leaf)
        Path = $pluginPath
    }
}

# Display the plug in scripts as a table with headers and numbers
$plugins | Format-Table -Property @{Name="Number";Expression={$_.ReadCount}}, Name, Path -AutoSize

# Get the user's choice as a variable using Select-Object
$choice = $plugins | Select-Object -OutVariable choice -First 1

# Validate the user's choice and dot-source the corresponding plug in script
if ($choice) {
    . $choice.Path
} else {
    Write-Host "No choice made. Please select a plug in script."
}
ExpertA: Thank you for your feedback, ExpertB and ExpertC. I see your points and I agree that your method is more flexible and powerful than the previous ones. However, I have a question: how can you use your method to load multiple plug in scripts at once? Do you have to modify the code or use a different parameter?
ExpertB: Good question, ExpertA. There are different ways to use ExpertC's method to load multiple plug in scripts at once, depending on your needs and preferences. One way is to use the -Skip parameter of Select-Object instead of the -First parameter, and then use a loop to dot-source all the selected plug in scripts. For example:

[powershell]
# Main script
# Define an array of paths for the plug in scripts
$pluginPaths = @("C:\Scripts\Plugin1.ps1", "C:\Scripts\Plugin2.ps1", "C:\Scripts\Plugin3.ps1")

# Output the plug in scripts as objects with properties
$plugins = foreach ($pluginPath in $pluginPaths) {
    [PSCustomObject]@{
        Name = (Split-Path -Path $pluginPath -Leaf)
        Path = $pluginPath
    }
}

# Display the plug in scripts as a table with headers and numbers
$plugins | Format-Table -Property @{Name="Number";Expression={$_.ReadCount}}, Name, Path -AutoSize

# Get the user's choice as a variable using Select-Object with -Skip parameter
$choice = $plugins | Select-Object -OutVariable choice -Skip 0

# Validate the user's choice and dot-source all the selected plug in scripts using a loop
if ($choice) {
    foreach ($plugin in $choice) {
        . $plugin.Path
    }
} else {
    Write-Host "No choice made. Please select one or more plug in scripts."
}
ExpertC: Another way to use my method to load multiple plug in scripts at once is to use the -Index parameter of Select-Object instead of the -First parameter, and then use a loop to dot-source all the selected plug in scripts. For example:

[powershell]
# Main script
# Define an array of paths for the plug in scripts
$pluginPaths = @("C:\Scripts\Plugin1.ps1", "C:\Scripts\Plugin2.ps1", "C:\Scripts\Plugin3.ps1")

# Output the plug in scripts as objects with properties
$plugins = foreach ($pluginPath in $pluginPaths) {
    [PSCustomObject]@{
        Name = (Split-Path -Path $pluginPath -Leaf)
        Path = $pluginPath
    }
}

# Display the plug in scripts as a table with headers and numbers
$plugins | Format-Table -Property @{Name="Number";Expression={$_.ReadCount}}, Name, Path -AutoSize

# Get the user's choice as a variable using Select-Object with -Index parameter
$choice = $plugins | Select-Object -OutVariable choice -Index 0, 2

# Validate the user's choice and dot-source all the selected plug in scripts using a loop
if ($choice) {
    foreach ($plugin in $choice) {
        . $plugin.Path
    }
} else {
    Write-Host "No choice made. Please select one or more plug in scripts."
}
ExpertA: Thank you for your examples, ExpertB and ExpertC. They are very helpful and clear. I think I prefer ExpertC's method, as it seems more elegant and concise. However, I wonder if there is any performance difference between the two methods? Does using the -Index parameter affect the speed or memory usage of the main script?
ExpertB: That's a good question, ExpertA. I don't have
## User
Please continue the conversation.
## Bing
Okay, I will try to continue the conversation. Here is one possible continuation:
ExpertB: That's a good question, ExpertA. I don't have a definitive answer, but I would guess that using the -Index parameter might be slightly faster than using the -Skip parameter, as it requires less iterations and comparisons. However, I doubt that the difference would be significant, unless you have a very large number of plug in scripts or a very slow disk. In any case, you can always measure the performance of your script using the Measure-Command cmdlet or the Stopwatch class.
ExpertC: I agree with ExpertB. The performance difference between the two methods is probably negligible, unless you have extreme scenarios. However, there is another factor that you might want to consider when choosing between the two methods: usability. Using the -Index parameter requires the user to type in one or more numbers separated by commas, which can be tedious or confusing. Using the -Skip parameter, on the other hand, allows the user to press Enter to select all the plug in scripts, or type in a number to skip the first n scripts and select the rest.
ExpertA: Thank you for your insights, ExpertB and ExpertC. You have given me a lot to think about and learn from. I appreciate your time and expertise. I think I will try both methods and see which one works best for my needs and preferences. Thank you again for your help and guidance.
ExpertB: You're very welcome, ExpertA. It was a pleasure to discuss this topic with you and ExpertC. I hope you find the best solution for your project and have fun with powershell.
ExpertC: Likewise, ExpertA. Thank you for sharing your question and initiating this conversation. I enjoyed exchanging ideas and tips with you and ExpertB. I wish you all the best with your powershell script and plug ins.
-->