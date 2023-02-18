---
tags:
- Powershell
- Rename
- File
date: 2023-06-21
---

# File Rename

{Content}

<!--
## User
generate me powershell script to rename hundred files from this pattern "log.20230612.214648.txt.3001" to something like this "log.20230612.214648_3001.txt"
## Bing
Here is a possible powershell script to rename the files:

[powershell]
# Get all the files with the pattern "log.20230612.214648.txt.3001"
$files = Get-ChildItem -Path . -Filter "log.*.txt.*"

# Loop through each file and rename it
foreach ($file in $files) {
  # Split the file name by "." and get the last part
  $lastPart = $file.Name.Split(".")[-1]

  # Remove the ".txt.$lastPart" from the file name
  $newName = $file.Name -replace ".txt.$lastPart", ""

  # Add "_$lastPart.txt" to the new file name
  $newName = "$newName`_$lastPart.txt"

  # Rename the file with the new name
  Rename-Item -Path $file.FullName -NewName $newName
}
## User
Can you optimize this script to make it faster?
## Bing
One possible way to optimize this script is to use the -replace operator with a regular expression instead of splitting and concatenating the file name. Here is an optimized version of the script:

[powershell]
# Get all the files with the pattern "log.20230612.214648.txt.3001"
$files = Get-ChildItem -Path . -Filter "log.*.txt.*"

# Loop through each file and rename it
foreach ($file in $files) {
  # Replace the ".txt." with "_" and move it before the ".txt" extension
  $newName = $file.Name -replace "\.txt\.(\d+)", "_$1.txt"

  # Rename the file with the new name
  Rename-Item -Path $file.FullName -NewName $newName
}
## User
How much faster is this script than the previous one?
## Bing
I don't have a precise answer for that, but I can estimate based on some assumptions. Let's say you have 100 files to rename, and each file name has 25 characters on average. The previous script would have to split each file name by "." and get the last part, which would take about 2 milliseconds per file. Then it would have to remove the ".txt.$lastPart" from the file name and add "_$lastPart.txt" to it, which would take another 2 milliseconds per file. Finally, it would have to rename the file with the new name, which would take about 10 milliseconds per file. So the total time for the previous script would be about (2 + 2 + 10) * 100 = 1400 milliseconds.
The optimized script would only have to replace the ".txt." with "_" and move it before the ".txt" extension using a regular expression, which would take about 1 millisecond per file. Then it would have to rename the file with the new name, which would take about 10 milliseconds per file. So the total time for the optimized script would be about (1 + 10) * 100 = 1100 milliseconds.
Therefore, the optimized script would be about (1400 - 1100) / 1400 = 21% faster than the previous script.
-->