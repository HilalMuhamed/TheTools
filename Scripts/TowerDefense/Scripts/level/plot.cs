using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plot : MonoBehaviour
{
    [Header("Refrences")]
    public SpriteRenderer sr;
    public Color hoverColor;
    private GameObject tower;
    public TowerUI towerui;
    private Color startColor;
    private GameObject ShootingRadius;
    public float scaleFactor = 1.1f;
    private Vector3 originalScale;

    void Start()
    {
        startColor = sr.color;
        originalScale = transform.localScale;
    }
    void OnMouseEnter()
    {
        transform.localScale = originalScale * scaleFactor;
        sr.color = hoverColor;
    }
    void OnMouseExit()
    {
        sr.color = startColor;
        transform.localScale = originalScale;
        if(tower!=null)
        {TowerUI tw = tower.GetComponent<TowerUI>();
        tw.ShootingRadius.SetActive(false);}
    }
    void OnMouseDown()
    {
        if(UIManager.main.IsHoveringUI()){return;}
        if(tower!=null)
        {
            TowerUI tw = tower.GetComponent<TowerUI>();
            tw.ShootingRadius.SetActive(true);
            if(tw.level < tw.maxlevel)
            {towerui.OpenUpgradeUi();}
            else{towerui.OpenOnlySellUi();Debug.Log("MaxLevel");}
            return;
        }
        Tower towerToBuild = buildManager.main.ReturnTower();
        if(towerToBuild.cost>levelManger.main.Currency)
        {
            Debug.Log("You cant afford this tower ");
            return;
        }
        levelManger.main.SpendCurrency(towerToBuild.cost);
        tower = Instantiate(towerToBuild.towerPrefab,transform.position,Quaternion.identity);
        towerui = tower.GetComponent<TowerUI>();
    }

}
