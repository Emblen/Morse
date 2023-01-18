using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class InputNormal : MonoBehaviour
{
    public TextMeshProUGUI InputSignalText;
    public string tmpSignal;
    private int stage; //inputsignalの出力のステージング
    private double PressTime;
    private double notPressTime;
    public double dotTime;
    // private const double dashTime = dotTime*3;
    private bool printDash = false;
    private bool printDot = false;
    private bool printSpace = false;

    public AudioClip SignalSound;
    public AudioSource adSource;

    
    void Start()
    {
        stage = 0;
        adSource = GetComponent<AudioSource>();
    }
    

    void Update()
    {
        if(stage==0)
        {
            
            if(printSpace) 
            {
                tmpSignal = "";
                printSpace = false;
            }
            //キーが押されたときに一度だけ呼び出される
            if(Input.GetKey(KeyCode.Space))
            {   
                adSource.Play();
                PressTime = 0;
                printDash = false;
                printDot = false;
                stage = 1;
            }
        }
        else if(stage==1)
        {
            if(Input.GetKey(KeyCode.Space))
            {   
                PressTime += Time.deltaTime;
                //dotTimeを超過したらdashを出力する
                if(PressTime>=dotTime && !printDash)
                {
                    InputSignalText.text += "-";
                    tmpSignal += "-";
                    printDash = true;
                }
            }
            else //キーが離されたとき
            {
                adSource.Stop();
                if(PressTime<dotTime && !printDot)
                {
                    InputSignalText.text += ".";
                    tmpSignal += ".";
                    printDot = true;
                }
                notPressTime = 0;
                stage = 2;
            }
        }
        else if(stage==2)
        {
            if(!Input.GetKey(KeyCode.Space))
            {
                notPressTime += Time.deltaTime;
                if(notPressTime > dotTime && !printSpace)
                {
                    InputSignalText.text = InputSignalText.text + " ";
                    printSpace = true;
                    stage = 0;
                }
            }
            else stage = 0;
        }
    }

    public bool isPrintSpace()
    {
        return printSpace;
    }
    public int getInputTextLength()
    {
        return InputSignalText.text.Length;
    }

    private void EndGame()
    {
        if(Input.GetKey(KeyCode.Escape)) Application.Quit();
    }
}
