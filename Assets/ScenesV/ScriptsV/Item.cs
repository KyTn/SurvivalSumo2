using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Item {
	public string itemName;
	public string itemRarity;
	public Sprite itemIcon;
	public GameObject itemModel;
	public ItemTypePart itemType_P;
	public ItemTypeSet itemType_S;
	public string item_Skill;
			


	public enum ItemTypePart{

		Head,
		Body,
		Back,
		Hands,
		Feet,

	}

	public enum ItemTypeSet{
	

	}
	public Item(string name, string rarity,string skill,ItemTypePart type_P,Sprite icon){
		itemName = name;
		itemRarity = rarity;
		item_Skill = skill;
		itemType_P = type_P;
		itemIcon = icon;


	}
}
