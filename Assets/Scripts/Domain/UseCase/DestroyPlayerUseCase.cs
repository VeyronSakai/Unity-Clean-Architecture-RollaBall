using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

namespace Domain.UseCase
{
    public class DestroyPlayerUseCase : IDestroyPlayerUseCase, IInitializable
    {
        [Inject] IPlayerPresenter playerPresenter;

        void IInitializable.Initialize()
        {
            // Playerが場外に落ちた場合、Playerを消去して、新たにPlayerを生成する
            playerPresenter
                .TransformProperty
                .Where(x => x.position.y < -1)
                .Subscribe(_ => ReInitializePlayer());
        }

        public void ReInitializePlayer()
        {
            playerPresenter.DestroyPlayer();
            playerPresenter.CreatePlayer();
        }
    }

    public interface IDestroyPlayerUseCase
    {

    }
}


