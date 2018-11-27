using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgsCommonLib;
using UnityEngine;

public class GameController : MgsSingleton<GameController>
{
    public Puzzle CurrentPuzzle;

    private void Start()
    {
        PlayController.Instance.PlayPuzzle(CurrentPuzzle);
    }


}