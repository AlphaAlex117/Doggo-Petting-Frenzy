using Godot;
using System;

public class Test : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private Area2D player;
    private Timer gameEndTimer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        player = GetNode<Area2D>("Player");
        gameEndTimer = GetNode<Timer>("GameEndTimer");
    }

    public override void _Process(float delta)
    {
        
    }

    public void OnDogSpawnTimerTimeout()
    { 

    }

    public void OnGameEndTimerTimeout()
    {
        player.Hide();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
