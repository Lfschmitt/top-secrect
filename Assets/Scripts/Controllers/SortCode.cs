using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCode : MonoBehaviour
{

    public EmoteManager emote;
    public void SortArrays(Necessitie[] ids)
    {
        List<Necessitie> itemcost = new List<Necessitie>
        {
            new Necessitie(ids[0].name, ids[0].id),
            new Necessitie(ids[1].name, ids[1].id),
            new Necessitie(ids[2].name, ids[2].id),
            new Necessitie(ids[3].name, ids[3].id),
            new Necessitie(ids[4].name, ids[4].id),
            new Necessitie(ids[5].name, ids[5].id),
            new Necessitie(ids[6].name, ids[6].id),
            new Necessitie(ids[7].name, ids[7].id),
        };

        List<Necessitie> SortedList = itemcost.OrderByDescending((Necessitie i) => i.id).ToList();

        /*
        for (int x = 0; x < ids.Length; x++)
        {
            Debug.Log(SortedList[x].name + " " + SortedList[x].id);
        }
        */
        emote.ReciveNecessities(SortedList);
    }
}