using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepStation : MonoBehaviour
{

    public GameObject dish;
    public GameObject dishContents;
    public bool isOccupied;
    public static PrepStation instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        isOccupied = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddIngredient(string Ingredient)
    {
        dish.GetComponent<Dish>().addIngredient(Ingredient);
    }

    public void AddSpice(string Spice, int spiceLevel)
    {
        dish.GetComponent<Dish>().addSpice(Spice, spiceLevel);
    }

    public void PlaceDish(GameObject Dish)
    {
        dish = Dish;
        dish.transform.SetParent(transform);
        dish.transform.localPosition = new Vector3(0, 0.5f + dish.GetComponent<Renderer>().bounds.size.y / 2, 0);
        isOccupied = true;
    }

    public GameObject PickUpDish(Transform player)
    {
        dish.transform.SetParent(player);
        GameObject item = dish;
        dish = null;
        isOccupied = false;
        return item;
    }

}
