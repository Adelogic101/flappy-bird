using Godot;
using System;

public partial class FlappyPlayer : CharacterBody2D
{
int Score = 0;
    [Signal]
    public delegate void GameOverEventHandler();
    [Signal]
    public delegate void TestEventHandler();
    [Export]
	public PackedScene PipeScoreScene {get;set;}

    // Called when the node enters the scene tree for the first time.

    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        Vector2 mVelocity = Velocity;
        //mVelocity.Y += gravity/2 * (float)delta;


        if(Input.IsActionJustPressed("jump")){
            mVelocity.Y=-150;
        }
        else if(Input.IsActionJustPressed("moveForward")){
            mVelocity.X=2000;
        }
        else{
            mVelocity.X=0;
        }
        Velocity=mVelocity;
        MoveAndSlide();
    }

    public void onCollide(Area2D area){
        if (area.Name == "ScoreSensor")
        {
            Score = Score + 1;
            GD.Print(Score);
        }
        else {
            EmitSignal(SignalName.GameOver);
        }
    }
    public void OnTimerTimeout()
    {
        PipeScore mPipeScore = PipeScoreScene.Instantiate<PipeScore>();
		mPipeScore.Position = GetNode<Marker2D>("PipeScoreSpawn").Position;
		AddChild(mPipeScore);
    }

}