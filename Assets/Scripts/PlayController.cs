using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgsCommonLib;

public class PlayController : MgsSingleton<PlayController>
{
    public void PlayPuzzle(Puzzle puzzle)
    {
        BoardController.Instance.Setup(puzzle);
    }
}