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
        //Ganhou
        if (tec > 700 && sci > 700 && pop > 700 && nat > 700)
            FinishGame("Your planet is work", true, timeController.totalDays);

        //Ganhou
        if (tec > 950 && sci > 950 && nat > 800)
            FinishGame("You got a perfect Planet", true, timeController.totalDays);

        //Destruição por poluição
        if (tec>500 && pop>500 && nat<300)
            Destruction("Destruição por poluição (Muitos Prédios)");

        //Greve Da Raça humana
        if (tec<400 && sci<400 && food<(pop-200) && water<(pop-200) && pop>600 && nat<200)
            Destruction("Greve Da Raça humana(População muito infeliz)");

        //Falta de população
        if((tec>400 || sci>400) && pop < 400)
            Destruction("Falta de população (Pouca estrutura para ter pessoas)");

        //Falta de comida
        if ((tec>300 || sci>300) && food<(pop-300) && pop>500 && nat<400)
            Destruction("Falta de comida");

        //Falta de água
        if ((tec>300 || sci>350) && water<(pop-300) && pop>500 && nat<400)
            Destruction("Falta de água");

        //Apocalipse
        if (sci>800 && army<500 && pop>500)
            Destruction("Apocalipse");

        //Tecnolipse
        if (tec>800 && army<500 && pop>500)
            Destruction("Tecnolipse");

        //Destruição por raça alienígena
        if ((tec<600 && sci<600 && army<400 && water>400 && pop>500) || timeController.totalDays == 1000)
            Destruction("Destruição por raça alienígena");

        //Destruição por outra espécie
        if (sci<300 && army<300 && food>300 && nat>600)
            Destruction("Destruição por outra espécie");

        //Ditadura  
        if (tec<(army-300) && sci<(army-300) && pop<(army-300))
            Destruction("Ditadura");

        //Planeta morreu
        if (nat < 10)
            Destruction("Your planet is dead");

        //A populaçao morreu
        if (pop == 0)
            Destruction("You dont Have peoples for your planets");

        //Energia abaixo dos Necessario
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
    void FinishGame(string name, bool ft, int Days)
    {
        levelManager.Panel(name, ft, 1, Days);
    }

    void CallPanel(string name, bool ft)
    {
        levelManager.Panel(name, ft, 0, 0);
    }

    public void TimeGame(int time)
    {
        Time.timeScale = time;
    }
}
