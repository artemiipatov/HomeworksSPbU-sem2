using Hw2Task1;

var myTrie = new Trie();
var addResult = myTrie.AddItem("test");
if (myTrie.Contains("test"))
{
    Console.WriteLine("There is string test in trie");
}

var howManyStartsWithPrefixResult = myTrie.HowManyStartsWithPrefix("te");
var removeResult = myTrie.Remove("test");
var howManyStartsWithPrefixRemoving = myTrie.HowManyStartsWithPrefix("te");
var containsResult = myTrie.Contains("test");