using _2DVector;
using System;
namespace PhysicsEngine
{
	public class GeneralPhysics
	{
		public static Vector CalculatePosition (IPhysics physicObject,double x, double y) //these two doubles ARE SHIT!
		{
			DateTime currentTime = DateTime.Now;
			double td = (DateTime.Now - physicObject.PreviousTime).TotalMilliseconds/1000;
			physicObject.PreviousTime = currentTime;
			double X = x + 1.0 / 2.0 * physicObject.Force.X / physicObject.Mass * td * td + physicObject.Velocity.X * td;
			double Y = y + 1.0 / 2.0 * physicObject.Force.Y / physicObject.Mass * td * td + physicObject.Velocity.Y * td;

			return new Vector(X, Y); 
		}

	}
}
