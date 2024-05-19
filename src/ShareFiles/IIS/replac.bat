@echo off
setlocal EnableExtensions DisableDelayedExpansion

rem // Define constants here:
set "_ROOT=%~3"   & rem // (path to root directory; third command line argument)
set "_MASK=%~4"   & rem // (file search pattern; fourth command line argument)
set "_SEARCH=%~1" & rem // (search string; first command line argument)
set "_REPLAC=%~2" & rem // (replace string; second command line argument)
set "_CASE=#"     & rem // (clear for case-insensitive search)
set "_RECURS=#"   & rem // (clear for non-recursive search)
set "_TMPF=%TEMP%\%~n0_%RANDOM%.tmp" & rem // (path to temporary file)

rem // Validate passed command line arguments, apply defaults:
if not defined _SEARCH exit /B 1
if not defined _ROOT set "_ROOT=."
if not defined _MASK set "_MASK=*appsettings.json"

rem // Prepare `if` option (case-insensitivity) for later use:
if defined _CASE (set "IFSW=") else (set "IFSW=/I")
rem // Prepare `for` option (recursion) for later use:
if defined _RECURS (set "FOROPT=/R") else (set "FOROPT=")
rem // Change into root directory temporarily:
pushd "%_ROOT%" || exit /B 1
rem // Loop through all matching files in the directory tree:
for %FOROPT% %%F in ("%_MASK%") do (
    rem // Write to temporary file:
    > "%_TMPF%" (
        set "FLAG="
        rem /* Read current file line by line; use `findstr` to precede every line by
        rem    its line number and a colon `:`; this way empty lines appear non-empty
        rem    to `for /F`, which avoids them to be ignored; otherwise empty lines
        rem    became lost: */
        for /F "delims=" %%L in ('findstr /N "^" "%%~fF"') do (
            rem // Store current line text:
            set "LINE=%%L"
            setlocal EnableDelayedExpansion
            rem // Remove line number prefix:
            set "LINE=!LINE:*:=!"
            rem // Skip replacement for empty line text:
            if defined LINE (
                rem /* Use `for /F` loop to avoid trouble in case search or replace
                rem    strings contain quotation marks `"`: */
                for /F "tokens=* delims=*= eol=~" %%K in ("!_SEARCH!=!_REPLAC!") do (
                    rem // Split search and replace strings:
                    for /F "tokens=1 delims== eol==" %%I in ("%%K") do (
                        rem // Query to handle case-sensitivity:
                        if %IFSW% "!LINE!"=="!LINE:%%I=%%I!" (
                            rem // Detect whether replacement changes line:
                            if not "!LINE!"=="!LINE:%%K!" (
                                rem // Actually do the sub-string replacement:
                                set "LINE=!LINE:%%K!"
                                set "FLAG=#"
                            )
                        )
                    )
                )
            )
            rem // Output the resulting line text:
            echo(!LINE!
            if defined FLAG (endlocal & set "FLAG=#") else (endlocal)
        )
    )
    rem // Check whether file content would change upon replacement:
    if defined FLAG (
        rem // Move the temporary file onto the original one:
        > nul move /Y "%_TMPF%" "%%~fF"
    ) else (
        rem // Simply delete temporary file:
        del "%_TMPF%"
    )
)
popd

endlocal
exit /B