using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public const float Speed = 130.0f;
    public const float JumpVelocity = -300.0f;

    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public int health = 100;
    public int life = 2;
    public bool Dead = false;

    private Vector2 originalPosition;

    public override void _Ready()
    {
        originalPosition = Position;
    }
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        var animSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        if (!IsOnFloor())
        {
            velocity.Y += gravity * (float)delta;
            animSprite.Play("jump");
        }
        if (Input.IsActionJustPressed("jump") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        float direction = Input.GetAxis("move_left", "move_right");
        if (direction < 0)
        {
            animSprite.FlipH = true;

        }
        else if (direction > 0)
        {
            animSprite.FlipH = false;

        }
        if (IsOnFloor())
        {
            if (direction == 0)
            {
                animSprite.Play("idle");
            }
            else
            {
                animSprite.Play("run");
            }
        }

        velocity.X = direction * Speed;

        Velocity = velocity;
        MoveAndSlide();
    }

    public void ResetHealth()
    {
        health = 100;
        var healthUI = GetParent().GetNode<CanvasLayer>("UserInterface").GetNode<Control>("GameUI").GetNode<Label>("Health");
        healthUI.Text = "Health: " + health;
    }

    public void LifeCounter()
    {
        life -= 1;
        var lifeUI = GetParent().GetNode<CanvasLayer>("UserInterface").GetNode<Control>("GameUI").GetNode<Label>("Lives");
		lifeUI.Text = "Lives: " + life;
        GD.Print("Life Used");
    }

    public void ResetPosition()
    {
        Position = originalPosition;
    }
    public void DecreaseHealth(int amount)
    {
        health -= amount;
        GD.Print("Player Health: " + health);
        
        var healthUI = GetParent().GetNode<CanvasLayer>("UserInterface").GetNode<Control>("GameUI").GetNode<Label>("Health");
        healthUI.Text = "Health: " + health;

        if (health <= 0)
        {
            GD.Print("Player is dead!");
            GD.Print("Player Lost a Life");
            Dead = true;
    
            if (Dead == true)
            {
                LifeCounter();
                ResetHealth();
                ResetPosition();
            }
            
            if(life < 0)
            {
                GetTree().ChangeSceneToFile("res://scenes/GameOver.tscn");
            }
        }
        
    }
}
