﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    BoxCollider m_enemyCollider;
    [SerializeField] float m_moveSpeed;
    float m_distanceToObstacle;
    GameObject m_enemyObj;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        PlayerMovement();
    }

    void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("LeftJoystickHorizontal");
        float moveVertical = Input.GetAxis("LeftJoystickVertical");

        //RaycastHit hit;

        //if (Physics.SphereCast(transform.position, 1.5f, transform.forward, out hit, 3))
        //{
        //    //m_distanceToObstacle = hit.distance;
        //    //Debug.Log(m_distanceToObstacle);
        //    m_enemyObjTransform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        //}

        if(m_enemyObj != null)
        {
            m_enemyObj.transform.position = new Vector3(transform.position.x , transform.position.y , transform.position.z + 1f);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("A Button Pressed");

            RaycastHit hit;

            if (m_enemyObj == null)
            {
                Vector3 rPosition = transform.position + (transform.forward.normalized * 0.2f);
                Debug.DrawLine(transform.position, rPosition);

                if (Physics.SphereCast(transform.position + (transform.forward.normalized * 0.2f) , 0.45f, transform.forward, out hit, 3))
                {
                    m_distanceToObstacle = hit.distance;
                    Debug.Log(m_distanceToObstacle);
                    Debug.Log(rPosition);
                    Debug.DrawLine(transform.position, rPosition);
                    Debug.Log(hit.collider.gameObject.name);

                    if(hit.collider.gameObject.tag.Equals("Enemy"))
                    {
                        m_enemyCollider = GameObject.Find("Enemy").GetComponent<BoxCollider>();
                        m_enemyCollider.enabled = false;
                        m_enemyObj = hit.collider.gameObject;

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            //Debug.Log("B Button Pressed");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            //Debug.Log("X Button Pressed");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            //Debug.Log("Y Button Pressed");
        }

        Vector3 movement = new Vector3(moveHorizontal , 0f , moveVertical);

        if(movement.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        transform.Translate(movement * m_moveSpeed * Time.deltaTime , Space.World);
    }
}