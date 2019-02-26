using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltStation : MonoBehaviour
{
    public GameObject Salt;
    // Start is called before the first frame update
    void Start()
    {
        spawnSalt();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnSalt()
    {
        Vector3 unitAbove = this.transform.position + Vector3.up;

        Instantiate(Salt, unitAbove, Quaternion.identity);
    }
}
