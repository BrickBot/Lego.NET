using System;

class C1
{
		public C1 c;
		public int i;
		public int j;		
		private short k;

		public C1 (int i, int j)
		{
			this.i = i;
			this.j = j;
		}		
		
		public short K 
		{
			get { return this.k; }
			set { this.k = value; }
		}

		public int add(short a, short b)
		{
			return a + b;
		}
}	

class UserProg
{
	static void Main()
	{        
		C1 c1 = new C1(30, 50);
		c1.c = new C1(10, 20);
		
		c1.i = 1001;
		c1.j += 1;
		
		c1.K = 10;
        c1.add(c1.K, 5);
	}	
}