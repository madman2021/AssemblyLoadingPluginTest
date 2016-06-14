#Loading plugins
This is a basic implementation of a plugin system for a project. This allows your application to be extended without changing existing code or re-compiling the original project, only a new .dll file is needed to extend the application. 

This is accomplished using [System.Reflection](https://msdn.microsoft.com/en-us/library/system.reflection%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396) to load the assemblies and [Interfaces](https://msdn.microsoft.com/en-us/library/ms173156.aspx).
https://msdn.microsoft.com/en-us/library/ms173156.aspx
##Creating Plugins
To create a plugin that can be consumed by the project simply do the following:- 
+ Create a new Project and Reference the PluginInterface project or dll. 
+ Create a public class and implement the IPlugin interface. 
```csharp
public class NewPlugin : IPlugin  
{  
    public string Name {
        get{ return "NewPlugin";}
    }
    
    public void Work(){
    //Do Stuff
    }
}   
```
+ Build and drop the DLL in the plugins directory. 
+ Win!

