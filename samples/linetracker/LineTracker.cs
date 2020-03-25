using System;
using brickOS;

namespace LineTracker
{	
	class LineTracker
	{
		static void Main()
		{			
			short bright = 42;
			short dark = 30;
		
			// Activate light sensor
                        dsensor.ds_active(dsensor.SENSOR_2);
		
			// Count down
			for (short i = 0; i < 3; i++)
			{
				dsound.dsound_system(dsound.DSOUND_BEEP);
				unistd.msleep(500);
			}
		
                        dmotor.motor_a_speed(dmotor.MAX_SPEED);
                        dmotor.motor_c_speed(dmotor.MAX_SPEED);

			// Main loop
			while (true)
			{
				if (dsensor.LIGHT_2 > bright)
				{
                                        dmotor.motor_a_dir(dmotor.rev);
                                        dmotor.motor_c_dir(dmotor.fwd);
				}
				else if (dsensor.LIGHT_2 < dark)
				{
                                        dmotor.motor_a_dir(dmotor.fwd);
                                        dmotor.motor_c_dir(dmotor.rev);
				}
				else
				{
                                        dmotor.motor_a_dir(dmotor.fwd);
                                        dmotor.motor_c_dir(dmotor.fwd);
				}
			}
		}

	}
}