using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutputSignal : MonoBehaviour
{   
    public GameObject signal;
    public InputNormal inputnormal;
    public InputElekey inputelekey;
    public TextMeshProUGUI OutputSignalText;
    private string getSignal;
    private string getChar;
    private bool OutputDone;
    private bool getPrintSpace;
    private string nowInputText;
    private int nowInputTextNum;

    private Dictionary<string, string> MtoEn = new Dictionary<string, string>()
    {
        {"A",".-"}, {"B","-..."}, {"C","-.-."}, {"D","-.."}, {"E","."},
        {"F","..-."}, {"G","--."}, {"H","...."}, {"I",".."}, {"J",".---"},
        {"K","-.-"}, {"L",".-.."}, {"M","--"}, {"N","-."}, {"O","---"},
        {"P",".--."}, {"Q","--.-"}, {"R",".-."}, {"S","..."}, {"T","-"},
        {"U","..-"}, {"V","...-"}, {"W",".--"}, {"X","-..-"}, {"Y","-.--"}, 
        {"Z","--.."},
        {".",".-.-.-"}, {",","--..--"}, {":","---..."}, {"?","..--.."}, {"'",".----."}, {"-","-....-"}, {"(","-.--."}, {"!","-.-.--"}, {"$","...-..-"}, {"&",".-..."}, {";","-.-.-."}, {"_", "..--.-"},
        {")","-.--.-"}, {"/","-..-."}, {"=","-...-"}, {"+",".-.-."}, {"@",".--.-."}, {"1",".----"}, {"2","..---"}, {"3","...--"},
        {"4","....-"}, {"5","....."},{"6","-...."},{"7","--..."},{"8","---.."},{"9","----."}, {"0","-----"}
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
        getSignal = (signal.GetComponent<InputElekey>().enabled) ? inputelekey.tmpSignal : inputnormal.tmpSignal;
        if(getSignal==".-..-.") getChar = '"'.ToString();
        else if (!MtoEn.ContainsValue(getSignal))
        {
            getChar = "<color=red>x</color>";
            nowInputTextNum = inputnormal.getInputTextLength();
            inputnormal.InputSignalText.text = inputnormal.InputSignalText.text.Substring(0, nowInputTextNum-getSignal.Length-1) + "<color=red>" + getSignal + "</color> ";
        }
        else foreach(var sig in MtoEn) if(sig.Value==getSignal) getChar = sig.Key;

        OutputSignalText.text += getChar;
        OutputDone = true;
    }
    
    // void ChangeJa()
    // {

    // }
    void Update()
    {   
        getPrintSpace = (signal.GetComponent<InputElekey>().enabled) ? inputelekey.isPrintSpace() : inputnormal.isPrintSpace();

        if(getPrintSpace && !OutputDone) ChangeEn();
        else if(!getPrintSpace) OutputDone = false; 
    }

}
