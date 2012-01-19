; example1.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply 
; prompts the user asking them where to install, and drops a copy of example1.nsi
; there. 

;--------------------------------

!define APP "AFPClient4Windows"
!define VER "0.2"
!define APV "0_2"

; The name of the installer
Name "${APP} ${VER}"

; The file to write
OutFile "${APP}_${APV}_portable.exe"

; The default installation directory
InstallDir "$APPDATA\${APP}"

; Request application privileges for Windows Vista
RequestExecutionLevel user

!define DOTNET_VERSION "2.0"

!include "DotNET.nsh"
!include LogicLib.nsh

;--------------------------------

; Pages

Page license
PageEx license
  LicenseData "CHANGES.rtf"
PageExEnd
Page directory
Page instfiles

LicenseData "NewBSD.rtf"

;--------------------------------

; The stuff to install
Section "" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR

  !insertmacro CheckDotNET ${DOTNET_VERSION}

  ; Put file there
  File "bin\x86\DEBUG\*.exe"
  File "bin\x86\DEBUG\*.config"
  File "bin\x86\DEBUG\*.dll"
  File "bin\x86\DEBUG\*.manifest"
  File "bin\x86\DEBUG\*.pdb"
  
  Exec '"$INSTDIR\AFPClient4Windows.exe"'

SectionEnd ; end the section
