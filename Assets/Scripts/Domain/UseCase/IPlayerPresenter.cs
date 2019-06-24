using UnityEngine;
using UniRx;
using Presentation.Presenter;

namespace Domain.UseCase
{
    public interface IPlayerPresenter
    {
        Transform Tr { get; }
        IReadOnlyReactiveProperty<Transform> TransformProperty { get; }
        IPlayerView CreatePlayer();
        void UpdatePlayerPosition(Vector3 pos);
		void DestroyPlayer();
    }
}