using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject LevelManager=GameObject.Find("LevelManager");
        float score = LevelManager.GetComponent<ScoreManager>().score;
        ScoreText.text = $"Score: {Mathf.FloorToInt(score)}";
        Destroy(LevelManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
