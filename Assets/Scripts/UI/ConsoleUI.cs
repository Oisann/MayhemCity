using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ConsoleUI : MonoBehaviour {
    public bool isShowing = true;

    [Range(0.0f, 1.0f)]
    public float coverPercentage = .3f;

    private int height = 0;
    private int width = 0;

    private RectTransform rt;

    void Start() {
        rt = GetComponent<RectTransform>();
	}

    private float getSize(int full) {
        return full * coverPercentage;
    }
	
	void Update() {
        if(Screen.currentResolution.height != height) {
            height = Screen.currentResolution.height;
        }
        if(Screen.currentResolution.width != width) {
            width = Screen.currentResolution.width;
        }
        float h = getSize(height);
        rt.sizeDelta = new Vector2(width, h);

        if(isShowing) {
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
                isShowing = false;
        } else {
            
            if(Input.GetKeyDown(KeyCode.Tab))
                isShowing = false;
        }
    }

    public void setShowing(bool show) {
        PlayerPrefs.GetInt("console_show", show ? 0 : 1);
        isShowing = show;
    }

}
