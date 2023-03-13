using System.Collections;
using System.Collections.Generic;
using System;using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class newPlayerControlls : MonoBehaviour
{      
    [Header("player Things")]
    public int health;
    private float Hight = 0f;
    private float HitBoxHight = 1.7f;
    [Header("Movemietn things")]
    private int moveSpeed = 100;
    public int speedLimit;
    private int rotateSpeed = 30;
    [Header("Jumping")]
    public int JumpHight;
    public float hightOfPlayer;
    [Header("Slideing")]
    public float slideAddVelosity;
    private float slideHight = -0.35f;
    private float slideHitBoxHight = 1f;
    [Header("GameObjects")]
    public Transform camera;
    public CapsuleCollider playerColishon;
    public LayerMask whatIsGround;
    public PhysicMaterial phisucsMatersl;
    public Transform testcube;
    public Camera cameraObject;
    private bool OnFloor;
    private Rigidbody player;
    private Vector2 joystickInput;
    private Vector2 rightJoystickInput;
    private Vector3 movement;
    private Vector3 movementAngle;
    private Vector3 camreaForward2d;
    private Vector3 camreaRight2d;
    private bool slidng = false;
    private float hightDifrents;
    private Vector3 flatVel;
    private Vector3 absalutevelosity;
    private int setmoveSpeed = 100; 


    [SerializeField]
    private InputActionReference jumpButoon, leftJoystick, rightJoystick, slideButoon;

    private void Start() {
        player = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision){
     if(collision.gameObject.tag == ("enime"))
     {
        health -= 1; 
     }
    }
    private void OnEnable() {
        jumpButoon.action.performed += jumping;
        slideButoon.action.started += slideing;
        slideButoon.action.canceled += stopslide;
    }
    
    private void OnDisable() {
        jumpButoon.action.performed -= jumping;
        slideButoon.action.started -= slideing;
        slideButoon.action.canceled -= stopslide;
    }

    private void Update() {
        cameraObject.fieldOfView = 150;
        camreaForward2d = new Vector3(camera.forward.x, 0.0f, camera.forward.z); 
        camreaRight2d = new Vector3(camera.right.x, 0.0f, camera.right.z); 
        joystickInput = leftJoystick.action.ReadValue<Vector2>();
        rightJoystickInput = rightJoystick.action.ReadValue<Vector2>();
        OnFloor = Physics.Raycast(new Vector3(camera.position.x,transform.position.y + hightDifrents,camera.position.z), Vector3.down, hightOfPlayer, whatIsGround);
        movement = camreaForward2d * joystickInput.y + camreaRight2d * joystickInput.x;
        playerColishon.center = new Vector3(camera.localPosition.x, 0.84f, camera.localPosition.z);
        testcube.position = new Vector3(camera.position.x,transform.position.y + hightDifrents,camera.position.z);
        absalutevelosity = new Vector3(Math.Abs(player.velocity.x), Math.Abs(player.velocity.y), Math.Abs(player.velocity.z));
        SpeedControl();
        if(health <= 0){
            die();
        }
        if(slidng){
            hightDifrents = -slideHight;
        }
        else if(slidng == false){
            hightDifrents = Hight;
        }
        if(OnFloor == false && slidng == false){
            moveSpeed = 20;
        }
        else if(OnFloor == true && slidng == false){
            moveSpeed = 100;
        }
    }
    private void FixedUpdate() {
        moveplayer(movement);
        rotateplayer(rightJoystickInput);   
    }

    private void jumping(InputAction.CallbackContext obj){
        if(OnFloor){
            jump(JumpHight);
        }
    }

    private void slideing(InputAction.CallbackContext obj){
        if(OnFloor){
           slide(); 
        }
    }
    private void stopslide(InputAction.CallbackContext obj){
        playerColishon.height = HitBoxHight;
        transform.SetLocalPositionAndRotation(new Vector3(transform.localPosition.x , transform.localPosition.y + Hight , transform.localPosition.z), transform.localRotation);
        slidng = false;
        moveSpeed = setmoveSpeed;
        JumpHight = 10;
    }

    public void jump(int hight) {
        player.velocity = new Vector3(player.velocity.x,hight,player.velocity.z);
    }

    public void moveplayer(Vector3 joysticInput) {
        player.AddForce(joysticInput * moveSpeed);
    }
    public void rotateplayer(Vector3 joysticInput) {
        transform.RotateAround(camera.position, new Vector3(0,1,0), joysticInput.x * 0.1f * rotateSpeed);
    }

    public void slide() {
        playerColishon.height = slideHitBoxHight;
        transform.SetLocalPositionAndRotation(new Vector3(transform.localPosition.x , transform.localPosition.y + slideHight , transform.localPosition.z), transform.localRotation);
        moveSpeed = setmoveSpeed / 10;
        JumpHight = 4;
        if(flatVel.magnitude > 5 && slidng == false){
            slidng = true;
            player.AddForce(camreaForward2d * slideAddVelosity);
        }
    }
    

   private void SpeedControl()
   {
       flatVel = new Vector3(player.velocity.x, 0f, player.velocity.z);
       if(flatVel.magnitude > speedLimit && slidng == false)
       {
           Vector3 limitedVel = flatVel.normalized * speedLimit;
           player.velocity = new Vector3(limitedVel.x, player.velocity.y, limitedVel.z);
       }
   }

    public void die(){
        SceneManager.LoadScene("main");
    }
}