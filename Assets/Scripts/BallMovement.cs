using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float speedX = 0;
    [SerializeField] float speedY = 0;

    [SerializeField] Camera mainCamera;

    void Start()
    {
        speedX = 8;
        speedY = 6;
        mainCamera = Camera.main;

        initialMovement();    
    }

    void Update()
    {
        move();      
    }

    private void initialMovement(){
        if(Random.Range(-1f, 1f) < 0){
            speedX *= -1;
        }
        if(Random.Range(-1f, 1f) < 0){
            speedY *= -1;
        }
        gameObject.transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0.0f);
    }

    private void move() {
        gameObject.transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0.0f);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("bottom_field") || collision.gameObject.CompareTag("top_field")){
            speedY *= -1;  
        }

        if(collision.gameObject.CompareTag("side_field") || collision.gameObject.CompareTag("Player")){
            speedX *= -1;
        }

        if(collision.gameObject.CompareTag("goal")){
            speedX = 0;
            speedY = 0;
            
            mainCamera.GetComponent<Goal>().GoalTime(collision);
        }
    }
}
