using Godot;
using System;

public class Button : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	
	public bool IsPressed 
	{get; set;}
	public Texture UpButton;
	public Texture DownButton;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		IsPressed = false; 
	}
	
	public override void _Process(float delta)
	{
		Console.WriteLog("IsPressed: " + isPressed);
		if (IsPressed) {
			GetNode("Sprite").Texture = DownButton;
		} else {
			GetNode("Sprite").Texture = UpBotton; 
		}
		
	}
	
	
	
	
	
}
