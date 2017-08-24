using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class ItemDataBase : MonoBehaviour
{

    public static ItemDataBase instanceData;



    public List<Item> items = new List<Item>();


    void Awake()
    {
        if (instanceData != null)
        {
            Debug.LogError("ItemDataBase: Solo se puede una instancia de este tipo");
            return;
        }
        DontDestroyOnLoad(gameObject);
        instanceData = this;
        Init();
    }

    void Init()
    {

        Sprite[] spriteIcon = Resources.LoadAll<Sprite>("garmentsIcon");


        items.Add(new Item(GameState.instance.itemNames[0], Item.ItemRarity.EPIC, Skills.Skill.SK1 /*"Skill2"*/, Item.ItemTypePart.Head, Item.ItemTypeSet.COWBOY, spriteIcon[2]));
        items.Add(new Item(GameState.instance.itemNames[1], Item.ItemRarity.EPIC, Skills.Skill.SK1 /*"Skill2"*/, Item.ItemTypePart.Body, Item.ItemTypeSet.COWBOY, spriteIcon[3]));
        items.Add(new Item(GameState.instance.itemNames[2], Item.ItemRarity.EPIC, Skills.Skill.SK1 /*"Skill2"*/, Item.ItemTypePart.Feet, Item.ItemTypeSet.COWBOY, spriteIcon[4]));

        items.Add(new Item(GameState.instance.itemNames[3], Item.ItemRarity.COMMON, Skills.Skill.SK1 /*"Skill3"*/, Item.ItemTypePart.Head, Item.ItemTypeSet.COWBOY, spriteIcon[5]));
        items.Add(new Item(GameState.instance.itemNames[4], Item.ItemRarity.COMMON, Skills.Skill.SK1 /*"Skill3"*/, Item.ItemTypePart.Hands, Item.ItemTypeSet.COWBOY, spriteIcon[6]));
        items.Add(new Item(GameState.instance.itemNames[5], Item.ItemRarity.COMMON, Skills.Skill.SK1 /*"Skill3"*/, Item.ItemTypePart.Feet, Item.ItemTypeSet.COWBOY, spriteIcon[7]));

        items.Add(new Item(GameState.instance.itemNames[6], Item.ItemRarity.EPIC, Skills.Skill.SK1 /*"Skill5"*/, Item.ItemTypePart.Head, Item.ItemTypeSet.COWBOY, spriteIcon[8]));
        items.Add(new Item(GameState.instance.itemNames[7], Item.ItemRarity.EPIC, Skills.Skill.SK1 /*"Skill5"*/, Item.ItemTypePart.Back, Item.ItemTypeSet.COWBOY, spriteIcon[9]));
        items.Add(new Item(GameState.instance.itemNames[8], Item.ItemRarity.EPIC, Skills.Skill.SK1 /*"Skill5"*/, Item.ItemTypePart.Feet, Item.ItemTypeSet.COWBOY, spriteIcon[10]));

        items.Add(new Item(GameState.instance.itemNames[9], Item.ItemRarity.EPIC, Skills.Skill.SK1 /*"Skill5"*/, Item.ItemTypePart.Head, Item.ItemTypeSet.COWBOY, spriteIcon[11]));
        items.Add(new Item(GameState.instance.itemNames[10], Item.ItemRarity.EPIC, Skills.Skill.SK1 /*"Skill4"*/, Item.ItemTypePart.Back, Item.ItemTypeSet.COWBOY, spriteIcon[12]));
        items.Add(new Item(GameState.instance.itemNames[11], Item.ItemRarity.EPIC, Skills.Skill.SK1 /*"Skill1"*/, Item.ItemTypePart.Body, Item.ItemTypeSet.COWBOY, spriteIcon[13]));
        items.Add(new Item(GameState.instance.itemNames[12], Item.ItemRarity.EPIC, Skills.Skill.SK1 /*"Skill2"*/, Item.ItemTypePart.Feet, Item.ItemTypeSet.COWBOY, spriteIcon[14]));

        items.Add(new Item(GameState.instance.itemNames[13], Item.ItemRarity.COMMON, Skills.Skill.NONE, Item.ItemTypePart.Head, Item.ItemTypeSet.COWBOY, spriteIcon[15]));
        items.Add(new Item(GameState.instance.itemNames[14], Item.ItemRarity.COMMON, Skills.Skill.NONE, Item.ItemTypePart.Body, Item.ItemTypeSet.COWBOY, spriteIcon[16]));
        items.Add(new Item(GameState.instance.itemNames[15], Item.ItemRarity.COMMON, Skills.Skill.NONE, Item.ItemTypePart.Back, Item.ItemTypeSet.COWBOY, spriteIcon[17]));

        items.Add(new Item(GameState.instance.itemNames[16], Item.ItemRarity.COMMON, Skills.Skill.SK1 /*"Skill2"*/, Item.ItemTypePart.Head, Item.ItemTypeSet.COWBOY, spriteIcon[18]));
        items.Add(new Item(GameState.instance.itemNames[17], Item.ItemRarity.COMMON, Skills.Skill.SK1 /*"Skill5"*/, Item.ItemTypePart.Body, Item.ItemTypeSet.COWBOY, spriteIcon[19]));
        items.Add(new Item(GameState.instance.itemNames[18], Item.ItemRarity.COMMON, Skills.Skill.SK1 /*"Skill4"*/, Item.ItemTypePart.Feet, Item.ItemTypeSet.COWBOY, spriteIcon[20]));

        items.Add(new Item(GameState.instance.itemNames[19], Item.ItemRarity.COMMON, Skills.Skill.SK1 /*"Skill1"*/, Item.ItemTypePart.Head , Item.ItemTypeSet.COWBOY, spriteIcon[21]));
        items.Add(new Item(GameState.instance.itemNames[20], Item.ItemRarity.COMMON, Skills.Skill.SK1 /*"Skill5"*/, Item.ItemTypePart.Hands, Item.ItemTypeSet.COWBOY, spriteIcon[22]));
        items.Add(new Item(GameState.instance.itemNames[21], Item.ItemRarity.COMMON, Skills.Skill.SK1 /*"Skill5"*/, Item.ItemTypePart.Back , Item.ItemTypeSet.COWBOY, spriteIcon[23]));

        items.Add(new Item(GameState.instance.itemNames[22], Item.ItemRarity.RARE, Skills.Skill.SK1 /*"Skill2"*/, Item.ItemTypePart.Head, Item.ItemTypeSet.COWBOY, spriteIcon[24]));
        items.Add(new Item(GameState.instance.itemNames[23], Item.ItemRarity.RARE, Skills.Skill.SK1 /*"Skill5"*/, Item.ItemTypePart.Body, Item.ItemTypeSet.COWBOY, spriteIcon[25]));
        items.Add(new Item(GameState.instance.itemNames[24], Item.ItemRarity.RARE, Skills.Skill.SK1 /*"Skill5"*/, Item.ItemTypePart.Hands,Item.ItemTypeSet.COWBOY, spriteIcon[26]));

        items.Add(new Item(GameState.instance.itemNames[25], Item.ItemRarity.RARE, Skills.Skill.SK1 /*"Skill3"*/, Item.ItemTypePart.Head, Item.ItemTypeSet.COWBOY, spriteIcon[27]));
        items.Add(new Item(GameState.instance.itemNames[26], Item.ItemRarity.RARE, Skills.Skill.SK1 /*"Skill5"*/, Item.ItemTypePart.Back, Item.ItemTypeSet.COWBOY, spriteIcon[28]));
        items.Add(new Item(GameState.instance.itemNames[27], Item.ItemRarity.RARE, Skills.Skill.SK1 /*"Skill2"*/, Item.ItemTypePart.Feet, Item.ItemTypeSet.COWBOY, spriteIcon[29]));
    }

}
