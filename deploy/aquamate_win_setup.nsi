; "AquaMate", Home aquariums manager.
; Copyright (C) 2019 by Sergey V. Zhdanovskih.

!include "MUI2.nsh"
!include "DotNetChecker.nsh"
!define MUI_ICON "..\AquaMate\resources\icon_aquamate.ico"


Unicode true
Name "AquaMate"
OutFile "aquamate_1.4.0_winsetup.exe"
InstallDir $PROGRAMFILES\AquaMate

CRCCheck on
SetCompress auto
SetCompressor lzma
SetDatablockOptimize on
AllowRootDirInstall false
XPStyle on

ShowInstDetails show
RequestExecutionLevel admin


!insertmacro MUI_LANGUAGE "English"
LangString al_req ${LANG_ENGLISH} "AquaMate (required)"
LangString al_lang ${LANG_ENGLISH} "Languages"

!insertmacro MUI_LANGUAGE "Russian"
LangString al_req ${LANG_RUSSIAN} "AquaMate (необходимо)"
LangString al_lang ${LANG_RUSSIAN} "Языки"


; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\AquaMate" "Install_Dir"


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

    File "..\AquaMate.exe"
    File "..\AquaMate.exe.config"

    File "..\AquaMate.Core.dll"

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

    CreateDirectory "$SMPROGRAMS\AquaMate"
    CreateShortCut "$SMPROGRAMS\AquaMate\AquaMate.lnk" "$INSTDIR\AquaMate.exe" "" "$INSTDIR\AquaMate.exe" 0
    CreateShortCut "$SMPROGRAMS\AquaMate\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0

    ; Write the installation path into the registry
    WriteRegStr HKLM SOFTWARE\AquaMate "Install_Dir" "$INSTDIR"

    ; Write the uninstall keys for Windows
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AquaMate" "DisplayName" "AquaMate"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AquaMate" "UninstallString" '"$INSTDIR\uninstall.exe"'
    WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AquaMate" "NoModify" 1
    WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AquaMate" "NoRepair" 1
    WriteUninstaller "uninstall.exe"

    CreateShortCut "$DESKTOP\AquaMate.lnk" "$INSTDIR\AquaMate.exe" "" "$INSTDIR\AquaMate.exe" 0
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\App Paths\AquaMate.exe" "" "$INSTDIR\AquaMate.exe"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\App Paths\AquaMate.exe" "Path" "$INSTDIR"
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
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\App Paths\AquaMate.exe"
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\AquaMate"
    DeleteRegKey HKLM "SOFTWARE\AquaMate"

    ; Remove files and uninstaller
    Delete $INSTDIR\LICENSE
    Delete $INSTDIR\AquaMate.exe
    Delete $INSTDIR\AquaMate.exe.config

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
    Delete "$SMPROGRAMS\AquaMate\*.*"
    Delete "$DESKTOP\AquaMate.lnk"

    ; Remove directories used
    RMDir "$SMPROGRAMS\AquaMate"
    RMDir "$INSTDIR"
SectionEnd
