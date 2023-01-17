using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderMotion : MonoBehaviour
{   
    public InputNormal inputnormal;
    public InputElekey inputelekey;
    public GameObject signal;
    
    private int freq, mode;
    private double dotRate;
    private float pitch600;
    private string[] ModeText = {"Normal", "Paddle"};
    
    public Slider PitchSlider, ModeSlider, SpeedSlider;
    public TextMeshProUGUI freqText, modeText, speedText;

    void PitchSliderSet()
    {
        PitchSlider = GetComponent<Slider>();
        PitchSlider.value = 600f;
    }
    void ModeSliderSet()
    {
        ModeSlider = GetComponent<Slider>();
        mode = 0;
        ModeSlider.value = mode;
        modeText.text = ModeText[mode];
        signal.GetComponent<InputElekey>().enabled = false;
        signal.GetComponent<InputNormal>().enabled = true;
    }
    void SpeedSliderSet()
    {
        SpeedSlider = GetComponent<Slider>();
    }
    void Start()
    {
        PitchSliderSet();
        ModeSliderSet();
        SpeedSliderSet();
    }

    public void ModeChanged() 
    {
        mode = (int)(ModeSlider.value+0.5);
        ModeSlider.value = mode;
        modeText.text = ModeText[mode];
        if(mode==0)
        {
            signal.GetComponent<InputElekey>().enabled = false;
            signal.GetComponent<InputNormal>().enabled = true;
        }
        else
        {
            signal.GetComponent<InputElekey>().enabled = true;
            signal.GetComponent<InputNormal>().enabled = false;
        }
    }

    public void PitchChanged()
    {
        freq = (int)PitchSlider.value;
        pitch600 = (float)freq/600;
        signal.GetComponent<AudioSource>().pitch = pitch600;
        freqText.text = freq.ToString() +"Hz";
    }

    public void SpeedChanged()
    {
        dotRate = SpeedSlider.value;
        inputnormal.dotTime = 0.2/dotRate;
        inputelekey.dotTime = 0.1/dotRate;
        inputelekey.dashTime = inputelekey.dotTime*3;

        speedText.text = "x" + dotRate.ToString("0.00");
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.P)) ModeSlider.value = 1;
        else if(Input.GetKey(KeyCode.N)) ModeSlider.value = 0;
    }
}
