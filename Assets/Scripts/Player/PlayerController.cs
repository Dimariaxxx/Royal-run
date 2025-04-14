using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    [SerializeField] float speed=2f;
    [SerializeField] float clamp=4f ;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Move(InputAction.CallbackContext context)
    {
        movement=context.ReadValue<Vector2>();
        
    }
    void Start()
    {
        rb=GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        Vector3 direction=new Vector3(movement.x, 0, movement.y);
        Vector3 targetPos=transform.position + direction * Time.deltaTime*speed;
        targetPos.x=Math.Clamp(targetPos.x, -clamp, clamp);
        targetPos.z=Math.Clamp(targetPos.z, -clamp, clamp);
        rb.MovePosition(targetPos);
    }

}
