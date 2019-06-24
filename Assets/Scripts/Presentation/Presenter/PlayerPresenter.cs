using UnityEngine;
using Zenject;
using Domain.UseCase;

namespace Presentation.Presenter
{
    public class PlayerPresenter : IPlayerPresenter{

        private IPlayerView playerView;

        public Transform Tr => playerView.Tr;

        [Inject] IFactory<IPlayerView> playerViewFactory;

        public IPlayerView CreatePlayer(){
            playerView =  playerViewFactory.Create();
            return playerView;
        }

        public void UpdatePlayerPosition(Vector3 pos){
            playerView.UpdatePosition(pos);
        }

        public void DestroyPlayer()
        {
            playerView.DestroyPlayer();
        }
    }
}
