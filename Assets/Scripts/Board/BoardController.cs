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
    public Transform LettersTransform;

    private readonly List<BoardWord> _words=new List<BoardWord>();

    public void Setup(Puzzle puzzle)
    {
        foreach (var word in _words)
        {
            word.Destroy();
        }

        _words.Clear();

        var pos2leter = new Dictionary<Vector2, BoardLetter>();


        for (int i = 0; i < puzzle.Count; i++)
        {
            _words.Add(CreateWord(puzzle[i],pos2leter));
        }

        var boardLetters = pos2leter.Values.ToList();

        Bounds bounds=boardLetters[0].Bound;

        boardLetters.ForEach(l=>bounds.Encapsulate(l.Bound));

        // Center letters
        LettersTransform.localPosition = -bounds.center;
        // Scale to fit
        float scale = Mathf.Min(
            Mathf.Min(1, 6f / bounds.size.x),
            Mathf.Min(1, 4f / bounds.size.y));

        LettersTransform.parent.localScale=new Vector3(scale,scale,1);
    }

    private BoardWord CreateWord(WordData wordData, Dictionary<Vector2, BoardLetter> pos2Leter)
    {
        BoardWord word = (BoardWord) PoolManager.Instance.Create(WordPrefab);

        word.transform.SetParent(transform);

        word.Setup(wordData, pos2Leter, LetterPrefab);

        return word;
    }

}