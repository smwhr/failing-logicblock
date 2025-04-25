namespace MinimalLogicTesting;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;
using Godot;

public interface IGameLogic : ILogicBlock<GameLogic.State>;

[Meta, Id("game_logic")]
[LogicBlock(typeof(State), Diagram = true)]
public partial class GameLogic : LogicBlock<GameLogic.State>, IGameLogic {
  public override Transition GetInitialState() => To<State.Initial>();

  public static class Input {
    public readonly record struct Go;
  }
  public static class Output {
    public readonly record struct Started;
  }

  [Meta]
  public abstract partial record State : StateLogic<State> {
    [Meta, Id("game_logic_initial")]
    public partial record Initial : State, IGet<Input.Go> {
      public Transition On(in Input.Go input) {
        GD.Print("This is successfully displayed");
        Output(new Output.Started());
        return To<Playing>();
      }
    }

    [Meta, Id("game_logic_playing")]
    public partial record Playing : State, IGet<Input.Go> {
      public Transition On(in Input.Go input) {
        GD.Print("Sorry, already started !");
        return ToSelf();
      }
    }
  }
}
