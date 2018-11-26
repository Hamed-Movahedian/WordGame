using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MgsCommonLib;
using UnityEngine;

public class BoardController : MgsSingleton<BoardController>
{
    public BoardWord WordPrefab;
    public BoardLetter LetterPrefab;

    private List<BoardWord> _words=new List<BoardWord>();

    public void Setup(Puzzle puzzle)
    {
        foreach (var word in _words)
        {
            word.Destroy();
        }

        _words.Clear();

        var pos2leter = new Dictionary<Vector2, BoardLetter>();

        Bounds bounds=new Bounds();

        for (int i = 0; i < puzzle.Count; i++)
        {
            _words.Add(CreateWord(puzzle[i],pos2leter,bounds));
        }

    }

    private BoardWord CreateWord(WordData wordData, Dictionary<Vector2, BoardLetter> pos2Leter, Bounds bounds)
    {
        BoardWord word = (BoardWord) PoolManager.Instance.Create(WordPrefab);

        word.transform.SetParent(transform);

        word.Setup(wordData, pos2Leter, bounds, LetterPrefab);

    }

}