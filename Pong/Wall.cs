using TransformEngine;
using PhysicsEngine;
using _2DVector;

namespace Worker
{
	class Wall : ITransformable, IPhysicObject
	{
		public double Mass { get; set; }
		public Vector Velocity { get; set; }
		public Vector Position { get; set; }
		public char[,] Shape { get; set; }

		public Wall(double x, double y, double xVelocity,double yVelocity)
		{
			Mass = 2;
			Position = new Vector(x, y);
			Velocity = new Vector(xVelocity,yVelocity);
			Shape = new char[4, 2]
			{
				{'█','█'},
				{'█','█' },
				{'█','█'},
				{'█','█'}
			};
		}

		public void AddForce(Vector force)
		{
		}

	}
}
