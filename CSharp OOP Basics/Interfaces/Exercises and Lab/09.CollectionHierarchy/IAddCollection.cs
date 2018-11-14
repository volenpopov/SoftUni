
using System.Collections.Generic;

internal interface IAddCollection<T>
{
    int Add(T element);
    IReadOnlyCollection<T> Data { get; }
}

