using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] GameObject rightWall;
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject leftWallWithDoor;
    [SerializeField] GameObject rightWallWithDoor;


    protected void CheckWalls(GameObject room)
    {
        Ray ray = new Ray(rightWall.gameObject.transform.position, Vector3.right);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 1f))
        {

            if (hitData.collider.tag.Equals(room.tag))
            {
                rightWall.SetActive(false);
            }
            else
            {
                rightWallWithDoor.SetActive(true);
                rightWall.SetActive(false);
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

            if (hitData.collider.tag.Equals(room.tag))
            {
                leftWall.SetActive(false);
            }
            else
            {
                leftWallWithDoor.SetActive(true);
                leftWall.SetActive(false);
            }
        }
        else
        {
            leftWall.SetActive(true);
            leftWallWithDoor.SetActive(false);
        }
    }

}



