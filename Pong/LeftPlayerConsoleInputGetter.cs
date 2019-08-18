using System;
using Input;

namespace Input
{
	class LeftPlayerConsoleInputGetter : IInputGetter
	{
		ConsoleKey lastPressed = ConsoleKey.A;
		public IInputTask UpAction { get; set; }
		public IInputTask DownAction { get; set; }

		public LeftPlayerConsoleInputGetter (IInputTask upAction,IInputTask downAction)
		{
			UpAction = upAction;
			DownAction = downAction;
		}
		


		public void Act()
		{
			while (true)
			{
				while (Console.KeyAvailable)
				{
					lastPressed = Console.ReadKey(true).Key;
				}
				switch (lastPressed)
				{
					case ConsoleKey.W:
						UpAction.Act();
						break;
					case ConsoleKey.S:
						DownAction.Act();
						break;
					default:
						break;
				}

			}
		}
	}
}
