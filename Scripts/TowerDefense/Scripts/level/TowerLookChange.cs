using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLookChange : MonoBehaviour
{
    public SpriteRenderer spriteRendererToHide;
    public SpriteRenderer spriteRendererToShow; 

    private void Start()
    {
        spriteRendererToHide.enabled = true;
        spriteRendererToShow.enabled = false;
    }

    private void OnMouseDown()
    {
        spriteRendererToHide.enabled = false;
        spriteRendererToShow.enabled = true;
    }
}
