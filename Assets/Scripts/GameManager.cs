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
        HandleEscape();
    }

    public void PickUnit(UnitButton unitbtn)
    {
        this.ClickedBtn = unitbtn;
        Hover.Instance.Activate(unitbtn.Sprite);
    }

    public void UnitPlaced()
    {
        Hover.Instance.Deactivate();
    }

    private void HandleEscape()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Hover.Instance.Deactivate();
        }
    }
}
