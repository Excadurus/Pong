using System;
using Input;

namespace Input
{
	class RightPlayerConsoleInputGetter : IInputGetter
	{
		ConsoleKey lastPressed = ConsoleKey.A;
		public IInputTask UpAction { get; set; }
		public IInputTask DownAction { get; set; }

		public RightPlayerConsoleInputGetter (IInputTask upAction,IInputTask downAction)
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
					lastPressed = Console.ReadKey().Key;
				}
				switch (lastPressed)
				{
					case ConsoleKey.UpArrow:
						UpAction.Act();
						break;
					case ConsoleKey.DownArrow:
						DownAction.Act();
						break;
					default:
						break;
				}

			}
		}
	}
}
