using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    public GameObject customer;
    public int numberOfCustomers = 0;
    public Vector3 table1Pos, table2Pos, table3Pos;
    public GameObject table1, table2, table3;
    public GameObject table;
    private Table tableScript;
    public GameObject[] tables;
    // Start is called before the first frame update
    void Awake()
    {
        tables = new GameObject[] { table1, table2, table3 };
        table1Pos = new Vector3(-6.5f, 1.05f, -6);
        table2Pos = new Vector3(-0.5f, 1.05f, -6);
        table3Pos = new Vector3(5.5f, 1.05f, -6);
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfCustomers < 1)
        {
            SpawnCustomers();
        }
    }
    void SpawnCustomers()
    {
        int tableNum = Random.Range(0, 3);
        table = tables[tableNum];
        tableScript = table.GetComponent<Table>();
        if (tableNum == 0 && tableScript.occupied == false)
        {
            Instantiate(customer, table1Pos, Quaternion.identity);
        }
        else if(tableNum == 1 && tableScript.occupied == false)
        {
            Instantiate(customer, table2Pos, Quaternion.identity);
        }
        else if(tableNum == 2 && tableScript.occupied == false)
        {
            Instantiate(customer, table3Pos, Quaternion.identity);
        }
        numberOfCustomers += 1;
    }
}
