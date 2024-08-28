using Models.Interfaces;
using Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Models
{
    public abstract class TransformableModel : ModelBase, ITransformable
    {
        public TransformableModel(IPresenter presenter) : base(presenter)
        {
        }

        public Vector2 Position { get; set; }

        public float Rotation { get; set; }

        public void Translate(Vector2 translated)
        {
            Position += translated;
        }
    }
}
