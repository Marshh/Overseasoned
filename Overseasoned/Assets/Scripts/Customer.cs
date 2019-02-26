using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    //public GameObject dish;
    public int spiceLvl;
    private string[] item;
    public string food;
    public float timer;

    // Start is called before the first frame update
    void Awake()
    {
        item = new string[] {"Rice bowl", "Curry"};
        int num = Random.Range(0, 2);
        spiceLvl = Random.Range(0, 3);
        food = item[num];
        timer = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime;
        //if (timer > 0)
        {
           //CustomerLeft();
        }
    }

    void CustomerLeft()
    {
        Destroy(this.gameObject);
        
    }
}
