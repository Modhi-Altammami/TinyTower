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
                targetPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -10)
            {
                targetPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < 15)
            {
                targetPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > 0)
            {
                targetPos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }

            transform.position = targetPos;
        }
    }
}
