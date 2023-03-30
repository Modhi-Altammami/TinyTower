using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;

    void Awake()
    {
        if (instance == null) // if instance is not initilized then instance is equal to class
            instance = this;
        else
        {
            Destroy(gameObject);
        }

    }

    [SerializeField] Transform Building;
    public void CreateRoom(GameObject room)
    {
        Instantiate(room , Building);
    }
}
