using Game;
var position = Game.Game.GenerateMap("/home/strider/repos/HomeworksSPbU-sem2/Game/Game/map.txt");

var eventLoop = new EventLoop();
var game = new Game.Game(position);

eventLoop.LeftHandler += game.OnLeft;
eventLoop.RightHandler += game.OnRight;
eventLoop.DownHandler += game.OnDown;
eventLoop.UpHandler += game.OnUp;

eventLoop.Run();