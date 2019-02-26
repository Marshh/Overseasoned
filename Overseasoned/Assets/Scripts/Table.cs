using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private Vector3 sphereCastPos;
    public Vector3 direction;
    public float radius;
    public bool occupied;
    // Start is called before the first frame update
    void Start()
    {
        radius = .25f;
        sphereCastPos = this.transform.position;
        direction = transform.TransformDirection(new Vector3(-1f, 0, 0));
        occupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkOccupation();
    }

    void checkOccupation()
    {
        if (Physics.SphereCast(sphereCastPos, radius, direction, out RaycastHit hitInfo, 3f))
        {
            Debug.Log("hello");
            if (hitInfo.collider.CompareTag("Customer"))
            {
                Debug.Log("Customer");
                occupied = true;
            }
            else
            {
                occupied = false;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(sphereCastPos, radius);
    }
}
