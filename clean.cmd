del .\*.exe.*
del .\*.dll
del .\*.pdb
del .\*.mdb
del .\*.xml
del .\*.log

rmdir .\.vs /s /q

rmdir .\AquaLog\bin /s /q
rmdir .\AquaLog\obj /s /q

rmdir .\AquaLog.Tests\bin /s /q
rmdir .\AquaLog.Tests\obj /s /q
rmdir .\AquaLog.Tests\OpenCover /s /q

rmdir .\ALWatcher\bin /s /q
rmdir .\ALWatcher\obj /s /q

rmdir .\AquaLog.TSDB\bin /s /q
rmdir .\AquaLog.TSDB\obj /s /q

del msbuild.log
