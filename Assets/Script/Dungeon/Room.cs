using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : MonoBehaviour
{
    [SerializeField] private string _id;

    public string Id => _id;
}
