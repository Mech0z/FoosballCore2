# FoosballCore2

To run frontend with visual studio code on windows

#1 Install npm
  choco install npm (need admin prev)
  
#2 install typescript and webpack
  npm install typescript
  npm install --save-dev webpack
  npm install -g yo generator-aspnetcore-spa
 
#3 Restore dotnet packages
  goto frontend dir \src\Frontend
  powershell: dotnet restore

#5
  F5 in Visual studio code
