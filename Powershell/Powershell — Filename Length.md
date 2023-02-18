---
tags:
- Powershell
- File
date: 2023-12-03
---

# Filename Length

```powershell
Clear-Host

$searcheddir = "D:\\Personal-Notes"
Get-ChildItem -Path $searcheddir -Recurse |
    Select-Object @{
        N="Type";
        E={
            If ($_ -Is [System.IO.DirectoryInfo]) { "D" }
            ElseIf ($_ -Is [System.IO.FileInfo]) { "F" }
        }
    }, @{
        N="Name";
        E={ $_.Name }
    }, @{
        N="NameLen";
        E={ $_.Name.Length }
    } |
    Sort-Object @{
        E={
            [System.Convert]::ToInt32($_.NameLen)
        }; 
        Ascending = $false; 
        Descending = $true
    }
```

Output-nya

```powershell
Type Name                                                                                            NameLen
---- ----                                                                                            -------
F    Which Version of the Java Development Kit Should You Install & Do You Need to Pay for It.srt.md      95
F    Why Your Less-Experienced Colleagues Are Promoted Instead of You! - English.srt.md                   82
F    Executive Communications Are Easy When You Conduct Them This Way - English.srt.md                    81
F    The Art of Active Listening _ The Harvard Business Review Guide - English.srt.md                     80
F    Learn Database Normalization - 1NF_ 2NF_ 3NF_ 4NF_ 5NF - English.srt.md                              71
F    Java SE 8 Is No Longer Available Without A License - What Next.srt.md                                69
F    How To Take Smart Notes (3 methods no one's talking about).srt.md                                    65
F    Sitecore — Sitecore Content Editor search configuration.md                                           58
F    Team Lead — Satya Nadella_s Authentic Leadership Style.md                                            57
F    Powershell — List Directory contents excluding some.md                                               54
F    20221127_075112_Oracle-JDK-License-General-FAQs.png                                                  51
F    aa063ee9-39e3-4a11-be15-55e27a0534f9_jpg_webp.png                                                    49
F    51641b4b-4d11-4453-a4ad-2ccc1ff316ec_jpg_webp.png                                                    49
F    66d8f1a0-dc97-4675-ab74-d95d8e3a896d_jpg_webp.png                                                    49
F    Three Habits for a Better Life - transcription.md                                                    49
F    93933c5d-ed2f-4bb2-bbb4-380a1dd89300_jpg_webp.png                                                    49
F    Powershell — Generate Self-signed Certificate.md                                                     48
F    Work — Project Roadmap with Ticketing-based.md                                                       46
F    Work — Work from home or work from anywhere.md                                                       46
F    BungaMatahari-CollectionPipeline-Aggregate.png                                                       46
F    Work — Facing Customer with Ticketing-based.md                                                       46
F    Naming Is Hard — Settings vs Configuration.md                                                        45
F    CSharp — Entity Framework EntityValidation.md                                                        45
F    Colors — Microsoft 365 hero title palette.md                                                         44
F    Work — Resolve ticket-based issue tracker.md                                                         44
F    AI Tools — Use generative-AI for studying.md                                                         44
. . . omitted . . .
D    Work                                                                                                  4
D    SQL                                                                                                   3
D    IIS                                                                                                   3
D    lua                                                                                                   3
D    Git                                                                                                   3
D    Go                                                                                                    2
```