using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGenerator : MonoBehaviour {

    public GameObject ledge;
    public float gameSpeed = 1;
    

    [SerializeField]
    private float ledgeSpacing = 5;

    float ledgeWidth;
    List<GameObject[]> ledges = new List<GameObject[]>();
    Camera cam;
    Vector2 camSize;
    float i = 0f;


    // Use this for initialization
    void Start () {
        cam = Camera.main;
        camSize = new Vector2(2 * cam.orthographicSize * cam.aspect, 2 * cam.orthographicSize);
        ledgeWidth = ledge.transform.localScale.y;
        i += (-1 * camSize.y / 2) + (ledgeWidth / 2);
        GameObject go = Instantiate(ledge,
            new Vector3(0, i, 0),
            Quaternion.identity);
        go.transform.localScale=new Vector3(camSize.x, ledgeWidth, 1);
        i += ledgeWidth + ledgeSpacing;
        ledges.Add(new GameObject[2] {go,new GameObject() });
        
        //InvokeRepeating("CreateLedge", gameSpeed, gameSpeed);

    }
	
	// Update is called once per frame
	void Update () {
        if (i < cam.transform.position.y + camSize.y / 2)
        {
            ledges.Add(CreateLedge());
        }
        if(ledges[0][0].transform.position.y< cam.transform.position.y - camSize.y / 2f)
        {
            Destroy(ledges[0][0]);
            Destroy(ledges[0][1]);
            ledges.RemoveAt(0);
        }
	}

    public GameObject[] CreateLedge()
    {
        GameObject[] ledges = new GameObject[2];
        Vector3 lscale = new Vector3(Random.Range(0.5f,camSize.x-0.5f), ledgeWidth, 1);
        bool genRight = Random.value > 0.5f ? true : false;
        float locx = (camSize.x / 2) - (lscale.x / 2);
        
        GameObject go = Instantiate(ledge,
            new Vector3(locx, i, 0),
            Quaternion.identity);
        go.transform.localScale = lscale;
        ledges[0] = go;
        
        if (lscale.x < camSize.x - 0.9f)
        {
            float scaleX = camSize.x - lscale.x-0.5f;
            float locX = scaleX / 2 - camSize.x/2;
            go = Instantiate(ledge,
            new Vector3(locX , i, 0),
            Quaternion.identity);
            go.transform.localScale = new Vector3(scaleX, ledgeWidth, 1f);
            ledges[1] = go;
        }
        else
        {
            ledges[1] = new GameObject();
        }
       
        i += ledgeWidth + ledgeSpacing;
        return ledges;
    }
}
