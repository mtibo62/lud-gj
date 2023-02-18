using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TdManager : MonoBehaviour
{
    public static TdManager instance;

    public GameStates gameState;

    [SerializeField]
    public List<MeleeCoots> availableMeleeCoots = new List<MeleeCoots>();

    [SerializeField]
    public List<RangedCoots> availableRangedCoots = new List<RangedCoots>();

    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum GameStates
    {
        None, 
        Waiting,
        Spawning,
        Menu
    }
}
