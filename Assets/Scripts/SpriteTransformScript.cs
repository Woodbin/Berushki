using UnityEngine;
using System.Collections;

public class SpriteTransformScript : MonoBehaviour {

	public bool facingRight = false;
	public bool facingUp = false;
	private float movex=0;
	private float movey=0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(movex>0&&!facingRight) flipX();
		else if(movex<0&&facingRight) flipX();
		if(movey>0&&!facingUp) flipY();
		else if(movey<0&&facingUp) flipY();
	}

	void FixedUpdate(){

		if(Input.GetAxis("Horizontal")>0) movex= Mathf.Ceil(Input.GetAxis("Horizontal"));
		else 		movex= Mathf.Floor(Input.GetAxis("Horizontal"));
		if(Input.GetAxis("Vertical")>0) movey= Mathf.Ceil(Input.GetAxis("Vertical"));
		else 		movey= Mathf.Floor(Input.GetAxis("Vertical"));
	}


	void flipX(){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *=-1;
		transform.localScale=scale;
	}

	void flipY(){
		facingUp = !facingUp;
		Vector3 scale = transform.localScale;
		scale.y *=-1;
		transform.localScale=scale;
	}



}
