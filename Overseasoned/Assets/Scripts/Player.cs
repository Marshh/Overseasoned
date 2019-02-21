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
        float movementModifierX = Input.GetAxisRaw("Horizontal");
        float movementModifierZ = Input.GetAxisRaw("Vertical");
        Vector3 newVelocity = playerRigidbody.velocity;
        newVelocity.x = movementModifierX * Speed;
        newVelocity.z = movementModifierZ * Speed;
        playerRigidbody.velocity = newVelocity;
    }
}
