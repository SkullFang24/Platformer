using Godot;
using System;

public partial class Score : Label
{
	// Called when the node enters the scene tree for the first time.
	public int Points = 0;

	public void AddScore(int score)
	{
		Points += score;
		GD.Print("Score: " + Points);

		var scorelbl = GetParent().GetNode<CanvasLayer>("UserInterface").GetNode<Node>("GameUI").GetNode<Label>("Score");
		scorelbl.Text = "Score: " +  Points;
	}
}
