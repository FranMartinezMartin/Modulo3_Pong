using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botPlayer : MonoBehaviour
{
     private float speed = 3.5f;

    private bool move_up = false;
    private bool move_down = false;

    [SerializeField] GameObject ball;

    void Start() {
        findBall();
    }

    void Update()
    {
        findBall();

        move();
        move_up = false;
        move_down = false;   
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

    private void findBall() {
        if (GameObject.FindGameObjectWithTag("ball") == true) {
            ball = GameObject.FindGameObjectWithTag("ball");

            if (ball.transform.position.y > gameObject.transform.position.y) {
                move_up = true;
            } else if(ball.transform.position.y < gameObject.transform.position.y) {
                move_down = true;
            }
        }        
    }
}
