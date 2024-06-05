# BattleshipCodingTestApplication

# I have added Documentation with .PDF file for the code at location ....\BattleShipCodingTest\Documentation\

#Function app end point:
#Create board - https://battleship-test5.azurewebsites.net/api/BattleshipApi/CreateBoard
#Place Ship - https://battleship-test5.azurewebsites.net/api/BattleshipApi/PlaceShip
#Display Board - https://battleship-test5.azurewebsites.net/api/BattleshipApi/DisplayBoard
#Attack Ship - https://battleship-test5.azurewebsites.net/api/BattleshipApi/AttackShip
#Restart Game - https://battleship-test5.azurewebsites.net/api/BattleshipApi/RestartGame

#Steps to test:
#Step 1 – Call Create board end point from swagger.
#EX: https://battleship-test5.azurewebsites.net/api/BattleshipApi/CreateBoard
#Place Ship - Call Place Ships end point from swagger and place ship one by one (Maximum ships to be placed will be less than equal to 5)
#EX: https://battleship-test5.azurewebsites.net/api/BattleshipApi/PlaceShip
#Display Board – Call Display Board end point to view position which you want to hit
#EX: https://battleship-test5.azurewebsites.net/api/BattleshipApi/DisplayBoard
#Attack Ship – Call Attack Ship end point from swagger and pass the x and y co-ordinate as displayed on board
#EX: https://battleship-test5.azurewebsites.net/api/BattleshipApi/AttackShip
#Restart Game – If you won the game you need to call this API to restart the game and follow the steps again
#EX: https://battleship-test5.azurewebsites.net/api/BattleshipApi/RestartGame
