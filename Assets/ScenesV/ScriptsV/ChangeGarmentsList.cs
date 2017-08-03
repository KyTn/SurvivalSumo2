using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class ChangeGarmentsList : MonoBehaviour {

	public GameObject panel_1;
	int button;
	
	//public Inventory myInventory;


	public Inventory myInv;

//	public GEAnim myGEAnim;
	void Start(){
		myInv = GetComponent<Inventory> ();
	//	panel_1.SetActive (true);
	//	myGarmentList.GetComponent<ItemDataBase> ().ChargeDatesInPanel_Body ();

	}

	public void ButtonPressed_1()
	{	button = 1;
		StartCoroutine (WaitForCharge(button));
		
		panel_1.GetComponent<GEAnim> ().MoveOut ();
		
		panel_1.GetComponent<GEAnim> ().MoveIn();;
		//panel_2.SetActive (false);
		
		
	}
	public void ButtonPressed_2()
	{	button = 2;
		StartCoroutine (WaitForCharge(button));

	
		panel_1.GetComponent<GEAnim> ().MoveOut ();



		panel_1.GetComponent<GEAnim> ().MoveIn ();
	
	}
	public void ButtonPressed_3()
	{	button = 3;
		StartCoroutine (WaitForCharge(button));
		
		panel_1.GetComponent<GEAnim> ().MoveOut ();
		
		panel_1.GetComponent<GEAnim> ().MoveIn();;
		//panel_2.SetActive (false);
		
		
	}

	public void ButtonPressed_4()
	{	button = 4;
		StartCoroutine (WaitForCharge(button));
		
		panel_1.GetComponent<GEAnim> ().MoveOut ();
		
		panel_1.GetComponent<GEAnim> ().MoveIn();;
		//panel_2.SetActive (false);
		
		
	}
	public void ButtonPressed_5()
	{	button = 5;
		StartCoroutine (WaitForCharge(button));
		
		panel_1.GetComponent<GEAnim> ().MoveOut ();
		
		panel_1.GetComponent<GEAnim> ().MoveIn();;
		//panel_2.SetActive (false);
		
		
	}

	IEnumerator WaitForCharge(int button){

		yield return new WaitForSeconds (0.5f);

		if (button == 1) {
		myInv.LoadDatesInPanel_Head ();
		} else if (button == 2) {
		myInv.LoadDatesInPanel_Body ();
		} else if (button == 3) {

		myInv.LoadDatesInPanel_Back ();
		
		}else if (button == 4) {
		
		myInv.LoadDatesInPanel_Hands ();
		
		}else if (button == 5) {
			
			myInv.LoadDatesInPanel_Feet ();
		}
	}
/*
	public void ChargeDatesInPanel_Body(){
		Debug.Log ("llama:"+myDB.items.Count);
		int j = 0;
		
		foreach (Item myItem in myDB.items) {
			Debug.Log (myItem.itemName);
			
			if (myItem.itemType_P.Equals (Item.ItemTypePart.Head)) {
				
				GameObject.Find ("Inventory").transform.GetChild (j).GetChild (0).GetComponent<Text> ().text = myItem.itemName; //+"\n";
				GameObject.Find ("Inventory").transform.GetChild (j).GetChild (1).GetComponent<Text> ().text = myItem.itemRarity;//+"\n";
				GameObject.Find ("Inventory").transform.GetChild (j).GetChild (2).GetComponent<Text> ().text = myItem.item_Skill; //+"\n";
			}
			if (this.gameObject.transform.GetChild (j).GetChild (1).GetComponent<Text> ().text.Equals ("")) {
				Destroy (this.gameObject.transform.GetChild (j).gameObject);//setActive (false);
				
			}
			j++;
		}
	}*/

			

}
