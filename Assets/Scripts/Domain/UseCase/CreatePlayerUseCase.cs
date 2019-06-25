using UnityEngine;
using Zenject;
using UniRx;

namespace Domain.UseCase
{
    public class CreatePlayerUseCase : IInitializable, ICreatePlayerUseCase
    {
        [Inject] IPlayerPresenter playerPresenter;

        void IInitializable.Initialize()
        {
            // 開始時にPlayerを生成

            playerPresenter.CreatePlayer();

            // Playerが場外に落ちた場合、Playerを消去して、新たにPlayerを生成する

            playerPresenter
                .PlayerPositionProperty
                .Where(pos => pos.y < -1)
                .Subscribe(_ => ReInitializePlayer());
        }

        public void ReInitializePlayer()
        {
            playerPresenter.DestroyPlayer();
            playerPresenter.CreatePlayer();
        }
    }

    public interface ICreatePlayerUseCase
    {

    }
}

