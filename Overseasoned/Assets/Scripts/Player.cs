using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRigidbody;

    public float Speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkObject();

        Movement();
    }

    void Movement()
    {
        float movementModifierZ = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(0,0, movementModifierZ) * Speed * Time.deltaTime);


        float movementModifierX = Input.GetAxisRaw("Horizontal");
        transform.Rotate(new Vector3(0, movementModifierX *50 * Speed * Time.deltaTime, 0));
        

    }

    void checkObject()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 rayCastPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        Debug.DrawRay(transform.position, fwd, Color.green);
        bool raycasthit = Physics.Raycast(rayCastPos, fwd, 50);


    }
}
