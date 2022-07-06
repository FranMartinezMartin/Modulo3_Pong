using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject gameBall;
    [SerializeField] TextMeshProUGUI scoreboard;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    [SerializeField] int player1_goal = 0;
    [SerializeField] int player2_goal = 0;
    

    void Start()
    {
        createBall();
    }

    private void createBall(){
        gameBall = GameObject.Instantiate(ball, new Vector3(0, 0, -0.6f), Quaternion.identity);
        gameBall.transform.localScale = new Vector3(8,8,8);

        BallMovement ballMovement = gameBall.GetComponent<BallMovement>();
        Rigidbody rb = gameBall.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    public void GoalTime(Collision collision){  
        goalSound();
        if(collision.gameObject.name == "Goal1"){
            ++player2_goal;
            if(player2_goal == 10){
                Destroy(gameBall);
                scoreboard.text = "Player2 Win";
                victorySound();
                scoreboard.transform.position = new Vector3(0, 0, -0.6f);
            } else {
                scoreboard.text = player1_goal + " : " + player2_goal;
                StartCoroutine(goalCelebration());
            }
        }

        if(collision.gameObject.name == "Goal2"){
            ++player1_goal;
            if(player1_goal == 10){
                Destroy(gameBall);
                scoreboard.text = "Player1 Win";
                victorySound();
                scoreboard.transform.position = new Vector3(0, 0, -0.6f);
            } else {
                scoreboard.text = player1_goal + " : " + player2_goal;
                StartCoroutine(goalCelebration());
            }
        }
    }

    IEnumerator goalCelebration(){
        yield return new WaitForSeconds(5f);
        Destroy(gameBall);
        yield return new WaitForSeconds(0.5f);
        createBall();
        player1.transform.position = new Vector3(-15, 0, -0.5f);
        player2.transform.position = new Vector3(15, 0, -0.5f);
    }

    void goalSound(){
        gameBall.GetComponent<Sounds>().goal_sound_clip();
    }

    void victorySound(){
        gameBall.GetComponent<Sounds>().victorySound();
    }
}
