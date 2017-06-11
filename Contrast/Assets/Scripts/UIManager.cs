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

        if(petalsCount > 0)
        {
            petalImages[petalsCount - 1].enabled = true;
        }
	}
}