using System;

namespace OpCodeSwitch
{
	class OpCodeSwitch
	{
		static void Main(string[] args)
		{
			for(ushort i = 0; i < 7; ++i)
			{
				show(i);
			}
			show(1000);
			show(2000);
		}

		static void show (ushort val)
		{
			brickOS.conio.cls();
			brickOS.dsound.dsound_system(brickOS.dsound.DSOUND_BEEP);

			switch (val)
			{
				/*
				case 0:
					brickOS.conio.cputw(0);
					break;
				*/
				case 1:
					brickOS.conio.cputw(1);
					break;
				case 2:
					brickOS.conio.cputw(2);
					break;
				case 4:
					brickOS.conio.cputw(4);
					break;
				case 5:
					brickOS.conio.cputw(5);
					break;
				case 1000:
					brickOS.conio.cputw(1000);
					break;					
				case 2000:
					brickOS.conio.cputw(2000);					
					break;
				default:
					brickOS.conio.cputw(255);
					break;
			}
			
			brickOS.unistd.sleep(1);
		}
	}
}
