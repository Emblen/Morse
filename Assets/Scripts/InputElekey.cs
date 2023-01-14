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
    private const double dotTime = 0.1f;
    private const double dashTime = dotTime*3;
    private double[] dotdashTime = {dotTime, dashTime};
    private string[] dotdashText = {".", "-"};

    private bool printSpace = false;

    public AudioClip SignalSound;
    AudioSource adSource;

    void PressKey(int dotdash)
    { //dot->0, dash->1
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
                adSource.Stop();
            }
            else if(!adSource.isPlaying && PressTime>=dotdashTime[dotdash]+dotTime) PressTime = 0;
        }
    }
    
    void notPressKey()
    {
        if(notPressTime>=0 && notPressTime<dotTime) notPressTime += Time.deltaTime;
        else if(notPressTime>=dotTime && !printSpace)
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
            if(Input.GetKey(KeyCode.B))
            {
                PressTime = 0;
                stage = 1;
                printSpace = false;
            }
            else if(Input.GetKey(KeyCode.Space))
            {
                PressTime = 0;
                stage = 2;
                printSpace = false;
            }
        }
        else if(stage==1) //dotステージ
        {
            if(Input.GetKey(KeyCode.B)) PressKey(0);
            else notPressKey();
        }
        else if(stage==2) //dashステージ
        {
            if(Input.GetKey(KeyCode.Space)) PressKey(1);
            else notPressKey();
        }
    } 
}
