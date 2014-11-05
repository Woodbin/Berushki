using UnityEngine;
using System.Collections;


public class Level_Control : MonoBehaviour {
	/*public bool prediction(int x,int y,int smer){
	}
	public int blockAt(int x,int y){
	}
	public void setBlockAt(int x,int y,int id){
	}
*/


	int[] parser(string vstup){
		int length = vstup.Length / 2;
		int[] array = new int[length];
		string[] text;
		text = vstup.Split(',');
		for (int i=0; i<text.Length; i++) {
			array[i] = int.Parse(text[i]);
				}
		return array;
		}
	void vypis(int[][] pole, int delka){

				for (int i=0; i<delka; i++) {
						for (int j=0; j<pole.Length; j++) {
				System.Console.Write(pole);
						}
				}
		}

	// Use this for initialization
	void Start () {
		string line;
		System.IO.StreamReader file = new System.IO.StreamReader(@"mapa_pro_pohyb.txt");
		int[,] herniPole = new int[40,40];
		int[] tempArray = new int[40];
		int j = 0;
		while((line = file.ReadLine()) != null)
		{
			tempArray = parser(line);
			for(int i=0;i<40;i++) herniPole[i,j] = tempArray[i];

		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
