using System;
using TransformEngine;
using ConsoleRenderer;
using System.Threading;

namespace Worker
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			//testing
			//Physcis engine should save last time it was called and the time it's called right now
			Pong pong = new Pong(10,14);
			//Console.WriteLine(Console.WindowHeight);//30
			//Console.WriteLine(Console.WindowWidth);//120
			Console.SetWindowSize(90,30);
			//Console.WriteLine(Console.BufferHeight);//9001
			//Console.WriteLine(Console.BufferWidth);//120
			Console.SetBufferSize(90, 30);
			//Console.WriteLine(Console.WindowTop);//0
			//Console.WriteLine(Console.WindowLeft);//0
			RenderShape renderer = new RenderShape();
			Thread main = Thread.CurrentThread;
			renderer.transformables.Add(pong);
			for(int i =0; i<=50000; i++)
			{
				renderer.Render();
				pong.Left = pong.Left + 2;
				Thread.Sleep(50);
				Console.Clear();
			}
			Console.ReadKey();
		}
	}
}
