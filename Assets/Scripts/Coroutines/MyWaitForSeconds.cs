using System;
using UnityEngine;

public class MyWaitForSeconds : MyYieldInstruction
{
    private readonly float seconds;
    private float endTime;

    public MyWaitForSeconds(float seconds)
    {
        this.seconds = seconds;
        SetEndTime();
    }

    private void SetEndTime()
    {
        endTime = Time + seconds;
    }

    public override object Current
    {
        get { return null; }
    }

    public override bool MoveNext()
    {
        return Time < endTime;
    }

    public override void Reset()
    {
        SetEndTime();
    }
}