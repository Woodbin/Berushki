using UnityEngine;
using System.Collections;

public class BugControlScript : MonoBehaviour {
	public float step = 16;
	public float maxSpeed = 32;
	private float movex=0;
	private float movey=0;
	private Vector3 pos;
	private Transform tr;

	// Use this for initialization
	void Start () {
		tr = gameObject.transform;
		pos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(Input.GetAxis("Horizontal")>0) movex= Mathf.Ceil(Input.GetAxis("Horizontal"));
		else 		movex= Mathf.Floor(Input.GetAxis("Horizontal"));
		if(Input.GetAxis("Vertical")>0) movey= Mathf.Ceil(Input.GetAxis("Vertical"));
		else 		movey= Mathf.Floor(Input.GetAxis("Vertical"));
		
		
		
		if(tr.position==pos){
			//pos=tr.position;
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
		transform.position= Vector3.MoveTowards(transform.position,pos, Time.deltaTime*maxSpeed);




}

	public void setPosition(float x, float y){
		gameObject.transform.Translate(x,y,0);



	}
}