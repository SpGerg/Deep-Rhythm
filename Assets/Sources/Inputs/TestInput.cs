using UnityEngine;
using Views;

namespace Inputs
{
    public class TestInput : MonoBehaviour
    {
        [SerializeField]
        private AcceptorsView _acceptorsView;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _acceptorsView.AcceptorsPresenter.OnSelectedLeft();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _acceptorsView.AcceptorsPresenter.OnSelectedRight();
            }
        }
    }
}
