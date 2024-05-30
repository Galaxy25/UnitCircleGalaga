using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Type : MonoBehaviour
{
    [HideInInspector]
    public string numerator = "";

    [HideInInspector]
    public string denominator = "";

    [HideInInspector]
    public bool dash = false;

    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Hello World!";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            dash = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (dash && denominator != "")
            {
                denominator = denominator.Remove(denominator.Length - 1);
            }
            else if (dash)
            {
                dash = false;
            }
            else if (numerator != "")
            {
                numerator = numerator.Remove(numerator.Length - 1);
            }
        }

        if (!dash)
        {
            numerator += GetNumberKeyCode();
        }
        else
        {
            denominator += GetNumberKeyCode();
        }
        

        if (dash)
        {
            text.text = numerator + "π" + "/" + denominator;
        }
        else if (numerator != "")
        {
            text.text = numerator + "π";
        }
        else
        {
            text.text = "";
        }
    }

    private string GetNumberKeyCode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            return "0";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return "1";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return "2";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            return "3";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            return "4";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            return "5";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            return "6";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            return "7";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            return "8";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            return "9";
        }
        else
        {
            return "";
        }
    }
}
