#!/bin/bash

NUGET=nuget

#=============================================================================
# 	sample snippet for the .gitignore
#	**/*.secure*
#	**/*.secret*	
#----------------------------------------------------------------------------
#	following script sets only few environment variables
#	API_KEY
#
FILE=nuget-set-api-key.secure.sh
NUGETS="
	artifacts\DotNetLibrary.*.nupkg
	"
	
	
if [ -x $FILE ]
	then
	echo file = $FILE
	./$FILE
fi


for n in $NUGETS
do
	echo "=========================================================================="
	echo Nuget= $n
	
	$NUGET push $n
	
done

