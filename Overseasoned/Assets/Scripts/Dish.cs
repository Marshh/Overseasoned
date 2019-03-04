using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public int Spiciness;
//  public bool hasAll = false;
    public List<string> ingredients;
    // Start is called before the first frame update
    void awake()
    {
        Spiciness = 0;
        ingredients = new List<string> { };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addIngredient(string ingredient)
    {
        ingredients.Add(ingredient);
    }

    int spicinessCheck()
    {
        return Spiciness;
    }

    public void clear()
    {
//        hasAll = false;
        ingredients.Clear();
    }
//    public void checkCurry()
//    {
//        List<string> curryIngredients = new List<string> {"Rice", "Curry"};
//        //        hasAll = true;
//        //        for (int i = 0; i < curryIngredients.Count; ++i)
//        //        {
//        //            bool found = false;
//        //            for(int j = 0; j < ingredients.Count; ++j)
//        //            {
//        //                if (curryIngredients[i] == ingredients[j])
//        //                {
//        //                    found = true;
//        //                }
//        //            }
//        //
//        //            if( !found )
//        //            {
//        //                hasAll = false;
//        //            }
//        //
//        //        }
//        if (curryIngredients.OrderBy(x => x).SequenceEqual(ingredients.OrderBy(x => x)))
//        {
//            hasAll = true;
//
//        }
//        
//
//    }
}
