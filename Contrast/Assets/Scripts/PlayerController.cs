using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveSpeed;

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

        Vector3 movement = new Vector3(moveHorizontal , 0f , moveVertical);

        if(movement.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        transform.Translate(movement * m_moveSpeed * Time.deltaTime , Space.World);
    }
}