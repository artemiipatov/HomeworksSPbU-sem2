namespace Trie;

public interface ITrie
{
    int Size { get; }
    
    bool AddItem(byte[] element);

    bool Remove(byte[] element);

    bool Contains(byte[] element);

    int GetNumber(byte[] sequence);

    int HowManyStartsWithPrefix(byte[] prefix);
}