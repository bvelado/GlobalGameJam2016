using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine.UI;
using UnityEngine;

public class UpdateTimerViewSystem : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Timer.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        Debug.Log("bloub");
        foreach (var e in entities)
        {
            if(e.hasTimerView)
            {
                e.timerView.view.GetComponentInChildren<Text>().text = e.timer.secondsLeft.ToString();
            }
        }
    }
}
