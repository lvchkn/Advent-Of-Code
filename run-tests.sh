#!/bin/bash
dotnet test --logger "console;verbosity=detailed;"
#dotnet test --filter FullyQualifiedName~Day3.Part2Tests.Example_Input