using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ActionCorotine
{
    public float Duration;

    public UnityEvent OnStart = new UnityEvent();
    public UnityEvent OnEnd = new UnityEvent();

    private int _waitConter = 0;

    public IEnumerator Run()
    {
        _waitConter = 0;
        OnStart.Invoke();

        if (Duration > 0)
            yield return new WaitForSeconds(Duration);

        while (_waitConter>0)
        {
            yield return null;
        }

        OnEnd.Invoke();
    }

    public void Wait() => _waitConter++;
    public void Continue() => _waitConter--;
}