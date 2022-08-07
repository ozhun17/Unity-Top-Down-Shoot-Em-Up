using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Town))]

public class TownProduction : MonoBehaviour
{
    // Start is called before the first frame update
    private Town Town;
    private int ProductionType;
    private IEnumerator prodRoutine;
    private void Awake()
    {
        Town = GetComponent<Town>();
        ProductionType = Town.TownType;
    }

    private void Start()
    {
        prodRoutine = ProductionRoutine(1f);
        StartCoroutine(prodRoutine);
    }

    IEnumerator ProductionRoutine(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Produce();
        }
        
    }
    private void Produce()
    {
        switch (ProductionType)
        {
            case 0:
                ProduceFood();
                break;
            case 1:
                ProduceOre();
                break;
        }
        Debug.Log(Town.FoodValue.ToString());
    }



    private void ProduceFood()
    {
        Town.FoodValue++;
    }

    private void ProduceOre()
    {
        Town.OreValue++;
    }

}
