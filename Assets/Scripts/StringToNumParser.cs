using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringToNumParser : MonoBehaviour
{
    public UnityEvent<float> OnParse;
    
    public void Parse(string str)
    {
        try
        {
            var value = float.Parse(str);
            
            OnParse.Invoke(value);
        }
        catch (Exception e)
        {
            Debug.Log("Incorrect value. Try again");
        }
    }
}
