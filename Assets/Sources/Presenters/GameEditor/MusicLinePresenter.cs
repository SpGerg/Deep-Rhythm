using Models.GameEditor;
using UnityEngine;
using Views.GameEditor;

namespace Presenters.GameEditor
{
    public class MusicLinePresenter : PresenterBase
    {
        public MusicLinePresenter(MusicLineView view, Vector2 start, float speed) : base(view)
        {
            MusicLineView = view;

            MusicLineModel = new MusicLineModel(this, start, speed);
            Model = MusicLineModel;

            MusicLineView.InitializeTransformable(this, MusicLineModel);
        }
        
        protected MusicLineModel MusicLineModel { get; }

        protected MusicLineView MusicLineView { get; }

        public void ToggleMove(bool toggle)
        {
            MusicLineModel.IsMove = toggle;
        }

        public void OnCollided(Collider2D collider)
        {
            MusicLineModel.OnCollided(collider);
        }
    }
}
