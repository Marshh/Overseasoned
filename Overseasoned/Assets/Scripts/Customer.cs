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
        CheckDish();
    }

    void CustomerLeft()
    {
        Destroy(this.gameObject);
        
    }

    void CheckDish()
    {
        Debug.DrawRay(transform.position, direction, Color.green);

        if (Physics.SphereCast(sphereCastPos, radius, direction, out RaycastHit hitInfo, 3f))
        {
            if(hitInfo.collider.CompareTag("Dish"))
            {   
                print("success");
                hitInfo.collider.gameObject.GetComponent<Dish>().checkCurry();
                completed = hitInfo.collider.gameObject.GetComponent<Dish>().hasAll;
                hitInfo.collider.gameObject.GetComponent<Dish>().clear();
            }
        }
    }
}
