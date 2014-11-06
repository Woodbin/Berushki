using UnityEngine;
using System.Collections;


public class Level_Control : MonoBehaviour {
	private int roomSizeX = 32;
	private int roomSizeY = 24;
	private int[,] herniPole;
	private const int cihla = 1;


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
		bool col = false;
		int[] coords = floatToCoords(x,y);
		switch(smer){
		case 0:
			//pravá
			if(herniPole[coords[1]+1, coords[0]]==cihla) col = true;
			break;
		case 1:
			//levá
			if(herniPole[coords[1]-1, coords[0]]==cihla) col = true;
			break;
		case 2:
			//dolu
			if(herniPole[coords[1], coords[0]+1]==cihla) col = true;
			break;
		case 3:
			//nahoru
			if(herniPole[coords[1], coords[0]-1]==cihla) col = true;

			break;
		}
		return col;
	}
	public int blockAt(float x,float y){

		int[] coords = floatToCoords(x,y);
		return herniPole[coords[1],coords[1]];

	}
	public void setBlockAt(float x,float y,int id){
		int[] coords = floatToCoords(x,y);
		herniPole[coords[0],coords[1]]=id;
	}
	public int[] floatToCoords(float x, float y){
		int[] coords = new int[2];
		coords[0] = (int)Mathf.Floor(x/25.6f);
		coords[1] = (int)Mathf.Floor(y/25.6f)+1;
		if(coords[0]<0) coords[0]=roomSizeX+coords[0]; 
		if(coords[1]<0) coords[1]=roomSizeY+coords[1];
		if(coords[0]>0) coords[0]=roomSizeX-coords[0]; 
		if(coords[1]>0) coords[1]=roomSizeY-coords[1];
		if(coords[0]==0) coords[0]=roomSizeX/2; 
		if(coords[1]==0) coords[1]=roomSizeY/2;

		Debug.Log(coords[0]);
		Debug.Log(coords[1]);

		return coords;
	}
}
