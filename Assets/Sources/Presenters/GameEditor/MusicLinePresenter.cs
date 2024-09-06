using Models.GameEditor;
using UnityEngine;
using Views.GameEditor;

namespace Presenters.GameEditor
{
    public class MusicLinePresenter : PresenterBase
    {
        public MusicLinePresenter(MusicLineView view, Vector2 start, float speed) : base(view)
        {
            View = view;

            Model = new MusicLineModel(this, start, speed);
            base.Model = Model;

            View.InitializeTransformable(this, Model);
        }
        
        protected new MusicLineModel Model { get; }

        protected new MusicLineView View { get; }

        public void ToggleMove(bool toggle)
        {
            Model.IsMove = toggle;
        }

        public void OnCollided(Collider2D collider)
        {
            Model.OnCollided(collider);
        }
    }
}
