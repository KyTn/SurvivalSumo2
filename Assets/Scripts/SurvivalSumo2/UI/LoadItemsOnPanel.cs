using SmartLocalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItemsOnPanel : MonoBehaviour {

    public ItemViewer panel;

    public RectTransform PanelContainer;
    public float width = 50;

    Dictionary<Item.ItemTypePart, List<ItemViewer>> panelsByTypePart;




	// Use this for initialization
	void Start () {
        Init();
	}

    private void Init()
    {
        foreach (Item it in ItemDataBase.instanceData.items)
        {
            if (panelsByTypePart.ContainsKey(it.itemType_P))
            {
                addPanel(it);
            }
            else
            {
                panelsByTypePart.Add(it.itemType_P, new List<ItemViewer>());
                addPanel(it);
            }
        }
    }

    private void addPanel(Item it)
    {
        GameObject panel_go = Instantiate(panel.gameObject) as GameObject;
        ItemViewer panel_itV = panel_go.GetComponent<ItemViewer>();
        RectTransform panel_rtt = panel_go.GetComponent<RectTransform>();

        // set info on panel
        panel_itV.SetInfoAndUpdate(it.itemIcon, 
            LanguageManager.Instance.GetTextValue(it.itemName),
            LanguageManager.Instance.GetTextValue("hasItemParts") + GameState.instance.itemPartsCollected[it.itemName],
            GameState.instance.ItemsObtained[it.itemName]);

        // adding panel to dictionary
        panelsByTypePart[it.itemType_P].Add(panel_itV);

        panel_rtt.SetParent(PanelContainer);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
