using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickScript : MonoBehaviour
{
    public float maxAngle = 30;
    public float speed = 1f * 200;
    public float pushForce = 10;

    private bool m_isDown = false;
    public void Down()
    {
        m_isDown = false;        
    }
    public void Up()
    {
        m_isDown = true;
    }

    private void FixedUpdate()
    {

        var angle = transform.localEulerAngles;
        if (m_isDown)
        {
            angle.z = Mathf.MoveTowardsAngle(angle.z, -maxAngle, speed * Time.fixedDeltaTime);
        }
        else
        {
            angle.z = Mathf.MoveTowardsAngle(angle.z, +maxAngle, speed * Time.fixedDeltaTime);
        }
        transform.localEulerAngles = angle;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided");
        if (other.rigidbody != null) {
            var contact = other.contacts[0];
            other.rigidbody.AddForce(-contact.normal, ForceMode.Impulse);
        }
    }


}
