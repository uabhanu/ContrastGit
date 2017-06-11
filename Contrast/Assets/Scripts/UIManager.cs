using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;
    [SerializeField] Image[] petalImages;
    public int petalsCount;

    private void Awake () {
        if(uiManager == null) {
            uiManager = this;
        }
    }

    void Start()
    {
        
    }
	
	void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }


	}

    public void Incrementpetals () {
        if (petalsCount < petalImages.Length) {
            petalsCount++;
            petalImages[petalsCount - 1].enabled = true;
        }
    }
}