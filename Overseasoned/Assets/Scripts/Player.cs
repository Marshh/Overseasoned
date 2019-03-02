using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject DishPrefab;
    public GameObject dish;
    public float Speed;

    int floorMask;

    
    
    // Start is called before the first frame update
    void Start()
    {
//        IniDish();
    }

   
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            checkObject();
        }
        Movement();

    }

    void Movement()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        mousePos.y = transform.position.y;

        transform.LookAt(mousePos, Vector3.up);


        float movementModifierZ = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(0,0, movementModifierZ) * Speed * Time.deltaTime);
        
    }

    void checkObject()
    {

       

        //Ignore dish infront of player
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        Vector3 fwd = transform.TransformDirection(new Vector3(0, 0, 5));
        //Debug.DrawRay(transform.position + new Vector3(0, .5f, 0), fwd, Color.green);
        Debug.DrawRay(transform.position + new Vector3(0, -.25f, 0),fwd);
        //The sphere can't spawn on the item collider. It won't detect it.
        float thickness = .30f;
        RaycastHit hit;
        if (Physics.SphereCast(transform.position+ new Vector3(0, .5f, 0), thickness, fwd, out hit,2f,layerMask))
        {
            if (hit.collider.CompareTag("Spice"))
            {
                //                Debug.Logwwssd("Salty");
                //                hit.collider.gameObject.SendMessage("OnPickup", hit.collider);
                print(hit.collider.gameObject.name);
                dish.GetComponent<Dish>().addIngredient(hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
            else 
            //            Debug.Log(hit.distance);
            print(hit.distance);
        }

        if (Physics.Raycast(transform.position + new Vector3(0, -.25f, 0), fwd, out hit, 2f))
        {
            if (hit.collider.CompareTag("Station"))
            {
                //Pick up plate
                dish = hit.collider.gameObject.GetComponent<DishStation>().getDish();
                dish.GetComponent<Rigidbody>().detectCollisions = true;
                dish.GetComponent<Rigidbody>().useGravity = false;
                dish.GetComponent<Rigidbody>().isKinematic = true;
                dish.transform.SetParent(transform);
                dish.transform.localPosition = new Vector3(0, .25f, 1);
                
            }
            else if (hit.collider.CompareTag("PrepStation"))
            {
                //Place plate
                if (dish != null)
                {
                    hit.collider.gameObject.GetComponent<PrepStation>().PlaceDish(dish);
                    dish = null;
                }
                else
                {
                    dish=hit.collider.gameObject.GetComponent<PrepStation>().dish;
                    hit.collider.gameObject.GetComponent<PrepStation>().dish = null;
                    dish.transform.SetParent(transform);
                    dish.transform.localPosition = new Vector3(0, .25f, 1);
                }
            }
        }
    }

    void IniDish()
    {
        dish = Instantiate(DishPrefab, transform);
        dish.transform.localPosition = new Vector3(0, 0, 1);
    }
}
