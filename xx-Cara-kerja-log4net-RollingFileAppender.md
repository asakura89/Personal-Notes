<p>
  <h1 align="center">Kelompok Belajar Bunga Matahari</h1>
  <h3 align="center" style="margin-top: -2em;">Coding sudah seharusnya menyenangkan!</h3>
  <h5 align="center" style="margin-top: -0.5em;">
    <a href="https://github.com/asakura89/BisaCSharp.git">asakura89</a> /
    <a href="https://choosealicense.com/licenses/unlicense/">UNLICENSE</a>
  </h5>
  <!-- use MistyLightWindows theme -->
</p>



[TOC]



## [.Net] Cara kerja log4net RollingFileAppender

use mutex to lock
FileStream --> FileMode.Append / Create based on parameter, FileAccess.Write, FileShare.Read
TextWriter
WindowsIdentity.Impersonate(IntPtr.Zero) --> Default Impersonation / process 's identity impersonation

