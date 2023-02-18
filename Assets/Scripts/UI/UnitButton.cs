using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    [SerializeField]
    private Image unitImage;

    [SerializeField]
    private TextMeshProUGUI unitName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Coots coots)
    {
        unitImage = coots.image;

        unitName.text = coots.name;
    }
}
