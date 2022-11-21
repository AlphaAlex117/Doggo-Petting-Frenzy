using Godot;
using System;

public class Dalmatian : Dog
{
    // Declare member variables here. Examples:


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		velocity.x = 1;
		velocity.y = 0;
	}

	public void OnBehaviorTimerTimeout()
	{
		behaviorStage = (behaviorStage + 1) % 4;

		switch (behaviorStage)
		{
			case 0:
				velocity.x = 1;
				velocity.y = 0;
				break;

			case 1:
				velocity.x = 0;
				velocity.y = 1;
				break;

			case 2:
				velocity.x = -1;
				velocity.y = 0;
				break;

			case 3:
				velocity.x = 0;
				velocity.y = -1;
				break;

			default:
				break;
		}
	}
}
