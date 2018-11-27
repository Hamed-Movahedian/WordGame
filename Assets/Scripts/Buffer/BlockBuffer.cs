using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MgsCommonLib;
using UnityEngine;

public class BlockBuffer : MonoBehaviour
{
    public Transform LetterParent;
    public LetterBase BufferLetterPrefab;

    private readonly List<LetterBase> _letters=new List<LetterBase>();

    private void OnDisable()
    {
        WheelController.Instance.OnChange.RemoveListener(UpdateLetters);
    }

    private void OnEnable()
    {
        WheelController.Instance.OnChange.AddListener(UpdateLetters);

    }

    private void UpdateLetters()
    {
        
        var selectedLetters = WheelController.Instance.SelectedLetters;

        while (_letters.Count>selectedLetters.Count)
        {
            RemoveLast();
        }

        while (_letters.Count<selectedLetters.Count)
        {
            AddLetter(selectedLetters[_letters.Count]);
        }

        FitToCenter();
    }


    public void AddLetter(WheelLetter wlet)
    {
        LetterBase let = (LetterBase) PoolManager.Instance.Create(BufferLetterPrefab);


        let.Setup(wlet.Text);
        let.transform.SetParent(LetterParent);
        let.transform.localPosition = new Vector3(-_letters.Count, 0, 0);

        _letters.Add(let);

    }

    private void FitToCenter()
    {
        if(_letters.Count==0)
            return;
        LetterParent.localPosition=new Vector3((_letters.Count-1)/2f,0,0);
        var scale = Mathf.Min(1,7f/_letters.Count);
        LetterParent.parent.localScale=new Vector3(scale,scale,1);
        _letters.ForEach(l=>l.transform.localScale=Vector3.one);
    }

    public void RemoveLast()
    {
        var last = _letters.Last();
        last.Destroy();
        _letters.Remove(last);
    }

    public void Clear()
    {
        _letters.ForEach(l=>l.Destroy());
        _letters.Clear();
    }
}