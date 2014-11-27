using UnityEngine;
using System.Collections;

public class BugControlScript : MonoBehaviour {
	//public float step = 16;
	private float moveSpeed = 96f;
	private float gridSize = 32f;
	private enum Orientation { Horizontal, Vertical};
	private Orientation gridOrientation = Orientation.Horizontal;
	private bool allowDiagonals = false;
	private bool correctDiagonalSpeed = true;
	private Vector2 input;
	private bool isMoving = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float t;
	private float factor;
	//public float rayCastLength = 16;
/*	private float movex=0;
	private float movey=0;*/
	private Vector3 pos ;
	private Transform tr;
	public bool rayState;
	private Level_Control lc;
	private string levelName;

	// Use this for initialization
	void Start () {
		levelName = "mapa_pro_pohyb";
	tr = gameObject.transform;
		pos = transform.position;
		lc = GameObject.Find(levelName).GetComponent<Level_Control>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isMoving){
			input = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
			pos = transform.position;
			bool ray = false;
			if(input.x>0&&input.y==0) ray = lc.prediction(pos.x,pos.y,0);
			if(input.x<0&&input.y==0) ray = lc.prediction(pos.x,pos.y,1);
			if(input.y>0&&input.x==0) ray = lc.prediction(pos.x,pos.y,2);
			if(input.y<0&&input.x==0) ray = lc.prediction(pos.x,pos.y,3);
			rayState = ray;
			if(!allowDiagonals){

				if(Mathf.Abs(input.x) > Mathf.Abs(input.y)){
					input.y=0;
				}else{
					input.x=0;				
				}
			}
			if((input!= Vector2.zero)&&(!ray)){
				StartCoroutine(move(transform));
			}
		

		}
		gameObject.GetComponent<Animator>().SetFloat("speed",Mathf.Abs(input.x+input.y));

	}
	/*
	void FixedUpdate(){
		/*if(Input.GetAxis("Horizontal")>0) movex= Mathf.Ceil(Input.GetAxis("Horizontal"));
		else 		movex= Mathf.Floor(Input.GetAxis("Horizontal"));
		if(Input.GetAxis("Vertical")>0) movey= Mathf.Ceil(Input.GetAxis("Vertical"));
		else 		movey= Mathf.Floor(Input.GetAxis("Vertical"));
		gameObject.GetComponent<Animator>().SetFloat("speed",0);
		Vector3 oldPos = new Vector3(pos.x,pos.y,pos.z);
		

		if((tr.position==pos)){
			gameObject.GetComponent<Animator>().SetFloat("speed",Mathf.Abs(0));

			if(movex>0&&movey==0){
				pos+=Vector3.right*step;
				
			}else if(movex<0&&movey==0){
					pos+=Vector3.left*step;
				
			}else if(movey>0&&movex==0){

					pos+=Vector3.up*step;
				
			}else if(movey<0&&movex==0){

					pos+=Vector3.down*step;
				
			}
		}
		if(ray) pos=oldPos;
		transform.position= Vector3.MoveTowards(transform.position,pos, Time.deltaTime*moveSpeed);

		
	}*/

	public IEnumerator move(Transform transform){
		isMoving = true;
		startPosition = transform.position;
		t = 0;
		
		if(gridOrientation == Orientation.Horizontal) {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                                      startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
		} else {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
			                          startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
		}
		
		if(allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) {
			factor = 0.7071f;
		} else {
			factor = 1f;
		}
		
		while (t < 1f) {
			t += Time.deltaTime * (moveSpeed/gridSize) * factor;
			transform.position = Vector3.Lerp(startPosition, endPosition, t);
			yield return null;
		}
		
		isMoving = false;

}
	void OnTriggerEnter2D(Collider2D c){
        if (c.gameObject.name == "barrel")
        {
            moveBarrel(c);
        }
	}

    private void moveBarrel(Collider2D c)
    {
        Debug.Log("collision");
        BarrelControl bc = c.gameObject.GetComponent<BarrelControl>();
        bool barrelMoved=false;
        if (input.x > 0 && input.y == 0) barrelMoved = bc.push(0);
        if (input.x < 0 && input.y == 0) barrelMoved = bc.push(1);
        if (input.y > 0 && input.x == 0) barrelMoved = bc.push(2);
        if (input.y < 0 && input.x == 0) barrelMoved = bc.push(3);
        if (!barrelMoved) StopCoroutine(move(transform));
    }



	public void setPosition(float x, float y){
		gameObject.transform.Translate(x,y,0);
	}
}