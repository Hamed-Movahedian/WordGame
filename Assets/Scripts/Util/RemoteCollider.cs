using System;
using Controllers;
using UnityEngine;

namespace Util
{
    [Serializable]
    public class RemoteCollider
    {
        public Collider2D Collider;
        private bool _lastOverlap = false;

        public bool OnEnter
        {
            get
            {
                if (InputController.Instance.IsMouse &&
                    Collider.OverlapPoint(InputController.Instance.MousePosition))
                {
                    if (!_lastOverlap)
                    {
                        _lastOverlap = true;
                        return true;
                    }
                    _lastOverlap = true;
                }
                else
                {
                    _lastOverlap = false;
                }
                return false;

            }
        }
    }
}
