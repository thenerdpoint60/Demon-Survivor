using UnityEngine;

namespace VampireSurvivor
{
    public interface IMovableState
    {
        public Vector2 CurrentPosition { get; }
    }
}