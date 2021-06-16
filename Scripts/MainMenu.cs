using Godot;
using System;

public class MainMenu : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	SceneTree tree; 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		tree = GetTree(); 
	}
	
	public void PlayGame()
	{
		tree.ChangeScene("res://Scenes/SampleScene.tscn"); 
	}

	public void QuitGame()
	{
		tree.Quit();
		PrintDebug("Quit");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
