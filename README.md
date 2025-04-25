# Minimal Failing Test

~~This a minimal reproducing godot project failing in a way that is mysterious to me.~~
This is now working as intended!

## Dependencies

```shell
dotnet add package Chickensoft.LogicBlocks
dotnet add package Chickensoft.LogicBlocks.DiagramGenerator
dotnet add package Chickensoft.Introspection.Generator
dotnet add package Chickensoft.AutoInject
dotnet add package Chickensoft.GodotNodeInterfaces
```

## Steps

Launch the godot project.  
Click on the button.  
Console displays :

```text
Setup Game !!!
OnResolved Called
Let's goooo !
This is successfully displayed
```

It never displays

```text
This never fires
```

despite the code in `Game.cs`

```C#
GameBinding
      .Handle(
      (in GameLogic.Output.Started output) => {
        GD.Print("This never fires");
        doSomething();
      });
```
