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
    private FinishAnimationController finishAnimation;
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
            Debug.Log("The game object -PointsController- not find in scene");
        }
        alertButton = GameObject.Find("LevelManager").GetComponent<AlertButton>();
        if (alertButton == null)
        {
            Debug.Log("The object -LevelManager- Dont find in scene");
        }
        finishAnimation = GameObject.Find("LevelManager").GetComponent<FinishAnimationController>();
    }

    void Update () {
        ReadPoints();
        CheckWinGame();
        CheckLoseGame();

        //Low Energy
        if (power < tec * 0.30 || power < sci * 0.30 || power < pop * 0.20 || power < food * 0.20)
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
        if (pop > (nat + 300))
            Destruction("there isn't enough nature for people");

        //Greve Da Raça humana
        if (food < (pop - 220) && water < (pop - 220) && nat < (pop -220))
            Destruction("People are sad and starting to turn-out");

        //Lack of popuation
        if (tec - pop > 300 || sci - pop > 300)
            Destruction("Lack people for companies and your planet went bankrupt");

        //Lack of army
        //if(army < (pop * 0.2))

        //Lack of food
        if (food < (pop / 2))
            Destruction("Lack food for people");

        //Lack of water
        if (water < (pop * 0.8))
            Destruction("Lack Water for people");

        //Apocalypse
        if (sci > (pop * 1.3) && army < (pop / 3))
            Destruction("The zombies took the planet control");

        //RobotLypse
        if (tec > (pop * 1.3) && army < (pop / 3))
            Destruction("The robots took the planet control");

        //Destruição por raça alienígena
        if ((tec < (pop - 250) || sci < (pop - 250)) && army < (pop / 3) && water > 800 || timeController.totalDays == 1000)
            Destruction("the planet was invaded by aliens");

        //Destruction for other specie
        if (army < (pop / 3) && food > (pop * 1.6) && nat > (pop * 1.5))
            Destruction("the planet was attacked by natives");

        //Dictatorship  
        if (army > (tec * 1.5) && army > (sci * 1.5) && army > (pop * 1.6))
            Destruction("The army took the planet control");

        //Nature of the Planet died
        if (nat <= 10)
            Destruction("The planet nature is died");

        //water of the planet dried out
        if (water <= 10)
            Destruction("The planet water dried out");

        //The population died
        if (pop <= 10)
            Destruction("The population died");
    }

    void CheckWinGame()
    {
        //Win With PerfectPlanet
        if (tec > 700 && sci > 700 && pop > 700 && nat > 700 && water > 700)
        {
            finishAnimation.ScienceTechnologyWinAnimation(true);
            finishAnimation.PopulationWinAnimation(true);
            FinishGame("You got a perfect planet with high Technology and Science", timeController.totalDays);
        }

        //Win With very high Technology
        if (tec > 800 && pop > 600 && nat > 700 && water > 700)
        {
            finishAnimation.ScienceTechnologyWinAnimation(true);
            FinishGame("You got a planet with high Technology", timeController.totalDays);
        }

        //Win with very high Science
        if (sci > 800 && pop > 600 && nat > 700 && water > 700)
        {
            finishAnimation.ScienceTechnologyWinAnimation(true);
            FinishGame("You got a planet with high Science", timeController.totalDays);
        }

        //Win With very high Population
        if (pop > 800 && nat > 700 && water > 700)
        {
            finishAnimation.PopulationWinAnimation(true);
            FinishGame("The population is in peace", timeController.totalDays);
        }
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
