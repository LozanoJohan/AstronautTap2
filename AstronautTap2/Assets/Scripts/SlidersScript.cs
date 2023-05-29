using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidersScript : MonoBehaviour
{
    public Slider iman;
    public Slider invencible;
    public Slider x2;
    public Slider gold;

    public Slider revive;
    public Button reviveBtn;
    public static float vlue;

    void Update()
    {
        if (EstrellaScript.startTime != 0) 
                iman.value = (EstrellaScript.startTime + EstrellaScript.powerDuration - Time.time) / EstrellaScript.powerDuration;
        if (SolScript.startTime != 0) 
                invencible.value = (SolScript.startTime + SolScript.powerDuration - Time.time) / SolScript.powerDuration;
        if (StaticStuff.startTime != 0) 
                x2.value = (StaticStuff.startTime + StaticStuff.powerDuration - Time.time) / StaticStuff.powerDuration;
        if (AsteroideScript.startTime != 0) 
                gold.value = (AsteroideScript.startTime + AsteroideScript.powerDuration - Time.time) / AsteroideScript.powerDuration;

        revive.value = (StaticStuff.timeDied + 6 - Time.time) / 6;
        if (revive.value == 0 && !StaticStuff.player) reviveBtn.interactable = false;
    }
}
