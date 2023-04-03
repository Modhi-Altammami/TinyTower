using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace modi.TinyTower {
    /// <summary>
    /// Room type
    /// </summary>
    public enum RoomType
    {
        Office,
        Gym,
        Restaurant
    }

    public class Room : MonoBehaviour
    {
        [Header("Room Type")]
        [SerializeField] RoomType type;

        [Header("Economy")]
        [SerializeField] float price;
        [SerializeField] float cost;
        [SerializeField] float income;
        [SerializeField] float happiness;

        [Header("Components")]
        [SerializeField] GameObject rightWall;
        [SerializeField] GameObject leftWall;
        [SerializeField] GameObject leftWallWithDoor;
        [SerializeField] GameObject rightWallWithDoor;


        //Set and Get
        public float Price
        {
            set { price = value; }
            get { return price; }
        }

        public float Cost
        {
            set { cost = value; }
            get { return cost; }
        }

        public float Income
        {
            set { income = value; }
            get { return income; }
        }

        public float Happiness
        {
            set { happiness = value; }
            get { return happiness; }
        }

        float initialCost;
        float initialIncome;
        float _time;

        protected static event Action CalculateEconomyEvent;

        /// <summary>
        /// subscribe to the functions that will be invoked every 5
        /// </summary>
        private void Start()
        {
            initialCost = cost;
            initialIncome = income;

            CalculateEconomyEvent += CalculateIncome;
            CalculateEconomyEvent += CalculateCost;
            CalculateEconomyEvent += CalculateHappiness;
            CalculateEconomyEvent += CalculateWallet;
            CalculateEconomyEvent += RoomManager.instance.updateWallet;

        }
        void Update()
        {
            CheckWalls();
            _time += Time.deltaTime;
            if (_time >= 5)
            {
                CalculateEconomyEvent?.Invoke();
                _time = 0;
            }
        }

        /// <summary>
        /// check the left and right of the room to see if neighbouring rooms exists
        /// </summary>
        protected void CheckWalls()
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
        /// <summary>
        /// the income will change based on room type
        /// office : the income is stable
        /// gym: the income can be semi stable
        /// resturant: the income can be unstable
        /// </summary>
        protected void CalculateIncome()
        {
            if (type == 0)
            {
                income += initialIncome;
            }
            if ((int)type == 1)
            {
                income += initialIncome / Random.Range(1, 2);
            }
            if ((int)type == 2)
            {
                income += initialIncome / Random.Range(1, 4);
            }
        }
        /// <summary>
        /// the cost is fixed for all room type
        /// </summary>
        protected void CalculateCost()
        {
            cost = initialCost;
        }
        /// <summary>
        /// the happiness is dependent on the income and cost.
        /// office : the office have a low increase
        /// gym: the office has a moderate increase
        /// resutrant: the happiness has a high increase
        /// </summary>
        protected void CalculateHappiness()
        {
            if ((int)type == 0)
            {
                happiness += income / 10 - cost / 10;
            }
            if ((int)type == 1)
            {
                happiness += income / 2 - cost / 2;
            }
            if ((int)type == 2)
            {
                happiness += income * 2;
            }

            RoomManager.instance.happiness += happiness;
        }
        /// <summary>
        /// the wallet is added from income minus cost
        /// </summary>
        protected void CalculateWallet()
        {
            RoomManager.instance.wallet += (income - cost);
        }
    }
}






