using Presenters.GameEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Views.GameEditor
{
    public class MusicLineView : TransformableView
    {
        public static UnityEvent Ended { get; } = new();

        public MusicLinePresenter MusicLinePresenter => _musicLinePresenter;

        private MusicLinePresenter _musicLinePresenter;

        [SerializeField]
        private float _speed;

        private Vector2 _start;

        public void Awake()
        {
            _start = transform.position;

            _musicLinePresenter = new MusicLinePresenter(this, _start, _speed);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            MusicLinePresenter.OnCollided(collision);
        }
    }
}
