using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public void deleteDish(GameObject item)
    {
        
        item.GetComponent<Dish>().clear();
    }
}
