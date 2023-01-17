using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderMotion : MonoBehaviour
{
    public InputElekey inputelekey;

    private int freq, mode;
    private double speed, pitch600;
    private string[] ModeText = {"Qcode","En","Ja"};
    
    public Slider PitchSlider, ModeSlider, SpeedSlider;
    public TextMeshProUGUI freqText;

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
    }
    void SpeedSliderSet()
    {
        SpeedSlider = GetComponent<Slider>();
    }
    void Start()
    {
        PitchSliderSet();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PitchChanged()
    {
        freq = (int)PitchSlider.value;
        pitch600 = (double)freq/600;
        inputelekey.adSource.pitch = (float)pitch600;
        freqText.text = ((int)freq).ToString() +"Hz";
    }
}
