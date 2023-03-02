using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class newPlayerControlls : MonoBehaviour
{      
    [Header("player Things")]
    public int health;
    [Header("Movemietn things")]
    private int moveSpeed = 100;
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
        slideButoon.action.performed += slideing;
    }
    
    private void OnDisable() {
        jumpButoon.action.performed -= jumping;
        slideButoon.action.performed -= slideing;
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
           slide(true,slideTime); 
        }
    }
    private void stopslide(InputAction.CallbackContext obj){
        slide(false,slideTime); 
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

    public void slide(bool StartStop, float time) {
        if(StartStop){
            if(time <= slideTime){
                Debug.Log("sart");
            }
            else if(time >= slideTime){
                Debug.Log("stop time");
            }
        }
        else if(StartStop == false){
            Debug.Log("stop");
        }
    }
    

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(player.velocity.x, 0f, player.velocity.z);

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