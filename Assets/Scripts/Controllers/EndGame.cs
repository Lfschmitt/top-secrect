using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EndGame : MonoBehaviour {

    private AllPoints allPoints;
    private LevelManager levelManager;
    private TimeController timeController;
    private MoneyCollect moneyCollect;
    private int tec;
    private int sci;
    private int army;
    private int food;
    private int water;
    private int pop;
    private int power;
    private int nat;

    void Start () {
        allPoints = GetComponent<AllPoints>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        if(levelManager == null)
        {
            Debug.Log("The game object -LevelManager- not find in scene");
        }
        timeController = GameObject.Find("TimeController").GetComponent<TimeController>();
        if (timeController == null)
        {
            Debug.Log("The game object -TimeController- not find in scene");
        }
        moneyCollect = GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The game object -PoitsController- not find in scene");
        }

    }
		
	void Update () {
        ReadPoints();
        //Destruição por poluição
        if(tec>500 && pop>600 && nat<200)
            Destruction("Destruição por poluição (Muitos Prédios)");

        //Greve Da Raça humana
        if (tec<400 && sci<400 && food<(pop-200) && water<(pop-200) && pop>600 && nat<200)
            Destruction("Greve Da Raça humana(População muito infeliz)");

        //Falta de população
        if(tec>500 && sci>500 && army<400 && pop < 400)
            Destruction("Falta de população (Pouca estrutura para ter pessoas)");

        //Falta de comida
        if (tec>350 && sci>350 && food<(pop-400) && pop>700 && nat<400)
            Destruction("Falta de comida");

        //Falta de água
        if (tec>350 && sci>350 && water<(pop-400) && pop>700 && nat<400)
            Destruction("Falta de água");

        //Apocalipse
        if (sci>900 && army<500 && pop>600)
            Destruction("Apocalipse");

        //Tecnolipse
        if (tec>900 && army<500 && pop>600)
            Destruction("Tecnolipse");

        //Destruição por raça alienígena
        if ((tec<500 && sci<500 && army<400 && water>600 && pop>600) || timeController.totalDays == 1000)
            Destruction("Destruição por raça alienígena");

        //Destruição por outra espécie
        if (sci<50 && army<30 && food>60 && nat>60)
            Destruction("Destruição por outra espécie");

        //Ditadura  
        if (tec<(army-50) && sci<(army-50) && food<(army-50) && water<(army-50) && pop<(army-50))
            Destruction("Ditadura");

        if (tec > power + 150 || pop > power + 200 || food > power + 200)
            moneyCollect.FreezeEconomy(true);
        else
            moneyCollect.FreezeEconomy(false);
    }

    void ReadPoints()
    {
        /*/ TECNOOLOGY /*/
        tec = allPoints.technology;
        /*/  SCIENCE  /*/
        sci = allPoints.science;
        /*/ ARMY /*/
        army = allPoints.army;
        /*/ FOOD /*/
        food = allPoints.food;
        /*/ WATER /*/
        water = allPoints.water;
        /*/  POPULATION  /*/
        pop = allPoints.population;
        /*/ POWER /*/
        power = allPoints.power;
        /*/ NATURE /*/
        nat = allPoints.nature;
    }

    void Destruction(string name)
    {
        Debug.Log(name);
        CallPanel(name, true);
        TimeGame(0);
    }

    void CallPanel(string name, bool ft)
    {
        levelManager.PanelDestruction(name, ft);
    }

    public void TimeGame(int time)
    {
        Time.timeScale = time;
    }
}
