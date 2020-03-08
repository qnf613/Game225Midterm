using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    public Vector3 positionOffset;

    private GameObject unit;

    private Renderer rend;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (buildManager.GetUnitPlaced() == null)
        {
            return;
        }

        if (unit != null)
        {
            return;
        }

        if (BuildManager.instance.GetUnitIsPlaced() == false)
        {
            GameObject placingUnit = BuildManager.instance.GetUnitPlaced();
            unit = (GameObject)Instantiate(placingUnit, transform.position + positionOffset, transform.rotation);
            BuildManager.instance.isthatPlaced[Array.IndexOf(BuildManager.instance.TempUnitPrefabs, BuildManager.instance.GetUnitPlaced())] = true;
        }
    }


    void OnMouseEnter()
    {
        if (buildManager.GetUnitPlaced() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;   
    }
}
