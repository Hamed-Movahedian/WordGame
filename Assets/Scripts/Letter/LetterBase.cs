using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LetterBase : EmptyLetter
{
    public ActionCorotine OnDestroy = new ActionCorotine();
    public TextMesh TextComponent;
    public string Text => TextComponent.text;

    public void Destroy()
    {
        StartCoroutine((IEnumerator) DestroyCorotine());
    }

    private IEnumerator DestroyCorotine()
    {
        yield return OnDestroy.Run();
        PoolManager.Instance.Return(this);
    }

    public void Setup(string text)
    {
        TextComponent.text = text;
        gameObject.name = $"Letter ({text})";
    }
}

