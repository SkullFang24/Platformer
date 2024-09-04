using Godot;
using System;

public partial class GameManager : Node
{
	public int Score = 0;
	public int health = 100;
	public int life = 2;
	

	public override void _Ready()
	{
		health = 100;
		life = 2;	
		var healthUI = GetParent().GetNode<CanvasLayer>("UserInterface").GetNode<Control>("GameUI").GetNode<Label>("Health");
		healthUI.Text = "Health: " + health;
		var lifeUI = GetParent().GetNode<CanvasLayer>("UserInterface").GetNode<Control>("GameUI").GetNode<Label>("Lives");
		lifeUI.Text = "Lives: " + life;	
	}
	public void AddScore(int score)
	{
		Score += score;
		GD.Print("Score: " + Score);

		var scorelbl = GetParent().GetNode<Node>("Labels").GetNode<Label>("score");
		var scorelblUI = GetParent().GetNode<CanvasLayer>("UserInterface").GetNode<Control>("GameUI").GetNode<Label>("score2");
		
		scorelbl.Text = "You Collected " +  Score + " Coins";
		scorelblUI.Text = "Score: "+ Score;

	}

	public void DamageTaken(int newHealth)
	{
		health = newHealth; 
		GD.Print("Player Health: " + health);
	}

	public void Lives(int newlives)
	{
		life = newlives; 
		GD.Print("Player Lives: " + life);
	}

	public void DecreaseLife()
	{
		life -= 1;
        var lifeUI = GetParent().GetNode<CanvasLayer>("UserInterface").GetNode<Control>("GameUI").GetNode<Label>("Lives");
		lifeUI.Text = "Lives: " + life;
        GD.Print("Life Used");
	}

	
	
}
