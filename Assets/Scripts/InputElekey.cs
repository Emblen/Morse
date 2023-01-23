using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputElekey : MonoBehaviour
{
    public TextMeshProUGUI InputSignalText;
    public string tmpSignal;
    private int stage; //inputsignalの出力のステージング
    private double PressTime;
    private double notPressTime;
    public double dotTime;
    public double dashTime;
    public string[] dotdashText = {".", "-"};

    private bool printSpace = false;

    public AudioClip SignalSound;
    public AudioSource adSource;

    void PressKey(int dotdash)
    { //dot->0, dash->1
        double[] dotdashTime = {dotTime, dashTime};
        if(PressTime==0)
        {
            adSource.Play();
            PressTime += Time.deltaTime;
        }

        if(PressTime>0 && PressTime<dotdashTime[dotdash]) PressTime+=Time.deltaTime;
        else if(PressTime>=dotdashTime[dotdash]) 
        {   
            if(adSource.isPlaying)
            {
                InputSignalText.text += dotdashText[dotdash];
                tmpSignal += dotdashText[dotdash];
                adSource.Stop();
            }
            else if(PressTime>=dotdashTime[dotdash]+dotTime) PressTime = 0;
            else PressTime+=Time.deltaTime;
        }
    }
    
    void notPressKey()
    {
        if(adSource.isPlaying) adSource.Stop();
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.B)) stage = 0;
        if(notPressTime>=0 && notPressTime<dashTime) notPressTime += Time.deltaTime;
        else if(notPressTime>=dashTime && !printSpace)
        {
            InputSignalText.text += " ";
            printSpace = true;
            stage = 0;
        }
    }


    void Start()
    {
        adSource = GetComponent<AudioSource>();
        PressTime = 0;
        notPressTime = 0;
        stage = 0;
    }

    void Update()
    {
        if(stage==0) //どちらかのキーが押されたときに一度だけ呼び出される
        {   
            PressTime = 0;
            notPressTime = 0;
            if(printSpace)
            {
                tmpSignal = "";
                printSpace = false;
            }
            if(Input.GetKey(KeyCode.Space)) stage = 1;
            else if(Input.GetKey(KeyCode.B)) stage = 2;
        }

        else if(stage==1) //dotステージ
        {
            if(Input.GetKey(KeyCode.Space)) PressKey(0);
            else
            {
                if(tmpSignal.Length==0)
                {
                    InputSignalText.text += ".";
                    tmpSignal=".";
                }
                notPressKey();
            }
        }
        else if(stage==2) //dashステージ
        {
            if(Input.GetKey(KeyCode.B)) PressKey(1);
            else 
            {
                if(tmpSignal.Length==0)
                {
                    InputSignalText.text += "-";
                    tmpSignal="-";
                }
                notPressKey();
            }
        }
    } 

    public bool isPrintSpace()
    {
        return printSpace;
    }
}
