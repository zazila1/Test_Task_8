using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Task1Script : MonoBehaviour
{
    [SerializeField] private InputField _Number;
    
    [SerializeField] private Text _Result1;
    [SerializeField] private Text _Result2;
    [SerializeField] private Text _Result3;
    
    public void CheckAll()
    {
        int num = Int32.Parse(_Number.text);

        _Result3.text = Check3(num).ToString();

    }

    private bool Check3(int number)
    {
        while((number % 4) == 0)
        {

            if ((number /= 4) == 1)
            {
                return true;
            }
        }
        return false;
    }
}
