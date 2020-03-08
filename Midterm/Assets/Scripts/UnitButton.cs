using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class UnitButton : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;
    [SerializeField] private Sprite sprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField] public bool deployed = false;

    public GameObject UnitPrefab
    {
        get
        {
            return unitPrefab;
        }
        
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }

    public bool Deployed
    {
        get
        {
            return deployed;
        }
    }

    private void ColorTile(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}
