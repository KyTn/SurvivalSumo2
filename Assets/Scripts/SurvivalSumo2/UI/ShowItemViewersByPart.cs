using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemViewersByPart : MonoBehaviour {

    public static RectTransform scrollViewerActive;

    public RectTransform scrollViewer;

    public bool activeThis = false;

	void Awake () {
		gameObject.GetComponent<Button>().onClick.AddListener(Unlock);
        if (activeThis) Unlock();
	}


    void Unlock()
    {
        if(scrollViewerActive) scrollViewerActive.gameObject.SetActive(false);
        scrollViewerActive = scrollViewer;
        scrollViewerActive.gameObject.SetActive(true);
    }
}
