﻿namespace _2DVector
{
	public struct Vector
	{
		public double X { get; set; }
		public double Y { get; set; }

		public Vector(double x,double y)
		{
			this.X = x;
			this.Y = y;
		}

		public Vector(Vector vector)
		{
			this.X = vector.X;
			this.Y = vector.Y;
		}

	}
}
