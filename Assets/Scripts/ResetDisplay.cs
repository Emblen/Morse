using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ResetDisplay : MonoBehaviour
{
    
    public InputSignal inputsignal;
    public OutputSignal outputsignal;
    public void ResetClick()
    {
        inputsignal.InputSignalText.text = "";
        outputsignal.OutputSignalText.text = "";
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Delete))
        {
            inputsignal.InputSignalText.text = "";
            outputsignal.OutputSignalText.text = "";
        }
    }
}
