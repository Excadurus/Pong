using System;
using _2DVector;
namespace PhysicsEngine
{
	public interface IPhysics
	{
		double Mass { get; set; }
		Vector GravityFriction { get; set; }
		Vector Force { get; set; }
		Vector Velocity { get; set; }
		DateTime PreviousTime { get; set; }
	}
}
