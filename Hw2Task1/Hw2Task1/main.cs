using Hw2Task1;

Trie myTrie = new Trie();
bool addResult = myTrie.AddItem("test");
if (myTrie.Contains("test"))
{
    Console.WriteLine("There is string test in trie");
}

int HowManyResult = myTrie.HowManyStartsWithPrefix("te");
bool removeResult = myTrie.Remove("test");
int HowManyResultAfterRemoving = myTrie.HowManyStartsWithPrefix("te");
bool containsResult = myTrie.Contains("test");