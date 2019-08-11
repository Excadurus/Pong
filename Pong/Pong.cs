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

		public void ResetPosition(double x, double y)
		{
			this.Position = new Vector(x, y);
		}

		public void ResetVelocity(double xVelocity,double yVelocity)
		{
			this.Velocity = new Vector(xVelocity, yVelocity);
		}

		public void CheckPongCollision(ITransformable leftWall, ITransformable rightWall, ITransformable topBorder, ITransformable bottomBorder)
		{
			if (IsWithinWidth(leftWall, this) && IsWithinHeight(leftWall, this))
			{
				this.Velocity = new Vector(-1 * this.Velocity.X, this.Velocity.Y);
			}
			if (IsWithinWidth(rightWall, this) && IsWithinHeight(rightWall, this))
			{
				this.Velocity = new Vector(-1 * this.Velocity.X, this.Velocity.Y);
			}
			if (IsWithinWidth(topBorder, this) && IsWithinHeight(topBorder, this))
			{
				this.Velocity = new Vector(this.Velocity.X, -1 * this.Velocity.Y);
			}
			if (IsWithinWidth(bottomBorder, this) && IsWithinHeight(bottomBorder, this))
			{
				this.Velocity = new Vector(this.Velocity.X, -1 * this.Velocity.Y);
			}
		}

		private bool IsWithinWidth(ITransformable itOne, ITransformable itTwo)
		{
			return (itOne.Position.X <= itTwo.Position.X
				&& itTwo.Position.X <= itOne.Position.X + itOne.Shape.GetLength(1)) ||
				(itOne.Position.X <= itTwo.Position.X + itTwo.Shape.GetLength(1)
				&& itTwo.Position.X + itTwo.Shape.GetLength(1) <= itOne.Position.X + itOne.Shape.GetLength(1));
		}
		private bool IsWithinHeight(ITransformable itOne, ITransformable itTwo)
		{
			return (itOne.Position.Y - 1.0 <= itTwo.Position.Y
				&& itTwo.Position.Y <= itOne.Position.Y + itOne.Shape.GetLength(0)) ||
				(itOne.Position.Y <= itTwo.Position.Y + itTwo.Shape.GetLength(0)
				&& itTwo.Position.Y + itTwo.Shape.GetLength(0) <= itOne.Position.Y + itOne.Shape.GetLength(0));
		}

	}
}
