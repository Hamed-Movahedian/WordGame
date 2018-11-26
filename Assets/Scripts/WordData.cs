using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class WordData
{
    [SerializeField]
    private bool _isHorizontal;
    [SerializeField]
    private string _letters = "";
    [SerializeField]
    private Vector2 _position;

    public int Count => _letters.Length;

    public char GetLetter(int i) => _letters[i];

    public Vector2 GetPos(int i) => _isHorizontal ? 
        _position + Vector2.left * i : 
        _position + Vector2.down * i;

    public List<char> Distinct => _letters.Distinct().ToList();
}