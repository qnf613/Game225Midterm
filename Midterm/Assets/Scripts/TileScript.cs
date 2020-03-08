using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get; private set; }
    public bool IsEmpty { get; private set; }
    private Color32 fullColor = new Color32(255, 118, 118, 255);
    private Color32 emptyColor = new Color32(96, 255, 90, 255);
    private SpriteRenderer spriteRenderer;
    public Vector2 WorldPos
    {
        get
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x/2), transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y/2));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUp(Point gridPos, Vector2 worldPos, Transform parent)
    {
        IsEmpty = true;
        this.GridPosition = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        LevelManager.Instance.Tiles.Add(gridPos, this);
        
    }

    private void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBtn != null
            && gameObject.CompareTag("ground"))
        {
            if (IsEmpty)
            {
                ColorTile(emptyColor);
            }
            //The color change according to the value of IsEmpty is always updated regardless
            //of whether the variable is true or false, so it doesn't matter that 'else if' is not used. 
            if (!IsEmpty)
            {
                ColorTile(fullColor);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                PlaceUnit();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GameManager.Instance.ClickedBtn.deployed = false;
            }
            //Line 54~61 description.
            //No unit on tile -> IsEmpty = true-> PlaceUnit() is available
            //Unit on tile -> IsEmpty = float-> PlaceUnit() is unavilalbe.
            //Only one of the two if statements is to be true, so combined them by else if
            //additional description for Line 62~65 (and I wasted more than 15 mins by writing this single line of code in another script. XD) 
            //If you cancelled your selection before you placed that specific unit, you can select it again
            //But, once you placed that unit, you will not be able to pick that unit.
        }
    }

    private void OnMouseExit()
    {
        ColorTile(Color.white);
    }

    private void PlaceUnit()
    {
        GameObject unit = (GameObject)Instantiate(GameManager.Instantiate(GameManager.Instance.ClickedBtn.UnitPrefab, transform.position, Quaternion.identity));
        unit.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.y;
        unit.transform.SetParent(transform);
        IsEmpty = false;
        ColorTile(Color.white);
        GameManager.Instance.UnitPlaced();
    }

    private void ColorTile(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}
