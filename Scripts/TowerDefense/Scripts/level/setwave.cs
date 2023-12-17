using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class setwave : MonoBehaviour
{
    public TextMeshProUGUI currentwave;
    public GameObject Enemyspwn;
    void Update()
    {
        currentwave.text = Enemyspwn.GetComponent<EnemySpawner>().currentwave.ToString();
    }
}
