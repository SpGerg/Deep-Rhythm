using UnityEngine;

namespace Models.Interfaces
{
    public interface ITransformable
    {
        Vector2 Position { get; set; }

        float Rotation { get; set; }
    }
}
