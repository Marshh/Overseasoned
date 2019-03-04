using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealSpawners : MonoBehaviour
{
    public GameObject dish;
    private GameObject dishInstance;
    public bool isOccupied = false;
    private float timer = 0f;
    private Stack<GameObject> dishes = new Stack<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOccupied)
        {
            spawnMeal();
        }
    }

    void spawnMeal()
    {
        Vector3 unitAbove = this.transform.position + new Vector3(0, 0.5f, 0);
        dishInstance = Instantiate(dish, unitAbove, Quaternion.identity);
        if(this.name == "Curry")
        {
            dishInstance.GetComponent<Dish>().name = this.name;
        }
        else if(this.name == "Steak")
        {
            dishInstance.GetComponent<Dish>().name = this.name;
        }
        else if(this.name == "Soup")
        {
            dishInstance.GetComponent<Dish>().name = this.name;
        }
        dishes.Push(dishInstance);
        isOccupied = true;
        timer = 0f;
    }

    public GameObject getDish()
    {
        return dishes.Pop();
    }
}
