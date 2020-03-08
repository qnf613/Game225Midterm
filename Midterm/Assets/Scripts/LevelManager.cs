    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : Singleton<LevelManager>
{
    //an array of tilePrefebs, these are used for creating the tiles in the game
    [SerializeField] private GameObject[] tilePrefabs;
    //the maps transform, this is needed for adding new tiles
    [SerializeField] private Transform map;
    //prefab for each of player H.Q. and enemy spawn, these are used for creating start and goal of enemy path 
    [SerializeField] private GameObject HQPrefab;
    [SerializeField] private GameObject enemySpawnPrefab;
    //spawn points for the HQ, enemy spawn
    private Point HQ, enemySpawn;
    private Point mapSize;
    //a property for returning the size of a tile
    public Dictionary<Point, TileScript> Tiles { get; set; }
    //calculates how big tiles are, this is used to place out tiles on the correct posistion
    //multiply tileSize by 3.1f because prefabs' scale is 3.1 for both x and y
    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x * 3.1f; }
    }

    //Start is called before the first frame update
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

        mapSize = new Point(mapData[0].ToCharArray().Length, mapData.Length);
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

    public void SpawnAndHQ()
    {
        //place enemy spawn at map
        enemySpawn = new Point(0, 0);
        GameObject eSpawn = (GameObject)Instantiate(enemySpawnPrefab, Tiles[enemySpawn].GetComponent<TileScript>().WorldPos, Quaternion.identity);
        //place player H.Q. at map
        HQ = new Point(12, 4);
        GameObject hq = (GameObject)Instantiate(HQPrefab, Tiles[HQ].GetComponent<TileScript>().WorldPos, Quaternion.identity);
    }

    public bool InBound(Point position)
    {
        return position.x >= 0 && position.y >= 0 && position.x < mapSize.x && position.y < mapSize.y;
    }
}
