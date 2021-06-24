using Godot;
using System;

public class PlayerMovement : RigidBody2D
{
	public float moveSpeed = 5f;
	public float acceleration = 1f; 
	public KinematicBody2D kb;
	public string playerType = "A";
	public AnimationTree animator;


	Vector2 movement;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		float right =  Input.GetActionStrength("Right" + playerType);
		float left = Input.GetActionStrength("Left" + playerType);
		float up = Input.GetActionStrength("Up" + playerType);
		float down = Input.GetActionStrength("Down" + playerType);
		
		
		movement.x = right - left; 
		movement.y = down - up; 
		
		// TODO: Create animatior, add paths to playermovement
		animator.Set("parameters/movement/Horizontal", movement.x);
		animator.Set("parameters/movement/Vertical", movement.y);
		animator.Set("parameters/movement/Speed", movement.LengthSquared());
 	}
	
	public override void _PhysicsProcess(float delta)
	{
		// if no input
		if(movement == Vector2.Zero) {
			moveSpeed = 0;
		} else if (moveSpeed <= Init.maxSpeed) {
			moveSpeed += acceleration; 
		}
	  
		kb.MoveAndCollide(movement * moveSpeed * delta);


	}
	
	
}
