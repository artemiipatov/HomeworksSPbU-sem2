namespace Lists;

public interface ICommonList
{
    /// <summary>
    /// Number of elements in the list
    /// </summary>
    int Length { get; set; }

    /// <summary>
    /// Adds the element to the list
    /// </summary>
    /// <param name="value"></param>
    void Add(int value);

    /// <summary>
    /// Removes the element from the list
    /// </summary>
    /// <param name="position"></param>
    void Remove(int position);
    
    /// <summary>
    /// Changes the value of the list element with give index
    /// </summary>
    /// <param name="position"></param>
    /// <param name="value"></param>
    void ChangeValue(int position, int value);

    /// <summary>
    /// Returns the value of the list element with given index
    /// </summary>
    /// <param name="position"></param>
    int Get(int position);
}