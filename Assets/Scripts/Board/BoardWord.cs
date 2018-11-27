using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BoardWord : MonoBehaviour
{
    private readonly List<BoardLetter> _letters=new List<BoardLetter>();

    public ActionCorotine OnDestroy=new ActionCorotine();
    public void Destroy()
    {
        _letters.ForEach(l=>l.Destroy());
        _letters.Clear();
        StartCoroutine(DestroyCorotine());
    }

    private IEnumerator DestroyCorotine()
    {
        yield return OnDestroy.Run();
        PoolManager.Instance.Return(this);
    }

    public void Setup(WordData wordData, Dictionary<Vector2, BoardLetter> pos2Leter, BoardLetter letterPrefab)
    {
        // Destroy old letters
        _letters.ForEach(l=>l.Destroy());
        _letters.Clear();

        // add new letters
        for (int i = 0; i < wordData.Count; i++)
        {
            var pos = wordData.GetPos(i);
            BoardLetter letter;
            if (pos2Leter.ContainsKey(pos))
            {
                letter = pos2Leter[pos];
            }
            else
            {
                letter = (BoardLetter) PoolManager.Instance.Create(letterPrefab);
                letter.Setup(wordData.GetLetter(i), pos);
                pos2Leter[pos] = letter;
            }
            _letters.Add(letter);
        }

        gameObject.name = $"Word ({PersianFixer.Fix(wordData.Text)})";
    }
}