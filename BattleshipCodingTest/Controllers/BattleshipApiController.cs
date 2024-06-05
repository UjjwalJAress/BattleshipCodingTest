using BattleshipCodingTest.Interfaces;
using BattleshipCodingTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipCodingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleshipApiController : ControllerBase
    {
        private readonly IBattleshipService _battleshipService;

        public BattleshipApiController(IBattleshipService battleshipService)
        {
            _battleshipService = battleshipService;
        }

        /// <summary>
        /// creates board of size 10 X 10
        /// </summary>
        [HttpPost("CreateBoard")]
        public IActionResult CreateBoard()
        {
            var board = _battleshipService.CreateBoard();
            return Ok(board);
        }

        /// <summary>
        /// Display the co-ordinates of board.
        /// </summary>
        [HttpGet("DisplayBoard")]
        public IActionResult DisplayBoard()
        {
            var board = _battleshipService.DisplayBoard();
            return Ok(board);
        }

        /// <summary>
        /// Add ships randomnly on the board of half the size of board
        /// </summary>
        [HttpPost("PlaceShip")]
        public IActionResult PlaceShip()
        {
            var message = _battleshipService.PlaceShip();
            return Ok(message);
        }

        /// <summary>
        /// Attacks the ship at specified co-ordinate.
        /// </summary>
        /// <param name="coordinate"></param>
        [HttpPost("AttackShip")]
        public IActionResult AttackShip([FromBody] Coordinate coordinate)
        {
            var result = _battleshipService.Attack(coordinate);
            return Ok(result);
        }

        /// <summary>
        /// Restarts the game and create a new board of size 10 X 10.
        /// </summary>
        [HttpGet("RestartGame")]
        public IActionResult RestartGame()
        {
            var message = _battleshipService.RestartGame();
            return Ok(message);
        }
    }
}