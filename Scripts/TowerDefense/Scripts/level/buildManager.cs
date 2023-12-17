using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildManager : MonoBehaviour
{
    public static buildManager main;
    [Header("References")]
    public Tower[] towers;
    private int SelectedTower = 0;
    public void Awake(){main=this;}
    public Tower ReturnTower(){return towers[SelectedTower];}
    public void SetSelectedTower(int _selectedTower){SelectedTower=_selectedTower;}
}
