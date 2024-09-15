using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory<T1>
{
    T1 Create(string id);
}
