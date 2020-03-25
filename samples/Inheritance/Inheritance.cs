using System;

namespace Inheritance
{
	class A 
	{
		protected int i = 0;

		public virtual int get_num()
		{
			return this.i;
		}

		public void set_attr_i(int val)
		{
			this.i = val;
		}
	}

	class B : A 
	{
		protected int k = 0;

		public int get_num_both()
		{
			return this.i + this.k;
		}
		
		public void set_attr_k(int val)
		{
			this.k = val;
		}
	}
	class Inheritance
	{
		static void Main()
		{
			B b = new B();
			
			b.set_attr_i(6);
			b.set_attr_k(2);

			int val = b.get_num_both();
			brickOS.conio.cputw ((ushort)val);
		}
	}
}
