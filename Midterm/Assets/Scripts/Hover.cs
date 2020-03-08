using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : Singleton<Hover>
{
    private SpriteRenderer spriterenderer;
    // Start is called before the first frame update
    void Start()
    {
        this.spriterenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        if (spriterenderer.enabled)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    //activate the fnction that unit icon follows mouse cursor
    public void Activate(Sprite sprite)
    {
        this.spriterenderer.sprite = sprite;
        spriterenderer.enabled = true;
    }
    //deactivate the fnction that unit icon follows mouse cursor
    public void Deactivate()
    {
        spriterenderer.enabled = false;
        GameManager.Instance.ClickedBtn = null;
    }
    
}
