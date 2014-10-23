using UnityEngine;
using System.Collections;

public class BugSpriteTransformScript : MonoBehaviour {

	public bool facingRight = true;
	public bool facingUp = true;
	private float movex=0;
	private float movey=0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if(movex>0&&!facingRight) flipX();
		else if(movex<0&&facingRight) flipX();
		if(movey>0&&!facingUp) flipY();
		else if(movey<0&&facingUp) flipY();*/

		if(movex>0) setDirection(3);
		if(movex<0) setDirection(1);
		if(movey>0) setDirection(0);
		if(movey<0) setDirection(2);


	}

	void FixedUpdate(){

		if(Input.GetAxis("Horizontal")>0) movex= Mathf.Ceil(Input.GetAxis("Horizontal"));
		else 		movex= Mathf.Floor(Input.GetAxis("Horizontal"));
		if(Input.GetAxis("Vertical")>0) movey= Mathf.Ceil(Input.GetAxis("Vertical"));
		else 		movey= Mathf.Floor(Input.GetAxis("Vertical"));
	}


	void flipX(){
		facingRight = !facingRight;
		float rot = 90;
		if(facingRight) rot*=-1f;
		transform.localEulerAngles = new Vector3(0,0,rot);
		
	}



	void flipY(){
		facingUp = !facingUp;
		Vector3 scale = transform.localScale;
		scale.y *=-1;
		transform.localScale=scale;
	}

	void setDirection(int dir){

		switch(dir){
		case 0: transform.localEulerAngles = new Vector3(0,0,0); break;
		case 1:	transform.localEulerAngles = new Vector3(0,0,90); break;
		case 2: transform.localEulerAngles = new Vector3(0,0,180); break;
		case 3: transform.localEulerAngles = new Vector3(0,0,270); break;
		default: transform.localEulerAngles = new Vector3(0,0,0); break;
		}
	}
}
