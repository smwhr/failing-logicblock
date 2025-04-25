namespace MinimalLogicTesting;

using System;
using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;



[Meta(typeof(IAutoNode))]
public partial class Game : Node3D, INode3D, IProvide<IGameLogic> {
  public override void _Notification(int what) => this.Notify(what);
  // IGameLogic IProvide<IGameLogic>.Value() => GameLogic;

  public IGameLogic GameLogic { get; set; } = default!;
  public GameLogic.IBinding GameBinding { get; set; } = default!;

  // public IGameLogic Value => new GameLogic(); // WRONG
  public IGameLogic Value => GameLogic; //GOOD


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


    this.Provide();
    GameLogic.Start();

  }

  private void doSomething() => throw new NotImplementedException();

  public void OnExitTree() {
    GameLogic.Stop();
    GameBinding.Dispose();
  }
}
