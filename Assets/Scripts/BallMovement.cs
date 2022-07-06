using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float speedX = 0;
    [SerializeField] float speedY = 0;

    [SerializeField] Camera mainCamera;
    [SerializeField] Rigidbody rb;

    [SerializeField] private int seconds;
    private int s;
    public AudioSource audioSource;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        mainCamera = Camera.main;

        initialMovement();   
        Invoke("updateTimer", 1f); 
    }
    void FixedUpdate() {
        rb.velocity = new Vector3(speedX, speedY, 0);
    }

    private void initialMovement(){
        int direction;

        do{
            direction = Random.Range(-1,1);
            if (direction < 0) {
                speedX = -Random.Range(1.0f,2.0f)*10;
            } else if (direction > 0) {
                speedX = Random.Range(1.0f,2.0f)*10;
            }           
        }while(direction == 0);

        do{
            direction = Random.Range(-1,1);
            if (direction < 0) {
                speedY = -Random.Range(1.0f,2.0f)*10;
            } else if (direction > 0) {
                speedY = Random.Range(1.0f,2.0f)*10;
            }
        }while(direction == 0);
    }
    
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("field") || collision.gameObject.CompareTag("Player")) {
            transform.GetComponent<Sounds>().collision_sound();
                        
            float force = 3;
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            dir *= force;
            if(System.Math.Pow(dir.y,2)  > System.Math.Pow(dir.x,2)) {
                speedY *= -1;
            }
            if(System.Math.Pow(dir.y,2) < System.Math.Pow(dir.x,2)) {
                speedX *= -1;
            }
        }
        
        if(collision.gameObject.CompareTag("goal")){
            speedX = 0;
            speedY = 0;
            
            stopTimer();
            mainCamera.GetComponent<Goal>().GoalTime(collision);
        }
    }

    public void stopTimer(){
        CancelInvoke();
    }

    public void updateTimer(){
        s++;
        if (s == 10){
            speedX *= 1.75f;
            speedY *= 1.75f;
            s = 0;
        }

        Invoke("updateTimer", 1f);
    }
}
