using System;
using _2DVector;
using PhysicsEngine;

namespace TransformEngine
{
	public class Pong : ITransformable, IPhysicObject
	{

		public Vector Position { get; set; }
		public char[,] Shape { get; set; }
		public double Mass { get; set; }
		public Vector Velocity { get; set; }

		public Pong(double x, double y,double xVelocity,double yVelocity)
		{
			Mass = 1;
			Velocity = new Vector(xVelocity, yVelocity);
			Position = new Vector(x, y);
			this.Shape = new char[1,1]{
				{'O'},
			};
		}

		public void AddForce(Vector force)
		{
			//some formula that changes Velocity
		}
	}
}
