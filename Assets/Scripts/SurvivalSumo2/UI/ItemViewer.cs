using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour {

    public Image icon_i_filled, icon_i_background;
    public Text name_t, quantity_t;
    public Button equip_b;

    public void SetInfoAndUpdate(Sprite iconImage, string name, float quantity_porcent, string quantity_text, bool hasItem = false)
    {
        icon_i_filled.sprite = iconImage;
        icon_i_filled.fillAmount = quantity_porcent;
        icon_i_background.sprite = iconImage;
        name_t.text = name;
        if (hasItem) quantity_t.gameObject.SetActive(false);
        else
        {
            quantity_t.gameObject.SetActive(true);
            quantity_t.text = quantity_text;
        }
    }
}
