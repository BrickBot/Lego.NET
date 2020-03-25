using System;

namespace UserProg
{	
	class Pitch
	{
		public const byte C3 = 27;
		public const byte D3 = 29;
	}

	class Duration
	{

		public const byte HALF = 8;
	}

	class Sound
	{
		public static void play(byte[] pitch, byte[] duration)
		{

		}
	}

	class ArraySample
	{

		static byte[] make(int l)
		{
			return new byte[l];
		}

		static void Main()
		{
			byte[] sound = make(3);
			byte[] length = new byte[3];
			int[] ia = new int[10];

			sound[0] = Pitch.C3;
			sound[1] = Pitch.D3;
			sound[2] = Pitch.C3;

			length[0] = Duration.HALF;
			length[1] = Duration.HALF;
			length[2] = Duration.HALF;

			Sound.play(sound, length);

			ia[0] = sound.Length + length.Length;

			make(ia[0]);
		}
	}
}
