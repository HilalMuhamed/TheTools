using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GridManager : MonoBehaviour
{
    public int width,height;
    public Tiles[] tiles;
    public Transform cam;
    private Tiles tile;
    public Color newColor;
    private int n =1;
    public TextMeshProUGUI targetTextMeshPro1,t2,t3,t4,t5,t6,t7,t8,t9;
    void Start()
    {
        int rand = Random.Range(0,tiles.Length);
        tile = tiles[rand];
        GenerateGrid();

    }
    void GenerateGrid()
    {
        for(int x = 0 ; x < width ; x++)
        {
            for(int y = 0 ; y < height ; y++)
            {
                var spawnTile = Instantiate(tile,new Vector3(x,y),Quaternion.identity);
                spawnTile.name = $"Tile{x}{y}";
                var isOffset = ( (x+y)%2 == 1 );
                spawnTile.Init(isOffset);
                if(n==1)
                {
                    newColor = spawnTile.returnColor(); n =0;
                    if (targetTextMeshPro1 != null)
                    {
                    targetTextMeshPro1.color = newColor;
                    }
                    if(t2 != null){t2.color = newColor;}
                    if(t3 != null){t3.color = newColor;}
                    if(t4 != null){t4.color = newColor;}
                    if(t5 != null){t5.color = newColor;}
                    if(t6 != null){t6.color = newColor;}
                    if(t7 != null){t7.color = newColor;}
                    if(t8 != null){t8.color = newColor;}
                    if(t9 != null){t9.color = newColor;}
            }
            }
        }
        cam.transform.position = new Vector3((float)width /2 - 0.5f,(float)height /2 - 0.5f,-10);
    }
    public int GivePlayerheight(){return height;}
    public int GivePlayerwidth(){return width;}
}
