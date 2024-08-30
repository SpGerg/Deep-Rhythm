using Pools;
using Presenters;
using Services;
using Views.Acceptors;
using Views.Interfaces;

namespace Models
{
    public class AcceptorsModel : ModelBase
    {
        public AcceptorsModel(AcceptorsPresenter presenter,
            AcceptorView[] acceptors) : base(presenter)
        {
            AcceptorsPresenter = presenter;
            _poolService = GameServiceLocator.Get<EnemiesPoolService>();

            _acceptors = acceptors;

            _current = 1;
        }

        public AcceptorsPresenter AcceptorsPresenter { get; }

        public AcceptorView CurrentAcceptor => _acceptors[_current];

        private EnemiesPoolService _poolService;

        private readonly AcceptorView[] _acceptors;

        private int _current;

        public void OnSelectedLeft()
        {
            CurrentAcceptor.IsSelected = false;

            if (_current - 1 < 0)
            {
                _current = _acceptors.Length - 1;
            }
            else
            {
                _current--;
            }

            CurrentAcceptor.IsSelected = true;
        }

        public void OnSelectedRight()
        {
            CurrentAcceptor.IsSelected = false;

            if (_current + 1 > _acceptors.Length - 1)
            {
                _current = 0;
            }
            else
            {
                _current++;
            }

            CurrentAcceptor.IsSelected = true;
        }

        public void OnCollisionWithEnemy(IEnemyView enemyView)
        {
            enemyView.GameObject.SetActive(false);
            _poolService.Return(enemyView);
            EnemyModel.Destroyed.Invoke();
        }
    }
}
