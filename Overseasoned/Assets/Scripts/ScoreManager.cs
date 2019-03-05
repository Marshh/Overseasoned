using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ScoreManager : MonoBehaviour
{
    

    public float score = 0;

    public GameObject Tables;

    public static ScoreManager instance;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform table in Tables.transform)
        {
            if (table.name != "Tables")
            {
                Table tableComponent= table.gameObject.GetComponent<Table>();
                tableComponent.OnScoreEvent.AddListener(IncreaseScore);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncreaseScore(float add)
    {
        score += add;
        print($"ADDED SCORE: {add}");

    }
}
