using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EndGame : MonoBehaviour {

    private AlertButton alertButton;
    private AllPoints allPoints;
    private LevelManager levelManager;
    private TimeController timeController;
    private MoneyCollect moneyCollect;
    private FinishGame finishGame;
    private Vibration vibration;
    private int tec;
    private int sci;
    private int army;
    private int food;
    private int water;
    private int pop;
    private int power;
    private int nat;
    private bool oneTime = true;

    void Start () {
        allPoints = GetComponent<AllPoints>();
        finishGame = GetComponent<FinishGame>();
        vibration = GetComponent<Vibration>();
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
        alertButton = GameObject.Find("LevelManager").GetComponent<AlertButton>();
        if (alertButton == null)
        {
            Debug.Log("The object -LevelManager- Dont find in scene");
        }

    }

    void Update () {
        ReadPoints();
        CheckWinGame();
        CheckLoseGame();

        //Low Energy
        if (tec > power + 150 || sci > power + 150 || pop > power + 200 || food > power + 200)
        {
            moneyCollect.FreezeEconomy(true);
            alertButton.SetButton(true);
        }
        else
        {
            moneyCollect.FreezeEconomy(false);
            alertButton.SetButton(false);
        }
    }

    void CheckLoseGame()
    {
        //Lose by pollution
        if (pop > 400 && nat < 200)
            Destruction("You dont have nature enought for the people");

        //Greve Da Raça humana
        if (tec < 300 && sci < 300 && food < (pop - 150) && water < (pop - 150) && pop > 300 && nat < 400)
            Destruction("Your people are sad and do strike");

        //Lack of popuation
        if (tec - pop > 200 || sci - pop > 200)
            Destruction("You dont have people for the companies an your planet went bankrupt");

        //Lack of food
        if (food < (pop - 200))
            Destruction("Lack of food for the populations");

        //Lack of water
        if (water < (pop - 200))
            Destruction("Lack of Water for the populations");

        //Apocalypse
        if (sci > 500 && army < 500 && pop > 300)
            Destruction("Apocalypse");

        //RobotLypse
        if (tec > 500 && army < 500 && pop > 300)
            Destruction("Robotlypse");

        //Destruição por raça alienígena
        if ((tec < 400 && sci < 400 && army < 400 && water > 800 && pop > 500) || timeController.totalDays == 1000)
            Destruction("Your planet was invaded by aliens");

        //Destruction for other specie
        if (army < 300 && food > 400 && nat > 600)
            Destruction("Your planet was attacked for the natives");

        //Dictatorship  
        if (tec < (army - 300) && sci < (army - 300) && pop < (army - 300))
            Destruction("The army take the control of the planet");

        //Nature of the Planet died
        if (nat < 10)
            Destruction("Nature of the your planet is dead");

        //water of the planet dried out
        if (water < 10)
            Destruction("Water of the planet dried out");

        //The population is dead
        if (pop == 0)
            Destruction("You dont Have people for your planets");
    }

    void CheckWinGame()
    {
        //Win With PerfectPlanet
        if (tec > 500 && sci > 500 && pop > 500 && nat > 600 && water > 600)
            FinishGame("You got a perfect planet with high Technology and Science", timeController.totalDays);
        
        //Win With very high Technology
        if (tec > 800 && pop > 600 && nat > 700 && water > 700)
            FinishGame("You got a plant with high Technology", timeController.totalDays);

        //Win with very high Science
        if (sci > 800 && pop > 600 && nat > 700 && water > 700)
            FinishGame("You got a plant with high Science", timeController.totalDays);

        //Win With very high Population
        if (pop > 800 && nat > 700 && water > 700)
            FinishGame("Your population are in peace", timeController.totalDays);
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
        vibration.Vibrate();
        if (oneTime) { 
            StartCoroutine(finishGame.LoseGame(name));
            oneTime = false;
        }
    }

    void FinishGame(string name, int days)
    {
        vibration.Vibrate();
        if (oneTime)
        {
            StartCoroutine(finishGame.WinGame(days, name));
            oneTime = false;
        }
    }

    public void ChangeOneTimeValue(bool one)
    {
        oneTime = one;
    }
}
