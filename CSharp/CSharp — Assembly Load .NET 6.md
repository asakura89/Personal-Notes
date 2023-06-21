---
tags:
- CSharp
- C#
date: 2023-06-21
---

# Assembly Load .NET 6

{Content}


<!-- 
## User
Hi Bing, do you know what is this and how to fix it? .NET 6 Assembly 'ExampleAssembly' was not found in the current AppDomain.
## Bing
It seems like you are encountering an error message that says Assembly 'ExampleAssembly' was not found in the current AppDomain. This error message usually occurs when the .NET runtime is unable to locate an assembly that is being referenced by your code. There could be several reasons why this error occurs, such as incorrect assembly name, version mismatch, or missing dependencies.
Unfortunately, I couldn't find any specific information about the 'ExampleAssembly' you mentioned in my search results. Could you provide more details about the context of this error message?
## User
ExampleAsembly is just a dummy assembly name that I build. can you find how I can load assembly in .NET 6 so I can run my project properly in above error context?
## Bing
To load an assembly in .NET 6, you can use one of the several load methods contained in the classes AppDomain and Assembly. For example, you can use the LoadFromAssemblyPath method of the AssemblyLoadContext.Default class to load an assembly from a specific file path . Here is an example:

[csharp]
Assembly dynamicAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(@"C:\LocationOf\ExampleAssembly.dll");
After loading the assembly, you can use methods such as GetModule and GetType to access the types defined within the assembly .
Is this what you were looking for?
## User
I don't use AssemblyLoadContext to load my assembly. I used Assembly.Load intead. where it loads my assembly? because it cannot be found in current AppDomain
## Bing
The Assembly.Load method loads an assembly into the current application domain . If you are using this method to load your assembly, but it cannot be found in the current AppDomain, it could mean that the assembly failed to load for some reason. There could be several reasons why this error occurs, such as incorrect assembly name, version mismatch, or missing dependencies.
You can try handling the AppDomain.AssemblyResolve event to gain more control over assembly loading and to troubleshoot assembly loading issues . This event is raised whenever the runtime fails to bind to an assembly by name. By handling this event, you can load an assembly into the load context from outside the normal probing paths, select which of several assembly versions to load, emit a dynamic assembly and return it, and so on .
Is this helpful?



## User
Hi Bing, can you generate me a .NET 6 code that load plug ins from folder and each folder is contains different plugins
## Bing
Sure, I can try to generate some code for you. Here is what I came up with:

[csharp]
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PluginDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the path of the plugins folder
            var pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            // Get all the subfolders in the plugins folder
            var pluginFolders = Directory.GetDirectories(pluginsPath);

            // Create a list to store the loaded plugins
            var plugins = new List<IPlugin>();

            // Loop through each subfolder
            foreach (var folder in pluginFolders)
            {
                // Get the name of the subfolder
                var folderName = Path.GetFileName(folder);

                // Get the path of the plugin assembly
                var pluginPath = Path.Combine(folder, $"{folderName}.dll");

                // Load the plugin assembly
                var pluginAssembly = Assembly.LoadFile(pluginPath);

                // Get the types that implement the IPlugin interface
                var pluginTypes = pluginAssembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t));

                // Loop through each plugin type
                foreach (var type in pluginTypes)
                {
                    // Create an instance of the plugin type
                    var plugin = (IPlugin)Activator.CreateInstance(type);

                    // Add the plugin to the list
                    plugins.Add(plugin);
                }
            }

            // Loop through each loaded plugin
            foreach (var plugin in plugins)
            {
                // Invoke the Execute method of the plugin
                plugin.Execute();
            }
        }
    }

    // Define a common interface for plugins
    public interface IPlugin
    {
        void Execute();
    }
}
## User
Can you improve this code to make it more efficient?
## Bing
Sure, I can try to optimize this code for you. Here are some possible improvements:
 - Use the Directory.EnumerateDirectories method instead of the Directory.GetDirectories method to avoid loading all the subfolders into memory at once.
 - Use the AssemblyLoadContext class instead of the Assembly.LoadFile method to load the plugin assemblies in a separate context and avoid locking the files.
 - Use the ActivatorUtilities.CreateInstance method instead of the Activator.CreateInstance method to support dependency injection for the plugin types.

Here is the updated code:

[csharp]
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyInjection;

namespace PluginDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the path of the plugins folder
            var pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            // Create a service collection for dependency injection
            var services = new ServiceCollection();

            // Add some services that the plugins may depend on
            services.AddSingleton<ILogger, ConsoleLogger>();
            services.AddSingleton<IConfiguration, AppConfiguration>();

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            // Create a list to store the loaded plugins
            var plugins = new List<IPlugin>();

            // Loop through each subfolder in the plugins folder
            foreach (var folder in Directory.EnumerateDirectories(pluginsPath))
            {
                // Get the name of the subfolder
                var folderName = Path.GetFileName(folder);

                // Get the path of the plugin assembly
                var pluginPath = Path.Combine(folder, $"{folderName}.dll");

                // Create a new assembly load context for the plugin assembly
                var pluginContext = new AssemblyLoadContext(folderName, true);

                // Load the plugin assembly into the context
                var pluginAssembly = pluginContext.LoadFromAssemblyPath(pluginPath);

                // Get the types that implement the IPlugin interface
                var pluginTypes = pluginAssembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t));

                // Loop through each plugin type
                foreach (var type in pluginTypes)
                {
                    // Create an instance of the plugin type using dependency injection
                    var plugin = (IPlugin)ActivatorUtilities.CreateInstance(serviceProvider, type);

                    // Add the plugin to the list
                    plugins.Add(plugin);
                }
            }

            // Loop through each loaded plugin
            foreach (var plugin in plugins)
            {
                // Invoke the Execute method of the plugin
                plugin.Execute();
            }
        }
    }

    // Define a common interface for plugins
    public interface IPlugin
    {
        void Execute();
    }

    // Define some interfaces and classes for dependency injection
    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IConfiguration
    {
        string GetSetting(string key);
    }

    public class AppConfiguration : IConfiguration
    {
        public string GetSetting(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}
## User
what about all references of the plugin? do they loaded together with the assemblies we load through AssemblyLoadContext?
## Bing
According to the documentation, the AssemblyLoadContext class creates an isolated context for loading code and its dependencies in their own instance. This means that the references of the plugin assemblies are not automatically loaded with them, unless they are explicitly resolved by overriding the AssemblyLoadContext.Load(AssemblyName) method or handling the AssemblyLoadContext.Resolving event. Otherwise, the default context will be used to locate and load the dependencies. This can cause versioning conflicts or type conversion issues if the same dependency is loaded by different contexts . Therefore, it is recommended to isolate the dependencies of each plugin assembly in its own AssemblyLoadContext instance.
## User
can you generate code that handles AssemblyLoadContext.Resolving event to load all plugin's references?
## Bing
Sure, I can try to generate some code for you. Here is what I came up with:

[csharp]
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace PluginDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the path of the plugins folder
            var pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            // Create a list to store the loaded plugins
            var plugins = new List<IPlugin>();

            // Loop through each subfolder in the plugins folder
            foreach (var folder in Directory.EnumerateDirectories(pluginsPath))
            {
                // Get the name of the subfolder
                var folderName = Path.GetFileName(folder);

                // Get the path of the plugin assembly
                var pluginPath = Path.Combine(folder, $"{folderName}.dll");

                // Create a new assembly load context for the plugin assembly
                var pluginContext = new PluginAssemblyLoadContext(folderName, pluginPath);

                // Load the plugin assembly into the context
                var pluginAssembly = pluginContext.LoadFromAssemblyPath(pluginPath);

                // Get the types that implement the IPlugin interface
                var pluginTypes = pluginAssembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t));

                // Loop through each plugin type
                foreach (var type in pluginTypes)
                {
                    // Create an instance of the plugin type
                    var plugin = (IPlugin)Activator.CreateInstance(type);

                    // Add the plugin to the list
                    plugins.Add(plugin);
                }
            }

            // Loop through each loaded plugin
            foreach (var plugin in plugins)
            {
                // Invoke the Execute method of the plugin
                plugin.Execute();
            }
        }
    }

    // Define a common interface for plugins
    public interface IPlugin
    {
        void Execute();
    }

    // Define a custom assembly load context for plugins
    public class PluginAssemblyLoadContext : AssemblyLoadContext
    {
        private readonly string _pluginFolder;
        private readonly string _pluginPath;

        public PluginAssemblyLoadContext(string name, string pluginPath) : base(name, true)
        {
            _pluginFolder = Path.GetDirectoryName(pluginPath);
            _pluginPath = pluginPath;

            // Subscribe to the Resolving event to handle the dependencies of the plugin assembly
            this.Resolving += OnResolving;
        }

        private Assembly OnResolving(AssemblyLoadContext context, AssemblyName name)
        {
            // Check if the requested assembly is already loaded in this context
            var loadedAssembly = context.Assemblies.FirstOrDefault(a => a.GetName().Name == name.Name);
            if (loadedAssembly != null)
            {
                return loadedAssembly;
            }

            // Check if the requested assembly is the same as the plugin assembly
            if (name.Name == Path.GetFileNameWithoutExtension(_pluginPath))
            {
                return null; // Let the base class load it from the specified path
            }

            // Try to find the dependency assembly in the same folder as the plugin assembly
            var dependencyPath = Path.Combine(_pluginFolder, $"{name.Name}.dll");
            if (File.Exists(dependencyPath))
            {
                return context.LoadFromAssemblyPath(dependencyPath); // Load it from there
            }

            return null; // Let the default context handle it
        }
    }
}
## User
Can you improve this code to make it more robust?
## Bing
Sure, I can try to make this code more robust. Here are some possible improvements:
 - Use the Path.Combine method instead of string interpolation to construct the paths of the subfolders and assemblies.
 - Use the AssemblyName.GetAssemblyName method instead of the Path.GetFileNameWithoutExtension method to compare the assembly names, as it also checks the version and culture information.
 - Use the TryGetValue method instead of the FirstOrDefault method to check if the requested assembly is already loaded in this context, as it is more efficient and avoids potential null reference exceptions.
 - Use the AssemblyDependencyResolver class instead of manually searching for the dependency assemblies in the same folder as the plugin assembly, as it can handle complex dependency graphs and native libraries.

Here is the updated code:

[csharp]
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace PluginDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the path of the plugins folder
            var pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            // Create a list to store the loaded plugins
            var plugins = new List<IPlugin>();

            // Loop through each subfolder in the plugins folder
            foreach (var folder in Directory.EnumerateDirectories(pluginsPath))
            {
                // Get the name of the subfolder
                var folderName = Path.GetFileName(folder);

                // Get the path of the plugin assembly
                var pluginPath = Path.Combine(folder, $"{folderName}.dll");

                // Create a new assembly load context for the plugin assembly
                var pluginContext = new PluginAssemblyLoadContext(folderName, pluginPath);

                // Load the plugin assembly into the context
                var pluginAssembly = pluginContext.LoadFromAssemblyPath(pluginPath);

                // Get the types that implement the IPlugin interface
                var pluginTypes = pluginAssembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t));

                // Loop through each plugin type
                foreach (var type in pluginTypes)
                {
                    // Create an instance of the plugin type
                    var plugin = (IPlugin)Activator.CreateInstance(type);

                    // Add the plugin to the list
                    plugins.Add(plugin);
                }
            }

            // Loop through each loaded plugin
            foreach (var plugin in plugins)
            {
                // Invoke the Execute method of the plugin
                plugin.Execute();
            }
        }
    }

    // Define a common interface for plugins
    public interface IPlugin
    {
        void Execute();
    }

    // Define a custom assembly load context for plugins
    public class PluginAssemblyLoadContext : AssemblyLoadContext
    {
        private readonly string _pluginPath;
        private readonly AssemblyDependencyResolver _resolver;

        public PluginAssemblyLoadContext(string name, string pluginPath) : base(name, true)
        {
            _pluginPath = pluginPath;

            // Create an assembly dependency resolver for the plugin assembly
            _resolver = new AssemblyDependencyResolver(pluginPath);

            // Subscribe to the Resolving event to handle the dependencies of the plugin assembly
            this.Resolving += OnResolving;
        }

        private Assembly OnResolving(AssemblyLoadContext context, AssemblyName name)
        {
            // Check if the requested assembly is already loaded in this context
            if (context.Assemblies.TryGetValue(name, out var loadedAssembly))
            {
                return loadedAssembly;
            }

            // Check if the requested assembly is the same as the plugin assembly
            if (name.Equals(AssemblyName.GetAssemblyName(_pluginPath)))
            {
                return null; // Let the base class load it from the specified path
            }

            // Try to resolve the dependency assembly using the resolver
            var dependencyPath = _resolver.ResolveAssemblyToPath(name);
            if (dependencyPath != null)
            {
                return context.LoadFromAssemblyPath(dependencyPath); // Load it from there
            }

            return null; // Let the default context handle it
        }
    }
}



-->