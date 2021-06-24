using Godot;
using System;

public class DoorBehavior : Node
{
	public AnimationTree animator;
	public Area2D boxCollider;
	public Bttn[] associatedButton;

	bool isOpen = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Update is called once per frame
	public override void _Process(float delta)
	{
		for (int i = 0; i < associatedButton.Length; i++)
		{
			if (associatedButton[i].isPressed)
			{
				isOpen = true;
			} else
			{
				isOpen = false;
				break;
			}
		}
		animator.Set("parameters/Open", isOpen);
		boxCollider.monitoring = !isOpen;
	}
}
