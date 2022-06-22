using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject gameBall;
    [SerializeField] GameObject scoreboard;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    [SerializeField] int player1_goal = 0;
    [SerializeField] int player2_goal = 0;

    void Start()
    {
        createBall();
    }

    private void createBall(){
        gameBall = GameObject.Instantiate(ball, new Vector3(2.5f, 3.5f, 1f), Quaternion.identity);

        BallMovement ballMovement = gameBall.GetComponent<BallMovement>();
        Rigidbody rb = gameBall.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    public void GoalTime(Collision collision){  
        if(collision.gameObject.name == "Goal1"){
            ++player2_goal;
            if(player2_goal == 3){
                Destroy(gameBall);
                scoreboard.GetComponent<TextMesh>().text = "Player2 Win";
                scoreboard.transform.position = new Vector3(2.5f, 3.5f, 1f);
            } else {
                scoreboard.GetComponent<TextMesh>().text = player1_goal + " : " + player2_goal;
                StartCoroutine(goalCelebration());
            }
        }

        if(collision.gameObject.name == "Goal2"){
            ++player1_goal;
            if(player1_goal == 3){
                Destroy(gameBall);
                scoreboard.GetComponent<TextMesh>().text = "Player1 Win";
                scoreboard.transform.position = new Vector3(2.5f, 3.5f, 1f);
            } else {
                scoreboard.GetComponent<TextMesh>().text = player1_goal + " : " + player2_goal;
                StartCoroutine(goalCelebration());
            }
        }
    }

    IEnumerator goalCelebration(){
        yield return new WaitForSeconds(2.5f);
        Destroy(gameBall);
        yield return new WaitForSeconds(0.5f);
        createBall();
        player1.transform.position = new Vector3(-5.75f,3.5f,0.0f);
        player2.transform.position = new Vector3(10.75f,3.5f,0.0f);
    }
}
