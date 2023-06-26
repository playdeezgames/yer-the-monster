rm -rf ./pub-linux
rm -rf ./pub-windows
rm -rf ./pub-mac
dotnet publish ./src/YerTheMonster/YerTheMonster.vbproj -o ./pub-linux -c Release --sc -r linux-x64
dotnet publish ./src/YerTheMonster/YerTheMonster.vbproj -o ./pub-windows -c Release --sc -r win-x64
dotnet publish ./src/YerTheMonster/YerTheMonster.vbproj -o ./pub-mac -c Release --sc -r osx-x64
butler push pub-windows thegrumpygamedev/a-game-in-vbnet-about-yer-the-monster-and-starting-with-nothing:windows
butler push pub-linux thegrumpygamedev/a-game-in-vbnet-about-yer-the-monster-and-starting-with-nothing:linux
butler push pub-mac thegrumpygamedev/a-game-in-vbnet-about-yer-the-monster-and-starting-with-nothing:mac
git add -A
git commit -m "shipped it!"