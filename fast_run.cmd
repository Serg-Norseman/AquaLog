@echo off

@if exist ".\AquaMate.exe" goto start

call clean.cmd
set MSBDIR=@%WINDIR%\Microsoft.NET\Framework\v4.0.30319
%MSBDIR%\msbuild.exe AquaMate.sln /verbosity:quiet /p:Configuration="Debug" /p:Platform="x86" /t:Rebuild /p:TargetFrameworkVersion=v4.5

:start
start .\AquaMate.exe