using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class ItemDataBase : MonoBehaviour {

	public static ItemDataBase instanceData;



public List<Item>items=new List<Item>();
	int j=0;
	Sprite[] spriteIcon;


	void Awake(){
		if (instanceData != null) {
			Debug.LogError("ItemDataBase: Solo se puede una instancia de este tipo");
			return;
		}

		instanceData = this;
	}

	void Start () {

		spriteIcon= Resources.LoadAll<Sprite>("garmentsIcon");
	
		
		items.Add (new Item ("Cowboy hat","Epic","Skill2",Item.ItemTypePart.Head,spriteIcon[2],true));
		items.Add (new Item ("Cowboy jacket","Epic","Skill2",Item.ItemTypePart.Body,spriteIcon[3],false));
		items.Add (new Item ("Cowboy boots","Epic","Skill2",Item.ItemTypePart.Feet,spriteIcon[4],false));
		items.Add (new Item ("Fighting Mask","Comun","Skill3",Item.ItemTypePart.Head,spriteIcon[5],false));
		items.Add (new Item ("Boxing gloves","Comun","Skill3",Item.ItemTypePart.Hands,spriteIcon[6],false));
		items.Add (new Item ("Boxing boots","Comun","Skill3",Item.ItemTypePart.Feet,spriteIcon[7],false));
		items.Add (new Item ("Knight helmet","Epic","Skill5",Item.ItemTypePart.Head,spriteIcon[8],true));
		items.Add (new Item ("Knight sword","Epic","Skill5",Item.ItemTypePart.Back,spriteIcon[9],false));
		items.Add (new Item ("Knight footwear", "Epic", "Skill5", Item.ItemTypePart.Feet,spriteIcon [10], false));
		items.Add (new Item ("Pirate hat","Epic","Skill5",Item.ItemTypePart.Head,spriteIcon[11],true));
		items.Add (new Item ("Parrot","Epic","Skill4",Item.ItemTypePart.Back,spriteIcon[12],false));
		items.Add (new Item ("Pirate jacket","Epic","Skill1",Item.ItemTypePart.Body,spriteIcon[13],false));
		items.Add (new Item ("Pirate boots","Epic","Skill2",Item.ItemTypePart.Feet,spriteIcon[14],false));
		items.Add (new Item ("Chef hat","Comun","Skill3",Item.ItemTypePart.Head,spriteIcon[15],false));
		items.Add (new Item ("Chef jacket","Comun","Skill3",Item.ItemTypePart.Body,spriteIcon[16],true));
		items.Add (new Item ("Frying pan","Comun","Skill5",Item.ItemTypePart.Back,spriteIcon[17],true));
		items.Add (new Item ("Ballet ring","Comun","Skill2",Item.ItemTypePart.Head,spriteIcon[18],false));
		items.Add (new Item ("Ballet skirt","Comun","Skill5",Item.ItemTypePart.Body,spriteIcon[19],false));
		items.Add (new Item ("Ballet shoes","Comun","Skill4",Item.ItemTypePart.Feet,spriteIcon[20],false));
		items.Add (new Item ("Ears of cat","Comun","Skill1",Item.ItemTypePart.Head,spriteIcon[21],true));
		items.Add (new Item ("Paw cat","Comun","Skill5",Item.ItemTypePart.Hands,spriteIcon[22],true));
		items.Add (new Item ("Cat tail","Comun","Skill5",Item.ItemTypePart.Back,spriteIcon[23],false));
		items.Add (new Item ("Hair Super Saiyan","Rare","Skill2",Item.ItemTypePart.Head,spriteIcon[24],false));
		items.Add (new Item ("Kimono Super Saiyan","Rare","Skill5",Item.ItemTypePart.Body,spriteIcon[25],true));
		items.Add (new Item ("Kame Ame Wave","Rare","Skill5",Item.ItemTypePart.Hands,spriteIcon[26],true));
		items.Add (new Item ("Angel Halo","Rare","Skill3",Item.ItemTypePart.Head,spriteIcon[27],false));
		items.Add (new Item ("Angel wings","Rare","Skill5",Item.ItemTypePart.Back,spriteIcon[28],true));
		items.Add (new Item ("Mercury boots","Rare","Skill2",Item.ItemTypePart.Feet,spriteIcon[29],true));
	

	
	}


	

}
