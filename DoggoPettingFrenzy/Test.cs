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
        Vector2 headDirection = head.Direction;
//        foreach(var dog in train)
//        {

//        }
    }

    public void AddDog(Dog dog)
    {
        train.Add(dog);
    }

    // Timer for Dog Spawn Rate
    public void OnDogSpawnTimerTimeout()
    { 

    }

    // Timer for Game Over
    public void OnGameEndTimerTimeout()
    {
        GD.Print(train.Count);
        foreach(Dog dog in train)
        {
            GD.Print(dog.Name);
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
