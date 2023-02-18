using TMPro;
using UnityEngine;

public class UnitCanvas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI MenuTitleText;

    [SerializeField]
    private GameObject UltraUnitContainer;

    [SerializeField]
    private GameObject EliteUnitContainer;

    [SerializeField]
    private GameObject RareUnitContainer;

    [SerializeField]
    private GameObject UnitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCanvas(bool IsMelee)
    {
        if (IsMelee)
        {
            MenuTitleText.text = "Melee Units";

            foreach (var item in TdManager.instance.availableMeleeCoots)
            {
                var newButton = Instantiate(UnitButton);

                switch (item.rarity)
                {
                    case (Rarities.Ultra):
                        newButton.transform.parent = UltraUnitContainer.transform;
                        break;
                    case (Rarities.Elite):
                        newButton.transform.parent = EliteUnitContainer.transform;
                        break;
                    case (Rarities.Rare):
                        newButton.transform.parent = RareUnitContainer.transform;
                        break;
                }
                
            }
        }
        else
        {
            MenuTitleText.text = "Ranged Units";
        }
    }

    public void OpenCanvas()
    {
        gameObject.active = true;
    }

    public void CloseCanvas()
    {
        gameObject.active = false;
    }
}
