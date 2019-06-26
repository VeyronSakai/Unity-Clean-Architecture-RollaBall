using UnityEngine;
using UniRx;

namespace Presentation.Presenter
{
    public interface IPlayerView {
        IReadOnlyReactiveProperty<Vector3> PlayerPositionProperty { get; }
        Vector3 PlayerPostion { get; }
        void ReInitializePlayer(Vector3 pos);
        void Move(Vector3 direction);
    }
}