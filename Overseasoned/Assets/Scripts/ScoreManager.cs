using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class ScoreManager : MonoBehaviour
{
    

    public float score = 0;

    public GameObject Tables;

    public float time;

    public TextMeshProUGUI ScoreText;

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
        time -= Time.deltaTime;
        if (time < 0)
        {
            
            
        }
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        ScoreText.text = $"Time: {min}:{sec:D2}\nScore: {Mathf.FloorToInt(score)}";
    }

    void IncreaseScore(float add)
    {
        score += add;
        print(score);

    }
}
