using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    //public GameObject dish;
    public float timer;
    public bool completed;
    public static Customer instance;

    public GameObject DishStation;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            
            
            if(completed) RespawnDish();

            CustomerLeft();
        }
        //CheckDish();
    }

    void CustomerLeft()
    {
        SpawnCustomer.instance.numberOfCustomers -= 1;
        Destroy(this.gameObject);

    }

    void RespawnDish()
    {
        Destroy(this.transform.parent.gameObject.GetComponent<Table>().dish);
        GameObject.Find("DishStation").GetComponent<DishStation>().spawnDish(1f);
    }
//    void CheckDish()
//    {
//        Debug.DrawRay(transform.position, direction, Color.green);
//
//        if (Physics.SphereCast(sphereCastPos, radius, direction, out RaycastHit hitInfo, 3f))
//        {
//            if(hitInfo.collider.CompareTag("Dish"))
//            {   
//                print("success");
//                hitInfo.collider.gameObject.GetComponent<Dish>().checkCurry();
//                completed = hitInfo.collider.gameObject.GetComponent<Dish>().hasAll;
//                hitInfo.collider.gameObject.GetComponent<Dish>().clear();
//            }
//        }
//    }
}
