using UnityEngine;
using UnityEngine.Events;

namespace Views.GameEditor
{
    public class MusicLineView : ViewBase
    {
        public bool IsMove
        {
            get
            {
                return _isMove;
            }
            set
            {
                transform.position = _start;

                _isMove = value;
            }
        }

        public UnityEvent Ended { get; } = new();

        [SerializeField]
        private float _speed;

        private Vector2 _start;

        private bool _isMove;

        public void Awake()
        {
            _start = transform.position;
        }

        public override void Update()
        {
            if (IsMove)
            {
                transform.Translate(_speed * Time.deltaTime * transform.up);
            }

            base.Update();
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("MusicLineEnd"))
            {
                return;
            }

            IsMove = false;

            Ended.Invoke();
        }
    }
}
