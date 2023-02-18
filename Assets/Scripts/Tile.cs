using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    [SerializeField] private Sprite[] sprites;

    [SerializeField] private TileTypes tileType;

    private BoxCollider2D collider;

    public bool placeable = false;


    private void Awake()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        collider = gameObject.GetComponent<BoxCollider2D>();


        if (tileType == TileTypes.Ranged || tileType == TileTypes.Path)
        {
            placeable = true;
        }
    }

    public void Init(bool isOffset, char value, GameObject tileContent = null)
    {
        Debug.Log(value);

        tileType = (TileTypes)int.Parse(value.ToString());

        if(tileType == TileTypes.Ranged || tileType == TileTypes.Path)
        {
            placeable = true;
        }

        _renderer.sprite = sprites[int.Parse(value.ToString())];

        if (tileContent != null)
        {
            var tileObject = Instantiate(tileContent, transform.position, Quaternion.identity);
        }

        if ((TileTypes)int.Parse(value.ToString()) == TileTypes.Wall || (TileTypes)int.Parse(value.ToString()) == TileTypes.Ranged)
        {
            collider.enabled = true;
        }
        
    }

    void OnMouseEnter()
    {
        if (placeable)
        {
            _renderer.color = new Color(255, 255, 255, 120);
            Debug.Log("OVER");
        }
        
    }

    void OnMouseExit()
    {
        if (placeable)
        {
            _renderer.color = new Color(255, 255, 255, 255);
            Debug.Log("LEAVE");
        }
        
    }
}

public enum TileTypes
{
    Wall = 0,
    Ranged = 1,
    Path = 2,
    EnemySpawn = 3, 
    Lud = 4,

}
