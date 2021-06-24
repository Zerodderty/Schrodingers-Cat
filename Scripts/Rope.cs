using Godot;
using System;

public class Rope : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	public RigidBody2D StartHook;
	public PackedScene LinkPrefab;
	public int links = 7;
	public MiddleLink MiddleLink;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Load LinkPrefab in as packed scene 
		LinkPrefab = GD.Load<PackedScene>("res://Scenes/LinkPrefab.tscn");
		
		// Set starthook to the child of TailA named RigidBody2D
		StartHook = GetNode("RigidBody2D"); 
		
		// Modify starthook's dampened string 
		DampedSpringJoint2D sj = StartHook.GetNode("DampedSpringJoint2D");
		Init.InitializeSpringJoint(sj, StartHook.GetPath()); 
		GenerateRope();
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }


	private void GenerateRope()
	{
		RigidBody2D previousRB = StartHook;

		for (int i = 0; i < links; i++)
		{
			Node2D link  = LinkPrefab.Instance(); 
			AddChild(link); 
			link.Owner = GetEditedSceneRoot(); 
			DampedSpringJoint2D joint = link.GetNode("RigidBody2D/DampedSpringJoint2D");
			
			Init.InitializeSpringJoint(joint, link.GetNode("RigidBody2D").GetPath());
			joint.NodeB = previousRB.GetPath();
			
			link.GetNode("Sprite").Modulate = startHook.GetNode("Sprite").Modulate;

			if (i < links - 1)
			{
				previousRB = link.GetNode("RigidBody2D");
			} else
			{
				MiddleLink.ConnectRopeEnd(link.GetNode("RigidBody2D"));
			}

		}
	}
}
