using UnityEngine;

namespace DemonSurvivor
{
    public interface IMovableState
    {
        public Vector2 CurrentPosition { get; }
    }
}