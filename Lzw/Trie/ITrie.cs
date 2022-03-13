namespace Trie;

public interface ITrie
{
    bool AddItem(byte[] element);

    bool Remove(byte[] element);

    bool Contains(byte[] element);

    int GetNumber(byte[] sequence);

    int HowManyStartsWithPrefix(byte[] prefix);
}