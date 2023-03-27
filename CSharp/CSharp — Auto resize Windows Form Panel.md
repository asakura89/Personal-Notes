---
tags:
- CSharp
- C#
date: 2020-06-28
---

# Type dari string

how I can properly arrange .NET windows form panel, like auto scale when maximized and minimized

To properly arrange a .NET Windows Form panel and make it auto-scale when maximized and minimized, you can follow these steps:

1. Open your Windows Form in the Visual Studio designer.
2. Click on the panel control that you want to auto-scale.
3. In the Properties window, set the Anchor property to Top, Bottom, Left, and Right. This will anchor the panel to all four sides of the form, allowing it to resize proportionally with the form.
4. Set the Dock property to Fill. This will ensure that the panel fills the entire client area of the form.
5. Set the AutoSizeMode property to GrowAndShrink. This will allow the panel to adjust its size automatically when the form is resized.
6. If you have any child controls inside the panel, set their Anchor properties appropriately to ensure that they also resize and reposition correctly when the panel is resized.

With these settings, your panel should now be able to auto-scale when the form is maximized or minimized. You can test this by running your application and resizing the form to see how the panel and its contents adjust accordingly.
break through
ok, then how I can put 2 panel together, side-by-side and keep the auto-scale intact without overlap each other?

To put two panels together side-by-side and keep the auto-scale intact without overlapping each other, you can follow these steps:

```
Open your Windows Form in the Visual Studio designer.
Add two Panel controls to your form, and set their properties as desired (such as background color, size, etc.).
Select the first Panel control and set its Anchor property to Top, Bottom, Left.
Select the second Panel control and set its Anchor property to Top, Bottom, Right.
Set the Dock property of both panels to None.
Adjust the width of each panel as desired.
If you have any child controls inside the panels, adjust their Anchor properties appropriately to ensure that they also resize and reposition correctly when the panels are resized.
```

With these settings, your two panels should be positioned side-by-side without overlapping each other, and will auto-scale when the form is resized. The left panel will be anchored to the left side of the form and will resize horizontally with the form, while the right panel will be anchored to the right side of the form and will also resize horizontally with the form.

Note: if the two panels do not fit side-by-side on smaller screens, you may want to consider using a different layout strategy (such as a flow layout or a tab control) to ensure that all controls are visible and accessible to the user.
break through
what is the normal windows form size nowadays to support at least 720p

To support at least 720p resolution (1280x720 pixels) on a Windows Form, the minimum size you should consider is 1280x720 pixels. However, this may not be the optimal size for all applications, as the size of the form should be determined by the specific needs of the application and the content it displays.

In general, it is a good practice to design your Windows Form to be resizable, so that users can adjust the size of the form to their liking and to accommodate different screen resolutions. You can achieve this by setting the appropriate anchor and docking properties for the controls on the form.

As for the initial size of the form, it can depend on various factors such as the number of controls and the amount of content to be displayed. A good starting point might be to design your form with a width of 1280 pixels and a height of 720 pixels, and then adjust the size as needed based on the content and user feedback.
break through
which one is better name, "Settings" or "Configuration" for application?

Both "Settings" and "Configuration" are commonly used to refer to the user-customizable options and preferences for an application. Ultimately, the choice between these two names depends on the specific context and usage of the application.

"Settings" is a more commonly used term and may be more familiar to users. It is often used in the context of mobile and desktop applications, as well as web applications. "Settings" typically refers to options and preferences that are specific to a particular instance of the application, such as language, theme, and notification preferences.

"Configuration" is a more technical term and may be more appropriate for applications that are used in an enterprise or business setting. It often refers to options and preferences that are set by system administrators or IT professionals, such as database connections, network settings, and security configurations.

In general, it is important to choose a name that accurately reflects the purpose and functionality of the options and preferences being presented to the user. The name should be clear, concise, and easy to understand, and should align with the overall branding and design of the application.


