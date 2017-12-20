using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public float accel = 10f;
    public float jumpHeight = 1.0f;
    public ForceMode fMoveMode = ForceMode.Force;
    public ForceMode fJumpMode = ForceMode.VelocityChange;

    public bool moveR = false;
    public bool moveL = false;
    public bool grounded = false;
    Rigidbody objTr;
    float deltaTime = 0;

	// Use this for initialization
	void Start () {
        objTr = gameObject.GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D) && !moveL)
        {
            deltaTime = 0f;
            moveR = true;
            //objTr.AddForce(moveSpeed, 0, 0,fMoveMode);
            //objTr.transform.Translate(moveSpeed, 0, 0);
            objTr.velocity = new Vector3(moveSpeed, 0, 0);
        }
        else if(Input.GetKey(KeyCode.D) && moveR)
        {
            deltaTime += Time.deltaTime;
            deltaTime *= (1 / accel);
            if (deltaTime > 1)
                deltaTime = 1;
            //objTr.velocity = new Vector3(moveSpeed * deltaTime, 0, 0);
        }
        else if (Input.GetKeyUp(KeyCode.D) && moveR)
        {
            objTr.velocity = new Vector3(0, objTr.velocity.y, 0);
            //objTr.AddForce(moveSpeed * -1, 0,0, fMoveMode);
            moveR = false;
        }

        if (Input.GetKeyDown(KeyCode.A) && !moveR)
        {
            deltaTime = 0;
            moveL = true;
            //objTr.AddForce(moveSpeed * -1 , 0, 0, fMoveMode);
            objTr.velocity = new Vector3(moveSpeed * -1, 0, 0);
        }
        else if(Input.GetKey(KeyCode.A) && moveL)
        {
            deltaTime += Time.deltaTime;
            deltaTime *= (1 / accel);
            if (deltaTime > 1)
                deltaTime = 1;
            
            //objTr.velocity = new Vector3(moveSpeed * deltaTime *-1, 0, 0);
        }
        else if (Input.GetKeyUp(KeyCode.A) && moveL)
        {
            //objTr.AddForce(moveSpeed, 0,0 , fMoveMode);
            objTr.velocity = new Vector3(0, objTr.velocity.y, 0);

            moveL = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            objTr.AddForce(0,jumpHeight,0, fJumpMode);
        }

        if(!moveL && !moveR)
        {
            objTr.velocity = new Vector3(0,objTr.velocity.y,0);
        }
    }
}
