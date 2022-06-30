using Game;
using IConsoleWrapper = ConsoleWrapper.IConsoleWrapper;

IConsoleWrapper console = new ConsoleWrapper.ConsoleWrapper();
var game = new Game.Game(console);
game.GenerateMap("../../../map.txt");

var eventLoop = new EventLoop();

eventLoop.LeftHandler += game.OnLeft;
eventLoop.RightHandler += game.OnRight;
eventLoop.DownHandler += game.OnDown;
eventLoop.UpHandler += game.OnUp;

eventLoop.Run();