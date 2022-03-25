namespace Lists;

public interface ICommonList
{
    int Length { get; set; }

    void Add(int value);

    void Remove(int position);

    void ChangeValue(int position, int value);

    int Get(int position);
}