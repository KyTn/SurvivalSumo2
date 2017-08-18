using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour {

    public Image icon_i;
    public Text name_t, quantity_t;
    public Button equip_b;

    public void SetInfoAndUpdate(Sprite iconImage, string name, string quantity_text, bool hasItem = false)
    {
        icon_i.sprite = iconImage;
        name_t.text = name;
        if (hasItem) quantity_t.gameObject.SetActive(false);
        else
        {
            quantity_t.gameObject.SetActive(true);
            quantity_t.text = quantity_text;
        }
    }
}
