using _2DVector;
namespace TransformEngine
{
	public interface ITransformable
	{
		Vector Position { get; set; }
		char[,] Shape { get; set;}
	}
}
