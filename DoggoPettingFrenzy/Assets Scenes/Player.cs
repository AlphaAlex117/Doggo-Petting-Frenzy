using Godot;
using System;

public class Player : Area2D
{
    // The player's direction.
    [Export]
    private Vector2 direction;
    public Vector2 Direction { get { return direction; } }

    // The player's petting reach.
    [Export]
    public int Reach = 50;

    // How fast the player will move (pixels/sec). Exported so that you can change it in Godot.
    [Export]
    private int speed = 400; 
    public int Speed { get { return speed; } }

    // Size of the game window.
    public Vector2 ScreenSize;

    // Set of Raycasts to detect dogs.
    public RayCast2D forwardRay;
    public RayCast2D sideLeftRay;
    public RayCast2D sideRightRay;

    // The Gameplay Node
    [Export]
    private Test gameplay;
    public Test Gameplay { set { gameplay = value; } }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Gets the screensize.
        ScreenSize = GetViewportRect().Size;

        // Gets the raycast node.
        forwardRay = GetNode<RayCast2D>("ForwardRay");
        sideLeftRay = GetNode<RayCast2D>("SideLeftRay");
        sideRightRay = GetNode<RayCast2D>("SideRightRay");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // The player's movement vector.
        var velocity = Vector2.Zero; 

        // If D is pressed, then move right.
        if (Input.IsActionPressed("MoveRight"))
        {
            velocity.x += 1;
        }

        // If A is pressed, then move left.
        if (Input.IsActionPressed("MoveLeft"))
        {
            velocity.x -= 1;
        }

        // If S is pressed, then move down.
        if (Input.IsActionPressed("MoveDown"))
        {
            velocity.y += 1;
        }

        // If W is pressed, then move up.
        if (Input.IsActionPressed("MoveUp"))
        {
            velocity.y -= 1;
        }

        // If SPACE is pressed, then pet dog.
        if (Input.IsActionJustPressed("PetDog"))
        {
            // if one of the rays touches a dog, then pet the dog.
            if (forwardRay.IsColliding())
            {
                /*
                 * Potentially, if you use filters, you might filter dog only objects from every other object int he game. 
                 * Therefore, the process of check could be streamlined.
                 */
                
                Dog nearestDog = (Dog)forwardRay.GetCollider();
                nearestDog.Pet();
                gameplay.AddDog(nearestDog);
            }
            else if (sideLeftRay.IsColliding())
            {
                Dog nearestDog = (Dog)sideLeftRay.GetCollider();
                nearestDog.Pet();
                gameplay.AddDog(nearestDog);
            }
            else if (sideRightRay.IsColliding())
            {
                Dog nearestDog = (Dog)sideRightRay.GetCollider();
                nearestDog.Pet();
                gameplay.AddDog(nearestDog);
            }
        }

        // Gets the AnimatedSprite node of the player.
        var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");

        // If velocity is bigger than 0, then:
        if (velocity.Length() > 0)
        {
            // Updates direction of the player after it moves.
            direction = velocity.Normalized() * Reach;
            forwardRay.CastTo = direction;
            sideLeftRay.CastTo = direction;
            sideRightRay.CastTo = direction;

            // Normalizes the velocity of the character (think about vectors).
            velocity = velocity.Normalized() * Speed;

            // Plays the animation if the character velocity is more than 0.
            animatedSprite.Play();
        }
        else
        {
            // Stops the animation if the character velocity is 0 or less.
            animatedSprite.Stop();
        }

        // Updates the position of the character.
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
