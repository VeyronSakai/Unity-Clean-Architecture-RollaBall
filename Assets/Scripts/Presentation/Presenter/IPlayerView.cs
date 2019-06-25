using UnityEngine;
using UniRx;

namespace Presentation.Presenter
{
    public interface IPlayerView {
        IReadOnlyReactiveProperty<Vector3> PlayerPositionProperty { get; }
        Vector3 PlayerPostion { get; }
        void UpdatePosition(Vector3 pos);
        void DestroyPlayer();
    }
}