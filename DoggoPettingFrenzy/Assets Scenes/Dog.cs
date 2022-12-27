using Godot;
using System;

public abstract class Dog : Area2D
{
    // Declare member variables here. Examples:

    [Export]
    private String name;
    public String Name { get { return name; } set { name = value; } }

    [Export]
    public int Speed;

    public int behaviorStage = 0;

    public Vector2 velocity;

    public void Pet()
    {
        Hide();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // Normalize velocity
        velocity = velocity.Normalized() * Speed;

        // Gets the AnimatedSprite node of the dog.
        var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");

        // Updates the position of the dog.
        Position += velocity * delta;

        if (velocity.y > 0)
        {
            animatedSprite.Animation = "down";
        }
        else if (velocity.y < 0)
        {
            animatedSprite.Animation = "up";
        }
        else if (velocity.x > 0)
        {
            animatedSprite.Animation = "right";
        }
        else if (velocity.x < 0)
        {
            animatedSprite.Animation = "left";
        }
    }
}
