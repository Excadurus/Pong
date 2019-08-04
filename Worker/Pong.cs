using System;
using _2DVector;
using PhysicsEngine;

namespace TransformEngine
{
	public class Pong : ITransformable, IPhysics
	{

		public Vector Position { get; set; }
		public char[,] Shape { get; set; }
		public double Mass { get; set; }
		public Vector GravityFriction { get; set; }
		public Vector Force { get; set; }
		public Vector Velocity { get; set; }
		public DateTime PreviousTime { get; set; }

		public Pong(double x, double y)
		{
			Mass = 1;
			GravityFriction = new Vector (0,0);
			Force = new Vector(0, 0);
			Velocity = new Vector(2, 0);
			Position = new Vector(x, y);
			PreviousTime = DateTime.Now;
			this.Shape = new char[1,1]{
				{'O'},
			};
		}
	}
}
