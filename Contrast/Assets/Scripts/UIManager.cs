using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image[] petalImages;
    [SerializeField] int petalsCount;

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
            if(petalsCount < petalImages.Length)
            {
                petalsCount++;
                petalImages[petalsCount - 1].enabled = true;
            }
        }
	}
}