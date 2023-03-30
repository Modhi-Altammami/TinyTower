using UnityEngine;

public enum RoomType
{
   Office,
   Gym,
   Restaurant
}

public class Room : MonoBehaviour
{
    [SerializeField] GameObject rightWall;
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject leftWallWithDoor;
    [SerializeField] GameObject rightWallWithDoor;
    [SerializeField] RoomType type;


    protected void CheckWalls(GameObject room)
    {
        Ray ray = new Ray(rightWall.gameObject.transform.position, Vector3.right);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 1f))
        {
            rightWall.SetActive(false);
            if (!hitData.collider.GetComponent<Room>().type.Equals(type))
            {
                rightWallWithDoor.SetActive(true);

            }
            
        }
        else
        {
            rightWall.SetActive(true);
            rightWallWithDoor.SetActive(false);
        }

        ray = new Ray(leftWall.gameObject.transform.position, Vector3.left);
        if (Physics.Raycast(ray, out hitData, 1f))
        {
            leftWall.SetActive(false);
            if (!hitData.collider.GetComponent<Room>().type.Equals(type))
            {
                leftWallWithDoor.SetActive(true);
            }
        }
        else
        {
            leftWall.SetActive(true);
            leftWallWithDoor.SetActive(false);
        }
    }

}





