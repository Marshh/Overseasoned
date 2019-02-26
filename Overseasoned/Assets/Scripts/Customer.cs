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
    private Vector3 sphereCastPos;
    public Vector3 direction;
    public float radius;
    public bool completed;

    // Start is called before the first frame update
    void Awake()
    {
        radius = 0.25f;
        sphereCastPos = this.transform.position;
        direction = transform.TransformDirection(new Vector3(1f, 0, 0));
        item = new string[] {"Rice bowl", "Curry"};
        int num = Random.Range(0, 2);
        spiceLvl = Random.Range(0, 3);
        food = item[num];
        timer = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (completed || timer < 0)
        {
            CustomerLeft();
        }
    }

    void CustomerLeft()
    {
        Destroy(this.gameObject);
        
    }

    void CheckDish()
    {
        if (Physics.SphereCast(sphereCastPos, radius, direction, out RaycastHit hitInfo, 3f))
        {
            if(hitInfo.collider.CompareTag("Dish"))
            {
                completed = hitInfo.collider.gameObject.GetComponent<Dish>().hasAll;
            }
        }
    }
}
