using _Code.Observer.Event;
using _Code.PlayerAndMovement.Interfaces;
using UnityEngine;

namespace _Code.PlayerAndMovement
{
    public class SimpleMovePointController : MonoBehaviour, IMovePointBehavior, ICollisionCheckBehavior
    {
        [SerializeField] private Transform _movePoint;
        [SerializeField] private VoidEvent _onMove;
        [SerializeField] private LayerMask _collisionLayer;
        public Transform MovePoint => _movePoint;

        private void Start()
        {
            _movePoint.parent = null;
        }

        public void StepTowards(Vector3 dir)
        {
            _movePoint.position += dir;
            _onMove.Raise();
        }

        public void SetPosition(Vector3 pos)
        {
            _movePoint.position = pos;
        }

        public bool CollisionCheck(Vector3 direction, float cellScale)
        {
            return Physics2D.OverlapCircle(_movePoint.position + direction*cellScale/2, cellScale/5, _collisionLayer);
        }
    }
}