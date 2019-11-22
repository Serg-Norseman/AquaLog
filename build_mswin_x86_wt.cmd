@echo off
set MSBDIR=@%WINDIR%\Microsoft.NET\Framework\v4.0.30319
%MSBDIR%\msbuild.exe AquaLog.sln /p:Configuration="Debug" /p:Platform="x86" /t:Rebuild /p:TargetFrameworkVersion=v4.5
