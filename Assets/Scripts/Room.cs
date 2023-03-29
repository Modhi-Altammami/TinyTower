using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    [SerializeField] GameObject rightWall;
    [SerializeField] GameObject leftWall;

   

    protected void CheckWalls(GameObject room)
    {
        Ray ray = new Ray(rightWall.gameObject.transform.position, Vector3.right);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 1f))
        {
            Debug.Log("hit room: "+ hitData.collider.tag + " the ray comes from " + room.tag);

            if (hitData.collider.tag.Equals(room.tag))
            {
                rightWall.SetActive(false);
            }
        }
        else
        {
            rightWall.SetActive(true);
        }

        ray = new Ray(leftWall.gameObject.transform.position, Vector3.left);
        if (Physics.Raycast(ray, out hitData, 1f))
        {
            Debug.Log("hit room: " + hitData.collider.tag + " the ray comes from " + room.tag);

            if (hitData.collider.tag.Equals(room.tag))
            {
                leftWall.SetActive(false);
            }
        }
        else
        {
            leftWall.SetActive(true);
        }
    }

}



