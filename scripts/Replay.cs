using Godot;
using System;

public partial class Replay : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/Level1.tscn");
	}
}
