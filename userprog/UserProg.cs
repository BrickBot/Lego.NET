using System;

namespace UserProg
{
	class StaticMember
	{
		
		public int ival;
		public static int sival = 1;
		public static bool sbval;
		private static StaticMember smval;

		static void Main(string[] args)
		{
			smval = new StaticMember();
			smval.ival = StaticMember.sival;
			sbval = true;

			++StaticMember.sival;

			brickOS.conio.cputw ((ushort)smval.ival);
			brickOS.unistd.sleep(2);
			brickOS.conio.cputw ((ushort)StaticMember.sival);
		}
	}
}
