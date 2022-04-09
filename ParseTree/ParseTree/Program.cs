using ParseTree;
IParseTree myTree = new ParseTree.ParseTree();
myTree.Parse("../../../expression.txt");
Console.WriteLine(myTree.Eval());
myTree.Print();