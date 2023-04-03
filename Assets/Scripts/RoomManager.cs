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
        [SerializeField] GameObject InsuffecientFunds;

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
            wallet = 250;
            happiness = 0;
            happinessText.text = happiness.ToString();
            walletText.text = "$" + wallet.ToString();
        }


        /// <summary>
        /// create room and add it in the brought rooms list
        /// </summary>
        /// <param name="room"></param>
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
            else
            {
                InsuffecientFunds.SetActive(true);
            }
        }

        /// <summary>
        /// deduct the price of the brought room
        /// </summary>
        /// <param name="room"></param>
        void deductPrice(Room room)
        {
            wallet += -room.Price;
        }

        /// <summary>
        /// display the information
        /// </summary>
        public void updateWallet()
        {
            walletText.text = "$" + wallet.ToString();
            happinessText.text = happiness.ToString();
        }
    }
}
