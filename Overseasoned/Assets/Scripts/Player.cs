using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRigidbody;

    public GameObject pickedUpItem;

    public float Speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkObject();

        movement();
        //float movementModifierX = Input.GetAxisRaw("Horizontal");
        //float movementModifierZ = Input.GetAxisRaw("Vertical");


        //Vector3 newVelocity = playerRigidbody.velocity;
        //newVelocity.x = movementModifierX * Speed;
        //newVelocity.z = movementModifierZ * Speed;
        //playerRigidbody.velocity = newVelocity;
    }

    void movement()
    {
        if ( Input.GetKey( "up" ) )
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        if ( Input.GetKey( "down" ) )
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }

        if ( Input.GetKey ( "left" ) )
        {
            transform.Rotate(new Vector3(0, -50 * Speed * Time.deltaTime, 0));
        }

        if (Input.GetKey( "right" ))
        {
            transform.Rotate(new Vector3(0, 50 * Speed * Time.deltaTime, 0));
        }

    }

    void checkObject()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 rayCastPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        Debug.DrawRay(transform.position, fwd, Color.green);
        bool raycasthit = Physics.Raycast(rayCastPos, fwd, 50);
    }
}
