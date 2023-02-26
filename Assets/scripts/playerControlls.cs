using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class playerControlls : MonoBehaviour
{
    public int JumpHight;
    public int health;
    public bool OnFloor = true;
    private Rigidbody player;
    [SerializeField]
    private InputActionReference jumpButoon, LeftJoystick;

    private void Start() {
        player = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
     if (collision.gameObject.tag == "florr")
     {
        OnFloor = true;
     }
     if(collision.gameObject.tag == ("enime"))
     {
        health -= 1; 
     }
    }
    private void OnEnable() {
        jumpButoon.action.performed += jumping;
    }
    
    private void OnDisable() {
        jumpButoon.action.performed -= jumping;
    }

    private void Update() {

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        if(health <= 0){
            die();
        }
    }

    private void jumping(InputAction.CallbackContext obj){
        if(OnFloor){
            jump();
        }
    }

//    private void slide(InputAction.CallbackContext obj){
//        if(OnFloor){
//
//        }
//    }

    public void jump() {
        player.AddForce(0,JumpHight,0);
        OnFloor = false;
    }

//    public void slide() {
//
//    }

    public void die(){
        SceneManager.LoadScene("main");
    }
}