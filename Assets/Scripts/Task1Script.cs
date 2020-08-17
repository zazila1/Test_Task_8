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
    [SerializeField] private Text _Result4;
    
    public void CheckAll()
    {
        int num = Int32.Parse(_Number.text);

        _Result1.text = Check1(num).ToString();
        _Result2.text = Check2(num).ToString();
        _Result3.text = Check3(num).ToString();
        _Result4.text = Check4(num).ToString();

    }

    private bool Check1(int number)
    {
        if (number == 0)
        {
            return false;
        }
        
        if(number % 4 == 0)
        {
            number /= 4;
        }
        else
        {
            return false;
        }

        return number == 1 || Check1(number);
    }
    
    private bool Check2(int number)
    {
        int count = 0;
        int x = number & (number - 1);

        if ( number > 0 && x == 0)
        {
            while(number > 1)
            {
                number >>= 1;
                count += 1;
            } 
            
            return (count % 2 == 0);
        }

        return false;
    } 

    private bool Check3(int number)
    {
        if (number == 0)
        {
            return false;
        }
        
        while((number % 4) == 0)
        {
            if ((number /= 4) == 1)
            {
                return true;
            }
        }
        return false;
    }
    
    private bool Check4(int number)
    {
        if (number == 0)
        {
            return false;
        }
        
        return (Math.Log(number, 4) % 1) == 0;
    }
}
