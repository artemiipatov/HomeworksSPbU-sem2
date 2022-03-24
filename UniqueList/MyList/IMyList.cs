namespace MyList;

public interface IMyList
{
    int Length { get; set; }

    void Add(int value);

    void Remove(int position);

    void ChangeValue(int position, int value);
}