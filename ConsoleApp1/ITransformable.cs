
namespace TransformEngine
{
	public interface ITransformable
	{
		int Left { get; set; }
		int Top { get; set; }
		char[,] Shape { get; set;}
		void Call();
	}
}
