using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TowerUI : MonoBehaviour
{
    public GameObject upgradeUI;
    public Button upgradeButton;
    public Button SellButton;
    public int towerNo ;
    public int level=1,maxlevel=3;
    public TMP_Text UpgradeText,SellText;
    public GameObject ShootingRadius;

    void Awake()
    {
        if(towerNo==1)
        {
            TowerScript tower = GetComponent<TowerScript>();
            upgradeButton.onClick.AddListener(tower.Upgrade);
            SellButton.onClick.AddListener(tower.Sell);
            Vector3 newScale = new Vector3(tower.targetingRange*2,tower.targetingRange*2,tower.targetingRange*2);
            ShootingRadius.transform.localScale = newScale;

        }
        else if(towerNo==2)
        {
            SlowMoTower tower = GetComponent<SlowMoTower>();
            upgradeButton.onClick.AddListener(tower.Upgrade);
            SellButton.onClick.AddListener(tower.Sell);   
        }

    }

     public void OpenUpgradeUi()
     {
        upgradeUI.SetActive(true);
        if(towerNo==1)
        {
            TowerScript tower = GetComponent<TowerScript>();
            UpgradeText.text = "Upgrade " + tower.CalculateUpCost().ToString();
            SellText.text = "Sell " + (tower.CalculateUpCost()/2).ToString();
        }
        else if(towerNo==2)
        {
            SlowMoTower tower = GetComponent<SlowMoTower>();
            UpgradeText.text = "Upgrade " + tower.CalculateUpCost().ToString();
            SellText.text = "Sell " + (tower.CalculateUpCost()/2).ToString();
        }
     }
     public void OpenOnlySellUi()
     {
        upgradeUI.SetActive(true);
        upgradeButton.gameObject.SetActive(false);
        if(towerNo==1)
        {
            TowerScript tower = GetComponent<TowerScript>();
            UpgradeText.text = "Upgrade " + tower.CalculateUpCost().ToString();
            SellText.text = "Sell " + (tower.CalculateUpCost()/2).ToString();
        }
        else if(towerNo==2)
        {
            SlowMoTower tower = GetComponent<SlowMoTower>();
            UpgradeText.text = "Upgrade " + tower.CalculateUpCost().ToString();
            SellText.text = "Sell " + (tower.CalculateUpCost()/2).ToString();
        }
     }
     public void CloseUpgradeUi()
     {
        upgradeUI.SetActive(false);
        UIManager.main.SetHoveringState(false);
    }
}
