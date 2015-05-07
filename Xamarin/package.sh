#!/bin/bash

set NUGET=.nuget\nuget

rm -fr artifacts/*

NUSPECS="
	src/HolisticWare.Sigil.Xamarin.nuspec
	"
	
	
for n in $NUSPECS
do
	echo "=========================================================================="
	echo NUSPEC= $n
	
	nuget pack $n	
	
done

