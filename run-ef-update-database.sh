#!/bin/bash
cd /app/LoggingAPI
dotnet tool install --global dotnet-ef
/root/.dotnet/tools/dotnet-ef database update