# BattleshipCodingTestApplication

# I have added Documentation with .PDF file for the code at location ....\BattleShipCodingTest\Documentation\

# Project architecture:
#Created web API with dot net core target framework 7.0.
#Added swagger.
#Testable through postman.
#Database and User interface is not available.

# Functionality achieved:
#Created board with 10x10 size.
#Place ships with half the size of board.
#Attack at specified position displayed on board to get hit or miss
#Display board
#Restart game
#Unit tests for positive and negative scenarios

# Hosting:
#Hosted the application at Azure

# Web API end point:
#Create board - https://battleship-test5.azurewebsites.net/api/BattleshipApi/CreateBoard
#Place Ships - https://battleship-test5.azurewebsites.net/api/BattleshipApi/PlaceShip
#Display Board - https://battleship-test5.azurewebsites.net/api/BattleshipApi/DisplayBoard
#Attack Ship - https://battleship-test5.azurewebsites.net/api/BattleshipApi/AttackShip
#Restart Game -  https://battleship-test5.azurewebsites.net/api/BattleshipApi/RestartGame

# Steps to test:
#Step 1 – Call Create board end point from postman
#EX:  https://battleship-test5.azurewebsites.net/api/BattleshipApi/CreateBoard
#Place Ships - Call Create Ships end point from postman
#EX:  https://battleship-test5.azurewebsites.net/api/BattleshipApi/PlaceShip
#Display Board – Call Display Board end point to view position which you want to hit
#EX:  https://battleship-test5.azurewebsites.net/api/BattleshipApi/DisplayBoard
#Attack Ship – Call Attack Ship end point from postman and pass the Position from body  as displayed on board 
#EX:  https://battleship-test5.azurewebsites.net/api/BattleshipApi/AttackShip 
#Pass the co-ordinates through body in postman:
#{
    "x": 8,
    "y": 9
}
#Restart Game – If you won the game you need to call this API to restart the game and follow the steps again
#EX: https://battleship-test5.azurewebsites.net/api/BattleshipApi/RestartGame
