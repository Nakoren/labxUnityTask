using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickScript : MonoBehaviour
{
    public float maxAngle = 30;
    public float speed = 1f * 200;
    public float pushForce = 10;
    private Vector3 prevFramePosition = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
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
        
        Vector3 currentFramePosition = transform.position;
        moveDirection = (currentFramePosition - prevFramePosition).normalized;
        prevFramePosition = currentFramePosition;

        transform.localEulerAngles = angle;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided");
        if (other.gameObject.TryGetComponent<StoneScript>(out var stone)) {
            var contact = other.contacts[0];
            Vector3 impulseDirection = -contact.normal + moveDirection;
            other.rigidbody.AddForce(impulseDirection, ForceMode.Impulse);
            //здесь вызвать метод у камня, чтобы он пометился
        }
    }
}
