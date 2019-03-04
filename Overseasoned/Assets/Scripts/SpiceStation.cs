using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpiceStation : MonoBehaviour
{
    public GameObject Spice;
    private GameObject _spiceInstance;
    public float SpawnTimer;
    private float _countDown;
    public TextMeshProUGUI TipText;

    // Start is called before the first frame update
    void Start()
    {
        spawnSpice();
        TipText.text = $"{Spice.name}\nStation";

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
        //Remove (clone)
        _spiceInstance.name = Spice.name;
    }

    public GameObject getSpice(Transform player)
    {
        _spiceInstance.GetComponent<Rigidbody>().detectCollisions = true;
        _spiceInstance.GetComponent<Rigidbody>().useGravity = false;
        _spiceInstance.GetComponent<Rigidbody>().isKinematic = true;
        _spiceInstance.transform.SetParent(player);
        GameObject item = _spiceInstance;
        _spiceInstance = null;
        return item;
    }
}
