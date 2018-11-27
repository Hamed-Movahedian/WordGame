using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BoardLetter : LetterBase
{
    public Vector2 Position => (Vector2)transform.localPosition;
    public Bounds Bound => new Bounds(Position+Vector2.one/2,Vector3.one);

    public void Setup(string text, Vector2 pos)
    {
        // set Text
        Setup(text);

        // set transform
        transform.SetParent(BoardController.Instance.LettersTransform);
        transform.localPosition = pos;
        transform.localScale = Vector3.one;

        // hide letter gameobject
        //TextComponent.gameObject.SetActive(false);
    }
}