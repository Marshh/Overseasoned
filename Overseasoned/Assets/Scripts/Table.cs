using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private Vector3 sphereCastPos;
    public Vector3 direction;
    public float radius;
    public bool occupied;
    public GameObject customer;
    public GameObject dish;
    // Start is called before the first frame update
    void Start()
    {
        radius = .90f;
        sphereCastPos = this.transform.position;
        direction = transform.TransformDirection(new Vector3(0, 1f, 0));
        occupied = false;
        Debug.DrawRay(sphereCastPos, direction);
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDish();
    }

    public void SetCustomer(GameObject customer)
    {
        this.customer = customer;
    }

    void CheckDish()
    {
        int layerMask = 1 << 8;

        if (Physics.SphereCast(transform.position-new Vector3(0,2,0), radius, direction, out RaycastHit hit, Mathf.Infinity,layerMask))
        {
            if (hit.collider.CompareTag("Dish") && Input.GetKeyDown(KeyCode.E) && dish==null)
            {
                print("success");
                dish = hit.collider.gameObject;
                hit.collider.gameObject.transform.parent.gameObject.GetComponent<Player>().item=null;
                dish.transform.SetParent(transform);
                dish.transform.localPosition = new Vector3(-1, dish.GetComponent<Renderer>().bounds.size.y, 0);
                dish.GetComponent<Rigidbody>().detectCollisions = false;
            }
        }
    }
}
