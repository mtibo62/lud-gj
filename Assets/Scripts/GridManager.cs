using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cam;

    [SerializeField] public GameObject gridObject;

    private Dictionary<Vector2, Tile> _tiles = new Dictionary<Vector2, Tile>();

    private string fileName = "";

    [SerializeField] GameObject Lud;

    [SerializeField] GameObject EnemySpawn;

    void Start()
    {
        GenerateGrid(fileName);
    }

    void GenerateGrid(string fileName)
    {


        //Read the text from directly from the test.txt file

        string path = Application.dataPath + "/Maps/map1.txt";
        //StreamReader reader = new StreamReader(path);

        //Debug.Log(reader.Read());

        var charList = new List<List<char>>();

        string line = "";


        using (var reader = new System.IO.StreamReader(path))
        {
            while (( line = reader.ReadLine()) != null)
            {
                charList.Add(line.ToList());
            }

            reader.Close();
        }

        var x = 0;
        var y = 0;

        foreach (var stringList in charList)
        {
            y = 0;
            foreach (var item in stringList)
            {

                var spawnedtile = Instantiate(_tilePrefab, new Vector3(y, x), Quaternion.identity);
                spawnedtile.transform.parent = gridObject.transform;
                spawnedtile.name = $"tile {x} {y}";

                var isoffset = (x % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0);

                if ((TileTypes)int.Parse(item.ToString()) == TileTypes.Lud)
                {
                    spawnedtile.Init(isoffset, item, Lud);
                }
                else if ((TileTypes)int.Parse(item.ToString()) == TileTypes.EnemySpawn)
                {
                    spawnedtile.Init(isoffset, item, EnemySpawn);
                }
                else
                {
                    spawnedtile.Init(isoffset, item);
                }


                _tiles[new Vector2(y, x)] = spawnedtile;
                y++;
            }
            x++;
        }


    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}


//for (int x = 0; x < _height; x++)
//{
//    for (int y = 0; y < _width; y++)
//    {
//        //Debug.Log(reader.Read());
//        var spawnedTile = Instantiate(_tilePrefab, new Vector3(y, x), Quaternion.identity);
//        spawnedTile.name = $"Tile {x} {y}";

//        var isOffset = (x % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0);
//        spawnedTile.Init(isOffset, '0');


//        _tiles[new Vector2(y, x)] = spawnedTile;
//    }
//}

//_cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
