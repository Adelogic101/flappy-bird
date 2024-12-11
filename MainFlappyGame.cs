using Godot;
using System;

public partial class MainFlappyGame : Node2D
{
	// Called when the node enters the scene tree for the first time.
	CanvasLayer gameOverScreen;

	public override void _Ready()
	{
		gameOverScreen = GetNode<CanvasLayer>("GameOverScreen");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void GameOverSignal(){
		gameOverScreen.Visible = true;
		GetTree().Paused = true;
		
	}
}
