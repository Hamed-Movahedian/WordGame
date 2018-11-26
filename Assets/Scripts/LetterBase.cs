using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LetterBase : EmptyLetter
{
    public ActionCorotine OnDestroy = new ActionCorotine();

    public void Destroy()
    {
        StartCoroutine((IEnumerator) DestroyCorotine());
    }

    private IEnumerator DestroyCorotine()
    {
        yield return OnDestroy.Run();
        PoolManager.Instance.Return(this);
    }
}

