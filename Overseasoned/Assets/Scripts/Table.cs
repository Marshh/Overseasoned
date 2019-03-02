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
    public bool hasPlate;
    private bool hasDish;
    // Start is called before the first frame update
    void Start()
    {
        radius = .64f;
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

        if (Physics.SphereCast(transform.position-new Vector3(0,2,0), radius, direction, out RaycastHit hitInfo, Mathf.Infinity,layerMask))
        {
            if (hitInfo.collider.CompareTag("Dish") && Input.GetKeyDown(KeyCode.E))
            {
                print("success");
//                hitInfo.collider.gameObject.GetComponent<Dish>().checkCurry();
//                completed = hitInfo.collider.gameObject.GetComponent<Dish>().hasAll;
//                hitInfo.collider.gameObject.GetComponent<Dish>().clear();
            }
        }
    }
}
