using System;

namespace Delegates
{	
	class Number
	{
		public delegate ushort Display(Number v);
        
		private ushort val;
		private Number pred;
		private Number succ;

		public ushort Value
		{
			get {return this.val;}
		}

		public Number Predecessor
		{
			get
			{
				return this.pred;
			}
		}			

		public Number Successor
		{
			get
			{
				return this.succ;
			}
		}			


		public Number (ushort v, Number p, Number s)
		{
			this.val = v;

			this.pred = p;
			
			this.succ = s;
		}

		public ushort show(Number.Display showNumbers)
		{
			return showNumbers(this);
		}
	}
	

	class Display
	{
		protected static ushort scount = 0;
		
		protected ushort count = 0;		

		public ushort showNumber(Number num)
		{			
			show(num.Value);
            
			++count;
                        			
			return this.count;
		}

		public virtual ushort showPredecessor(Number num)
		{
			show(num.Predecessor.Value);

			++count;
                        			
			return this.count;
		}

		public virtual ushort showSuccessor(Number num)
		{
			show(num.Successor.Value);

			++count;
                        			
			return this.count;
		}


		public static ushort sshow(Number num)
		{
			show(num.Value);

			++scount;
                        			
			return scount;
		}
		
		
		public static void show(ushort val)
		{
			brickOS.conio.cputw (val);
			brickOS.unistd.sleep(1);
			brickOS.conio.cls();
			brickOS.unistd.msleep(500);
						
			//Console.WriteLine(val);
		}
	}

	class SpecialDisplay : Display
	{
		public override ushort showPredecessor(Number num)
		{
			show(0);

			++count;
                        			
			return this.count;
		}

		public override ushort showSuccessor(Number num)
		{
			show(0xFFFF);

			++count;
                        			
			return this.count;
		}
	}
	
	class Delegates
	{		
		static void Main(string[] args)
		{
			
			Number four = new Number(4, null, null);
			Number six = new Number(6, null, null);
			Number five = new Number(5, four, six);
			
			Number.Display staticShow= new Number.Display(Display.sshow);			

			Display display = new Display();

			Number.Display showPrec = new Number.Display(display.showPredecessor);
			Number.Display showSucc = new Number.Display(display.showSuccessor);

			Display.show(five.show(staticShow));
			Display.show(five.show(showPrec));
			Display.show(five.show(showSucc));

			Display sdisplay = new SpecialDisplay();
			
			showPrec = new Number.Display(sdisplay.showPredecessor);
			showSucc = new Number.Display(sdisplay.showSuccessor);
		
			Display.show(five.show(showPrec));
			Display.show(five.show(showSucc));
			
			//Console.ReadLine();
		}
	}
}