using _2DVector;
using System;
using System.Collections.Generic;
namespace PhysicsEngine
{
	public class GeneralPhysicsEngine
	{
		//Part of core loop, should hold a list of Iphysics and call all of them in the loop!
		public List<IPhysicObject> physicObjects = new List<IPhysicObject>();
		public DateTime currentTime;
		public DateTime previousTime;
		public GeneralPhysicsEngine()
		{
			this.previousTime = DateTime.Now;
		}

		public List<Vector> GivePositionUpdate()
		{
			currentTime = DateTime.Now;
			List<Vector> newPositions = new List<Vector>();
			for(int i = 0; i < physicObjects.Count; i++)
			{
				newPositions.Add(CalculatePosition(i));
			}
			previousTime = DateTime.Now;
			return newPositions;

		}

		private Vector CalculatePosition (int index)
		{
			double td = (currentTime - previousTime).TotalSeconds;
			double X = physicObjects[index].Velocity.X * td;
			double Y =physicObjects[index].Velocity.Y * td;
			return new Vector(X, Y); 
		}

	}
}
