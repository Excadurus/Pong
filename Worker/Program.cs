using System;
using TransformEngine;
using ConsoleRenderer;
using System.Threading;
using _2DVector;
using PhysicsEngine;
using System.Collections.Generic;

namespace Worker
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			//testing
			//Physcis engine should save last time it was called and the time it's called right now
			Pong pong = new Pong(10,14,500,1000);			//Console.WriteLine(Console.WindowWidth);//120
			//Console.WriteLine(Console.WindowHeight);//30
			Console.SetWindowSize(90,30);
			//Console.WriteLine(Console.BufferWidth);//120
			//Console.WriteLine(Console.BufferHeight);//9001
			Console.SetBufferSize(90, 30);
			//Console.WriteLine(Console.WindowLeft);//0
			//Console.WriteLine(Console.WindowTop);//0
			RenderShape renderer = new RenderShape();
			GeneralPhysicsEngine physicsEngine = new GeneralPhysicsEngine();
			Thread main = Thread.CurrentThread;
			renderer.transformables.Add(pong);

			physicsEngine.physicObjects.Add(pong);

			List<Vector> Positions = new List<Vector>();
			
			for(int i =0; i<=50000; i++)
			{
				renderer.Render();
				Thread.Sleep(1);
				//Console.SetCursorPosition((int)pong.Position.X % Console.BufferWidth, (int)pong.Position.Y % Console.BufferHeight);
				//Console.Write(" ");
				Positions = new List<Vector>(physicsEngine.GivePositionUpdate());
				for(int j = 0; j < Positions.Count; j++)
				{
					renderer.transformables[j].Position = Vector.VectorAddition(Positions[j], renderer.transformables[j].Position);
				}
				Console.Clear();
				
			}
			Console.ReadKey();
		}
	}
}
