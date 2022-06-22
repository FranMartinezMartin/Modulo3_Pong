using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    private float speed = 2f;

    private bool move_up = false;
    private bool move_down = false;

    void Start() {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            move_up = true;
            
        } else if(Input.GetKeyUp(KeyCode.W)){
            move_up = false;
        }

        if(Input.GetKeyDown(KeyCode.S)){
            move_down = true;
            
        } else if(Input.GetKeyUp(KeyCode.S)){
            move_down = false;
        }
        move();
    }

    private void move(){
        if(move_up == true){
            transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
        }
        if(move_down == true){
            transform.Translate(0.0f, -speed * Time.deltaTime, 0.0f);
        }
    }

    private void OnCollisionEnter(Collision collision) {        
        if(collision.gameObject.CompareTag("field")){
            move_up = false;
            move_down = false;
        }
    }
}
