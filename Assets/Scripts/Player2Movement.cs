using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private float speed = 4f;

    private bool move_up = false;
    private bool move_down = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            move_up = true;
            
        } else if(Input.GetKeyUp(KeyCode.UpArrow)){
            move_up = false;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){
            move_down = true;
            
        } else if(Input.GetKeyUp(KeyCode.DownArrow)){
            move_down = false;
        }
        if (Time.timeScale >= 0) {
            move();
        }
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
