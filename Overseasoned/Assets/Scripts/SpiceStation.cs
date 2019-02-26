using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiceStation : MonoBehaviour
{
    public GameObject Spice;

    private GameObject _spiceInstance;

    public float SpawnTimer;

    private float _countDown;
    // Start is called before the first frame update
    void Start()
    {
        spawnSpice();
    }

    // Update is called once per frame
    void Update()
    {

        if (_spiceInstance == null)
        {
            _countDown -= Time.deltaTime;
            if (_countDown < 0)
            {
                spawnSpice();
            }
        }

    }

    void spawnSpice()
    {
        _countDown = SpawnTimer;
        Vector3 unitAbove = this.transform.position + Vector3.up;

        _spiceInstance = Instantiate(Spice, unitAbove, Quaternion.identity);
    }
}
