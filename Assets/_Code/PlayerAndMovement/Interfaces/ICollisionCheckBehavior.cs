using UnityEngine;

namespace _Code.PlayerAndMovement.Interfaces
{
    public interface ICollisionCheckBehavior
    {
        bool CollisionCheck(Vector3 direction, float cellScale);
    }
}