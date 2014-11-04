using UnityEngine;
using System.Collections;
using System.


public class Level_Control : MonoBehaviour {
	public bool prediction(x,y,smer){
	}
	public int blockAt(int x,int y){
	}
	public void setBlockAt(x,y,id){
	}



	int[] Parser(string text){
		int length = text.Length;
		int[] array; 
		for (int i=0; i<length; i++) {
			array[i] = int.Parse(text[i]);


				}
		}


	// Use this for initialization
	void Start () {
		string line;
		System.IO.StreamReader file = new System.IO.StreamReader(@"mapa_pro_pohyb.txt");
		while((line = file.ReadLine()) != null)
		{
			Parser(line);
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
