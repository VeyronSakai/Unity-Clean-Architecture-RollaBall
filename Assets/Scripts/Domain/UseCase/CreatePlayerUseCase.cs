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

            playerPresenter
                .PlayerPositionProperty
                .Where(pos => pos.y < -1)
                .Subscribe(_ => ReInitializePlayer());
        }


        public void ReInitializePlayer()
        {
            // 初期位置に戻す
            playerPresenter.ReInitializePlayer(new Vector3(0, 1, 0));
        }
    }

    public interface ICreatePlayerUseCase
    {

    }
}