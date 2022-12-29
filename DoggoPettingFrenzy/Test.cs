using Godot;
using System;
using System.Collections;

public class Test : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Contains the player, which is the head of the train.
    private Player head;

    // Contains the train of dogs that follow the player.
    private ArrayList train;

    // Contains the Game Over timer.
    private Timer gameEndTimer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Get Player as Head of Train
        head = (Player) GetNode<Area2D>("Player");
        head.Gameplay = this;
        // Get Game Over Timer
        gameEndTimer = GetNode<Timer>("GameEndTimer");
        // Initialize new ArrayList for Train.
        train = new ArrayList();

    }

    public override void _Process(float delta)
    {
        // If train Count is greater than 0, then modifify direction and velocity of train.
        if (train.Count > 0)
        {
            Vector2 previousVelocity = head.TrainVelocity;
            Vector2 previousDirection = head.TrainDirection;
            
            foreach (Dog dog in train)
            {
                var temp = dog.velocity;
                dog.velocity = previousVelocity;
                previousVelocity = temp;

                dog.Direction = previousDirection;
            }
        }
    }
    
    public void AddDog(Dog dog)
    {
        if (train.Count <= 0)
        {
            var position = head.Position;
            //position.x += -head.TrainDirection.x / 2;
            //position.y += -head.TrainDirection.y / 2;
            dog.Position += position;
            GD.Print(position);
        }
        else
        {
            Dog tailDog = (Dog) train[train.Count - 1];
            var position = tailDog.Position;
            position.x += -tailDog.Direction.x / 2;
            position.y += -tailDog.Direction.y / 2;
            dog.Position += position;
        }
        dog.Speed = head.Speed;
        train.Add(dog);
    }

    // Timer for Dog Spawn Rate
    public void OnDogSpawnTimerTimeout()
    { 

    }

    // Timer for Game Over
    public void OnGameEndTimerTimeout()
    {
//        GD.Print(train.Count);
//        foreach(Dog dog in train)
//        {
//            GD.Print(dog.Name);
//        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
