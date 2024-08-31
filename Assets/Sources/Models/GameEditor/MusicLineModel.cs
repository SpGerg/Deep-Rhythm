using Models.Interfaces;
using Presenters.GameEditor;
using UnityEngine;
using Views.GameEditor;

namespace Models.GameEditor
{
    public class MusicLineModel : TransformableModel, IUpdatable
    {
        public MusicLineModel(MusicLinePresenter presenter, Vector2 start, float speed) : base(presenter)
        {
            _musicLinePresenter = presenter;
            _start = start;
            _speed = speed;
        }

        public bool IsMove
        {
            get
            {
                return _isMove;
            }
            set
            {
                Position = _start;

                _isMove = value;
            }
        }

        private readonly MusicLinePresenter _musicLinePresenter;

        private readonly Vector2 _start;

        private readonly float _speed;

        private bool _isMove;

        public void Update()
        {
            if (IsMove)
            {
                Translate(_speed * Time.deltaTime * Vector2.up);
            }
        }

        public void LateUpdate() { }

        public void OnCollided(Collider2D collision)
        {
            if (!collision.CompareTag("MusicLineEnd"))
            {
                return;
            }

            IsMove = false;

            MusicLineView.Ended.Invoke();
        }
    }
}
