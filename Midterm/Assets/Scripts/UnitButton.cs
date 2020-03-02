using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class UnitButton : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;
    [SerializeField] private Sprite sprite;

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
}
