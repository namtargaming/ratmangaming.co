using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class newPlayerControlls : MonoBehaviour
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
{      
    [Header("player Things")]
    public int health;
    [Header("Movemietn things")]
    private int moveSpeed = 90;
=======
=======
>>>>>>> parent of 28169a78 (start slideing)
=======
>>>>>>> parent of 28169a78 (start slideing)
{   
    public Transform camera;
    public int moveSpeed;
>>>>>>> parent of 28169a78 (start slideing)
    public int speedLimit;
    private int rotateSpeed = 30;
    [Header("Jumping")]
    public int JumpHight;
    public float hightOfPlayer;
    [Header("Slideing")]
    public float slideTime;
    public float slideHight;
    [Header("GameObjects")]
    public Transform camera;
    public CapsuleCollider playerColishon;
    public LayerMask whatIsGround;
    public PhysicMaterial phisucsMatersl;
    
    private bool OnFloor;
    private Rigidbody player;
    private Vector2 joystickInput;
    private Vector2 rightJoystickInput;
    private Vector3 movement;
    private Vector3 movementAngle;
    private Vector3 camreaForward2d;
    private Vector3 camreaRight2d;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    private Animator anim;
    
=======
>>>>>>> parent of 28169a78 (start slideing)
=======
>>>>>>> parent of 28169a78 (start slideing)
=======
>>>>>>> parent of 28169a78 (start slideing)
    [SerializeField]
    private InputActionReference jumpButoon, leftJoystick, rightJoystick;

    private void Start() {
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody>();
        anim.enabled = true;
    }

    void OnCollisionEnter(Collision collision){
     if(collision.gameObject.tag == ("enime"))
     {
        health -= 1; 
     }
    }
    private void OnEnable() {
        jumpButoon.action.performed += jumping;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        slideButoon.action.performed += slideing;
=======
>>>>>>> parent of 28169a78 (start slideing)
=======
>>>>>>> parent of 28169a78 (start slideing)
=======
>>>>>>> parent of 28169a78 (start slideing)
    }
    
    private void OnDisable() {
        jumpButoon.action.performed -= jumping;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        slideButoon.action.performed -= slideing;
=======
>>>>>>> parent of 28169a78 (start slideing)
=======
>>>>>>> parent of 28169a78 (start slideing)
=======
>>>>>>> parent of 28169a78 (start slideing)
    }

    private void Update() {
        camreaForward2d = new Vector3(camera.forward.x, 0.0f, camera.forward.z); 
        camreaRight2d = new Vector3(camera.right.x, 0.0f, camera.right.z); 
        joystickInput = leftJoystick.action.ReadValue<Vector2>();
        rightJoystickInput = rightJoystick.action.ReadValue<Vector2>();
        OnFloor = Physics.Raycast(transform.position + new Vector3(0,0,0), Vector3.down, hightOfPlayer, whatIsGround);
        movement = camreaForward2d * joystickInput.y + camreaRight2d * joystickInput.x;
        playerColishon.center = new Vector3(camera.localPosition.x, 0.84f, camera.localPosition.z);
        SpeedControl();
        if(health <= 0){
            die();
        }
        if(OnFloor == false){
            moveSpeed =  50;
        }
        if(OnFloor == true){
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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    private void slideing(InputAction.CallbackContext obj){
        if(OnFloor){
           slide(true,slideTime); 
        }
    }
    private void stopslide(InputAction.CallbackContext obj){
        slide(false,slideTime); 
    }
=======
=======
>>>>>>> parent of 28169a78 (start slideing)
=======
>>>>>>> parent of 28169a78 (start slideing)
//    private void slide(InputAction.CallbackContext obj){
//        if(OnFloor){
//
//        }
//    }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 28169a78 (start slideing)
=======
>>>>>>> parent of 28169a78 (start slideing)
=======
>>>>>>> parent of 28169a78 (start slideing)

    public void jump(int hight) {
        player.AddForce(0,hight,0);
    }

    public void moveplayer(Vector3 joysticInput) {
        player.AddForce(joysticInput * moveSpeed);
    }
    public void rotateplayer(Vector3 joysticInput) {
        transform.RotateAround(camera.position, new Vector3(0,1,0), joysticInput.x * 0.1f * rotateSpeed);
    }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public void slide(bool StartStop, float time) {
        if(StartStop){
            //anim.Play("Base Layer.Sliding", 0 ,0.0f);
            if(time <= slideTime){
                //phisucsMatersl.dynamicFriction = 0;
                //rotateSpeed = 0;
                //slideTime += 1 * TimeDelta.Time;
                Debug.Log("sart");
            }
            else if(time >= slideTime){
                //phisucsMatersl.dynamicFriction = 3;
                //rotateSpeed = 30;
                Debug.Log("stop time");
            }
        }
        else if(StartStop == false){
            //anim.Play("Base Layer.StopSliding", 0 ,0.0f);
            Debug.Log("stop");
        }
    }
    

=======
//    public void slide() {
//
//    }
>>>>>>> parent of 28169a78 (start slideing)
=======
//    public void slide() {
//
//    }
>>>>>>> parent of 28169a78 (start slideing)
=======
//    public void slide() {
//
//    }
>>>>>>> parent of 28169a78 (start slideing)
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(player.velocity.x, 0f, player.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > speedLimit)
        {
            Vector3 limitedVel = flatVel.normalized * speedLimit;
            player.velocity = new Vector3(limitedVel.x, player.velocity.y, limitedVel.z);
        }
    }

    public void die(){
        SceneManager.LoadScene("main");
    }
}