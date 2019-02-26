using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRigidbody;

    public GameObject pickedUpItem;

    public float Speed;

    private GameObject inHandGameObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
        float movementModifierZ = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(0,0, movementModifierZ) * Speed * Time.deltaTime);


        float movementModifierX = Input.GetAxisRaw("Horizontal");
        transform.Rotate(new Vector3(0, movementModifierX *25 * Speed * Time.deltaTime, 0));
        

    }

    void checkObject()
    {

        // Vector3 fwd = transform.TransformDirection(Vector3.forward);
        // Vector3 rayCastPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        // Debug.DrawRay(transform.position, fwd, Color.green);
        // bool raycasthit = Physics.Raycast(rayCastPos, fwd, 50);


              Vector3 rayCastPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
         
        //       Ray ray = new Ray(transform.position+new Vector3(0,.25f,0), fwd);
        Vector3 fwd = transform.TransformDirection(new Vector3(0, 0, 5));
        Debug.DrawRay(transform.position + new Vector3(0, .5f, 0), fwd, Color.green);
        //The sphere can't spawn on the item collider. It won't detect it.
        float thickness = .30f;
        if(Physics.SphereCast(transform.position+ new Vector3(0, .5f, 0), thickness, fwd, out RaycastHit hit,2f))
        {
            if (hit.collider.CompareTag("Salt"))
            {
                Debug.Log("Salty");
                hit.collider.gameObject.SendMessage("OnPickup", hit.collider);
            }
//            Debug.Log(hit.distance);
        }
    }
}
