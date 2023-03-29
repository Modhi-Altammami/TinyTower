using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;

    public void CreateRoom(GameObject room)
    {
        Instantiate(room);
    }
}



