; "AquaLog", Home aquariums manager.
; Copyright (C) 2019 by Sergey V. Zhdanovskih.

!include "MUI2.nsh"
!include "DotNetChecker.nsh"
!define MUI_ICON "..\AquaLog\resources\icon_aqualog.ico"


Unicode true
Name "AquaLog"
OutFile "aqualog_1.1.0_winsetup.exe"
InstallDir $PROGRAMFILES\AquaLog

CRCCheck on
SetCompress auto
SetCompressor lzma
SetDatablockOptimize on
AllowRootDirInstall false
XPStyle on

ShowInstDetails show
RequestExecutionLevel admin


!insertmacro MUI_LANGUAGE "English"
LangString al_req ${LANG_ENGLISH} "AquaLog (required)"
LangString al_lang ${LANG_ENGLISH} "Languages"

!insertmacro MUI_LANGUAGE "Russian"
LangString al_req ${LANG_RUSSIAN} "AquaLog (необходимо)"
LangString al_lang ${LANG_RUSSIAN} "Языки"


; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\AquaLog" "Install_Dir"


; Pages
Page components
Page directory
Page instfiles


function .onInit
    !insertmacro MUI_LANGDLL_DISPLAY
functionEnd

UninstPage uninstConfirm
UninstPage instfiles

Section "$(al_req)"
    SectionIn RO

    SetOutPath $INSTDIR

    !insertmacro CheckNetFramework 35

    File "..\AquaLog.exe"
    File "..\AquaLog.exe.config"

    File "..\AquaLog.Core.dll"

    File "..\BSLib.dll"
    File "..\BSLib.Controls.dll"
    File "..\BSLib.Timeline.dll"
    File "..\csgl.dll"
    File "..\csgl.native.dll"
    File "..\DotNetRtfWriter.dll"
    File "..\ExcelLibrary.dll"
    File "..\log4net.dll"
    File "..\sqlite3.dll"
    File "..\ZedGraph.dll"

    File "..\LICENSE"

    CreateDirectory "$INSTDIR\locales"
    SetOutPath "$INSTDIR\locales"

    CreateDirectory "$SMPROGRAMS\AquaLog"
    CreateShortCut "$SMPROGRAMS\AquaLog\AquaLog.lnk" "$INSTDIR\AquaLog.exe" "" "$INSTDIR\AquaLog.exe" 0
    CreateShortCut "$SMPROGRAMS\AquaLog\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0

    ; Write the installation path into the registry
    WriteRegStr HKLM SOFTWARE\AquaLog "Install_Dir" "$INSTDIR"

    ; Write the uninstall keys for Windows
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AquaLog" "DisplayName" "AquaLog"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AquaLog" "UninstallString" '"$INSTDIR\uninstall.exe"'
    WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AquaLog" "NoModify" 1
    WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AquaLog" "NoRepair" 1
    WriteUninstaller "uninstall.exe"

    CreateShortCut "$DESKTOP\AquaLog.lnk" "$INSTDIR\AquaLog.exe" "" "$INSTDIR\AquaLog.exe" 0
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\App Paths\AquaLog.exe" "" "$INSTDIR\AquaLog.exe"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\App Paths\AquaLog.exe" "Path" "$INSTDIR"
SectionEnd

SectionGroup /e "$(al_lang)"
    Section "English"
        SectionIn RO
        SetOutPath "$INSTDIR\locales"
        File "..\locales\english.xml"
    SectionEnd

    Section "Русский"
        SetOutPath "$INSTDIR\locales"
        File "..\locales\russian.xml"
    SectionEnd
SectionGroupEnd

Section "Uninstall"
    ; Remove registry keys
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\App Paths\AquaLog.exe"
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AquaLog"
    DeleteRegKey HKLM "SOFTWARE\AquaLog"

    ; Remove files and uninstaller
    Delete $INSTDIR\LICENSE
    Delete $INSTDIR\AquaLog.exe
    Delete $INSTDIR\AquaLog.exe.config

    Delete $INSTDIR\BSLib.dll
    Delete $INSTDIR\BSLib.Timeline.dll
    Delete $INSTDIR\csgl.dll
    Delete $INSTDIR\csgl.native.dll
    Delete $INSTDIR\DotNetRtfWriter.dll
    Delete $INSTDIR\ExcelLibrary.dll
    Delete $INSTDIR\log4net.dll
    Delete $INSTDIR\sqlite3.dll
    Delete $INSTDIR\ZedGraph.dll

    Delete $INSTDIR\uninstall.exe

    Delete "$INSTDIR\locales\*.*"
    RMDir "$INSTDIR\locales"

    ; Remove shortcuts, if any
    Delete "$SMPROGRAMS\AquaLog\*.*"
    Delete "$DESKTOP\AquaLog.lnk"

    ; Remove directories used
    RMDir "$SMPROGRAMS\AquaLog"
    RMDir "$INSTDIR"
SectionEnd
