using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class VirtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public string Name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDrag(PointerEventData data)
    {    }


    public void OnPointerUp(PointerEventData data)
    {
        CrossPlatformInputManager.SetButtonUp(Name);
    }


    public void OnPointerDown(PointerEventData data)
    {
        CrossPlatformInputManager.SetButtonDown(Name);
    }
}
