using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepStation : MonoBehaviour
{

    public GameObject dish;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddIngredient(string Ingredient)
    {
        dish.GetComponent<Dish>().addIngredient(Ingredient);
    }

    public void PlaceDish(GameObject Dish)
    {
        dish = Dish;
        dish.transform.SetParent(transform);
        dish.transform.localPosition = new Vector3(0, 0.5f + dish.GetComponent<Renderer>().bounds.size.y / 2, 0);
    }

    public GameObject PickUpDish(Transform player)
    {



        dish.transform.SetParent(player);
        GameObject item = dish;
        dish = null;

        return item;


    }

}
