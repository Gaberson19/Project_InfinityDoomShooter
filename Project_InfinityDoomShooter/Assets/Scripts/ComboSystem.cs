using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    List<int> comboList = new List<int> { 0, 0, 0};
    
    void EmptyList()
    {
        for(int i = 0; i == 3; i++)
        {
            comboList.Add(0);
            comboList.RemoveAt(3);
        }
    }

    //comboAdd is a number from 1-4
    void AddList(int comboAdd)
    {
        comboList.Add(comboAdd);

        if(comboList.Count > 3)
        {
            comboList.RemoveAt(0);
        }

    }

    void SkillCheck()
    {
        string combo = comboList[0].ToString() + comboList[1].ToString() + comboList[2].ToString();

        //3 symbol combos
        switch (combo)
        {

            case "124":
                //do something
                break;
            default:
                combo = comboList[1].ToString() + comboList[2].ToString();
                break;
        }

        //2 symbol combos
        switch (combo)
        {

            case "14":
                //do something
                break;
            default:
                combo = comboList[2].ToString();
                break;
        }

        switch (combo)
        {

            case "1":
                //do something
                break;

            case "2":
                //do something
                break;

            case "3":
                //do something
                break;

            case "4":
                //do something
                break;
            default:
                combo = comboList[2].ToString();
                break;
        }


    }
}
