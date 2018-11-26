using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Puzzle
{
    [SerializeField]
    private List<WordData> _words=new List<WordData>();

    public int Count => _words.Count;

    public WordData this[int i] => _words[i];

    public List<char> Distinct => _words.SelectMany(w => w.Distinct).Distinct().ToList();
}
