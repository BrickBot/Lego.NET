.assembly mscorlib
{
  .ver 1:0:5000:0
  .hash algorithm 0x00008004
  .publickey = (00 00 00 00 00 00 00 00 04 00 00 00 00 00 00 00)
}
.module mscorlib.dll

.namespace System
{

	.class public auto ansi serializable beforefieldinit Object
	{
		.method public hidebysig  specialname  rtspecialname 
			instance default void .ctor ()  cil managed 
		{
			.maxstack 0
			ret 
		}

		.method public virtual  hidebysig  newslot 
			instance default bool Equals (object o)  cil managed 
		{
			.maxstack 1
			ldc.i4.0
			ret 
		}

		.method family virtual  hidebysig  newslot 
			instance default void Finalize ()  cil managed 
		{
			.maxstack 0
			ret 
		}

		.method public virtual  hidebysig  newslot 
			instance default int32 GetHashCode ()  cil managed
		{
			.maxstack 1
			ldc.i4.0
			ret
		}

		.method public virtual  hidebysig  newslot 
			instance default string ToString ()  cil managed
		{
			ldnull
			ret
		}

	}

	.class public auto ansi sealed serializable beforefieldinit String
		extends System.Object
	{
		.field  private notserialized   int32 length
		.field  private notserialized   char start_char
	}
	
	.class public abstract auto ansi serializable beforefieldinit ValueType
		extends System.Object
	{
	}
	 
	.class public abstract auto ansi serializable beforefieldinit Enum
		extends System.ValueType
		implements	System.IComparable,
					System.IConvertible,
					System.IFormattable
	{
		.method public hidebysig newslot virtual 
				instance int32  CompareTo(object obj) cil managed
		{
			.maxstack 1
			ldc.i4.0
			ret
		} // end of method IComparable::CompareTo

	} // end of class Enum
	
		.class public abstract auto ansi beforefieldinit Delegate
		extends System.Object
	{
		.field private class System.Type target_type
		.field private object m_target
		.field private string method_name
		.field private native int method_ptr
		//TODO: complete fields and methods
		//.field private native int delegate_trampoline
		//.field private class System.Reflection.MethodInfo method_info
	} // end of class Delegate
	
	.class public abstract auto ansi beforefieldinit MulticastDelegate
		extends System.Delegate
	{
		//TODO: complete fields and methods
		//.field private class System.MulticastDelegate prev
		//.field private class System.MulticastDelegate kpm_next
	} // end of class MulticastDelegate
	
	.class public auto ansi sealed AsyncCallback
			extends System.MulticastDelegate
	{
		// TODO: complete methods
	} // end of class AsyncCallback
	
	.class public abstract auto ansi serializable beforefieldinit Type
	{
		//TODO: complete
	} // end of class Type
	
	.class interface public abstract auto ansi IComparable
	{
		.method public hidebysig newslot abstract virtual 
				instance int32  CompareTo(object obj) cil managed
		{
		} // end of method IComparable::CompareTo

	} // end of class IComparable
	
	.class interface public abstract auto ansi IConvertible
	{
	} // end of class IConvertible
  
	.class interface public abstract auto ansi IFormattable
	{
	} // end of class IFormattable
	
	.class interface public abstract auto ansi IAsyncResult
	{
		//TODO: complete
	} // end of class IAsyncResult
}