using UnityEngine;
using Zenject;
using UniRx;
using Domain.UseCase;

namespace Presentation.Presenter
{
    public class PlayerPresenter : IPlayerPresenter
	{
        private IPlayerView playerView;

        public Vector3 PlayerPosition => playerView.PlayerPostion;

        public IReadOnlyReactiveProperty<Vector3> PlayerPositionProperty => playerView.PlayerPositionProperty;

        [Inject] IFactory<IPlayerView> playerViewFactory;

        public IPlayerView CreatePlayer()
        {
            playerView =  playerViewFactory.Create();
            return playerView;
        }

        public void UpdatePlayerPosition(Vector3 pos)
        {
            playerView.UpdatePosition(pos);
        }

        public void DestroyPlayer()
        {
            playerView.DestroyPlayer();
        }
    }
}
