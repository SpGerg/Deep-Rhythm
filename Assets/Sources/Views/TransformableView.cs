using Models.Interfaces;
using Presenters.Interfaces;
using UnityEngine;

namespace Views
{
    public abstract class TransformableView : ViewBase
    {
        private ITransformable _transformable;

        public void InitializeTransformable(IPresenter presenter, ITransformable transformable)
        {
            _transformable = transformable;
            _transformable.Position = transform.position;
            _transformable.Rotation = transform.rotation.z;

            base.Initialize(presenter);
        }

        public override void Update()
        {
            transform.SetPositionAndRotation(_transformable.Position, GetRotation());

            base.Update();
        }

        public void SetPosition(Vector2 position)
        {
            _transformable.Position = position;
        }

        public void SetRotation(float rotation)
        {
            _transformable.Rotation = rotation;
        }

        private Quaternion GetRotation()
        {
            return new Quaternion(0, 0, _transformable.Rotation, 0);
        }
    }
}
