using System;
using gcc;

namespace demo
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class InterruptSample
	{
		static int ticks;

		[interrupt]
		void clock_handler()
		{
			ticks++;
		}

		static void Main()
		{
		}
	}
}
