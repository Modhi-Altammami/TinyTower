using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace modi.TinyTower
{
    public class RoomPlacement : MonoBehaviour
    {
        [SerializeField] GameObject indicator;
        [SerializeField] List<GameObject> Rays;
        bool isPlaced;
        bool isOverlapped;
        Vector3 mousePosition;
        Camera cam;
        Vector3 mouseInput;

        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isPlaced)
            {
                MoveMouse();

                if (CheckValidPlace() && Input.GetMouseButtonDown(0))
                {
                    isPlaced = true;
                }
            }
        }

        /// <summary>
        /// move the mouse to follow the 3d object
        /// </summary>
        void MoveMouse()
        {
            mouseInput = Input.mousePosition;
            mouseInput.z = 10;
            mousePosition = cam.ScreenToWorldPoint(mouseInput);
            mousePosition.x = Mathf.Round(mousePosition.x);
            mousePosition.y = Mathf.Round(Mathf.Clamp(mousePosition.y, 0, int.MaxValue));
            transform.position = mousePosition;
        }
        /// <summary>
        /// check if the place is valid after mouse movement
        /// </summary>
        /// <returns></returns>
        bool CheckValidPlace()
        {
            if (isOverlapped)
            {
                indicator.SetActive(true);
                return false;
            }

            foreach (GameObject rayObject in Rays)
            {
                Ray ray = new Ray(rayObject.gameObject.transform.position, Vector3.down);
                RaycastHit hitData;
                if (!Physics.Raycast(ray, out hitData, 1.5f))
                {
                    indicator.SetActive(true);
                    return false;
                }
            }

            indicator.SetActive(false);
            return true;

        }
        /// <summary>
        /// check if the rooms is overlapped
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerStay(Collider other)
        {
            if (isPlaced) return;
            isOverlapped = true;
        }
        /// <summary>
        /// check if the rooms is not overlapped anymore 
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerExit(Collider other)
        {
            if (isPlaced) return;
            isOverlapped = false;
        }
    }
}
