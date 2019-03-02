using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    public GameObject customer;
    public int numberOfCustomers;

    private List<Transform> childList;
    public static SpawnCustomer instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {

        childList = GetComponentsInChildren<Transform>().ToList();
        childList.RemoveAt(0);
        SpawnCustomers();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (numberOfCustomers < 3 && Random.value < 0.004f)
        {
            SpawnCustomers();
        }
    }
    void SpawnCustomers()
    {
        int tableNum = Random.Range(0, childList.Count);
        Transform tableTransform = childList[tableNum];
        if (tableTransform.gameObject.GetComponent<Table>().customer != null) return;
        GameObject customerSpawn=Instantiate(customer, tableTransform);
        customerSpawn.transform.localPosition=new Vector3(-2, 0, 0);
        tableTransform.gameObject.GetComponent<Table>().SetCustomer(customerSpawn);
        numberOfCustomers += 1;
    }
}
