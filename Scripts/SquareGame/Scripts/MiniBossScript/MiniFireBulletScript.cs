using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniFireBulletScript : MonoBehaviour
{
    //public Transform transfrom;
    [SerializeField]
    private int bulletsAmount = 10;
    [SerializeField]
    private float starAngle = 90f , endAngle =270f;
    
    private Vector2 bulletMoveDirection;
    void Start()
    {
        InvokeRepeating("Fire",0f,6f);
    }
    private void Fire()
    {
        FindObjectOfType<AudioManager>().Play("BossSound");
        float angelStep =(endAngle -starAngle)/ bulletsAmount;
        float  angle = starAngle;
        for(int i=0;i<bulletsAmount+1;i++){
        float bulDirX = transform.position.x + Mathf.Sin((angle*Mathf.PI)/180f);
        float bulDirY = transform.position.y + Mathf.Cos((angle*Mathf.PI)/180f);
        Vector3 bulMoveVector = new Vector3(bulDirX,bulDirY,0f);
        Vector2 bulDir =(bulMoveVector - transform.position).normalized;

        GameObject bul = MiniBulletpool.MinibulletPoolInstanse.GetBullet();
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<MiniBossBulletScript>().SetMoveDirection(bulDir);

        angle += angelStep;
    }
}
}

