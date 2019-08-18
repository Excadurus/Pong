using System;
using System.Threading;

namespace Worker
{
	class Program
	{
		//Take away pong related stuff from Core loop : half done, honestly don't think the rest must be pulled away from core loop
		//Fix hardcodings : input for Positionings and speed is the only thing that comes to mind right now
		
		
		//check nullable char


		//Input: Interface with a method: get last key which then might run a thread to move the pads
		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			//testing
			//Physcis engine should save last time it was called and the time it's called right now
			//Console.WriteLine(Console.WindowWidth);//120
			//Console.WriteLine(Console.WindowHeight);//30
			Console.SetWindowSize(90,30);
			//Console.WriteLine(Console.BufferWidth);//120
			//Console.WriteLine(Console.BufferHeight);//9001
			Console.SetBufferSize(90, 30);
			//Console.WriteLine(Console.WindowWidth);//120
			Console.SetWindowPosition(0, 0);
			//Console.WriteLine(Console.WindowLeft);//0
			//Console.WriteLine(Console.WindowTop);//0
			PongCoreLoop coreLoop = new PongCoreLoop(90,30,40);
			coreLoop.RunCoreLoop();
		}

		
	}
}
