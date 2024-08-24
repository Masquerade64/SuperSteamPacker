::msbuild
cd bin\release
ilrepack /ndebug /xmldocs /noRepackRes /wildcards /parallel /out:..\SSP.exe SuperSteamPacker.exe *.dll
cd ..
rmdir /s /q release
ilstrip SSP.EXE SuperSteamPacker.exe
del ssp.exe
pause