using System;
using System.Collections.Generic;
using System.Text;

namespace TransformEngine
{
	class WallLeft : ITransformable
	{
		public int Left { get; set; }
		public int Top { get; set; }
		public char[,] Shape { get; set; }

		public WallLeft(int left, int top)
		{
			this.Left = left;
			this.Top = top;
			this.Shape = new char[4, 2]{
				{'█','█'},
				{'█','█'},
				{'█','█'},
				{'█','█'},
			};
		}

		public void Call()
		{
			throw new NotImplementedException();
		}
	}
}
