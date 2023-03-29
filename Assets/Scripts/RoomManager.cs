using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    [SerializeField] Transform Building;
    public void CreateRoom(GameObject room)
    {
        Instantiate(room , Building);
    }
}
