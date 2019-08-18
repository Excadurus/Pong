using System.Threading;

namespace Input
{
	public interface IInputGetter
	{
		IInputTask UpAction { get; set; }
		IInputTask DownAction { get; set; }

		void Act();
	}
}
