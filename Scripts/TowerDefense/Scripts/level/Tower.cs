using System;
using UnityEngine;

[Serializable]
public class Tower
{
    public string name;
    public int cost;
    public GameObject towerPrefab;
    public Tower(string _name,int _cost,GameObject _towerPrefab)
    {
        name = _name;
        cost = _cost;
        towerPrefab = _towerPrefab;
    }
}
