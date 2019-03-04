using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject DishPrefab;
    public GameObject item;
    public float Speed;

    private Vector3 _itemLocalPosition = new Vector3(0, .25f, 1);

    int floorMask;



    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        Movement();
    }


    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            checkObject();
        }


    }

    void Movement()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos2 = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        mousePos.y = transform.position.y;

        transform.LookAt(mousePos, Vector3.up);



        if ((Mathf.Abs(playerPos.x - mousePos2.x) > 20) || (Mathf.Abs(playerPos.y - mousePos2.y) > 60))
        {
            //Debug.Log("IS MY CONDITIONAL A JOKE TO YOU, C SHARP");
            float movementModifierZ = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector3(0, 0, movementModifierZ) * Speed * Time.deltaTime);
        }

    }

    void checkObject()
    {

        Vector3 fwd = transform.TransformDirection(new Vector3(0, 0, 5));
        //Debug.DrawRay(transform.position + new Vector3(0, .5f, 0), fwd, Color.green);
        Debug.DrawRay(transform.position + new Vector3(0, -.25f, 0), fwd);
        RaycastHit hit;

        if (Physics.Raycast(transform.position + new Vector3(0, -.25f, 0), fwd, out hit, 2f))
        {
            if (hit.collider.CompareTag("DishStation"))
            {
                //Pick up plate
                item = hit.collider.gameObject.GetComponent<DishStation>().getDish(transform);
                item.transform.localPosition = _itemLocalPosition;

            }
            else if (hit.collider.CompareTag("PrepStation"))
            {
                //Place plate
                if (item != null && item.CompareTag("Dish"))
                {
                    hit.collider.gameObject.GetComponent<PrepStation>().PlaceDish(item);
                    item = null;
                }
                else if (item == null)
                {
                    item = hit.collider.gameObject.GetComponent<PrepStation>().PickUpDish(transform);
                    item.transform.localPosition = _itemLocalPosition;
                }
            }
            else if (hit.collider.CompareTag("MealStation"))
            {
                item = hit.collider.gameObject.GetComponent<MealSpawners>().getDish();
                item.GetComponent<Rigidbody>().detectCollisions = true;
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.SetParent(transform);
                item.transform.localPosition = new Vector3(0, .25f, 1);
            }
            else if (hit.collider.CompareTag("SpiceStation"))
            {
                item = hit.collider.gameObject.GetComponent<SpiceStation>().getSpice(this.transform);
                item.transform.localPosition = _itemLocalPosition;
            }
        }
    }

  
}
