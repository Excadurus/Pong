using TransformEngine;
using PhysicsEngine;
using _2DVector;

namespace Worker
{
	class Border : ITransformable, IPhysicObject
	{
		public double Mass { get; set; }
		public Vector Velocity { get; set; }
		public Vector Position { get; set; }
		public char[,] Shape { get; set; }

		public void AddForce(Vector force)
		{
		}

		public Border(double x, double y, double xVelocity, double yVelocity)
		{
			Mass = 2;
			Position = new Vector(x, y);
			Velocity = new Vector(xVelocity, yVelocity);
			Shape = new char[1, 80];
			for(int i = 0; i < 80; i++)
			{
				Shape[0, i] = '█';
			}
			
		}
	}
}
