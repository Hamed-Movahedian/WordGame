using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controllers;
using MgsCommonLib;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class WheelController : MgsSingleton<WheelController>
{
    public Transform WheelCenter;
    public WheelLetter WheelLetterPrefab;
    public float Radius = 2.5f;

    public UnityEvent OnChange;

    public List<WheelLetter> SelectedLetters=new List<WheelLetter>();
    
    private readonly List<WheelLetter> _letters= new List<WheelLetter>();
    
    public void Setup(List<char> letters)
    {
        // Destroy old letters
        _letters.ForEach(l=>l.Destroy());
        _letters.Clear();

        // Add new letters
        float deltaAngle = 360f / letters.Count;
        float angle = 0;

        for (int i = 0; i < letters.Count; i++)
        {
            WheelLetter let = (WheelLetter) PoolManager.Instance.Create(WheelLetterPrefab);

            let.Setup(letters[i].ToString(), angle,Radius);

            angle += deltaAngle;

            _letters.Add(let);
        }
    }

    public void ReselectLetter(WheelLetter letter)
    {
        var index = SelectedLetters.IndexOf(letter);

        while (SelectedLetters.Count>index+1)
        {
            RemoveLast();
        }
    }

    private void RemoveLast()
    {
        var letter = SelectedLetters.Last();
        letter.Unselect();
        SelectedLetters.Remove(letter);
        OnChange.Invoke();
    }

    public void SelectLetter(WheelLetter letter)
    {
        SelectedLetters.Add(letter);
        OnChange.Invoke();
    }

    private void Update()
    {
        if (InputController.Instance.IsMouseUp)
        {
            SelectedLetters.ForEach(l=>l.Unselect());
            SelectedLetters.Clear();
            OnChange.Invoke();
        }
    }

}