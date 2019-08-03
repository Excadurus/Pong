using System;
using System.Collections.Generic;
using System.Text;

namespace TransformEngine
{
	public class Pong : ITransformable
	{

		public int Left { get; set; }
		public int Top { get; set; }
		public char[,] Shape { get; set; }

		public Pong(int left, int top)
		{
			this.Left = left;
			this.Top = top;
			this.Shape = new char[3,3]{
				{'█','█','█'},
				{'█','█','█'},
				{'█','█','█'},
			};
		}

		public void Call()
		{
			throw new NotImplementedException();
		}
	}
}
