using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public void CreateRoom(GameObject room)
    {
        Instantiate(room);
    }
}
