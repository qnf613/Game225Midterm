    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameObject[] tilePrefabs;

    private Point HQ, enemySpawn;

    [SerializeField] private Transform map;

    [SerializeField] private GameObject HQPrefab;
    [SerializeField] private GameObject enemySpawnPrefab;

    public Dictionary<Point, TileScript> Tiles { get; set; }
    //calculates how big tiles are, this is used to place out tiles on the correct posistion
    //multiply tileSize by 3.1f because prefabs' scale is 3.1 for both x and y
    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x * 3.1f; }
    }

    // Start is called before the first frame update
    void Start()
    {
        createLevel();
    }
    
    //create level
    private void createLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();
        //A tmp instantioation of the tile map, we will use a text document to load this later.
        string[] mapData = ReadLevelText();
        //calculates the map sizes
        int mapXSize = mapData[0].ToCharArray().Length; 
        int mapYSize = mapData.Length;


        //calculate the world start point, this will be the top left corner of the screen
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));

        for (int y = 0; y < mapYSize; y++) //the y position
        {
            char[] newTiles = mapData[y].ToCharArray();

            for(int x = 0; x < mapXSize; x++) //the x position
            {
                PlaceTile(newTiles[x].ToString(), x, y, worldStart);
            }
        }

        SpawnAndHQ();
    }

    private void PlaceTile(string tileType, int x, int y, Vector2 worldStart)
    {
        //tileType will read .txt file which is map data of the level
        //and int.Pars (fileType) converts the data in the .txt file to int so that the Unity can actually use any tile data to generate the level
        int tileIndex = int.Parse(tileType);
        //create a new tile and makes a reference to that tile in the newTile
        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();
        //uses the new tile to change the position of the tile
        newTile.SetUp(new Point(x, y), new Vector2(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y)), map);

        

    }

    //this is a method to read .txt file
    private string[] ReadLevelText()
    {
        TextAsset textData = Resources.Load("Level") as TextAsset;
        string tempData = textData.text.Replace(Environment.NewLine, string.Empty);
        return tempData.Split('-');
    }

    private void SpawnAndHQ()
    {
        enemySpawn = new Point(0, 0);
        Instantiate(enemySpawnPrefab, Tiles[enemySpawn].GetComponent<TileScript>().WorldPos, Quaternion.identity);
        //Instantiate(tilePrefabs[9], Tiles[enemySpawn].GetComponent<TileScript>().WorldPos, Quaternion.identity);
        
        HQ = new Point(12, 4);
        Instantiate(HQPrefab, Tiles[HQ].GetComponent<TileScript>().WorldPos, Quaternion.identity);


    }
}
