@ECHO OFF
SET APP_DIR=Demo
SET LIB_DIR=Lib

ECHO Cleaning up project
ECHO ===================

:: DELETE without prompt
DEL /f /s /q /a %APP_DIR%\debug.log
RMDIR %APP_DIR%\.vs /s /q
RMDIR %APP_DIR%\.idea /s /q
RMDIR %APP_DIR%\bin /s /q
RMDIR %APP_DIR%\obj /s /q
RMDIR %APP_DIR%\packages /s /q
RMDIR %APP_DIR%\GPUCache /s /q
RMDIR %APP_DIR%\MigrationBackup /s /q

DEL /f /s /q /a %LIB_DIR%\debug.log
RMDIR %LIB_DIR%\.vs /s /q
RMDIR %LIB_DIR%\.idea /s /q
RMDIR %LIB_DIR%\bin /s /q
RMDIR %LIB_DIR%\obj /s /q
RMDIR %LIB_DIR%\packages /s /q
RMDIR %LIB_DIR%\GPUCache /s /q
RMDIR %LIB_DIR%\MigrationBackup /s /q

ECHO Done.
ECHO rofiqsetiawan@gmail.com

EXIT