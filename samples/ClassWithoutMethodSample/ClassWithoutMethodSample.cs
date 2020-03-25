using System;

namespace UserProg
{	
	class C1
	{
		public int i;
		public int j;
	}	

	class UserProg
	{
		static void Main()
		{
			C1 c1 = new C1();
			c1.i = 1001;
			c1.j += 1;
		}
	}
}
