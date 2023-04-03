using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace modi.TinyTower
{
    public class RoomManager : MonoBehaviour
    {
        public static RoomManager instance;

        [SerializeField] Transform Building;
        [SerializeField] TextMeshProUGUI happinessText;
        [SerializeField] TextMeshProUGUI walletText;

        List<Room> broughtRooms;
        public float wallet;
        public float happiness;

        void Awake()
        {
            if (instance == null) // if instance is not initilized then instance is equal to class
                instance = this;
            else
            {
                Destroy(gameObject);
            }

        }

        private void Start()
        {
            broughtRooms = new List<Room>();
            wallet = 25000;
            happiness = 0;
            happinessText.text = happiness.ToString();
            walletText.text = "$" + wallet.ToString();
        }



        public void CreateRoom(GameObject room)
        {
            Room roomObj = room.GetComponent<Room>();

            if (roomObj.Price < wallet)
            {
                Instantiate(room, Building);
                deductPrice(roomObj);
                updateWallet();
                broughtRooms.Add(roomObj);
            }
        }

        void deductPrice(Room room)
        {
            wallet += -room.Price;
        }


        public void updateWallet()
        {
            walletText.text = "$" + wallet.ToString();
            happinessText.text = happiness.ToString();
        }
    }
}
