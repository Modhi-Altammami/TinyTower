using UnityEngine;

namespace modi.TinyTower
{
    public class CameraMovement : MonoBehaviour
    {
        Vector3 targetPos;

        private void Start()
        {
            targetPos = transform.position;
        }
        // Update is called once per frame
        void Update()
        {
            MoveCamera();
        }

        void MoveCamera()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 10)
            {
                targetPos.x++;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -10)
            {
                targetPos.x--;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < 15)
            {
                targetPos.y++;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > 0)
            {
                targetPos.y--;
            }

            transform.position = targetPos;
        }
    }
}
