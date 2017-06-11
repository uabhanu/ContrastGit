using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    public Collider m_enemyCollider;
    [SerializeField] float m_moveSpeed;
    float m_distanceToObstacle;
    public GameObject m_enemyObj;
    public Transform monsterAnim;
    public float maxDistanceToPickup = 3.5f;

    private void Awake () {
        if (player==null) { 

             player = this;
        }
    }

    private void Start()
    {
        maxDistanceToPickup = 3.5f;
        Physics.IgnoreCollision(this.GetComponent<Collider>(), HorrorPlayerStats.horrorPlayerStats.GetComponent<Collider>());
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
            m_enemyObj.transform.position = transform.position + (transform.forward * 1.1f);
            m_enemyObj.transform.rotation = transform.rotation;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            //Debug.Log("A Button Pressed");

            //RaycastHit hit;

            if (m_enemyObj == null)
            {
                GameObject obj = PickupClosestFlower();
                if (obj != null) {
                    m_enemyCollider = obj.GetComponent<Collider>();
                    m_enemyCollider.enabled = false;
                    m_enemyObj = obj;
                    m_enemyObj.GetComponent<FlowerType>().hasBeenDropped = false;
                    if (m_enemyObj.GetComponent<HorrorPlayerStats>()) { 
                        m_enemyObj.GetComponent<HorrorPlayerStats>().isBeingHeld = true; 

                    }
                }
                /*
                Vector3 rPosition = transform.position + (transform.forward.normalized * 0.2f);
                //Debug.DrawLine(transform.position, rPosition);

                if (Physics.SphereCast(rPosition, 0.45f, transform.forward, out hit, 3))
                {
                    m_distanceToObstacle = hit.distance;
                    //Debug.Log(m_distanceToObstacle);
                    //Debug.Log(rPosition);
                    //Debug.DrawLine(transform.position, rPosition);
                    //Debug.Log(hit.collider.gameObject.name);

                    if(hit.collider.gameObject.tag.Equals("Enemy"))
                    {
                        m_enemyCollider = hit.collider;
                        m_enemyCollider.enabled = false;
                        m_enemyObj = hit.collider.gameObject;
                        if(m_enemyObj.GetComponent<FlowerType>()) {
                            m_enemyObj.GetComponent<FlowerType>().hasBeenDropped = false;
                        }
                    }
                }
                */
            }
            else
            {
                m_enemyCollider.enabled = true;
                if (m_enemyObj.GetComponent<FlowerType>()) {
                    m_enemyObj.GetComponent<FlowerType>().hasBeenDropped = true;
                }
                if (m_enemyObj.GetComponent<HorrorPlayerStats>()) {
                    m_enemyObj.GetComponent<HorrorPlayerStats>().isBeingHeld = false;
                    Vector3 pos = new Vector3(m_enemyObj.transform.position.x, 1, m_enemyObj.transform.position.z);
                    m_enemyObj.transform.position = pos;

                }
                m_enemyCollider = null;
                m_enemyObj = null;
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
            monsterAnim.GetComponent<Animator>().SetBool("isMoving", true);
        } else {
            monsterAnim.GetComponent<Animator>().SetBool("isMoving", false);
        }

        transform.Translate(movement * m_moveSpeed * Time.deltaTime , Space.World);
    }

    GameObject PickupClosestFlower () {
        GameObject closest = null;
        foreach (FlowerType f in FoxRequest.foxRequest.flowerList) {
            float distance = Vector3.Distance(transform.position, f.gameObject.transform.position);
            //print(f.gameObject.name + "|" + distance);
            if (distance <= maxDistanceToPickup) {
                print(f.gameObject.name);
                if (closest == null)
                    closest = f.gameObject;
                else {
                    if(distance < Vector3.Distance(transform.position, closest.transform.position)) {
                        closest = f.gameObject;
                    }
                }
            }
        }
        
        if (closest != null) {
            //print(closest.name + "|" + Vector3.Distance(transform.position, closest.transform.position));
            return closest;
        }
            
        return null;
    }
}