#!/bin/bash
RUNTIME=$1

echo $1
dotnet restore
dotnet publish -r $RUNTIME -c Release
bin/Release/netcoreapp2.2/$RUNTIME/publish/aws-lambda-crt-db