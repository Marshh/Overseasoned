using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealSpawners : MonoBehaviour
{
    public GameObject skillet;
    private GameObject skilletInstance;
    public bool isOccupied = false;
    private float timer;
    private Stack<GameObject> dishes = new Stack<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        timer = 30f;
        spawnMeal();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOccupied)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                spawnMeal();
                timer = 30f;
            }
        }
    }

    void spawnMeal()
    {
        Vector3 unitAbove = this.transform.position + new Vector3(0, 0.5f, 0);
        skilletInstance = Instantiate(skillet, unitAbove, Quaternion.identity);
        if (this.name == "Curry")
        {
            skilletInstance.GetComponent<Skillet>().name = this.name;
        }
        else if (this.name == "Steak")
        {
            skilletInstance.GetComponent<Skillet>().name = this.name;
        }
        else if (this.name == "Soup")
        {
            skilletInstance.GetComponent<Skillet>().name = this.name;
        }
        dishes.Push(skilletInstance);
        isOccupied = true;
    }

    public GameObject getSkillet(Transform player)
    {
        GameObject Skillet = dishes.Pop();
        Skillet.GetComponent<Rigidbody>().detectCollisions = true;
        Skillet.GetComponent<Rigidbody>().useGravity = false;
        Skillet.GetComponent<Rigidbody>().isKinematic = true;
        Skillet.transform.SetParent(player);
        isOccupied = false;
        return Skillet;
    }
}
