---
tags:
- Research
- Concept
- Draft
date: 2021-08-14
---

# Cara kerja log4net RollingFileAppender

use mutex to lock
FileStream --> FileMode.Append / Create based on parameter, FileAccess.Write, FileShare.Read
TextWriter
WindowsIdentity.Impersonate(IntPtr.Zero) --> Default Impersonation / process 's identity impersonation

