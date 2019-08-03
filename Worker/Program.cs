using System;
using TransformEngine;
using ConsoleRenderer;

namespace Worker
{
	class Program
	{
		static void Main(string[] args)
		{
			//Physcis engine should save last time it was called and the time it's called right now
			Pong pong = new Pong(20, 20);
			RenderShape renderer = new RenderShape();
			renderer.transformables.Add(pong);
			renderer.Render();
			Console.ReadKey();
		}
	}
}
