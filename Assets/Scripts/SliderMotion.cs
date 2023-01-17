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
    private double speed, pitch600;
    private string[] ModeText = {"Normal", "Paddle"};
    
    public Slider PitchSlider, ModeSlider, SpeedSlider;
    public TextMeshProUGUI freqText, modeText;

    void PitchSliderSet()
    {
        PitchSlider = GetComponent<Slider>();
        PitchSlider.value = 600;
        freq = (int)PitchSlider.value;
        pitch600 = 1.0;
        freqText.text = "600Hz";
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

    }

    // Update is called once per frame
    void Update()
    {
        
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

    // public void PitchChanged()
    // {
    //     freq = (int)PitchSlider.value;
    //     pitch600 = (double)freq/600;
    //     if(signal.GetComponent<InputElekey>().enabled) inputelekey.adSource.pitch = (float)pitch600;
    //     else inputnormal.adSource.pitch = (float)pitch600;
    //     freqText.text = ((int)freq).ToString() +"Hz";
    // }
}
