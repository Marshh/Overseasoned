using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DishesContents : MonoBehaviour
{
    public TextMeshProUGUI DishText;
    public string food;
    public int spiceLevel;
    public static DishesContents instance;
    // Start is called before the first frame update
    void Start()
    {
        spiceLevel = 0;
        DisplayText($"   No plate at the \n   Prepstation.");
    }

    // Update is called once per frame
    void Update()
    {
        instance = this;
        if (PrepStation.instance.dish == null && Player.instance.item == null)
        {

            DisplayText($"   No plate at the \n   Prepstation.");
        }
        else if(PrepStation.instance.dish == null && Player.instance.item != null)
        {
            if (Player.instance.item.CompareTag("Dish") == false)
            {
                DisplayText($"   No plate at the \n   Prepstation.");
            }
        }
    }

    void DisplayText(string message)
    {
        DishText.text = message;
    }

    public void ChangeFood(string newFood)
    {
        food = newFood;
        DisplayText($"  Dish Contents\n  Food: {food}\n  Spiciness: {spiceLevel}");
    }

    public void ChangeSpiceLevel(int newSpiceLevel)
    {
        spiceLevel += newSpiceLevel;
        DisplayText($"  Dish Contents\n  Food: {food}\n  Spiciness: {spiceLevel}");
    }

    public void CreateDish()
    {
        DisplayText($"  Dish Contents\n  Food: \n  Spiciness: ");
    }

    public void ClearDish()
    {
        spiceLevel = 0;
        DisplayText($"   No plate at the \n   Prepstation.");
    }
}
