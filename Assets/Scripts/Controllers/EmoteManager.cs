using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmoteManager : MonoBehaviour {

    //valores para troca de sprite onde o minvalue[0] e o menor para de ocorrer um troca de sprite para pior
    public int[] minValues;
    //Imagem onde sera indicado os sprites
    public Image emote;
    //Sprites para trocar na imagem "emote"
    public Sprite[] sprites;
    //Aqui serao definidas mensagens aleatorias 
    [TextArea(3,10)]
    public string[] mensages;
    //Esse texto ira depois da mensagem complementando-a dizendo o quao importante é
    [TextArea(3,10)]
    public string[] necessiteString;
    //O menor valor(mais necessario) ficara mais a cima(necessities[0] > necessities[1] ...) 
    public Necessitie[] necessities;
    //Principal necessidade
    public Necessitie mainNecessitie;
    //Texto onde sera exibido a mensagem
    public Text infoText;
    //Painel que sera aberto
    public Animator infoPanelAnimator;
    //De onde tira valores
    private AllPoints allPoints;
    //pontos 
    private int tech, sci, pop, army, water, food, power, nat;
    //Codigo que ordena as necessidades
    private SortCode sortCode;

    void Start() {
        allPoints = GameObject.Find("PointsController").GetComponent<AllPoints>();
        sortCode = GetComponent<SortCode>();
    }

    private void Update()
    {
        ReadPoint();
        CalculatePoints();
        SendNecessities();
    }
    //Responsavel por passar valores para as variaveis
    void ReadPoint () {
        tech = allPoints.technology;
        sci = allPoints.science;
        pop = allPoints.population;
        army = allPoints.army;
        water = allPoints.water;
        food = allPoints.food;
        power = allPoints.power;
        nat = allPoints.nature;
    }

    void CalculatePoints()
    {
        if(tech > ((pop - minValues[0])*2))
        {
            necessities[0].id = 0;
        }
        else
        {
            necessities[0].id = 1;
            if (tech < (pop - minValues[1]))
            {
                necessities[0].id = 2;
                if (tech < (pop - minValues[2]))
                {
                    necessities[0].id = 3;
                    if (tech < (pop - minValues[3]))
                    {
                        necessities[0].id = 4;
                        if (tech < (pop - minValues[4]))
                        {
                            necessities[0].id = 5;
                        }
                    }
                }
            }
        }

        if (sci > ((pop - minValues[0])*2))
        {
            necessities[1].id = 0;
        }
        else
        {
            necessities[1].id = 1;
            if (sci < (pop - minValues[1]))
            {
                necessities[1].id = 2;
                if (sci < (pop - minValues[2]))
                {
                    necessities[1].id = 3;
                    if (sci < (pop - minValues[3]))
                    {
                        necessities[1].id = 4;
                        if (sci < (pop - minValues[4]))
                        {
                            necessities[1].id = 5;
                        }
                    }
                }
            }
        }

        if (army > (pop - minValues[0]))
        {
            necessities[3].id = 0;
        }
        else
        {
            necessities[3].id = 1;
            if (army < (pop - minValues[1]))
            {
                necessities[3].id = 2;
                if (army < (pop - minValues[2]))
                {
                    necessities[3].id = 3;
                    if (army < (pop - minValues[3]))
                    {
                        necessities[3].id = 4;
                        if (army < (pop - minValues[4]))
                        {
                            necessities[3].id = 5;
                        }
                    }
                }
            }
        }

        if (water > (pop - minValues[0]))
        {
            necessities[4].id = 0;
        }
        else
        {
            necessities[4].id = 1;
            if (water < (pop - minValues[1]))
            {
                necessities[4].id = 2;
                if (water < (pop - minValues[2]))
                {
                    necessities[4].id = 3;
                    if (water < (pop - minValues[3]))
                    {
                        necessities[4].id = 4;
                        if (water < (pop - minValues[4]))
                        {
                            necessities[4].id = 5;
                        }
                    }
                }
            }
        }

        if (food > (pop - minValues[0]))
        {
            necessities[5].id = 0;
        }
        else
        {
            necessities[5].id = 1;
            if (food < (pop - minValues[1]))
            {
                necessities[5].id = 2;
                if (food < (pop - minValues[2]))
                {
                    necessities[5].id = 3;
                    if (food < (pop - minValues[3]))
                    {
                        necessities[5].id = 4;
                        if (food < (pop - minValues[4]))
                        {
                            necessities[5].id = 5;
                        }
                    }
                }
            }
        }

        if (nat > (pop - minValues[0]))
        {
            necessities[6].id = 0;
        }
        else
        {
            necessities[6].id = 1;
            if (nat < (pop - minValues[1]))
            {
                necessities[6].id = 2;
                if (nat < (pop - minValues[2]))
                {
                    necessities[6].id = 3;
                    if (nat < (pop - minValues[3]))
                    {
                        necessities[6].id = 4;
                        if (nat < (pop - minValues[4]))
                        {
                            necessities[6].id = 5;
                        }
                    }
                }
            }
        }

        if (power > (pop - minValues[0]))
        {
            necessities[7].id = 0;
        }
        else
        {
            necessities[7].id = 1;
            if (power < (pop - minValues[1]))
            {
                necessities[7].id = 2;
                if (power < (pop - minValues[2]))
                {
                    necessities[7].id = 3;
                    if (power < (pop - minValues[3]))
                    {
                        necessities[7].id = 4;
                        if (power < (pop - minValues[4]))
                        {
                            necessities[7].id = 5;
                        }
                    }
                }
            }
        }

        if(pop > (tech - minValues[0]) || pop > (sci - minValues[0]))
        {
            necessities[2].id = 0;
        }
        else
        {
            necessities[2].id = 1;
            if (pop > (tech - minValues[1]) || pop > (sci - minValues[1]))
            {
                necessities[2].id = 2;
                if (pop > (tech - minValues[2]) || pop > (sci - minValues[2]))
                {
                    necessities[2].id = 3;
                    if (pop > (tech - minValues[3]) || pop > (sci - minValues[3]))
                    {
                        necessities[2].id = 4;
                        if (pop > (tech - minValues[4]) || pop > (sci - minValues[4]))
                        {
                            necessities[2].id = 5;
                        }
                    }
                }
            }
        }
    }

    void SendNecessities()
    {
        //Manda o array para ser organizado
        sortCode.SortArrays(necessities);
    }

    public void ReciveNecessities(List<Necessitie> necessitie)
    {
        //Debug.Log(necessities2[0].name + " " + necessities2[0].id);
        //Coloca a mairo necessidade com principal
        mainNecessitie.id = necessitie[0].id;
        mainNecessitie.name = necessitie[0].name;
        //Muda o emote conforme a necessidade do que mais precisa
        emote.sprite = sprites[necessitie[0].id];
        //Debug.Log("The " + necessitie[0].name + " is in critical stage with " + necessitie[0].id + "/5 ");
    }

    public void GenerateMensage(bool open)
    {
        //Cria uma mensagem aleatoria dizendo o que precisa e quanto é necessario  
        int number = 0;
        number = Random.Range(0, 5);
        if (mainNecessitie.id > 0)
            infoText.text = mensages[number] + " " + mainNecessitie.name + " " + necessiteString[mainNecessitie.id];
        else
            infoText.text = necessiteString[0];

        //Abre o painel com a informaçao
        infoPanelAnimator.SetBool("IsOpen", open);
    }
}
//Cada necessidade tera um nome e um valor
[System.Serializable]
public class Necessitie
{
    public string name;
    public int id;
    public Necessitie(string idName, int idValue)
    {
        name = idName;
        id = idValue;
    }
}

