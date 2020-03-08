using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;    
    }

    public void Unit1()
    {
        buildManager.SetUnitToBuild(buildManager.TempUnitPrefabs[0]);
        
    }

    public void Unit2()
    {
        buildManager.SetUnitToBuild(buildManager.TempUnitPrefabs[1]);
    }
}
