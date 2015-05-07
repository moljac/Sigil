# Sigil Xamarin Support

moljac 2015-04-25

NOTE:

Xamarin.iOS cannot be supported because of System.Reflection.Emit!!



A fail-fast, validating helper for DynamicMethod and ILGenerator.

Usage

Sigil is a roughly 1-to-1 replacement for ILGenerator. Rather than calling 

	ILGenerator.Emit(OpCode, ...), 
	
user can call 

	Emit.OpCode(...).


## Dependencies

*	System.Data.DataSetExtensions patch (from mono souerce)
	HolisticWare.System.Data.DataSetExtensions


	
	Get-Project *.Xamarin* | Install-Package HolisticWare.System.Data.DataSetExtensions -PRE