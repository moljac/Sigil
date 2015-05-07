@echo off

set NUGET=.nuget\nuget

del /q artifacts\*.*

:: this nuget wiil be unpacked and folder structure used to pack the last one
::	*Unpack.nuspec is for packaging structure to be copied to duplo-dep-nugets 

SET NUSPECS=^
	"src\HolisticWare.Sigil.Xamarin.nuspec" ^


FOR %%n IN (%NUSPECS%) DO (
	echo "=========================================================================="
	echo NUSPEC = %%n
	
	%NUGET% ^
		pack ^
		%%n ^
		-Symbols ^
		-OutputDirectory artifacts ^
		-Build ^
		-IncludeReferencedProjects ^
		-NonInteractive
		
	pause
)	
	
echo ========================================================================
dir artifacts\
echo ========================================================================
	
@IF %ERRORLEVEL% NEQ 0 PAUSE	

