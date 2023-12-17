using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class TowerScript : MonoBehaviour
{
    [Header("Reference")]
    public Transform RotatePoint;
    public LayerMask enemyMask;
    public GameObject BulletPrefab;
    public Transform firingPoint;
    [Header("Attribute")]
    public float targetingRange = 5f;
    private Transform target;
    public float rotationspeed = 5f;
    public float bulletpersecond = 1f;
    public float baseUpgradeCost= 100;
    public float timeUntilFire;
    public int level =1;
    public int maxlevel =3;
    private float bpsBase;
    private float targetingRangeBase;
    void Start()
    {
        bpsBase = bulletpersecond;
        targetingRangeBase = targetingRange;
        TowerUI ui = GetComponent<TowerUI>();
        ui.maxlevel = maxlevel;
    }

    void Update()
    {
        if(target==null){FindTarget();return;}
        RotateTowardsTarget();
        if(!CheckTargetInRange()){target=null;}
        else
        {
            timeUntilFire += Time.deltaTime;
            if(timeUntilFire >= 1f/ bulletpersecond){ShootTheBullet();timeUntilFire = 0f;}
        }
    }
    void ShootTheBullet()
    {
       GameObject bullet = Instantiate(BulletPrefab,firingPoint.position,Quaternion.identity);
       BulletScript BulletScript = bullet.GetComponent<BulletScript>();
       BulletScript.SetTarget(target);
    }
    bool CheckTargetInRange()
    {
        return Vector2.Distance(target.position,transform.position) <= targetingRange;
    }
    void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y,target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f,angle - 90f));
        RotatePoint.rotation = Quaternion.RotateTowards(RotatePoint.rotation,targetRotation,rotationspeed*Time.deltaTime);
    }
    void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position,targetingRange,(Vector2)transform.position,0f,enemyMask);
        if(hits.Length > 0){target = hits[0].transform;}
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
        bulletpersecond = CalculateUpBps();
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
    private float CalculateUpBps()
    {
        return bpsBase* Mathf.Pow(level,0.5f);
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
