using Godot;
using System;

public partial class SlimeKill : Area2D
{
    
    public override void _Ready()
    {
        Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
    }

    public override void _Process(double delta)
    {
    }

    private void OnBodyEntered(Node body)
    {
        if (body is Player)
        {
            int damage = 25;
            Player player = (Player)body;
            player.DecreaseHealth(damage);
            
            GameManager gameManager = GetNode<GameManager>("../../GameManager");
            gameManager.DamageTaken(player.health);
            
        }
    }
}
