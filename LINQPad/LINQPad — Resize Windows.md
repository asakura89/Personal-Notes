---
tags:
- CSharp
- LINQPad
date: 2023-12-30
---

# Laptop always wake

```c#
<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Xml</Namespace>
</Query>

void Main() {
    IList<Profile> profiles = new List<Profile> {
        /*new Profile { Name = "Default Window", Size = new Size(1265, 695) },
        new Profile { Name = "Default Mini-window", Size = new Size(850, 340) },
        new Profile { Name = "Default Bar", Size = new Size(235, 26) },*/
        new Profile { Name = "Make sense for 125% 1080p", Size = new Size(1442, 780) }
    };
    
    var profile = profiles.Last();

    try {
        IList<ActiveWindow> allWindows = ActiveWindowCollector.GetActiveWindows();
        IList<ActiveWindow> selectedWindowList = allWindows
            .Where(wnd => !new[] { "start", "chiisanairoiro" }.Contains(wnd.Name.ToLowerInvariant()))
            .ToList();

        Boolean considerScalingFactor = false;
        foreach (ActiveWindow item in selectedWindowList) {
            Sizer.Set(item.Id, (Int32) profile.Size.Width, (Int32) profile.Size.Height, considerScalingFactor);
        }
    }
    catch (Exception ex) {
        
    }
}

public class Profile {
    public String Name { get; set; }
    public Size Size { get; set; }

    public override String ToString() => $"{Name} [{Size.Width}×{Size.Height}]";
}

public class ActiveWindow {
    public IntPtr Id { get; set; }
    public String Name { get; set; }
}

public static class Sizer {
    public static void Set(IntPtr hWnd, Int32 w, Int32 h, Boolean isScaled = true) {
        if (isScaled)
            SetSizeAsScaled(ref w, ref h);

        var rect = new Rect();
        if (GetWindowRect(hWnd, ref rect))
            MoveWindow(hWnd, rect.X, rect.Y, w, h, true);
    }

    static void SetSizeAsScaled(ref Int32 w, ref Int32 h) {
        Single scale = GetScalingFactor();
        w = (Int32) Math.Round(w * scale);
        h = (Int32) Math.Round(h * scale);
    }

    static Single GetScalingFactor() {
        UInt32 dpix, dpiy;
        GetDpi(0, 0, MONITOR_DPI_TYPE.MDT_EFFECTIVE_DPI, out dpix, out dpiy);

        const Int32 Default = 96;
        return (Single) dpix / Default;
    }

    static void GetDpi(Int32 x, Int32 y, MONITOR_DPI_TYPE dpiType, out UInt32 dpiX, out UInt32 dpiY) {
        var point = new System.Drawing.Point(x + 1, y + 1);
        IntPtr mon = MonitorFromPoint(point, MONITOR_POINT.MONITOR_DEFAULTTONEAREST);
        GetDpiForMonitor(mon, dpiType, out dpiX, out dpiY);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect {
        public Int32 X;
        public Int32 Y;
        public Int32 Width;
        public Int32 Height;
    }

    [DllImport("user32.dll", SetLastError = true)]
    static extern Boolean GetWindowRect(IntPtr hWnd, ref Rect rect);

    [DllImport("user32.dll", SetLastError = true)]
    static extern Boolean MoveWindow(IntPtr hWnd, Int32 x, Int32 y, Int32 width, Int32 height, Boolean repaint);

    enum MONITOR_POINT {
        MONITOR_DEFAULTTONULL = 0,
        MONITOR_DEFAULTTOPRIMARY = 1,
        MONITOR_DEFAULTTONEAREST = 2
    }

    enum MONITOR_DPI_TYPE {
        MDT_EFFECTIVE_DPI = 0,
        MDT_ANGULAR_DPI = 1,
        MDT_RAW_DPI = 2,
        MDT_DEFAULT = 3
    }

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr MonitorFromPoint([In]System.Drawing.Point pt, [In]MONITOR_POINT dwFlags);

    [DllImport("SHCore.dll", SetLastError = true)]
    static extern IntPtr GetDpiForMonitor([In]IntPtr hmonitor, [In]MONITOR_DPI_TYPE dpiType, [Out]out UInt32 dpiX, [Out]out UInt32 dpiY);
}

public static class ActiveWindowCollector {
    public static IList<ActiveWindow> GetActiveWindows() {
        IntPtr lShellWindow = GetShellWindow();
        var lWindows = new List<ActiveWindow>();

        EnumWindows(delegate (IntPtr hWnd, Int32 lParam) {
            if (hWnd == lShellWindow)
                return true;
            if (!IsWindowVisible(hWnd))
                return true;

            Int32 lLength = GetWindowTextLength(hWnd);
            if (lLength == 0)
                return true;

            var lBuilder = new StringBuilder(lLength);
            GetWindowText(hWnd, lBuilder, lLength + 1);

            lWindows.Add(new ActiveWindow { Id = hWnd, Name = lBuilder.ToString() });
            return true;

        }, 0);

        return lWindows;
    }

    delegate Boolean EnumWindowsProc(IntPtr hWnd, Int32 lParam);

    [DllImport("user32.dll", SetLastError = true)]
    static extern Boolean EnumWindows(EnumWindowsProc enumFunc, Int32 lParam);

    [DllImport("user32.dll", SetLastError = true)]
    static extern Int32 GetWindowText(IntPtr hWnd, StringBuilder lpString, Int32 nMaxCount);

    [DllImport("user32.dll", SetLastError = true)]
    static extern Int32 GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    static extern Boolean IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr GetShellWindow();
}
```

