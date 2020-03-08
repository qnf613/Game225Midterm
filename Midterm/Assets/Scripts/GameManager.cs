using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{ 

    public UnitButton ClickedBtn { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CancelSelect();
    }

    public void PickUnit(UnitButton unitbtn)
    {
        //this condition enables the player to pick a unit only if that unit is not deployed yet or the player is not picking up another unit
        if (unitbtn.Deployed == false && GameManager.Instance.ClickedBtn == null)
        {
            this.ClickedBtn = unitbtn;
            Hover.Instance.Activate(unitbtn.Sprite);
            unitbtn.deployed = true;   
        }
    }

    public void UnitPlaced()
    {
        Hover.Instance.Deactivate();
    }

    private void CancelSelect()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Hover.Instance.Deactivate();
        }
    }

}
