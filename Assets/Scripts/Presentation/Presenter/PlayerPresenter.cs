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

        public void ReInitializePlayer(Vector3 pos)
        {
            playerView.ReInitializePlayer(pos);
        }

        public void Move(Vector3 direction)
        {
            playerView.Move(direction);
        }
    }
}
