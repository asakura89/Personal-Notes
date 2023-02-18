---
tags:
- CSharp
- LINQPad
date: 2023-12-30
---

# Laptop always wake

```c#
<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main() {
    active = !active;
    if (active) {
        //CommonView.ProcessButtonAccesssor.Content = "❚❚";
        "Start".Dump();

        ctSource = new CancellationTokenSource();
        SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
        var taskSch = TaskScheduler.FromCurrentSynchronizationContext();
        await Task
            .Factory
            .StartNew(async () => {
                ctSource.Token.ThrowIfCancellationRequested();
                while (!ctSource.Token.IsCancellationRequested) {
                    await Task.Factory.StartNew(() => $"Pressing keeey at {DateTime.Now.ToString("hh:mm")}".Dump(), CancellationToken.None, TaskCreationOptions.None, taskSch);

                    // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys.send?view=netframework-4.6.1
                    // https://stackoverflow.com/questions/1645815/how-can-i-programmatically-generate-keypress-events-in-c
                    // https://docs.microsoft.com/id-id/windows/win32/inputdev/virtual-key-codes
                    Int32 VK_F13 = 0x7C;
                    UInt32 KEYEVENTF_EXTENDEDKEY = 0x0001;
                    keybd_event((Byte) VK_F13, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);

                    await Task.Factory.StartNew(() => "\r\nPressed".Dump(), CancellationToken.None, TaskCreationOptions.None, taskSch);
                    await Task.Factory.StartNew(() => "\r\nOk cooldown a bit\r\n\r\n".Dump(), CancellationToken.None, TaskCreationOptions.None, taskSch);

                    // should implement timer that can be cancelled by cancellationtoken ut I'm to lazy
                    Thread.Sleep(1000 * 60 * 5);
                }

                await Task.Factory.StartNew(() => {
                    "\r\nStopped\r\n\r\n".Dump();
                    //CommonView.ProcessButtonAccesssor.Content = "▷";
                }, CancellationToken.None, TaskCreationOptions.None, taskSch);
            }, ctSource.Token);
    }
    else
        ctSource.Cancel();
}

[DllImport("user32.dll")]
static extern void keybd_event(Byte bVk, Byte bScan, UInt32 dwFlags, UInt32 dwExtraInfo);

CancellationTokenSource ctSource;

Boolean active = false;
```

