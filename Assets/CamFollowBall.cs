using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CamFollowBall : MonoBehaviour {

    public Transform ball;
    public float speed = 1.0f;
    public GameObject gameOver;
    bool gameEnded = false;

    Vector2 camSize;
    Camera cam;
    private float ballYPosToCam = 0;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        camSize = new Vector2(2 * cam.orthographicSize * cam.aspect, 2 * cam.orthographicSize);
    }
	
	// Update is called once per frame
	void Update () {

        if (gameEnded)
            return;

        if (ball.position.y > transform.position.y)
            transform.Translate(Vector3.up * speed * Time.deltaTime);

        if(ball.position.y< transform.position.y-camSize.y/2 || ball.position.y > transform.position.y + camSize.y/2)
        {
            print("out of bound!" + ball.position);
            gameOver.SetActive(true);
            ball.GetComponent<Rigidbody>().isKinematic = true;
            gameEnded = true;
        }
        if(ball.position.x+ball.localScale.x/2 < transform.position.x-camSize.x/2 || ball.position.x - ball.localScale.x / 2 > transform.position.x + camSize.x / 2)
        {
            print("out of bound!" + ball.position);
            gameOver.SetActive(true);
            ball.GetComponent<Rigidbody>().isKinematic = true;
            gameEnded = true;
        }

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
