using System;

namespace BeepLib
{
	public class Beep
	{
		public int unusedField;
		public short Count = 1;
		public ushort Pause = 1;		
		
		public Beep()
		{			
		}

		public void multiBeep()
		{
			for (short i = 0; i < Count; ++i) 
			{
				brickOS.dsound.dsound_system(0);
				brickOS.unistd.sleep(Pause);
			}
		}

	}	
}
