; example1.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply 
; prompts the user asking them where to install, and drops a copy of example1.nsi
; there. 

;--------------------------------

!define APP "AFPClient4Windows"
!define VER "0.12"
!define APV "0_12"

!define EXT ".AFPClient4Windows"
!define MIME "application/x-AFPClient4Windows"

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
!include "LogicLib.nsh"

;--------------------------------

; Pages

Page license
PageEx license
  LicenseData "CHANGES.rtf"
PageExEnd
Page directory
Page components
Page instfiles

LicenseData "NewBSD.rtf"

;--------------------------------
; http://nsis.sourceforge.net/FileAssoc

; !defines for use with SHChangeNotify
!ifdef SHCNE_ASSOCCHANGED
!undef SHCNE_ASSOCCHANGED
!endif
!define SHCNE_ASSOCCHANGED 0x08000000
!ifdef SHCNF_FLUSH
!undef SHCNF_FLUSH
!endif
!define SHCNF_FLUSH        0x1000

!macro UPDATEFILEASSOC
; Using the system.dll plugin to call the SHChangeNotify Win32 API function so we
; can update the shell.
  System::Call "shell32::SHChangeNotify(i,i,i,i) (${SHCNE_ASSOCCHANGED}, ${SHCNF_FLUSH}, 0, 0)"
!macroend

;--------------------------------

; The stuff to install
Section "" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR

  !insertmacro CheckDotNET ${DOTNET_VERSION}

  ; Put file there
  File /r /x "*.vshost.*" "bin\x86\DEBUG\*.*"

SectionEnd ; end the section

Section "拡張子 関連付け HKCU"
  SetOutPath $INSTDIR
  WriteRegStr HKCU "Software\Classes\${EXT}" "" "${APP}"
  WriteRegStr HKCU "Software\Classes\${EXT}" "Content Type" "${MIME}"
  WriteRegStr HKCU "Software\Classes\${EXT}" "PerceivedType" "application"
  
  WriteRegStr HKCU "Software\Classes\${APP}" "" "${APP}"
  WriteRegStr HKCU "Software\Classes\${APP}\DefaultIcon" "" "$INSTDIR\1.ico"
  WriteRegStr HKCU "Software\Classes\${APP}\shell\open\command" "" '"$INSTDIR\AFPClient4Windows.exe" /open "%1"'
  
  !insertmacro UPDATEFILEASSOC
SectionEnd

Section "スタートメニューへ登録"
  CreateShortcut "$SMPROGRAMS\AFPClient4Windows.lnk" \
    "$INSTDIR\AFPClient4Windows.exe" \
    "" \
    "$INSTDIR\1.ico"
SectionEnd

Section "起動"
  SetOutPath $INSTDIR
  Exec '"$INSTDIR\AFPClient4Windows.exe"'
SectionEnd

Section
  IfErrors +2
    SetAutoClose true
SectionEnd
