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
    private double speed;
    private float pitch600;
    private string[] ModeText = {"Normal", "Paddle"};
    
    public Slider PitchSlider, ModeSlider, SpeedSlider;
    public TextMeshProUGUI freqText, modeText;

    void PitchSliderSet()
    {
        PitchSlider = GetComponent<Slider>();
        freq = (int)PitchSlider.value;
        pitch600 = 1.0f;
        freqText.text = "700Hz";
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

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            ModeSlider.value = 1;
        }
        else if(Input.GetKey(KeyCode.N))
        {
            ModeSlider.value = 0;
        }
    }
}
