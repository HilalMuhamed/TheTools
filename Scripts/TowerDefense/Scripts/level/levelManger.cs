using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManger : MonoBehaviour
{
    public static levelManger main;
    public Transform startingpath,endingPath;
    public Transform[] path;

    public int Currency =100;

    private void Awake()
    {
        main = this;
    }
    void Start()
    {
    }
    public void IncreaseCurrency(int amount){Currency+=amount;}
    public bool SpendCurrency(int amount)
    {
        if(amount<=Currency)
        {
            Currency-=amount;
            return true;
        }
        else{Debug.Log("You dont have enought money");return false;}
    }
}
