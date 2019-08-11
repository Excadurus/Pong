namespace _2DVector //Projects like this should contatin general classes like, 2dvector- 3dvector- or sth else, and also use a 
	//common name showing this kind of meaning.
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

		public static Vector Add(Vector first,Vector second)
		{
			return new Vector(first.X + second.X, first.Y + second.Y);
		}
	}
}
