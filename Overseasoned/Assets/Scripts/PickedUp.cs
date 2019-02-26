using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUp : MonoBehaviour
{
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
       rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPickup(Collider o)
    {
        rend.enabled = false;
    }
}
