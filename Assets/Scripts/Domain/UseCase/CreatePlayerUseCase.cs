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
            playerPresenter.CreatePlayer();
        }
    }

    public interface ICreatePlayerUseCase
    {

    }
}

