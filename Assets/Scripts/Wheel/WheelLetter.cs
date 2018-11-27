using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controllers;
using UnityEngine;
using UnityEngine.Events;
using Util;
using Random = UnityEngine.Random;

public class WheelLetter : LetterBase
{
    public RemoteCollider RemoteCollider;

    public UnityEvent OnSelect;
    public UnityEvent OnReselect;
    public UnityEvent OnUnselect;

    private bool _isSelected=false;

    internal void Setup(string text, float angle, float distance)
    {
        Setup(text);

        // set parent as wheel center
        transform.SetParent(WheelController.Instance.WheelCenter);
        
        // set angle
        transform.localEulerAngles=new Vector3(0,0,angle);

        // set distance
        Distance = distance;

        // safty 
        transform.localPosition=Vector3.zero;
        transform.GetChild(0).rotation = Quaternion.identity;

        RemoteCollider.Collider.transform.Rotate(0,0, Random.Range(-10, +10));
    }

    public float Distance
    {
        set
        {
            transform.GetChild(0).localPosition = new Vector3(value, 0, 0);
        }
    }

    private void Update()
    {
        if (RemoteCollider.OnEnter)
        {
            if (!_isSelected)
            {
                _isSelected = true;
                Select();
            }
            else
                ReSelect();
        }

    }

    private void ReSelect()
    {
        OnReselect.Invoke();
        WheelController.Instance.ReselectLetter(this);
    }

    private void Select()
    {
        OnSelect.Invoke();
        WheelController.Instance.SelectLetter(this);
    }

    public void Unselect()
    {
        OnUnselect.Invoke();
        _isSelected = false;
    }
}