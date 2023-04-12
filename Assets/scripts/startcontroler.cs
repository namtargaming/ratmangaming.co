using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class startcontroler : MonoBehaviour
{   

    public bool hovoring = false;
    public string sean;
    [SerializeField]
    private InputActionReference startbutton;
    // Start is called before the first frame update

    private void OnEnable() {
        startbutton.action.performed += startGame;
    }
    
    private void OnDisable() {
        startbutton.action.performed -= startGame;
    }
    private void startGame(InputAction.CallbackContext obj){
        if (hovoring == true){
            SceneManager.LoadScene(sean); 
        }
    }
    public void hooving(){
        hovoring = true;
    }
    public void nothooving(){
        hovoring = false;
    }

}
