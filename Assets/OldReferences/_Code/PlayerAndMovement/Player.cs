using _Code.PlayerAndMovement.Interfaces;
using _Code.Toolbox.ValueHolders;
using UnityEngine;

namespace _Code.PlayerAndMovement
{
    public class Player : MonoBehaviour
    {
        [Header("Mechanics")]
        [SerializeField] private float _stepSpeed = 1;
        [SerializeField] private FloatValue _cellScaleSize;
        [SerializeField] private BoolValue _canMove;
        
        [Header("Juice Components")]
        [SerializeField] private Animator _animatorController;
        // [SerializeField] private CameraEffects cameraEffects;
        // [SerializeField] private float _shakeTime = 1.0f;
        // [SerializeField] private float _downscalingFactor = 1.0f;
        private IMovePointBehavior _movePointBehavior;
        private ICollisionCheckBehavior _collisionCheckBehavior;

        private void Awake()
        {
            _movePointBehavior = GetComponent<IMovePointBehavior>();
            _collisionCheckBehavior = GetComponent<ICollisionCheckBehavior>();
            // cameraEffects = FindObjectOfType<CameraEffects>();
        }

        public void SetPosition(Vector3 position)
        {
            _movePointBehavior.SetPosition(position);
            gameObject.transform.position = position;
        }

        private void Update()
        {
            if (!_canMove.Value)
                return;
            
            ChaseMovePoint();

            bool arrivedAtMovePoint =
                Vector3.Distance(transform.position, _movePointBehavior.MovePoint.position) < 0.05f;

            bool onlyOneDirectionIsDown =
                (Input.GetButtonDown("Horizontal") && !Input.GetButtonDown("Vertical")) ||
                (!Input.GetButtonDown("Horizontal") && Input.GetButtonDown("Vertical"));
            
            if (arrivedAtMovePoint)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ScreenClickMovement();
                }
                else if (onlyOneDirectionIsDown)
                {
                    var direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
                    TryMoving(direction);
                }
            }
        }

        private void ChaseMovePoint()
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _movePointBehavior.MovePoint.position,
                    _stepSpeed * Time.deltaTime);
        }

        private void ScreenClickMovement()
        {
            // here, I'm centering the cartesian of the screen in the center, as opposed to the bottom-left corner 
            var screenCenterPosition = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
            var xPercent = (Input.mousePosition.x - screenCenterPosition.x) / screenCenterPosition.x;
            var yPercent = (Input.mousePosition.y - screenCenterPosition.y) / screenCenterPosition.y;

            if (Mathf.Abs(xPercent) > Mathf.Abs(yPercent))
            {
                TryMoving(new Vector3(xPercent / Mathf.Abs(xPercent), 0, 0));
            }
            else if (Mathf.Abs(yPercent) > Mathf.Abs(xPercent))
            {
                TryMoving(new Vector3(0, yPercent / Mathf.Abs(yPercent), 0));
            }
        }

        private void TryMoving(Vector3 direction)
        {
            if (_collisionCheckBehavior.CollisionCheck(direction, _cellScaleSize.Value))
                return;

            // StartCoroutine(cameraEffects.ScreenKick(_shakeTime, _downscalingFactor)); // A good value for DS factor was 0.998f, weird....
            _animatorController.Play("Move");
            _movePointBehavior.StepTowards(direction * _cellScaleSize.Value);
        }
    }
}