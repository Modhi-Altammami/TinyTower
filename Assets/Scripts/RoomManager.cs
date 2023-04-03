using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
namespace modi.TinyTower
{
    public class RoomManager : MonoBehaviour
    {

        [SerializeField] Transform Building;
        [SerializeField] TextMeshProUGUI happinessText;
        [SerializeField] TextMeshProUGUI walletText;
        [SerializeField] GameObject InsuffecientFunds;

        public static RoomManager instance;
        public float wallet;
        public float happiness;

        List<Room> broughtRooms;

        /// <summary>
        /// singleton
        /// </summary>
        void Awake()
        {
            if (instance == null) // if instance is not initilized then instance is equal to class
                instance = this;
            else
            {
                Destroy(gameObject);
            }

        }

        /// <summary>
        /// declare the rooms list and display the initial happiness/wallet values
        /// </summary>
        private void Start()
        {
            broughtRooms = new List<Room>();
            wallet = 250;
            happiness = 0;
            UpdateWallet();
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
                DeductPrice(roomObj);
                UpdateWallet();
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
        void DeductPrice(Room room)
        {
            wallet += -room.Price;
        }

        /// <summary>
        /// display the information to users
        /// </summary>
        public void UpdateWallet()
        {
            happinessText.text = Math.Round(happiness, 1).ToString();
            walletText.text = "$" + Math.Round(wallet, 1);
        }
    }
}
