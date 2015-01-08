using UnityEngine;
using System.Collections;

public class DestroyableWallControl : MonoBehaviour {

    private string levelName;
    private Level_Control lc;
    private Transform tr;
    private Vector2 pos;
	// Use this for initialization
	void Start () {
        levelName = "mapa_pro_pohyb";
        lc = GameObject.Find(levelName).GetComponent<Level_Control>();
        tr = gameObject.transform;
        pos = transform.position;
        lc.setBlockAt(pos.x, pos.y, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void tearDown()
    {
        lc.setBlockAt(pos.x, pos.y, 2);
        Destroy(gameObject);
    }
}
