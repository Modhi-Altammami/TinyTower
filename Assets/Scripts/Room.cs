using System;
using UnityEngine;
using Random = UnityEngine.Random;
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


    protected void CalculateIncome()
    {

        if ((int)type == 0)
        {
            income += income;
        }
        if ((int)type == 1)
        {
            income += income/ Random.Range(1, 2);
        }
        if ((int)type == 2)
        {
            income += income/Random.Range(1, 4);
        }

    }

    protected void CalculateCost()
    {

        cost = initialCost;
    }

    protected void CalculateHappiness()
    {
        if ((int)type == 0)
        {
            happiness += income / 10 - cost / 10;
        }
        if ((int)type == 1)
        {
            happiness += income / 2 - cost / 5;
        }
        if ((int)type == 2)
        {
            happiness += income*2 ;
        }

        RoomManager.instance.happiness = happiness;
    }

    protected void CalculateWallet()
    {
        RoomManager.instance.wallet += (income - cost);
    }

}





