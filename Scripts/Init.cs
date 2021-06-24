using Godot;
using System;

public class Init : Node
{
	
	public static float frictionStatic = 0.5f; 
	public static float frictionDynamic = 0.25f; 

	public static float maxSpeed = 10f; 
	public static float startMoveSpeed = 5f; 

	public static float RestLength {get; set;} = 0.1f; 
	public static float Frequency {get; set;} = 5f; 
	public static float Damping {get; set;} = 0.5;
	public static float Stiffness {get; set;} = 20f; 
	
	public static Init _instance;

	public static Init Instance 
	{
		get
		{
			if (_instance == null) {
				Console.WriteLine("Null manager?"); 
			}

			return _instance; 
		}
	}
	
	private override void _Ready()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}
	
	public static void InitializeSpringJoint(DampedSpringJoint2D joint, NodePath rb) {
		joint.Damping = this.Damping;
		joint.RestLength = this.RestLength;
		joint.Length = this.Length; 
		joint.Stiffness = this.Stiffness; 
		
		joint.NodeB = rb;  
	}
}
