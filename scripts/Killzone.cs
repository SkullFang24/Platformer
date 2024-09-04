using Godot;
using System;

public partial class Killzone : Area2D
{
    public int life = 2;
    public int deathcount = 0;
    private Vector2 originalPlayerPosition;

    public override void _Ready()
    {
        Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
        originalPlayerPosition = GetNode<Player>("../../Player").GlobalPosition;
    }

    public override void _Process(double delta)
    {

    }

    public void LifeCounter()
    {
        life -= 1;
        var lifeUI = GetParent().GetNode<CanvasLayer>("UserInterface").GetNode<Control>("GameUI").GetNode<Label>("Lives");
		lifeUI.Text = "Lives: " + life;
        GD.Print("Life Used");
    }
    private void OnBodyEntered(Node body)
    {
        if (body is Player)
        {
            
            LifeCounter();

            if (life < 0)
            {
                GetTree().ChangeSceneToFile("res://scenes/GameOver.tscn");
            }
            else
            {
                var player = (Player)body;
                player.GlobalPosition = originalPlayerPosition;

                var resetTimer = GetNode<Timer>("Timer");
                resetTimer.Start();
                resetTimer.Connect("timeout", new Callable(this, nameof(OnResetTimerTimeout)));
                Engine.TimeScale = 0.5f;

            }
        }
    }

    private void OnResetTimerTimeout()
    {
        Engine.TimeScale = 1.0f;
    }
}
