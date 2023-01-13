using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonClick : MonoBehaviour
{
    
    public InputSignal inputsignal;
    public OutputSignal outputsignal;
    public void ResetClick()
    {
        inputsignal.InputSignalText.text = "";
        outputsignal.OutputSignalText.text = "";
    }
}
