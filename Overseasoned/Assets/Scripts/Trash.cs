using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public void deleteDish(Transform player)
    {
        foreach (Transform child in player.transform)
        {
            if (!(child.name == "ScaleReset"))
            {
                Destroy(child.gameObject);
            }
        }
    }
}
