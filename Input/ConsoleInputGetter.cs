using System;
using System.Collections.Generic;

namespace Input
{
	class ConsoleInputGetter
	{
		ConsoleKey lastPressed = new ConsoleKey();
		private readonly IInputTask upAction;
		private readonly IInputTask downAction;
		ConsoleInputGetter(IInputTask upAction,IInputTask downAction)
		{
			this.upAction = upAction;
			this.downAction = downAction;
		}
		public void Act()
		{
			while (true)
			{
				if (Console.KeyAvailable)
				{
					lastPressed = Console.ReadKey().Key;
				}
				switch (lastPressed)
				{
					case ConsoleKey.W:
						upAction.Act();
						break;
					case ConsoleKey.S:
						downAction.Act();
						break;
					default:
						break;
				}

			}
		}
	}
}
