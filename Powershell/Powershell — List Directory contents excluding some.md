---
tags:
- Powershell
- Directory
- File
date: 2023-12-02
---

# List Directory contents excluding some

```powershell
Clear-Host

Get-ChildItem -Path . -Recurse |
    Where-Object { $_.FullName -NotMatch "(^\.|\\\.).+" } |
    Select-Object @{
        Name="FullName";
        Expression={
            If ($_ -Is [System.IO.DirectoryInfo]) { $_.FullName + "\" }
            Else { $_.FullName }
        }
    } |
    Select-Object -ExpandProperty FullName
```

Contoh hasil run

```
D:\Personal-Notes\AI Tools\
D:\Personal-Notes\Coffee\
D:\Personal-Notes\Communication\
D:\Personal-Notes\CSharp\
D:\Personal-Notes\Design\
D:\Personal-Notes\Excel\
D:\Personal-Notes\Git\
D:\Personal-Notes\Go\
D:\Personal-Notes\IIS\
D:\Personal-Notes\Java\
D:\Personal-Notes\Javascript\
D:\Personal-Notes\Life\
D:\Personal-Notes\LINQPad\
D:\Personal-Notes\Markdown\
D:\Personal-Notes\Office 365\
D:\Personal-Notes\Powershell\
D:\Personal-Notes\Productive\
D:\Personal-Notes\Programming Concept\
D:\Personal-Notes\Sitecore\
D:\Personal-Notes\SQL\
D:\Personal-Notes\Tech\
D:\Personal-Notes\Time Management\
D:\Personal-Notes\Work\
D:\Personal-Notes\_templates\
D:\Personal-Notes\LICENSE.md
D:\Personal-Notes\notes.code-workspace
D:\Personal-Notes\README.md
D:\Personal-Notes\AI Tools\AI Index.md
D:\Personal-Notes\AI Tools\AI Tools — Bing Prompt.md
D:\Personal-Notes\AI Tools\AI Tools — chatGPT Prompt.md
D:\Personal-Notes\AI Tools\AI Tools — Use generative-AI for studying.md
D:\Personal-Notes\Coffee\_media\
D:\Personal-Notes\Coffee\Coffee — Simple Recipe.md
D:\Personal-Notes\Coffee\_media\51641b4b-4d11-4453-a4ad-2ccc1ff316ec_jpg_webp.png
D:\Personal-Notes\Coffee\_media\66d8f1a0-dc97-4675-ab74-d95d8e3a896d_jpg_webp.png
D:\Personal-Notes\Coffee\_media\93933c5d-ed2f-4bb2-bbb4-380a1dd89300_jpg_webp.png
D:\Personal-Notes\Coffee\_media\aa063ee9-39e3-4a11-be15-55e27a0534f9_jpg_webp.png
D:\Personal-Notes\Communication\English\
D:\Personal-Notes\Communication\Writing\
D:\Personal-Notes\Communication\_media\
D:\Personal-Notes\Communication\Communication Index.md
D:\Personal-Notes\Communication\Communication — Active Listening 1.md
D:\Personal-Notes\Communication\Communication — Active Listening.md
D:\Personal-Notes\Communication\Communication — Article or Paragraph.md
D:\Personal-Notes\Communication\Communication — Communicate.md
D:\Personal-Notes\Communication\Communication — Communication Method.md
D:\Personal-Notes\Communication\Communication — Effective Communication.md
D:\Personal-Notes\Communication\Communication — English.md
D:\Personal-Notes\Communication\Communication — Executive Communication.md
D:\Personal-Notes\Communication\Communication — Meeting Minutes.md
D:\Personal-Notes\Communication\Communication — Microsoft Teams.md
D:\Personal-Notes\Communication\Communication — Nice to e-meet you.md
D:\Personal-Notes\Communication\Communication — Problem Escalation.md
D:\Personal-Notes\Communication\Communication — Progress Report.md
D:\Personal-Notes\Communication\English\English Index.md
D:\Personal-Notes\Communication\English\English — Apologize.md
D:\Personal-Notes\Communication\English\English — Approving.md
D:\Personal-Notes\Communication\English\English — Attainable.md
D:\Personal-Notes\Communication\English\English — Banting Setir.md
D:\Personal-Notes\Communication\English\English — Blissful.md
D:\Personal-Notes\Communication\English\English — Colokan Listrik.md
D:\Personal-Notes\Communication\English\English — Compile and Put Together.md
D:\Personal-Notes\Communication\English\English — Dana.md
D:\Personal-Notes\Communication\English\English — Fine Print.md
D:\Personal-Notes\Communication\English\English — Firm in Decision.md
D:\Personal-Notes\Communication\English\English — How to tackle.md
D:\Personal-Notes\Communication\English\English — i.e. e.g..md
D:\Personal-Notes\Communication\English\English — Mengingat Bahwa.md
D:\Personal-Notes\Communication\English\English — Modal Awal Yang Bagus.md
D:\Personal-Notes\Communication\English\English — Moving Forward.md
D:\Personal-Notes\Communication\English\English — On-premises.md
D:\Personal-Notes\Communication\English\English — Quantifiable.md
D:\Personal-Notes\Communication\English\English — Results and Outcomes.md
D:\Personal-Notes\Communication\English\English — Stakeholders.md
D:\Personal-Notes\Communication\English\English — Stricter.md
D:\Personal-Notes\Communication\English\English — Succeed.md
D:\Personal-Notes\Communication\Writing\Writing — Folder Structure in ASCII.md
D:\Personal-Notes\Communication\Writing\Writing — Writing in ASCII.md
D:\Personal-Notes\Communication\_media\Executive Communications Are Easy When You Conduct Them This Way - English.srt.md
D:\Personal-Notes\Communication\_media\The Art of Active Listening _ The Harvard Business Review Guide - English.srt.md
D:\Personal-Notes\CSharp\_media\
D:\Personal-Notes\CSharp\CSharp Index.md
D:\Personal-Notes\CSharp\CSharp — 1-Perkenalan.md
D:\Personal-Notes\CSharp\CSharp — 10-Conditional Statement.md
D:\Personal-Notes\CSharp\CSharp — 2-String.md
D:\Personal-Notes\CSharp\CSharp — 3-Type.md
D:\Personal-Notes\CSharp\CSharp — 4-Collection.md
D:\Personal-Notes\CSharp\CSharp — 5-Collection-Pipeline.md
D:\Personal-Notes\CSharp\CSharp — 6-Extension-Methods.md
D:\Personal-Notes\CSharp\CSharp — 7-Delegate.md
D:\Personal-Notes\CSharp\CSharp — 8-Event-Handler.md
D:\Personal-Notes\CSharp\CSharp — 9-DataTable.md
D:\Personal-Notes\CSharp\CSharp — Assembly Load .NET 6.md
D:\Personal-Notes\CSharp\CSharp — Auto resize Windows Form Panel.md
D:\Personal-Notes\CSharp\CSharp — Blacklist Whitelist Upload File.md
D:\Personal-Notes\CSharp\CSharp — Code Review.md
D:\Personal-Notes\CSharp\CSharp — Compare String.md
D:\Personal-Notes\CSharp\CSharp — Condition Parser.md
D:\Personal-Notes\CSharp\CSharp — Download Simulation.md
D:\Personal-Notes\CSharp\CSharp — Duration between dates.md
D:\Personal-Notes\CSharp\CSharp — Early Return.md
D:\Personal-Notes\CSharp\CSharp — Encode Decode.md
D:\Personal-Notes\CSharp\CSharp — Entity Framework EntityValidation.md
D:\Personal-Notes\CSharp\CSharp — Event Emitter.md
D:\Personal-Notes\CSharp\CSharp — Filename and Extension.md
D:\Personal-Notes\CSharp\CSharp — Find String by Regex.md
D:\Personal-Notes\CSharp\CSharp — Minimal API returns Xml.md
D:\Personal-Notes\CSharp\CSharp — Nuget package copy to bin.md
D:\Personal-Notes\CSharp\CSharp — Quiz_001_20210517.md
D:\Personal-Notes\CSharp\CSharp — Quiz_001_20210517_Solution.md
D:\Personal-Notes\CSharp\CSharp — Read assembly version.md
D:\Personal-Notes\CSharp\CSharp — SecureString.md
D:\Personal-Notes\CSharp\CSharp — Simple return value.md
D:\Personal-Notes\CSharp\CSharp — Simple Service Bus.md
D:\Personal-Notes\CSharp\CSharp — Simple Task Scheduler.md
D:\Personal-Notes\CSharp\CSharp — Type dari string.md
D:\Personal-Notes\CSharp\CSharp — Xml Encode.md
D:\Personal-Notes\CSharp\CSharp — Xml Parser.md
D:\Personal-Notes\CSharp\_media\2020-03-27_22-20-53.png
D:\Personal-Notes\CSharp\_media\2020-03-27_22-52-45.png
D:\Personal-Notes\CSharp\_media\2020-03-28_19-16-35.png
D:\Personal-Notes\CSharp\_media\2020-05-17_204428.png
D:\Personal-Notes\CSharp\_media\BungaMatahari-CollectionPipeline-Aggregate.png
D:\Personal-Notes\CSharp\_media\BungaMatahari-CollectionPipeline-Select.png
D:\Personal-Notes\CSharp\_media\BungaMatahari-CollectionPipeline-Sort.png
D:\Personal-Notes\CSharp\_media\BungaMatahari-CollectionPipeline-Where.png
D:\Personal-Notes\CSharp\_media\BungaMatahari-CollectionPipeline.xml
D:\Personal-Notes\CSharp\_media\BungaMatahari-DataTable-Collections.png
D:\Personal-Notes\CSharp\_media\BungaMatahari-DataTable-Table.png
D:\Personal-Notes\CSharp\_media\BungaMatahari-DataTable.xml
D:\Personal-Notes\CSharp\_media\DownloadSimulation.7z
D:\Personal-Notes\Design\Colors\
D:\Personal-Notes\Design\Design — Design Token.md
D:\Personal-Notes\Design\Colors\Colors Index.md
D:\Personal-Notes\Design\Colors\Colors — Article card and text palette.md
D:\Personal-Notes\Design\Colors\Colors — dotnet support policy palette.md
D:\Personal-Notes\Design\Colors\Colors — Microsoft 365 hero title palette.md
D:\Personal-Notes\Design\Colors\Colors — MS Edge welcome page palette.md
D:\Personal-Notes\Design\Colors\Colors — Palette 0045.md
D:\Personal-Notes\Design\Colors\Colors — Stromi palette.md
D:\Personal-Notes\Design\Colors\Colors — Turtles palette.md
D:\Personal-Notes\Design\Colors\DRAFT.md
D:\Personal-Notes\Excel\_media\
D:\Personal-Notes\Excel\Excel Index.md
D:\Personal-Notes\Excel\Excel — CEILING.md
D:\Personal-Notes\Excel\Excel — Datetime.md
D:\Personal-Notes\Excel\Excel — Decimal point.md
D:\Personal-Notes\Excel\Excel — Find duplicates.md
D:\Personal-Notes\Excel\_media\20230225_183801_image.png
D:\Personal-Notes\Excel\_media\20230225_183950_image.png
D:\Personal-Notes\Excel\_media\20230225_184040_image.png
D:\Personal-Notes\Excel\_media\20230225_184102_image.png
D:\Personal-Notes\Excel\_media\20230225_185810_image.png
D:\Personal-Notes\Excel\_media\20230225_185829_image.png
D:\Personal-Notes\Excel\_media\Pasted image 20220708200433.png
D:\Personal-Notes\Excel\_media\Pasted image 20220708202005.png
D:\Personal-Notes\Excel\_media\Pasted image 20220708202235.png
D:\Personal-Notes\Excel\_media\Pasted image 20220708202700.png
D:\Personal-Notes\Excel\_media\Pasted image 20220708202955.png
D:\Personal-Notes\Git\Git Index.md
D:\Personal-Notes\Git\Git — Merge conflict.md
D:\Personal-Notes\Git\Git — User info.md
D:\Personal-Notes\Go\Go — 1-Perkenalan.md
D:\Personal-Notes\Go\Go — 2-String.md
D:\Personal-Notes\Go\Go — 3-Type.md
D:\Personal-Notes\Go\Go — 4-Collection.md
D:\Personal-Notes\Go\Go — 5-Collection-Pipeline.md
D:\Personal-Notes\Go\Go — 6-Extension-Methods.md
D:\Personal-Notes\Go\Go — 7-Delegate.md
D:\Personal-Notes\Go\Go — 8-Event-Handler.md
D:\Personal-Notes\IIS\_media\
D:\Personal-Notes\IIS\IIS Index.md
D:\Personal-Notes\IIS\IIS — Auto recycle.md
D:\Personal-Notes\IIS\IIS — Log Investigation.md
D:\Personal-Notes\IIS\IIS — Max URL Length.md
D:\Personal-Notes\Java\_media\
D:\Personal-Notes\Java\Java Index.md
D:\Personal-Notes\Java\Java — Java JDK alternatives.md
D:\Personal-Notes\Java\Java — Java JDK licensing status.md
D:\Personal-Notes\Java\_media\20221127_071344_image.png
D:\Personal-Notes\Java\_media\20221127_075112_Oracle-JDK-License-General-FAQs.png
D:\Personal-Notes\Java\_media\20221127_080507_image.png
D:\Personal-Notes\Java\_media\20221127_081720_image.png
D:\Personal-Notes\Java\_media\Java SE 8 Is No Longer Available Without A License - What Next.srt.md
D:\Personal-Notes\Java\_media\Oracle Java 11 - A paid trap.srt.md
D:\Personal-Notes\Java\_media\Which Version of the Java Development Kit Should You Install & Do You Need to Pay for It.srt.md
D:\Personal-Notes\Javascript\Regex\
D:\Personal-Notes\Javascript\Typescript\
D:\Personal-Notes\Javascript\Javascript — Ajax.md
D:\Personal-Notes\Javascript\Javascript — Array Methods.md
D:\Personal-Notes\Javascript\Javascript — Local Storage.md
D:\Personal-Notes\Javascript\Javascript — Simple Condition Parser.md
D:\Personal-Notes\Javascript\Javascript — Unix epoch to Date time.md
D:\Personal-Notes\Javascript\Regex\Regex — Common Password.md
D:\Personal-Notes\Javascript\Regex\Regex — Version check.md
D:\Personal-Notes\Javascript\Typescript\Typescript — Buffer experiment.md
D:\Personal-Notes\Javascript\Typescript\Typescript — Typescript Types.md
D:\Personal-Notes\Life\Thought\
D:\Personal-Notes\Life\_media\
D:\Personal-Notes\Life\Life Index.md
D:\Personal-Notes\Life\Life — Ada dua.md
D:\Personal-Notes\Life\Life — Digital Life.md
D:\Personal-Notes\Life\Life — Feeling down.md
D:\Personal-Notes\Life\Life — Kebiasaan Penting.md
D:\Personal-Notes\Life\Life — Kewalahan.md
D:\Personal-Notes\Life\Life — Mental Illness.md
D:\Personal-Notes\Life\Life — Mindset.md
D:\Personal-Notes\Life\Life — Sukses.md
D:\Personal-Notes\Life\Life — Taking Notes.md
D:\Personal-Notes\Life\Life — Thinking models.md
D:\Personal-Notes\Life\Life — Yang Sering Terjadi.md
D:\Personal-Notes\Life\Thought\Thought — Arale.md
D:\Personal-Notes\Life\Thought\Thought — If I want to sell tickets.md
D:\Personal-Notes\Life\Thought\Thought — Why.md
D:\Personal-Notes\Life\_media\How To Take Smart Notes (3 methods no one's talking about).srt.md
D:\Personal-Notes\Life\_media\msg123406151-220841.jpg
D:\Personal-Notes\Life\_media\Three Habits for a Better Life - transcription.md
D:\Personal-Notes\LINQPad\LINQPad Index.md
D:\Personal-Notes\LINQPad\LINQPad — Benchmarkdotnet in LINQPad.md
D:\Personal-Notes\LINQPad\LINQPad — Important directory.md
D:\Personal-Notes\LINQPad\LINQPad — Query saved checker.md
D:\Personal-Notes\Markdown\Markdown Index.md
D:\Personal-Notes\Markdown\Markdown — Citation.md
D:\Personal-Notes\Markdown\Markdown — Comment.md
D:\Personal-Notes\Markdown\Markdown — Footnotes.md
D:\Personal-Notes\Markdown\Markdown — Label.md
D:\Personal-Notes\Markdown\Markdown — Message Box.md
D:\Personal-Notes\Office 365\365 — Office 365 for Productivity.md
D:\Personal-Notes\Office 365\365 — Task Management with Office 365.md
D:\Personal-Notes\Office 365\_DRAFT.md
D:\Personal-Notes\Powershell\_media\
D:\Personal-Notes\Powershell\Powershell Index.md
D:\Personal-Notes\Powershell\Powershell — Array Methods.md
D:\Personal-Notes\Powershell\Powershell — Constant Variable.md
D:\Personal-Notes\Powershell\Powershell — Count Line of Code.md
D:\Personal-Notes\Powershell\Powershell — Create Empty File.md
D:\Personal-Notes\Powershell\Powershell — Current Working Dir.md
D:\Personal-Notes\Powershell\Powershell — File Hash.md
D:\Personal-Notes\Powershell\Powershell — File Rename.md
D:\Personal-Notes\Powershell\Powershell — Generate Password.md
D:\Personal-Notes\Powershell\Powershell — Generate Self-signed Certificate.md
D:\Personal-Notes\Powershell\Powershell — Get Environment Variable.md
D:\Personal-Notes\Powershell\Powershell — Get OS Version.md
D:\Personal-Notes\Powershell\Powershell — Get Random.md
D:\Personal-Notes\Powershell\Powershell — Get Script Name.md
D:\Personal-Notes\Powershell\Powershell — List Directory contents excluding some.md
D:\Personal-Notes\Powershell\Powershell — List Directory.md
D:\Personal-Notes\Powershell\Powershell — Load Script.md
D:\Personal-Notes\Powershell\Powershell — Load Xml.md
D:\Personal-Notes\Powershell\Powershell — Monitoring website.md
D:\Personal-Notes\Powershell\Powershell — Multiline chain-method.md
D:\Personal-Notes\Powershell\Powershell — Ping Website.md
D:\Personal-Notes\Powershell\Powershell — Powershell ISE.md
D:\Personal-Notes\Powershell\Powershell — PSCommand.md
D:\Personal-Notes\Powershell\Powershell — Read-Json.md
D:\Personal-Notes\Powershell\Powershell — Rename File.md
D:\Personal-Notes\Powershell\Powershell — Script Template.md
D:\Personal-Notes\Powershell\Powershell — Search Files CreatedAt.md
D:\Personal-Notes\Powershell\Powershell — Throw and handle errors.md
D:\Personal-Notes\Powershell\Powershell — WPF App.md
D:\Personal-Notes\Powershell\Powershell — Write Log.md
D:\Personal-Notes\Powershell\_media\Simply-Form.config.xml
D:\Personal-Notes\Powershell\_media\Simply-Form.ps1
D:\Personal-Notes\Productive\Productive Index.md
D:\Personal-Notes\Productive\Productive — OKR and SMART Goals.md
D:\Personal-Notes\Productive\Productive — SMART Goals.md
D:\Personal-Notes\Programming Concept\Code Maintainability\
D:\Personal-Notes\Programming Concept\Naming\
D:\Personal-Notes\Programming Concept\_media\
D:\Personal-Notes\Programming Concept\Concept Index.md
D:\Personal-Notes\Programming Concept\Concept — Application Analytics.md
D:\Personal-Notes\Programming Concept\Concept — Authentication.md
D:\Personal-Notes\Programming Concept\Concept — CSP.md
D:\Personal-Notes\Programming Concept\Concept — Dynamic Type Loading.md
D:\Personal-Notes\Programming Concept\Concept — Easily Develop Features.md
D:\Personal-Notes\Programming Concept\Concept — Error Handling.md
D:\Personal-Notes\Programming Concept\Concept — Event Sourcing.md
D:\Personal-Notes\Programming Concept\Concept — Gray Box and Black Box Testing.md
D:\Personal-Notes\Programming Concept\Concept — High Level and Low Level.md
D:\Personal-Notes\Programming Concept\Concept — Ice Moca.md
D:\Personal-Notes\Programming Concept\Concept — log4net RollingFileAppender.md
D:\Personal-Notes\Programming Concept\Concept — Logging.md
D:\Personal-Notes\Programming Concept\Concept — Model and View.md
D:\Personal-Notes\Programming Concept\Concept — MVC.md
D:\Personal-Notes\Programming Concept\Concept — MVP.md
D:\Personal-Notes\Programming Concept\Concept — MVVM.md
D:\Personal-Notes\Programming Concept\Concept — Reminder.md
D:\Personal-Notes\Programming Concept\Concept — Technical Documentation.md
D:\Personal-Notes\Programming Concept\Concept — Troubleshooting Code.md
D:\Personal-Notes\Programming Concept\Concept — Unique Id.md
D:\Personal-Notes\Programming Concept\Concept — Unit Test.md
D:\Personal-Notes\Programming Concept\Concept — Workflow engine.md
D:\Personal-Notes\Programming Concept\Naming\Naming Is Hard — Settings vs Configuration.md
D:\Personal-Notes\Programming Concept\_media\HighLevelLowLevel_Example_1.drawio
D:\Personal-Notes\Programming Concept\_media\HighLevelLowLevel_Example_1.svg
D:\Personal-Notes\Programming Concept\_media\HighLevelLowLevel_Example_2.drawio
D:\Personal-Notes\Programming Concept\_media\HighLevelLowLevel_Example_2.svg
D:\Personal-Notes\Programming Concept\_media\Reminder.drawio
D:\Personal-Notes\Programming Concept\_media\Reminder.svg
D:\Personal-Notes\Sitecore\Sitecore Index.md
D:\Personal-Notes\Sitecore\Sitecore — Cache optimization.md
D:\Personal-Notes\Sitecore\Sitecore — Debug log.md
D:\Personal-Notes\Sitecore\Sitecore — Profiling.md
D:\Personal-Notes\Sitecore\Sitecore — Sitecore Content Editor search configuration.md
D:\Personal-Notes\Sitecore\Sitecore — Sitecore Event.md
D:\Personal-Notes\SQL\_media\
D:\Personal-Notes\SQL\SQL Index.md
D:\Personal-Notes\SQL\SQL — Analyze ASP .NET Membership.md
D:\Personal-Notes\SQL\SQL — Backup Database.md
D:\Personal-Notes\SQL\SQL — Database Normalization.md
D:\Personal-Notes\SQL\SQL — Delete or Drop Database.md
D:\Personal-Notes\SQL\SQL — Generate Key.md
D:\Personal-Notes\SQL\SQL — Transaction script template.md
D:\Personal-Notes\SQL\_media\Learn Database Normalization - 1NF_ 2NF_ 3NF_ 4NF_ 5NF - English.srt.md
D:\Personal-Notes\Tech\Tech — PII.md
D:\Personal-Notes\Tech\Tech — VS Code Optimization.md
D:\Personal-Notes\Time Management\Time Management Index.md
D:\Personal-Notes\Work\Team Lead\
D:\Personal-Notes\Work\_media\
D:\Personal-Notes\Work\Work Index.md
D:\Personal-Notes\Work\Work — API QA and Prod Strategies.md
D:\Personal-Notes\Work\Work — Asking Question.md
D:\Personal-Notes\Work\Work — Behavior Interview.md
D:\Personal-Notes\Work\Work — Bug Issue Resolution.md
D:\Personal-Notes\Work\Work — Burn out.md
D:\Personal-Notes\Work\Work — Carrot and Stick.md
D:\Personal-Notes\Work\Work — Client Oriented Mindsets.md
D:\Personal-Notes\Work\Work — Daylight Productivity.md
D:\Personal-Notes\Work\Work — Developer Resolutions.md
D:\Personal-Notes\Work\Work — Effort estimation.md
D:\Personal-Notes\Work\Work — Eligibility to Work in Singapore.md
D:\Personal-Notes\Work\Work — Facing Customer with Ticketing-based.md
D:\Personal-Notes\Work\Work — Feedback.md
D:\Personal-Notes\Work\Work — High Resilience Person.md
D:\Personal-Notes\Work\Work — Individual Contributor.md
D:\Personal-Notes\Work\Work — KPI.md
D:\Personal-Notes\Work\Work — Manager.md
D:\Personal-Notes\Work\Work — Marketplace Value.md
D:\Personal-Notes\Work\Work — Microsoft Leadership Principles.md
D:\Personal-Notes\Work\Work — OKR.md
D:\Personal-Notes\Work\Work — Ownership.md
D:\Personal-Notes\Work\Work — Project Managing.md
D:\Personal-Notes\Work\Work — Project Roadmap with Ticketing-based.md
D:\Personal-Notes\Work\Work — Propose ideas.md
D:\Personal-Notes\Work\Work — Requirement Gathering.md
D:\Personal-Notes\Work\Work — Resolve ticket-based issue tracker.md
D:\Personal-Notes\Work\Work — SMART Goals.md
D:\Personal-Notes\Work\Work — Solving Complex Problem.md
D:\Personal-Notes\Work\Work — T Model.md
D:\Personal-Notes\Work\Work — Taking Notes.md
D:\Personal-Notes\Work\Work — Technical Breadth.md
D:\Personal-Notes\Work\Work — Ways of working.md
D:\Personal-Notes\Work\Work — Work from home or work from anywhere.md
D:\Personal-Notes\Work\Team Lead\_media\
D:\Personal-Notes\Work\Team Lead\Team Lead — 30-day plan.md
D:\Personal-Notes\Work\Team Lead\Team Lead — Brain and Labor.md
D:\Personal-Notes\Work\Team Lead\Team Lead — First Time Manager.md
D:\Personal-Notes\Work\Team Lead\Team Lead — Good Leader slash Manager.md
D:\Personal-Notes\Work\Team Lead\Team Lead — Hybrid Work for Leaders.md
D:\Personal-Notes\Work\Team Lead\Team Lead — Leaders eat last.md
D:\Personal-Notes\Work\Team Lead\Team Lead — Performance Improvement Plan.md
D:\Personal-Notes\Work\Team Lead\Team Lead — Roadblock removing.md
D:\Personal-Notes\Work\Team Lead\Team Lead — Satya Nadella_s Authentic Leadership Style.md
D:\Personal-Notes\Work\Team Lead\Team Lead — Team Lead.md
D:\Personal-Notes\Work\Team Lead\Team Lead — Team Member.md
D:\Personal-Notes\Work\Team Lead\Team Lead — Terminating Member.md
D:\Personal-Notes\Work\Team Lead\_media\20231126_003131_image.png
D:\Personal-Notes\Work\_media\Why Your Less-Experienced Colleagues Are Promoted Instead of You! - English.srt.md
D:\Personal-Notes\_templates\Default.md
```