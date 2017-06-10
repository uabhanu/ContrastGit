using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveSpeed;
    float m_horizontalDir , m_verticalDir;


    void Start()
    {
		
	}
	
	void Update()
    {
		if(Time.timeScale == 0)
        {
            return;
        }

        m_horizontalDir = m_moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        m_verticalDir = m_moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(m_horizontalDir , 0f , m_verticalDir);
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag.Equals("Obstacle"))
        {
            Debug.Log("Collision");
        }
    }
}
