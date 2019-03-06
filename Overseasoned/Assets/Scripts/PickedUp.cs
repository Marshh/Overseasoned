using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUp : MonoBehaviour
{

    public int spiceLevel
    {
        get
        {
            spices = new Dictionary<string, int>
            {
                {"Bell Pepper", 1},
                {"Pepper", 1},
                {"Banana Pepper", 2},
                {"Chipotle", 2},
                {"Jalapeno", 3},
                {"Ghost Pepper", 3},
                {"Carolina Reaper", 4}
            };
            return spices[this.name];
        }
    }
    private Dictionary<string, int> spices;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
