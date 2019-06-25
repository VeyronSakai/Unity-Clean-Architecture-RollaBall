using UnityEngine;
using UniRx;
using Presentation.Presenter;

namespace Domain.UseCase
{
    public interface IPlayerPresenter
    {
        Vector3 PlayerPosition { get; }
        IReadOnlyReactiveProperty<Vector3> PlayerPositionProperty { get; }
        IPlayerView CreatePlayer();
        void UpdatePlayerPosition(Vector3 pos);
		void DestroyPlayer();
    }
}