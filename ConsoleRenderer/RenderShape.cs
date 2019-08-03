using System;
using System.Collections.Generic;
using TransformEngine;

namespace ConsoleRenderer
{
	public class RenderShape
	{
		public List<ITransformable> transformables = new List<ITransformable>();


		public void Render()
		{
			for(int i=0;i < transformables.Count; i++)
			{
				DrawShapeInConsole(i);
			}
		}

		private void DrawShapeInConsole(int index)
		{
			for(int i= 0; i < transformables[index].Shape.GetLength(0); i++)
			{
				for(int j = 0; j < transformables[index].Shape.GetLength(1); j++)
				{
					
					Console.SetCursorPosition((j + transformables[index].Left)%Console.BufferWidth, (i + transformables[index].Top) % Console.BufferHeight);
					Console.Write(transformables[index].Shape[i,j]);
				}
			}

		}
	}
}
