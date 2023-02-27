using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class newPlayerControlls : MonoBehaviour
{   
    public Transform camera;
    public int moveSpeed;
    public int JumpHight;
    public int hightOfPlayer;
    public int health;
    private bool OnFloor;
    private Rigidbody player;
    public LayerMask whatIsGround;
    private Vector2 joystickInput;
    private Vector3 movement;
    private Vector3 movementAngle;
    private Vector3 camreaForward2d;
    private Vector3 camreaRight2d;
    [SerializeField]
    private InputActionReference jumpButoon, leftJoystick;

    private void Start() {
        player = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
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
        camreaForward2d = new Vector3(camera.forward.x, 0.0f, camera.forward.z); 
        camreaRight2d = new Vector3(camera.right.x, 0.0f, camera.right.z); 
        joystickInput = leftJoystick.action.ReadValue<Vector2>();
        OnFloor = Physics.Raycast(transform.position + new Vector3(0,1,0), Vector3.down, hightOfPlayer, whatIsGround);
        movement = camreaForward2d * joystickInput.y + camreaRight2d * joystickInput.x;
        
        if(health <= 0){
            die();
        }
    }
    private void FixedUpdate() {
        moveplayer(movement);
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
    }

    public void moveplayer(Vector3 joysticInput) {
        player.AddForce(joysticInput * moveSpeed);
    }

//    public void slide() {
//
//    }

    public void die(){
        SceneManager.LoadScene("main");
    }
}
