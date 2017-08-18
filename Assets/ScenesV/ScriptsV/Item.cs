using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Item {
	public string itemName;
    public ItemRarity itemRarity;
	public Sprite itemIcon;
	public GameObject itemModel;
	public ItemTypePart itemType_P;
	public ItemTypeSet itemType_S;
	public Skills.Skill item_Skill;
			


	public enum ItemTypePart{

		Head,
		Body,
		Back,
		Hands,
		Feet,

	}

	public enum ItemTypeSet{
	
        COWBOY, BOXEO, KNIGHT, PIRATE, CHEF, BALLET, CAT, SAIYAN, ANGEL

	}

    public enum ItemRarity
    {
        COMMON = 0, RARE = 1, EPIC=2
    }


    public Item(string name, ItemRarity rarity, Skills.Skill skill, ItemTypePart type_Part, ItemTypeSet type_Set, Sprite icon)
    {
		itemName = name;
		itemRarity = rarity;
		item_Skill = skill;
        itemType_P = type_Part;
        itemType_S = type_Set;
		itemIcon = icon;
	}
}
