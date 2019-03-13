using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ARposjetnica : MonoBehaviour
{
    public TextMeshPro brojPobjedaTekst;
    public TextMeshPro brojPorazaTekst;

    private int wins;
    private int losses;

    private void Start(){
        //TODO save
        wins = 0;
        losses = 0;
    }

    public void IncrementWin(){
        wins++;
        Render(brojPobjedaTekst, wins);
    }

    public void IncrementLoss(){
        losses++;
        Render(brojPorazaTekst, losses);
    }

    public void Render(TextMeshPro tmpro, int num)
    {
        tmpro.text = num.ToString();
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.W)){
            IncrementWin();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            IncrementLoss();
        }      
    }
}
