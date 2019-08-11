using System;
using System.Collections.Generic;
using TransformEngine;

namespace ConsoleRenderer
{
	public class RenderShape
	{
		public List<ITransformable> staticTransformables = new List<ITransformable>();
		public List<ITransformable> movingTransformables = new List<ITransformable>();


		public void Render()
		{
			Console.Clear();

			for (int i = 0; i < movingTransformables.Count; i++)
			{
				DrawShapeInConsole(movingTransformables[i]);
			}

			for (int i = 0; i < staticTransformables.Count; i++)
			{
				DrawShapeInConsole(staticTransformables[i]);
			}
		}


		private void DrawShapeInConsole(ITransformable transformable)
		{
			for (int i = 0; i < transformable.Shape.GetLength(0); i++)
			{
				for (int j = 0; j < transformable.Shape.GetLength(1); j++)
				{
					int cursorLeft = (int)Math.Round(j + transformable.Position.X);
					int cursorTop = (int)Math.Round(i + transformable.Position.Y);
					if (cursorTop >= 28)
					{
						cursorTop = 28;
					}

					try
					{
						Console.SetCursorPosition(cursorLeft, cursorTop);
						Console.Write(transformable.Shape[i, j]);
					}
					catch (Exception e)
					{
						Console.SetCursorPosition(1, 1);

						continue;
					}
				}
			}
		}

		//public void Clear()
		//{
		//	foreach (ITransformable transformable in movingTransformables)
		//	{
		//		DrawSpaceInConsole(transformable);
		//	}
		//}

		//private void DrawSpaceInConsole(ITransformable transformable)
		//{
		//	for (int i = 0; i < transformable.Shape.GetLength(0); i++)
		//	{
		//		for (int j = 0; j < transformable.Shape.GetLength(1); j++)
		//		{
		//			int cursorLeft = (int)Math.Round(j + transformable.Position.X);
		//			int cursorTop = (int)Math.Round(i + transformable.Position.Y);

		//			if (cursorTop > 28)
		//				break;

		//			try
		//			{
		//				Console.SetCursorPosition(cursorLeft, cursorTop);
		//				Console.Write(' ');
		//			}
		//			catch (Exception e)
		//			{
		//				continue;
		//			}
		//		}
		//	}
		//}
	}
}
