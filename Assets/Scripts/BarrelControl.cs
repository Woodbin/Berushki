using UnityEngine;
using System.Collections;

public class BarrelControl : MonoBehaviour {

    private string levelName;
    private Level_Control lc;
    private Vector3 pos;
    private Transform tr;

    //grid movement variables
    private float moveSpeed = 960f;
    private float gridSize = 32f;
    private enum Orientation { Horizontal, Vertical };
    private Orientation gridOrientation = Orientation.Horizontal;
    private bool allowDiagonals = false;
    private bool correctDiagonalSpeed = true;
    private Vector2 input;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float t;
    private float factor;

	// Use this for initialization
	void Start () {
        levelName = "mapa_pro_pohyb";
        lc = GameObject.Find(levelName).GetComponent<Level_Control>();
        tr = gameObject.transform;
        pos = transform.position;
	}


    public IEnumerator move(Transform transform)
    {
        
        isMoving = true;
        startPosition = transform.position;
        t = 0;

        if (gridOrientation == Orientation.Horizontal)
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                                      startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
        }
        else
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                                      startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
        }

        if (allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0)
        {
            factor = 0.7071f;
        }
        else
        {
            factor = 1f;
        }

        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        isMoving = false;

    }


    private Vector2 getVector(int direction)
    {
        Vector2 ret = new Vector2();
        switch (direction)
        {
            case 0: //right
                ret[0] = 1;
                ret[1] = 0;
                break;
            case 1: //left
                ret[0] = -1;
                ret[1] = 0;
                break;
            case 2: //up y+
                ret[0] = 0;
                ret[1] = 1;
                break;
            case 3: //down y-
                ret[0] = 0;
                ret[1] = -1;
                break;
        }
        return ret;
    }



    public bool push(int to)
    {
        
        bool success = false;
        pos = transform.position;

        if (!lc.prediction(pos.x, pos.y, to))
        {
            input = getVector(to);
            StartCoroutine(move(transform));
            success = true;
        }
        Debug.Log("Push " + to + " : " + success);
        return success;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
