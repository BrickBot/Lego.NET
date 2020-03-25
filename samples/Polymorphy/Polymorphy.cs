using System;

namespace Polymorphy
{	
	class ListItem
	{
		public ListItem next;
		
		public virtual int get_wert()
		{			
			return 0;
		}
	};

	class IntItem:ListItem
	{
		int wert;
		
		public IntItem(int v, ListItem n)
		{
			wert = v;
			next = n;
		}
		
		public override int get_wert()
		{
			return wert;
		}
	}

	class ShortItem:ListItem
	{
		short wert;
		
		public ShortItem(short v, ListItem n)
		{
			wert = v;
			next = n;
		}		
		
		public override int get_wert()
		{
			return wert;
		}
	}

	class Polymorphy
	{
		static int sum(ListItem l)
		{
			if (l == null)
			{
				return 0;
			}			
			int rest = sum(l.next);
			
			return rest + l.get_wert();
		}
		
		public static void Main()
		{
			ListItem x = new IntItem(10, new ShortItem(20, new IntItem(30, null)));
			
			//brickOS.conio.cputw((ushort)sum(x));
			//brickOS.unistd.sleep(1);
			//brickOS.conio.cls();
			//brickOS.unistd.msleep(500);
			display((ushort)sum(x));
			
			//Console.ReadLine();
		}

		public static void display(ushort val)
		{
			/*
			brickOS.conio.cputw (val);
			brickOS.unistd.sleep(1);
			brickOS.conio.cls();
			brickOS.unistd.msleep(500);			
			*/
			Console.WriteLine(val);
		}
	}
}