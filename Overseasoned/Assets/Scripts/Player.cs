using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject DishPrefab;
    public GameObject item;
    public float Speed;

    private Vector3 _itemLocalPosition = new Vector3(0, .25f, 1);

    int floorMask;

    public Image LoadingBar;
    public TextMeshProUGUI AlertText;

    private float _alerttexttimer;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            LoadingBar.fillAmount = 0;
        }
        Interaction();
        
        ClearAlertText();
    }

    void FixedUpdate()
    {
        Movement();
    }


  
    void Movement()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos2 = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        mousePos.y = transform.position.y;

        transform.LookAt(mousePos, Vector3.up);



        if ((Mathf.Abs(playerPos.x - mousePos2.x) > 20) || (Mathf.Abs(playerPos.y - mousePos2.y) > 60))
        {
            //Debug.Log("IS MY CONDITIONAL A JOKE TO YOU, C SHARP");
            float movementModifierZ = Input.GetAxisRaw("Vertical");
            //            transform.Translate();
            //transform.Translate(new Vector3(0, 0, movementModifierZ) * Speed * Time.deltaTime);
            Vector3 movement = transform.TransformDirection(new Vector3(0, 0, movementModifierZ) * Speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position+ movement);

        }


    }


    void Interaction()
    {

        Vector3 fwd = transform.TransformDirection(new Vector3(0, 0, 5));
        //Debug.DrawRay(transform.position + new Vector3(0, .5f, 0), fwd, Color.green);
        Debug.DrawRay(transform.position + new Vector3(0, -.50f, 0), fwd);
        RaycastHit hit;

        if (Physics.Raycast(transform.position + new Vector3(0, -.50f, 0), fwd, out hit, 2f))
        {
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("DishStation") && item == null)
            {
                //Pick up plate
                item = hit.collider.gameObject.GetComponent<DishStation>().getDish(transform);
                item.transform.localPosition = _itemLocalPosition;
                item.GetComponent<MeshCollider>().isTrigger = true;

            }
            else if (hit.collider.CompareTag("PrepStation"))
            {
                //Place plate
                if (Input.GetKeyDown(KeyCode.E) && item != null && item.CompareTag("Dish"))
                {
                    hit.collider.gameObject.GetComponent<PrepStation>().PlaceDish(item);
                    item = null;
                }
                else if (item != null && item.CompareTag("Spice") && Input.GetKey(KeyCode.E) && hit.collider.gameObject.GetComponent<PrepStation>().isOccupied == true)
                {
                    if (LoadingBar.fillAmount < 1.0f)
                    {
                        LoadingBar.fillAmount += 0.025f;
                    }

                    else if (LoadingBar.fillAmount >= 1.0f)
                    {
                        int spiceLevel = item.gameObject.GetComponent<PickedUp>().spiceLevel;
                        LoadingBar.fillAmount = 0;
                        hit.collider.gameObject.GetComponent<PrepStation>().AddIngredient(item.name);
                        hit.collider.gameObject.GetComponent<PrepStation>().AddSpice(item.name, spiceLevel);
                        Destroy(item);
                        DisplayAlertText($"Added {item.name}");
                    }

                }
                else if (item != null && item.CompareTag("Skillet") && Input.GetKey(KeyCode.E) && hit.collider.gameObject.GetComponent<PrepStation>().isOccupied == true)
                {
                    if (LoadingBar.fillAmount < 1.0f)
                    {
                        LoadingBar.fillAmount += 0.025f;
                    }

                    else if (LoadingBar.fillAmount >= 1.0f)
                    {
                        LoadingBar.fillAmount = 0;
                        hit.collider.gameObject.GetComponent<PrepStation>().AddIngredient(item.name);
                        Destroy(item);
                        DisplayAlertText($"Added {item.name}");
                    }

                }
                else if (Input.GetKeyDown(KeyCode.E) && item == null)
                {
                    item = hit.collider.gameObject.GetComponent<PrepStation>().PickUpDish(transform);
                    item.transform.localPosition = _itemLocalPosition;
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("SpiceStation") && item == null)
            {
                item = hit.collider.gameObject.GetComponent<SpiceStation>().getSpice(this.transform);
                item.transform.localPosition = _itemLocalPosition;
            }

            else if (Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("MealStation") && item == null)
            {
                item = hit.collider.gameObject.GetComponent<MealSpawners>().getSkillet(transform);
                item.transform.localPosition = _itemLocalPosition;
            }
            else if (Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("Trash") && item != null)
            {
                hit.collider.gameObject.GetComponent<Trash>().deleteDish(item);
            }
        }
    }


    void DisplayAlertText(string message)
    {
        
        _alerttexttimer = 4f;
        AlertText.text = message;

    }

    void ClearAlertText()
    {

        if (_alerttexttimer <= 0)
        {
            AlertText.text = "";
        }else if (AlertText.text != "")
        {
            _alerttexttimer -= Time.deltaTime;
        }
    }
  
}
