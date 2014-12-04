using UnityEngine;
using System.Collections;


public class Level_Control : MonoBehaviour {
//~~~~~~~~~~~~~ Hlavička ~~~~~~~~~~~~~
	private int roomSizeX = 32;
	private int roomSizeY = 24;
	private int[,] herniPole;
	private const int cihla = 1;        //cihla má v tiledové mapě ID 1
    private const int barel = 3;        //barel má v mapě ID 3

//~~~~~~~~~~~~~ Parser ~~~~~~~~~~~~~
	int[] parser(string vstup){
		int[] array = new int[roomSizeX];
		string[] text = vstup.Split(',');
		/*vypis ("Parsovany radek");
		vypis (text);*/
	for (int i=0; i<text.Length-1; i++) {
			array[i] = int.Parse(text[i]);
				}
		return array;
		}
//~~~~~~~~~~~~~ Výpisy ~~~~~~~~~~~~~
	void vypis(string[] pole){
        string mes = "";
		for (int i = 0; i< pole.Length; i++) {
			mes+=pole[i]+",";		
		
		}
        Debug.Log(mes);

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
				for (int i=0; i<pole.GetLength(0); i++) {
			string mes = "";

						for (int j=0; j<pole.GetLength(1); j++) {
				mes+=pole[i,j];
						}
			Debug.Log(mes);
				}
		}

//~~~~~~~~~~~~~ Inicializace ~~~~~~~~~~~~~
	void Start () {
		vypis ("start");
        createLevel("mapa_pro_pohyb.txt");
		vypis(herniPole);
	}
	
//~~~~~~~~~~~~~~ Update ~~~~~~~~~~~
	void Update () {
	
	}

//~~~~~~~~~~~~~ Vytvoření mapy ~~~~~~~~~~~~~
    private void createLevel(string levelName)
    {
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader(@levelName);
        herniPole = new int[roomSizeY, roomSizeX];
        int[] tempArray = new int[roomSizeX];
        for (int i = 0; i < roomSizeY; i++)
        {
            line = file.ReadLine();
            tempArray = parser(line);
            Debug.Log(i + " : " + line);
            for (int j = 0; j < roomSizeX; j++)
            {
                herniPole[ i, j] = tempArray[j];
            }
        }
    }

//~~~~~~~~~~~~~ Metody rozhraní ~~~~~~~~~~~~~

    //public bool prediction(float x, float y, int smer)
    //{
    //    bool col = false;
    //    int[] coords = floatToCoords(x, y);
    //    switch (smer)
    //    {
    //        case 0:


    //            if (herniPole[coords[1], coords[0] + 1] == cihla) col = true;
    //            break;
    //        case 1:

    //            if (herniPole[coords[1], coords[0] - 1] == cihla) col = true;
    //            break;
    //        case 2:

    //            if (herniPole[coords[1] - 1, coords[0]] == cihla) col = true;
    //            break;
    //        case 3:

    //            if (herniPole[coords[1] + 1, coords[0]] == cihla) col = true;

    //            break;
    //    }
    //    Debug.Log("ray z " + coords[0] + " " + coords[1] + " ve smeru " + smer + " : " + col);
    //    return col;
    //}


    public int prediction(float x, float y, int smer)
    {
        int col = 0;
        int[] coords = floatToCoords(x, y);
        switch (smer)
        {
            case 0:
                //pravá

                return herniPole[coords[1], coords[0] + 1];
                break;
            case 1:
                //levá
                return herniPole[coords[1], coords[0] - 1];
                break;
            case 2:
                //dolu
                return herniPole[coords[1] - 1, coords[0]];
                break;
            case 3:
                //nahoru
                return herniPole[coords[1] + 1, coords[0]];

                break;
        }
        Debug.Log("ray z " + coords[0] + " " + coords[1] + " ve smeru " + smer + " : " + col);
        return col;
    }

	public int blockAt(float x,float y){
		int[] coords = floatToCoords(x,y);
		return herniPole[coords[1],coords[0]];
	}

	public void setBlockAt(float x,float y,int id){
		int[] coords = floatToCoords(x,y);
		herniPole[coords[1],coords[0]]=id;
	}

//~~~~~~~~~~~~~ Převod na koordináty ~~~~~~~~~~~~~
	public int[] floatToCoords(float x, float y){
		int[] coords = new int[2];

        coords[0] = (int)Mathf.Floor((x-16f)/32f);
        coords[1] = (int)Mathf.Floor(Mathf.Abs((y-16f/2) / 32f));
        /*
		Debug.Log(coords[0]);
		Debug.Log(coords[1]);
        */
		return coords;
    }



    public Vector2 getVector(int direction)
    {
        Vector2 ret = new Vector2();
        switch (direction)
        {
            case 0: //right
                ret[0] = 1;
                ret[1] = 0;
                break;
            case 1: //left
                ret[0] = -1;
                ret[1] = 0;
                break;
            case 2: //up y+
                ret[0] = 0;
                ret[1] = 1;
                break;
            case 3: //down y-
                ret[0] = 0;
                ret[1] = -1;
                break;
        }
        return ret;
    }




}
