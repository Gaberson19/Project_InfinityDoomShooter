using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboSystem : MonoBehaviour
{
    public static PlayerComboSystem Instance { get; private set; }

    [SerializeField] List<int> combo = new List<int>() { 0, 0, 0 };

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }



    //basically, add a skill from 1-4, if the combo array has more than 3 values, remove the 1st one
    void ComboAdd(int skillAdd)
    {
        if(combo.Count > 2)
        {
            combo.RemoveAt(0);
        }

        combo.Add(skillAdd);
    }

    //Empty's the combo when hit
    void EmptyCombo()
    {
        combo = new List<int> {0, 0, 0};
    }

    void skillCast()
    {
        string comboString = combo[0].ToString() + combo[1].ToString() + combo[2].ToString();
        //Turn List into a string

        switch (comboString)
        {
            case "144":
                //do something
                break;
            case "121":
                //DO SOMETHING
                break;
            default:
                comboString = combo[1].ToString() + combo[2].ToString();
                break;
        }

        switch (comboString)
        {
            case "22":
                //do something
                break;
            case "12":
                //DO SOMETHING
                break;
            default:
                comboString = combo[2].ToString();
                break;
        }

        switch (comboString)
        {
            case "1":
                //do something
                break;
            case "2":
                //DO SOMETHING
                break;
            case "3":
                //DO SOMETHING
                break;
            case "4":
                //DO SOMETHING
                break;
        }

        //Check for trio combinations
        //Check for duo combinations
        //else, check the last number

    }

}
