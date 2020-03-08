using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject placingUnit;

    public GameObject[] TempUnitPrefabs;
    public List<bool> isthatPlaced;

    public GameObject GetUnitPlaced()
    {
        return placingUnit;
    }

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

        isthatPlaced = new List<bool>();

        foreach (GameObject GO in TempUnitPrefabs)
        {
            isthatPlaced.Add(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SetUnitToBuild(GameObject unit)
    {
        placingUnit = unit;
    }

    public bool GetUnitIsPlaced()
    {
        foreach (GameObject GO in TempUnitPrefabs)
        {
            if (placingUnit == GO)
            {
                return isthatPlaced[Array.IndexOf(TempUnitPrefabs, GO)];
            }
        }
        return false;
    }
}
