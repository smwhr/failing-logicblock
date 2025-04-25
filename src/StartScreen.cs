namespace MinimalLogicTesting;

using Chickensoft.AutoInject;
using Chickensoft.Introspection;
using Godot;

[Meta(typeof(IAutoNode))]
public partial class StartScreen : Control {

  public override void _Notification(int what) => this.Notify(what);

  [Dependency] public IGameLogic GameLogic => this.DependOn<IGameLogic>();

  public GameLogic.IBinding GameBinding { get; set; } = default!;


  public Button StartButton { get; private set; } = default!;
  public int ButtonPresses { get; private set; }

  // Called when the node enters the scene tree for the first time.
  public override void _Ready() => StartButton = GetNode<Button>("%StartButton");

  public void OnStartButtonPressed() {
    GD.Print("Let's goooo !");
    GameLogic.Input(new GameLogic.Input.Go());
  }
}
