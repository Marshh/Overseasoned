using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishStation : MonoBehaviour
{
    public GameObject Dish;

    private GameObject _DishInstance;

    public float SpawnTimer;

    private float _countDown;

    private Stack<GameObject> dishes = new Stack<GameObject>();

    void Start()
    {
        spawnDish(0.5f);
        spawnDish(1.0f);
        spawnDish(1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnDish(float height)
    {
        _countDown = SpawnTimer;
        Vector3 unitAbove = this.transform.position+new Vector3(0,height,0);

        _DishInstance = Instantiate(Dish, unitAbove, Quaternion.identity);
        //Remove (clone)
        _DishInstance.name = Dish.name;
        dishes.Push(_DishInstance);
    }

    public GameObject getDish()
    {
        return dishes.Pop();
    }
}