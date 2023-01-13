using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutputSignal : MonoBehaviour
{
    public InputSignal inputsignal;
    public TextMeshProUGUI OutputSignalText;
    private string getSignal;
    private string getChar;
    private bool OutputDone;
    private bool getPrintSpace;

    private Dictionary<string, string> MtoEn = new Dictionary<string, string>()
    {
        {"A",".-"}, {"B","-..."}, {"C","-.-."}, {"D","-.."}, {"E","."},
        {"F","..-."}, {"G","--."}, {"H","...."}, {"I",".."}, {"J",".---"},
        {"K","-.-"}, {"L",".-.."}, {"M","--"}, {"N","-."}, {"O","---"},
        {"P",".--."}, {"Q","--.-"}, {"R",".-."}, {"S","..."}, {"T","-"},
        {"U","..-"}, {"V","...-"}, {"W",".--"}, {"X","-..-"}, {"Z","--.."},
        {".",".-.-.-"}, {",","--..--"}
    };
    // private Dictionary<string, char> MtoJa = new Dictionary<string, char>()
    // {

    // };
    void Start()
    {
        getPrintSpace = false;
    }

    void ChangeEn()
    {
        getSignal = inputsignal.tmpSignal;
        foreach(var sig in MtoEn)
        {
            if(sig.Value==getSignal) getChar = sig.Key;
        }
        OutputSignalText.text += getChar;
        OutputDone = true;
    }
    
    // void ChangeJa()
    // {

    // }
    void Update()
    {   
        getPrintSpace = inputsignal.isPrintSpace();
        if(getPrintSpace && !OutputDone) ChangeEn();
        else if(!getPrintSpace) OutputDone = false; 
    }

}
