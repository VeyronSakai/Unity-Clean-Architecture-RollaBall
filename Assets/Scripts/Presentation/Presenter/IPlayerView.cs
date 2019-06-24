using UnityEngine;
using UniRx;

namespace Presentation.Presenter
{
    public interface IPlayerView {
        Transform Tr{get;}
        IReadOnlyReactiveProperty<Transform> TransformProperty { get; }
        void UpdatePosition(Vector3 pos);
        void DestroyPlayer();
    }
}