using Godot;
using System;

public partial class Game_Finished : Area2D
{
	public override void _Ready()
	{
		GD.Print("Gate Level Initialized");
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBodyEntered(Node body)
	{
		if(body is Player){
			GD.Print("Collided");
			GetTree().ChangeSceneToFile("res://scenes/GameFinishedScreen.tscn");
		}
	}

}
