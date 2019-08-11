using System.Threading;

namespace Input
{
	class InputGetter
	{
		public InputGetter(IInputTask task)
		{
			Thread th = new Thread(task.act);
		}

		public
	}
}
