using System;

namespace Enums
{
	enum Colors : ushort
	{
		None = 0,
		Red = 1,
		Green = 2,
		Blue = 4,
		Black = Red | Green | Blue
	};

	class Color
	{		
		private ushort usc = 0;
		private Colors c = Colors.None;

		public Color (Colors c)
		{
			this.Value = c;
		}
		
		public ushort UShortValue
		{
			get {return this.usc;}
			
			set
			{
				this.c = (Colors)value;
				this.usc = value;
			}
		}

		public Colors Value
		{
			get {return this.c;}
			
			set
			{
				this.c = value;
				this.usc = (ushort)value;
			}
		}

		public ushort compare (Color c)
		{
			if (this.c < c.Value)
			{
				return 0;
			}
			else if (this.c > c.Value)
			{
				return 2;
			}
			else
			{
				return 1;
			}
		}
		
		public static void show(Colors c)
		{			
			switch(c)
			{
				case Colors.None:
					display(Colors.None);
					break;
				case Colors.Red:
					display(Colors.Red);
					break;
				case Colors.Green:
					display(Colors.Green);
					break;
				case Colors.Blue:
					display(Colors.Blue);
					break;
				case Colors.Black:
					display(Colors.Black);
					break;
			}
		}

		private static void display(Colors color)
		{
			Enums.display((ushort)color);
		}

	}
	
	class Enums
	{		
		static void Main(string[] args)
		{
			Color color = new Color(Colors.None);

			Colors[] colors = {Colors.None, Colors.Red, Colors.Green, Colors.Blue, Colors.Black};

			foreach (Colors c in colors)
			{
				color.Value = c;
				Color.show(color.Value);
			}

			foreach (Colors c in colors)
			{
				color.UShortValue = (ushort)c;
				Color.show(color.Value);
			}

			Color black = new Color(Colors.Black);		
			
			color.Value = Colors.Red | Colors.Green | Colors.Blue;
	
			display (color.compare(black));

			Color blue = new Color(Colors.Blue);

			display (color.compare(blue));

			color.Value -= 4;

			display (color.compare(blue));

			//Console.ReadLine();
		}

		public static void display(ushort val)
		{
			//*
			brickOS.conio.cputw (val);
			brickOS.unistd.sleep(1);
			brickOS.conio.cls();
			brickOS.unistd.msleep(500);
			//*/

			//Console.WriteLine(val);
		}
	}
}
