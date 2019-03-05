using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public void deleteDish(GameObject item)
    {
        if (item.name == "Dish")
        {
            item.GetComponent<Dish>().clear();
            item.GetComponent<Dish>().clearSpiciness();
        }
        else
        {
            Destroy(item);
        }
    }
}
