using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	RectTransform my_rtt;
	public	RectTransform containers;
	public List<Item>listNew=new List<Item>();
	//public ItemDataBase myDB;
	int j=0;
	int n=0 ;
	int k=0;
	//bool listCreated=false;

	void Awake(){
		my_rtt = GetComponent<RectTransform> ();

	}

	void Start () {

		if (Application.loadedLevelName.Equals ("sceneBuy")) {
			CheckNumberContainersBuyScene ();
			CreateContainersList ();
			LoadDatesNotAcquired ();
		}
		else {
			CheckNumberContainersChangeSkinScene();
			CreateContainersList();
			LoadDatesInPanel_Head();

			//creamos 5 funciones por cada parte del cuerpo, ya que hecemos un filtro distinto en la lista, la cual contiene los distintos tipos(parte del cuerpo) de prendas
			//poner este codigo en una funcion aparte que sea llamada desde el codigo de los botones segun sea para la parte del cuerpo en cuestion
		}
		}

	public void CheckNumberContainersBuyScene(){
	
		foreach (Item myItem in ItemDataBase.instanceData.items) {
			
			if (myItem.item_acquired == false) {

				n++;
			
			}
	
		}
	}

	public void CheckNumberContainersChangeSkinScene(){
		n = 0;
		int a=0;
		int b=0;
		int c=0;
		int d=0;
		int e=0;

		Debug.Log ("a y e:" + a + e);
		foreach (Item myItem in ItemDataBase.instanceData.items) {
			
			if (myItem.itemType_P.Equals (Item.ItemTypePart.Head) && myItem.item_acquired == true) {

				a++;
			}
		}	
	
		n = a;
	

	//public void CheckNumberContainersChangeSkinBodyScene(){
		//n = 0;
		foreach (Item myItem in ItemDataBase.instanceData.items) {
			
			if (myItem.itemType_P.Equals (Item.ItemTypePart.Body) && myItem.item_acquired == true) {
				
				b++;
			}
		}	
		
		if (b > a)
			n = b;

	//public void CheckNumberContainersChangeSkinBackScene(){
	
		foreach (Item myItem in ItemDataBase.instanceData.items) {
			
			if (myItem.itemType_P.Equals (Item.ItemTypePart.Back) && myItem.item_acquired == true) {
				
				c++;
			}
		}	
		
		if (c > b)
			n = c;

	//public void CheckNumberContainersChangeSkinHandsScene(){

		foreach (Item myItem in ItemDataBase.instanceData.items) {
			
			if (myItem.itemType_P.Equals (Item.ItemTypePart.Hands) && myItem.item_acquired == true) {
				
				d++;
			}

		}
	
		if (d > c)
			n = d;
//	public void CheckNumberContainersChangeSkinFeetScene(){
		foreach (Item myItem in ItemDataBase.instanceData.items) {
			
			if (myItem.itemType_P.Equals (Item.ItemTypePart.Feet) && myItem.item_acquired == true) {
				
				e++;
			}
		}
		if (e > d)
			n = e;

		
	}


	public void CreateContainersList(){
		Debug.Log ("Primera llamada");
		int height_elements = 51;

		int y = 118;//118;


		for (int i=0; i < n; i++) {
			
			GameObject container = Instantiate (containers.gameObject) as GameObject;
			container.GetComponent<RectTransform> ().SetParent (my_rtt);//ultimo

			//container.GetComponent<RectTransform>().parent=my_rtt.parent;
			//container.transform.parent=this.gameObject.transform;

			container.GetComponent<RectTransform> ().localPosition = new Vector3 (0, y, 0);


			y = y - 48;

		
		}
		my_rtt.sizeDelta=new Vector2(my_rtt.sizeDelta.x,(height_elements*n)-328);//ultimo
		int res=(height_elements*n)-328;

}




/*	public	void Clean(){
				
				for(int i = transform.childCount -1; i >= 0; i--)
				{
					GameObject.Destroy(transform.GetChild(i).gameObject);

				}

	}*/


//	--------------
public	void LoadDatesInPanel_Head(){
		int j = 0;
		k = n;
		//poner dos funcionas una que cuente los contenedores de cabeza y a true y otra que los pase a la escena
		foreach (Item myItem in ItemDataBase.instanceData.items) {
		


			if (myItem.itemType_P.Equals( Item.ItemTypePart.Head)&& myItem.item_acquired==true){
				this.gameObject.transform.GetChild (j).gameObject.SetActive(true);//se ponen a true el contenedor necesarios
				//this.gameObject.transform.GetChild (j).GetChild (1).gameObject.SetActive(true);
				Debug.Log("seteando valores del objeto del head "+ myItem.itemName+" para el hijo "+j);
				this.gameObject.transform.GetChild (j).GetChild (0).GetComponent<Text> ().text = myItem.itemName; 
				this.gameObject.transform.GetChild (j).GetChild (1).GetComponent<Text> ().text = myItem.itemRarity;
				this.gameObject.transform.GetChild (j).GetChild (2).GetComponent<Text> ().text = myItem.item_Skill; 
				this.gameObject.transform.GetChild (j).GetChild (3).GetChild(0).GetComponent<Image>().sprite= myItem.itemIcon; 
				j++;
			}
		
			}
		
		
			while (k>j){//se encarga de poner a falso los contenedores que sobran en cada recarga de los paneles de cada parte del cuerpo
				this.gameObject.transform.GetChild (k-1).gameObject.SetActive(false);
				k--;
			}
			}
		


public	void LoadDatesInPanel_Body(){
		int j = 0;
		 k = n;

		foreach (Item myItem in ItemDataBase.instanceData.items) {

			if (myItem.itemType_P.Equals( Item.ItemTypePart.Body)&& myItem.item_acquired==true) {
				this.gameObject.transform.GetChild (j).gameObject.SetActive(true);
				Debug.Log("seteando valores del objeto del body "+ myItem.itemName+" para el hijo "+j);

				this.gameObject.transform.GetChild (j).GetChild (0).GetComponent<Text> ().text = myItem.itemName; 
				this.gameObject.transform.GetChild (j).GetChild (1).GetComponent<Text> ().text = myItem.itemRarity;
				this.gameObject.transform.GetChild (j).GetChild (2).GetComponent<Text> ().text = myItem.item_Skill; 
				this.gameObject.transform.GetChild (j).GetChild (3).GetChild(0).GetComponent<Image>().sprite = myItem.itemIcon;

				j++;
			}

			while (k>j){
			this.gameObject.transform.GetChild (k-1).gameObject.SetActive(false);
				k--;
			}


		}
		

	}





public	void LoadDatesInPanel_Back(){
		int j = 0;
		 k = n;
		
		foreach (Item myItem in ItemDataBase.instanceData.items) {
			
			if (myItem.itemType_P.Equals( Item.ItemTypePart.Back)&& myItem.item_acquired==true) {
				this.gameObject.transform.GetChild (j).gameObject.SetActive(true);
				
				this.gameObject.transform.GetChild (j).gameObject.SetActive (true);
				this.gameObject.transform.GetChild (j).GetChild (0).GetComponent<Text> ().text = myItem.itemName; 
				this.gameObject.transform.GetChild (j).GetChild (1).GetComponent<Text> ().text = myItem.itemRarity;
				this.gameObject.transform.GetChild (j).GetChild (2).GetComponent<Text> ().text = myItem.item_Skill; 
				this.gameObject.transform.GetChild (j).GetChild (3).GetChild(0).GetComponent<Image>().sprite= myItem.itemIcon; 

				j++;
			}
			
			while (k>j){
				this.gameObject.transform.GetChild (k-1).gameObject.SetActive(false);
				k--;
			}
			
			
		}
			
		}
		


public	void LoadDatesInPanel_Hands(){
		int j = 0;
		 k = n;
		
		foreach (Item myItem in ItemDataBase.instanceData.items) {
			
			if (myItem.itemType_P.Equals( Item.ItemTypePart.Hands)&& myItem.item_acquired==true ){
				this.gameObject.transform.GetChild (j).gameObject.SetActive(true);			

				this.gameObject.transform.GetChild (j).GetChild (0).GetComponent<Text> ().text = myItem.itemName; 
				this.gameObject.transform.GetChild (j).GetChild (1).GetComponent<Text> ().text = myItem.itemRarity;
				this.gameObject.transform.GetChild (j).GetChild (2).GetComponent<Text> ().text = myItem.item_Skill; 
				this.gameObject.transform.GetChild (j).GetChild (3).GetChild(0).GetComponent<Image>().sprite= myItem.itemIcon; 

				j++;
			}
			
			while (k>j){
				this.gameObject.transform.GetChild (k-1).gameObject.SetActive(false);
				k--;
			}
			
			
		}
	}


public	void LoadDatesInPanel_Feet(){
		int j = 0;
		 k = n;
		
		foreach (Item myItem in ItemDataBase.instanceData.items) {
			
			if (myItem.itemType_P.Equals (Item.ItemTypePart.Feet)&& myItem.item_acquired==true) {
				this.gameObject.transform.GetChild (j).gameObject.SetActive (true);
				
				//this.gameObject.transform.GetChild (j).gameObject.SetActive (true);
				this.gameObject.transform.GetChild (j).GetChild (0).GetComponent<Text> ().text = myItem.itemName; 
				this.gameObject.transform.GetChild (j).GetChild (1).GetComponent<Text> ().text = myItem.itemRarity;
				this.gameObject.transform.GetChild (j).GetChild (2).GetComponent<Text> ().text = myItem.item_Skill; 
				this.gameObject.transform.GetChild (j).GetChild (3).GetChild(0).GetComponent<Image>().sprite= myItem.itemIcon; //+"\n";

			j++;
			}
			
			while (k>j) {
				this.gameObject.transform.GetChild (k - 1).gameObject.SetActive (false);
				k--;
			}
			
			
		}
	}



	public	void LoadDatesNotAcquired(){
		int j = 0;
		int k = 0;
		int y = n;
		foreach (Item myItem in ItemDataBase.instanceData.items) {

			if(myItem.item_acquired==false){
		
			this.gameObject.transform.GetChild (j).GetChild (0).GetComponent<Text> ().text = myItem.itemName; 
			this.gameObject.transform.GetChild (j).GetChild (1).GetComponent<Text> ().text = myItem.itemRarity;
			this.gameObject.transform.GetChild (j).GetChild (2).GetComponent<Text> ().text = myItem.item_Skill; 
			this.gameObject.transform.GetChild (j).GetChild (3).GetChild (0).GetComponent<Image> ().sprite = myItem.itemIcon; 
				
			j++;
			}

		
		}
		while (j<y) {
			Debug.Log("k:"+k);
			this.gameObject.transform.GetChild (y-1).gameObject.SetActive (false);
			y--;
		}
		}

}
