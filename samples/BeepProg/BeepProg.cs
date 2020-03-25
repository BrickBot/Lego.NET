using System;
using BeepLib;

namespace BeepProg
{
	class BeepProg
	{
		[STAThread]
		static void Main()
		{
			Beep beep = new Beep();

			beep.Count = 5;

			beep.Pause = 1;

			beep.multiBeep();
		}
	}
}
