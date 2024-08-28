using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Views.Acceptors
{
    public class Acceptor : MonoBehaviour
    {
        public SpriteRenderer Renderer => _renderer;

        [SerializeField]
        private SpriteRenderer _renderer;
    }
}
