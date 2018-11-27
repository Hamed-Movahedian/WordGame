using MgsCommonLib;
using UnityEngine;

namespace Controllers
{
    public class InputController : MgsSingleton<InputController>
    {
        public Camera Camera;
        public bool IsMouse => Input.GetMouseButton(0);
        public Vector2 MousePosition => Camera.ScreenToWorldPoint(Input.mousePosition);
        public bool IsMouseDown => Input.GetMouseButtonDown(0);
        public bool IsMouseUp => Input.GetMouseButtonUp(0);
    }
}
