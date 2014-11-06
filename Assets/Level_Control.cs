using UnityEngine;
using System.Collections;


public class Level_Control : MonoBehaviour {
	private int roomSizeX = 32;
	private int roomSizeY = 24;
	private int[,] herniPole;


	int[] parser(string vstup){
		int[] array = new int[roomSizeX];
		string[] text;
		text = vstup.Split(',');
		vypis ("Parsovany radek");
		vypis (text);
	for (int i=0; i<text.Length-1; i++) {
			array[i] = int.Parse(text[i]);
				}
		return array;
		}


	void vypis(string[] pole){
		for (int i = 0; i< pole.Length; i++) {
			Debug.Log(pole[i]);		
		
		}

		}
	void vypis(int[] pole){
		for (int i = 0; i< pole.Length; i++) {
			Debug.Log(pole[i]);		
			
		}
		
	}

	void vypis(string s){
		Debug.Log (s);
		}

	void vypis(int[,] pole){
				for (int i=0; i<roomSizeX; i++) {
			string mes = "";

						for (int j=0; j<roomSizeY; j++) {
				mes+=pole[j,i];
						}
			Debug.Log(mes);
				}
		}

	// Use this for initialization
	void Start () {
		vypis ("start");
		string line;
		System.IO.StreamReader file = new System.IO.StreamReader(@"mapa_pro_pohyb.txt");
		herniPole = new int[roomSizeY,roomSizeX];
		int[] tempArray = new int[roomSizeY];
		/*while((line = file.ReadLine()) != null)
		{
			Debug.Log(line);
			tempArray = parser(line);
			//for(int i=0;i<roomSizeX;i++) herniPole[i,j] = tempArray[i];

		}*/

		for(int i = 0; i<roomSizeY; i++){
			line = file.ReadLine();
			tempArray = parser(line);
			Debug.Log(line);
			for(int j = 0;j<roomSizeX;j++){
				herniPole[i,j] = tempArray[j];
			}

		}
		vypis(herniPole);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool prediction(float x,float y,int smer){
		//TODO Placeholder
		return false;
	}
	public int blockAt(float x,float y){
		//TODO Placeholder

		return 0;
	}
	public void setBlockAt(float x,float y,int id){
		//TODO Placeholder
		
	}
	public int floatToCoords(float f){
		//TODO Placeholder
		return 0;
	}
}
