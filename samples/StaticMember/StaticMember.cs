using System;

namespace StaticMember
{
	class BaseStaticMember
	{
		public ushort ival;
		public static int sival = 1;
		public const int iconst = 254;

		public virtual int get_sival()
		{
			return sival;
		}
		
	}
	
	class StaticMember : BaseStaticMember
	{
		
		public new static int sival = 2;
		public static bool sbval;
		private static StaticMember smval;
		private new const int iconst = 255;		

		public override int get_sival()
		{
			return sival;
		}
		
		static void Main(string[] args)
		{
			debug((ushort)BaseStaticMember.sival);
			
			debug((ushort)StaticMember.sival);
			
			smval = new StaticMember();

			++StaticMember.sival;
			
			sbval = true;

			if (sbval)
			{
				debug((ushort)smval.get_sival());
			}

			smval.ival = (ushort) StaticMember.sival;

			debug (smval.ival);

			debug ((ushort)BaseStaticMember.iconst);
			
			debug ((ushort)StaticMember.iconst);

			Console.ReadLine();
		}

		static void debug (ushort val)
		{
			/*
			brickOS.dsound.dsound_system(0);
			brickOS.conio.cputw (val);
			brickOS.unistd.sleep(2);
			brickOS.conio.cls();
			*/
			Console.WriteLine(val);
		}
	}
}
