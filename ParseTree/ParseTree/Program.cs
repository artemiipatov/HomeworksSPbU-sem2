Console.WriteLine();

var myTree = new ParseTree.ParseTree();
myTree.Parse("/home/strider/repos/HomeworksSPbU-sem2/ParseTree/ParseTree/expression.txt");
int result = myTree.Eval();
myTree.Print();