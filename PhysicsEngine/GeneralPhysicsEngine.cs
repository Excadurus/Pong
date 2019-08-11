using _2DVector;
using System;
using System.Collections.Generic;
using TransformEngine;

namespace PhysicsEngine
{
	public class GeneralPhysicsEngine
	{
		class PO
		{
			public IPhysicObject PhysicObject { get; set; }
			public ITransformable Transformable { get; set; }

			public PO(IPhysicObject PhysicObject, ITransformable Transformable)
			{
				this.PhysicObject = PhysicObject;
				this.Transformable = Transformable;
			}
		}

		//Part of core loop, should hold a list of Iphysics and call all of them in the loop!
		List<PO> Objects = new List<PO>();
		public DateTime previousTime;

		public GeneralPhysicsEngine()
		{
			this.previousTime = DateTime.Now;
		}

		public void Add<T>(T obj)
			where T : class, ITransformable, IPhysicObject
		{
			PO po = new PO(obj, obj);
			Objects.Add(po);

		}
		public void Remove<T>(T obj)//BAD REMOVE :(
			where T : class, ITransformable, IPhysicObject
		{
			foreach (PO p in Objects)
			{
				if (p.Transformable == obj)
					Objects.Remove(p);
			}
		}
		public void Update()
		{
			DateTime currentTime = DateTime.Now;
			Double td = (currentTime - previousTime).TotalSeconds;
			for (int i = 0; i < Objects.Count; i++)
			{
				//CheckCollision(Objects[i]);
				CalculatePosition(Objects[i], td);
			}
			previousTime = currentTime;
		}

		/*private void CheckCollision(PO po)
		{
			foreach (PO pos in Objects)
			{
				if(po.Equals(pos))
				{
					continue;
				}
				if (IsWithinWidth(po.Transformable, pos.Transformable))
				{
					if (IsWithinHeight(po.Transformable, pos.Transformable))
					{
						po.PhysicObject.Velocity = new Vector(-po.PhysicObject.Velocity.X, po.PhysicObject.Velocity.Y);

					}
				}
				else if(IsWithinHeight(po.Transformable, pos.Transformable))
				{
					if (IsWithinWidth(po.Transformable, pos.Transformable))
					{
						po.PhysicObject.Velocity = new Vector(po.PhysicObject.Velocity.X, -po.PhysicObject.Velocity.Y);
					}
				}
			}
		}

		private bool IsWithinWidth(ITransformable itOne, ITransformable itTwo)
		{
			return (itOne.Position.X - itOne.Shape.GetLength(0) < itTwo.Position.X - itTwo.Shape.GetLength(0)
				&& itTwo.Position.X - itTwo.Shape.GetLength(0) < itOne.Position.X + itOne.Shape.GetLength(0)) ||
				(itOne.Position.X - itOne.Shape.GetLength(0) < itTwo.Position.X + itTwo.Shape.GetLength(0)
				&& itTwo.Position.X + itTwo.Shape.GetLength(0) < itOne.Position.X + itOne.Shape.GetLength(0));
		}

		private bool IsWithinHeight(ITransformable itOne, ITransformable itTwo)
		{
			return (itOne.Position.Y - itOne.Shape.GetLength(1) < itTwo.Position.Y - itTwo.Shape.GetLength(1)
				&& itTwo.Position.Y - itTwo.Shape.GetLength(1) < itOne.Position.Y + itOne.Shape.GetLength(1)) ||
				(itOne.Position.Y - itOne.Shape.GetLength(1) < itTwo.Position.Y + itTwo.Shape.GetLength(1)
				&& itTwo.Position.Y + itTwo.Shape.GetLength(1) < itOne.Position.Y + itOne.Shape.GetLength(1));
		}*/

		private void CalculatePosition(PO po, Double td)//When you can pass element don't pass index, it might be a side effect
		{
			//Vector distanceTraveled = new Vector(po.PhysicObject.Velocity.X * td, po.PhysicObject.Velocity.Y * td);
			double newX = po.PhysicObject.Velocity.X * td + po.Transformable.Position.X;
			double newY = po.PhysicObject.Velocity.Y * td + po.Transformable.Position.Y;
			po.Transformable.Position = new Vector(newX, newY);
		}

	}
}
