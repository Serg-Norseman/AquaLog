del .\*.exe.*
del .\*.dll
del .\*.pdb
del .\*.mdb
del .\*.xml
del .\*.log

rmdir .\.vs /s /q

rmdir .\AquaMate\bin /s /q
rmdir .\AquaMate\obj /s /q

rmdir .\AquaMate.Core\bin /s /q
rmdir .\AquaMate.Core\obj /s /q

rmdir .\AquaMate.Tests\bin /s /q
rmdir .\AquaMate.Tests\obj /s /q
rmdir .\AquaMate.Tests\OpenCover /s /q

rmdir .\BSLib.Timeline\bin /s /q
rmdir .\BSLib.Timeline\obj /s /q

del msbuild.log

rmdir .\.sonarqube /s /q
