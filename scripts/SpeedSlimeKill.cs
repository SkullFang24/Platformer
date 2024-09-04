using Godot;
using System;

public partial class SpeedSlimeKill : Area2D
{
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private void OnBodyEntered(Node body)
    {
        if (body is Player)
        {
            int damage = 10;
            Player player = (Player)body;
            player.DecreaseHealth(damage);
            
            // Get reference to the GameManager node and update player's health in UI
            GameManager gameManager = GetNode<GameManager>("../../GameManager");
            gameManager.DamageTaken(player.health);
            
        }
    }
}
