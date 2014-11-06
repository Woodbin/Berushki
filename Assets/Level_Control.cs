using UnityEngine;
using System.Collections;


public class Level_Control : MonoBehaviour {
	int roomSizeX = 32;
	int roomSizeY = 24;



	int[] parser(string vstup){
		//int length = vstup.Length / 2;
		int[] array = new int[roomSizeY];
		string[] text;
		text = vstup.Split(',');
		vypis ("Parsovany radek");
		vypis (text);
	/*	for (int i=0; i<text.Length; i++) {
			array[i] = int.Parse(text[i].ToString);
				}*/
		return array;
		}


	void vypis(string[] pole){
		for (int i = 0; i< pole.Length; i++) {
			Debug.Log(pole[i]);		
		
		}

		}


	void vypis(string s){
		Debug.Log (s);
		}

	void vypis(int[][] pole, int delka){

				for (int i=0; i<delka; i++) {
						for (int j=0; j<pole.Length; j++) {
				Debug.Log(pole);
						}
				}
		}

	// Use this for initialization
	void Start () {
		vypis ("start");
		string line;
		System.IO.StreamReader file = new System.IO.StreamReader(@"mapa_pro_pohyb.txt");
		int[,] herniPole = new int[roomSizeY,roomSizeX];
		int[] tempArray = new int[roomSizeX];
		int j = 0;
		while((line = file.ReadLine()) != null)
		{
			tempArray = parser(line);
			//for(int i=0;i<roomSizeX;i++) herniPole[i,j] = tempArray[i];

		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool prediction(int x,int y,int smer){
		//TODO Placeholder
		return false;
	}
	public int blockAt(int x,int y){
		//TODO Placeholder

		return 0;
	}
	public void setBlockAt(int x,int y,int id){
		//TODO Placeholder
		
	}

}
