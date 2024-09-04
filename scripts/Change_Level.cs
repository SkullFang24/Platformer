using Godot;
using System;

public partial class Change_Level : Area2D
{
	// Called when the node enters the scene tree for the first time.
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
			GetTree().ChangeSceneToFile("res://scenes/Level2.tscn");
			
		}
	}

}
