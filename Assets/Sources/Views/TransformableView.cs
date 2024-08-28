using Models.Interfaces;
using Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Views;

namespace Assets.Sources.Views
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

        private Quaternion GetRotation()
        {
            return new Quaternion(0, 0, _transformable.Rotation, 0);
        }
    }
}
