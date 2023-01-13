using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class InputSignal : MonoBehaviour
{
    public TextMeshProUGUI InputSignalText;
    public string tmpSignal;
    private int stage; //inputsignalの出力のステージング
    private double PressTime;
    private double notPressTime;
    private const double dotTime = 0.2f;
    // private const double dashTime = dotTime*3;
    private bool printDash = false;
    private bool printDot = false;
    private bool printSpace = false;

    public AudioClip SignalSound;
    AudioSource adSource;

    
    void Start()
    {
        stage = 0;
        adSource = GetComponent<AudioSource>();
    }
    

    void Update()
    {
        if(stage==0)
        {
            //キーが押されたときに一度だけ呼び出される
            if(Input.GetKey(KeyCode.Space))
            {   
                adSource.Play();
                if(printSpace) tmpSignal = "";
                PressTime = 0;
                printDash = false;
                printDot = false;
                printSpace = false;
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
                }
            }
            else stage = 0;
        }
    }

    public bool isPrintSpace()
    {
        return printSpace;
    }

    private void EndGame()
    {
        if(Input.GetKey(KeyCode.Escape)) Application.Quit();
    }
}
