using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory<T>
{
    T Create(string id);
    T Create();
}
