using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
  public float moveSpeed;
  public Rigidbody2D myRigibody;
  private bool moving;
  public float timeBetweenMove;
  public float timeToMove;
  private float timeBetweenMoveCounter;
  private float timeToMoveCounter;
  private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()  {

      myRigibody = GetComponent<Rigidbody2D>();
      timeBetweenMoveCounter = timeBetweenMove;
      timeToMoveCounter = timeToMove;

    }

    // Update is called once per frame
    void Update(){

      if (moving) {
        timeToMoveCounter -= Time.deltaTime;
        myRigibody.velocity = moveDirection;

        if (timeToMoveCounter < 0f) {
          moving = false;
          timeBetweenMoveCounter = timeBetweenMove;
        }

      }else{
         timeBetweenMoveCounter -= Time.deltaTime;
         myRigibody.velocity = Vector2.zero;
         if (timeBetweenMoveCounter < 0f) {
           moving = true;
           timeToMoveCounter = timeToMove;

           moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f)* moveSpeed, 0f);
         }
      }

    }
}
