using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Menu : MonoBehaviour
{

    [Header("Reference")]
    public TextMeshProUGUI currencyUI;
    public TextMeshProUGUI EnemyAliveUI;
    public Animator anim;
    public bool isMenuOpen= true;
    public EnemySpawner es;

    void Start(){anim=GetComponent<Animator>();}
    void Update(){EnemyAliveUI.text = es.enemiesalive.ToString();}

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuOpen",isMenuOpen);
    }
    private void OnGUI()
    {
        currencyUI.text = levelManger.main.Currency.ToString();
    }
    public void SetSeleceted(){}
}
