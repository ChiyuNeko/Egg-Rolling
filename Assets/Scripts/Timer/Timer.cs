using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;
    public float time;
    public int min;
    public int sec;
    public Text TimeText;
    bool stop;
    void Start()
    {
        time = Time.time;
    }

    
    void Update()
    {
        if(!stop)
        {
            UpdateTime();
        }

        
    }

    public void PrintTime()
    {
        TimeText.text = "你共使用了" + text.text;
    }
    public void UpdateTime()
    {
        min = (int)(Time.time - time)/60;
        sec = (int)(Time.time - time)%60;

        if (sec < 10)
            text.text = $"{min}:0{sec}";
        else if(sec == 0)
            text.text = $"{min}:00";
        else
            text.text = $"{min}:{sec}";
    }

    public void StopTimer()
    {
        stop = true;
    }
}
