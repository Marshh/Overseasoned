using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject DishPrefab;
    public GameObject item;
    public AudioSource audioSource;
    public AudioClip seasoning;
    public AudioClip food;
    public static Player instance;
    public float Speed;

    private Vector3 _itemLocalPosition = new Vector3(0, .25f, 1);

    int floorMask;

    public Image LoadingBar;
    public TextMeshProUGUI AlertText;

    private float _alerttexttimer;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            LoadingBar.fillAmount = 0;
            if (item != null)
            {
                DisplayAlertText("");
            }
        }
        Interaction();
        
        ClearAlertText();
        Movement();
    }

    void FixedUpdate()
    {
       
    }


    void Movement()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
            {
                //Up and Right, rotation = 225
                this.transform.localEulerAngles = new Vector3(0, 225, 0);
            }
            else if(Input.GetKey(KeyCode.D))
            {
                this.transform.localEulerAngles = new Vector3(0, 135, 0);
            }
            else
            {
                //Up, rotation = 180
                this.transform.localEulerAngles = new Vector3(0, 180, 0);
            }
            transform.position += transform.forward * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.S))
            {
                //Up and Right, rotation = 225
                this.transform.localEulerAngles = new Vector3(0, 225, 0);
            }
            else if(Input.GetKey(KeyCode.W))
            {
                this.transform.localEulerAngles = new Vector3(0, 315, 0);
            }
            else
            {
                //Right, rotation = 270
                this.transform.localEulerAngles = new Vector3(0, 270, 0);
            }
            transform.position += transform.forward * Time.deltaTime * Speed;
        }
        else if(Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.A))
            {
                this.transform.localEulerAngles = new Vector3(0, 315, 0);
            }
            else if(Input.GetKey(KeyCode.D))
            {
                this.transform.localEulerAngles = new Vector3(0, 45, 0);
            }
            else
            {
                this.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            transform.position += transform.forward * Time.deltaTime * Speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.S))
            {
                this.transform.localEulerAngles = new Vector3(0, 135, 0);
            }
            else if(Input.GetKey(KeyCode.W))
            {
                this.transform.localEulerAngles = new Vector3(0, 45, 0);
            }
            else
            {
                this.transform.localEulerAngles = new Vector3(0, 90, 0);
            }
            transform.position += transform.forward * Time.deltaTime * Speed;
        }
                
        //else if(Input.GetKey(KeyCode.S))
        //{
        //    //Down, rotation = 0
        //    this.transform.localEulerAngles = new Vector3(0, 0, 0);
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    //Left, rotation = 90
        //    this.transform.localEulerAngles = new Vector3(0, 90, 0);
        //}

        //else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        //{
        //    //Up and Right, rotation = 225
        //    this.transform.localEulerAngles = new Vector3(0, 225, 0);
        //}
        //else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        //{
        //    //Up and Left, rotation = 135
        //    this.transform.localEulerAngles = new Vector3(0, 135, 0);
        //}
        //else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        //{
        //    //Down and Right, rotation = 315
        //    this.transform.localEulerAngles = new Vector3(0, 315, 0);
        //}
        //else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        //{
        //    //Down and Left, rotation = 45
        //    this.transform.localEulerAngles = new Vector3(0, 45, 0);
        //}
    }

    //void Movement()
    //{
    //    Vector3 mousePos = Input.mousePosition;
    //    Vector3 mousePos2 = Input.mousePosition;
    //    Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);

    //    mousePos.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
    //    mousePos = Camera.main.ScreenToWorldPoint(mousePos);

    //    mousePos.y = transform.position.y;

    //    transform.LookAt(mousePos, Vector3.up);



    //    if ((Mathf.Abs(playerPos.x - mousePos2.x) > 20) || (Mathf.Abs(playerPos.y - mousePos2.y) > 60))
    //    {
    //        //Debug.Log("IS MY CONDITIONAL A JOKE TO YOU, C SHARP");
    //        float movementModifierZ = Input.GetAxisRaw("Vertical");
    //        //            transform.Translate();
    //        //transform.Translate(new Vector3(0, 0, movementModifierZ) * Speed * Time.deltaTime);
    //        Vector3 movement = transform.TransformDirection(new Vector3(0, 0, movementModifierZ) * Speed * Time.deltaTime);
    //        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position+ movement);

    //    }


    //}


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
                if (item != null && Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject.GetComponent<PrepStation>().isOccupied == true)
                {
                    if (item.CompareTag("Spice"))
                    {
                        audioSource.clip = seasoning;
                        audioSource.Play();
                    }
                    if (item.CompareTag("Skillet"))
                    {
                        audioSource.clip = food;
                        audioSource.Play();
                    }
                }
                if (Input.GetKeyDown(KeyCode.E) && item != null && item.CompareTag("Dish") && hit.collider.gameObject.GetComponent<PrepStation>().isOccupied == false)
                {
                    hit.collider.gameObject.GetComponent<PrepStation>().PlaceDish(item);
                    item = null;
                    DishesContents.instance.CreateDish();
                }
                else if (item != null && item.CompareTag("Spice") && Input.GetKey(KeyCode.E) && hit.collider.gameObject.GetComponent<PrepStation>().isOccupied == true)
                {
                    if (LoadingBar.fillAmount < 1.0f)
                    {
                        DisplayAlertText($"Adding {item.name}");
                        LoadingBar.fillAmount += 0.025f;
                    }
                    else if (LoadingBar.fillAmount >= 1.0f)
                    {
                        audioSource.Pause();
                        int spiceLevel = item.gameObject.GetComponent<PickedUp>().spiceLevel;
                        LoadingBar.fillAmount = 0;
                        hit.collider.gameObject.GetComponent<PrepStation>().AddSpice(item.name, spiceLevel);
                        DishesContents.instance.ChangeSpiceLevel(spiceLevel);
                        Destroy(item);
                        DisplayAlertText($"Added {item.name}");
                    }

                }
                else if (item != null && item.CompareTag("Skillet") && Input.GetKey(KeyCode.E) && hit.collider.gameObject.GetComponent<PrepStation>().isOccupied == true)
                {
                    if (LoadingBar.fillAmount < 1.0f)
                    {
                        DisplayAlertText($"Adding {item.name}");
                        LoadingBar.fillAmount += 0.025f;
                    }
                    else if (LoadingBar.fillAmount >= 1.0f)
                    {
                        audioSource.Pause();
                        LoadingBar.fillAmount = 0;
                        hit.collider.gameObject.GetComponent<PrepStation>().AddIngredient(item.name);
                        DishesContents.instance.ChangeFood(item.name);
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
                item.GetComponent<MeshCollider>().isTrigger = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("Trash") && item != null)
            {
                hit.collider.gameObject.GetComponent<Trash>().deleteDish(item);
                DisplayAlertText($"Cleared Dish");
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
