namespace MinimalLogicTesting;

using System;
using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;



public interface IGame : INode3D {
  public IGameLogic GameLogic { get; }
}


[Meta(typeof(IAutoNode))]
public partial class Game : Node3D, IProvide<IGameLogic> {
  public override void _Notification(int what) => this.Notify(what);

  public IGameLogic GameLogic { get; set; } = default!;
  public GameLogic.IBinding GameBinding { get; set; } = default!;

  public IGameLogic Value => new GameLogic();


  public void Setup() {
    GameLogic = new GameLogic();
    GD.Print("Setup Game !!!");
  }


  public void OnResolved() {
    GD.Print("OnResolved Called");

    GameBinding = GameLogic.Bind();
    GameBinding
      .Handle(
      (in GameLogic.Output.Started output) => {
        GD.Print("This never fires");
        doSomething();
      });

    GameLogic.Start();

    this.Provide();

  }

  private void doSomething() => throw new NotImplementedException();

  public void OnExitTree() {
    GameLogic.Stop();
    GameBinding.Dispose();
  }
}
