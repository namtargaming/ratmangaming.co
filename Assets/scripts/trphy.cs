using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class trphy : MonoBehaviour
{   

    [SerializeField]
    // Start is called before the first frame update

   void OnTriggerEnter(Collider collision){
     if(collision.gameObject.tag == ("Player"))
     {
        SceneManager.LoadScene("end"); 
     }
    }


}
