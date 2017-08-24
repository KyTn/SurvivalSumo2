using SmartLocalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItemsOnPanel : MonoBehaviour {

    public ItemViewer panel;

    public RectTransform PanelContainer_part1;
    public RectTransform PanelContainer_part2;
    public RectTransform PanelContainer_part3;
    public RectTransform PanelContainer_part4;
    public RectTransform PanelContainer_part5;
    public float width = 50;

    Dictionary<Item.ItemTypePart, List<ItemViewer>> panelsByTypePart;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        panelsByTypePart = new Dictionary<Item.ItemTypePart, List<ItemViewer>>();
    }
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
        Debug.Log("Loading item: " + it.itemName);

        GameObject panel_go = Instantiate(panel.gameObject) as GameObject;
        ItemViewer panel_itV = panel_go.GetComponent<ItemViewer>();
        RectTransform panel_rtt = panel_go.GetComponent<RectTransform>();

        // set info on panel
        panel_itV.SetInfoAndUpdate(it.itemIcon, 
            LanguageManager.Instance.GetTextValue(it.itemName),
            GameState.instance.itemPartsTotal[it.itemName] / (GameState.instance.itemPartsCollected[it.itemName] == 0?1:GameState.instance.itemPartsCollected[it.itemName]),
            LanguageManager.Instance.GetTextValue("hasItemParts") + GameState.instance.itemPartsCollected[it.itemName],
            GameState.instance.ItemsObtained[it.itemName]);


        RectTransform PanelContainer;

        switch(it.itemType_P){
            case Item.ItemTypePart.Back: PanelContainer = PanelContainer_part1; break;
            case Item.ItemTypePart.Body: PanelContainer = PanelContainer_part2; break;
            case Item.ItemTypePart.Feet: PanelContainer = PanelContainer_part3; break;
            case Item.ItemTypePart.Hands: PanelContainer = PanelContainer_part4; break;
            case Item.ItemTypePart.Head: PanelContainer = PanelContainer_part5; break;
            default: PanelContainer = PanelContainer_part1; break;
        }

        panel_go.SetActive(true);


        panel_rtt.SetParent(PanelContainer);
        panel_rtt.localPosition = Vector3.zero;
        panel_rtt.localRotation = new Quaternion(0, 0, 0, 1);
        panel_rtt.localScale = Vector3.one;

        panel_rtt.anchoredPosition = new Vector2(0, -width / 2 - (panelsByTypePart[it.itemType_P].Count-1) * width);

        PanelContainer.sizeDelta = new Vector2(0, (-width / 2 - (panelsByTypePart[it.itemType_P].Count - 1) * width) *-1 + 45);
        panelsByTypePart[it.itemType_P].Add(panel_itV);

    }
	

    public void ReloadInfo(){
        foreach (List<ItemViewer> litV in panelsByTypePart.Values)
        {
            foreach (ItemViewer itV in litV)
            {
                Destroy(itV);
            }
        }
        panelsByTypePart.Clear();

        Init();
    }


}
