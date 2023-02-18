using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Coots", menuName = "Coots/BasicCoots")]
public class Coots : ScriptableObject
{
    public string Name;

    public int Health = 0;

    public Image image;

    public float damageRate = 0.0f;

    public AfflictionTypes afflication;

    public Rarities rarity;
}

public enum AfflictionTypes
{
    Slow,
    Burn,
    Freeze,
    None
}

public enum Rarities
{
    Ultra,
    Elite,
    Rare,
}
