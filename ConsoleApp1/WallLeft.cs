using System;
using _2DVector;


namespace TransformEngine
{
	class WallLeft : ITransformable
	{
		public Vector Position { get; set; }
		public char[,] Shape { get; set; }

		public WallLeft(double x, double y)
		{
			Position = new Vector(x, y);
			this.Shape = new char[4, 2]{
				{'█','█'},
				{'█','█'},
				{'█','█'},
				{'█','█'},
			};
		}
	}
}
