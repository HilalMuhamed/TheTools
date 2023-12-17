using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SlowMoTower : MonoBehaviour
{
    [Header("Reference")]

    public LayerMask enemyMask;

    [Header("Attribute")]
    public float targetingRange = 5f;
    public float attackPerSecond= 2f;
    public float timeUntilFire;

    public float freezingSpeed = 0.5f;
    public float freezeTime = 4f;

    public int level =1;
    public int maxlevel =3;

    private float atpsBase;
    private float targetingRangeBase;

    public float baseUpgradeCost = 200;
    public GameObject freezeParticle;
    public Color freezeColor;
    void Start()
    {
        atpsBase = attackPerSecond;
        targetingRangeBase = targetingRange;
        TowerUI ui = GetComponent<TowerUI>();
        ui.maxlevel = maxlevel;
    }

    void Update()
    {
            timeUntilFire += Time.deltaTime;
            if(timeUntilFire >= 1f/ attackPerSecond){FreezeEnemy();timeUntilFire = 0f;}
    }
    void FreezeEnemy()
    {
       RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position,targetingRange,(Vector2)transform.position,0f,enemyMask);
       if(hits.Length > 0){for(int i=0;i<hits.Length;i++)
       {
        RaycastHit2D hit = hits[i];
        enemyMovement em = hit.transform.GetComponent<enemyMovement>();
        SpriteRenderer esr = hit.transform.GetComponent<SpriteRenderer>();
        Instantiate(freezeParticle,transform.position,Quaternion.identity);
        em.UpdateSpeed(freezingSpeed);
        Color baseColor = esr.color;
        esr.color=freezeColor;
        StartCoroutine(ResetEnemySpeed(em,esr,baseColor));
       }}
    }
    private IEnumerator ResetEnemySpeed(enemyMovement em,SpriteRenderer esr,Color baseColor)
    {
        yield return new WaitForSeconds(freezeTime);
        em.ResetSpeed();
        esr.color=baseColor;
    }
    void OnDrawGizmosSelected()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position,transform.forward,targetingRange);    
    }
    public void Upgrade()
    {
        if(CalculateUpCost() > levelManger.main.Currency){Debug.Log("Not enough Currency");return;}
        levelManger.main.SpendCurrency(CalculateUpCost());
        level++;
        attackPerSecond = CalculateUpAtps();
        targetingRange =CalculateRange();
        TowerUI ui = GetComponent<TowerUI>();
        ui.level = level;
        Vector3 newScale = new Vector3(targetingRange*2,targetingRange*2,targetingRange*2);
        ui.ShootingRadius.transform.localScale = newScale;
        ui.CloseUpgradeUi();
    }
    public int CalculateUpCost()
    {
        return Mathf.RoundToInt(baseUpgradeCost * Mathf.Pow(level,0.5f));
    }
    private float CalculateUpAtps()
    {
        return atpsBase* Mathf.Pow(level,0.5f);
    }
    private float CalculateRange()
    {
        return targetingRangeBase*Mathf.Pow(level,0.2f);
    }
    public void Sell()
    {
        levelManger.main.IncreaseCurrency(CalculateUpCost()/2);
        UIManager.main.SetHoveringState(false);
        Destroy(gameObject);
    }
}
