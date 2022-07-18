using Routers;

string inputFilePath = "../../../input.txt";
string outputFilePath = "../../../output.txt";
Routers.Routers routers = new Routers.Routers(inputFilePath);
routers.GenerateConfig(outputFilePath);