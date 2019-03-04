using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUp : MonoBehaviour
{
    public int spiceLevel;
    private Dictionary<string, int> spices;
    // Start is called before the first frame update
    void Start()
    {
        spices = new Dictionary<string, int>
        {
            {"Salt", 1},
            {"Paprika", 1},
            {"Garlic", 2},
            {"Black Pepper", 2},
            {"Chipotle", 3},
            {"Chili Flakes", 3},
            {"Ghost Pepper", 4}
        };
        spiceLevel = spices[this.name];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
