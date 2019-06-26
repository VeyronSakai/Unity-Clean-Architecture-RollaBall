using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;
using Presentation.Presenter;

namespace Domain.UseCase
{
    public class MovePlayerUseCase : IMovePlayerUseCase, IInitializable
    {
        [Inject] private IPlayerPresenter playerPresenter;

        [Inject] private IInputPresenter inputPresenter;

        private Vector3 moveDirection;

        void IInitializable.Initialize()
        {
            Observable
                .EveryUpdate()
                .Subscribe(_ => playerPresenter.Move(moveDirection));

            playerPresenter
                .Move(moveDirection);

            inputPresenter
                .OnUpKeyDownAsObservable()
                .Subscribe(_ => moveDirection.z = 1);

            inputPresenter
                .OnRightKeyDownAsObservable()
                .Subscribe(_ => moveDirection.x = 1);

            inputPresenter
                .OnDownKeyDownAsObservable()
                .Subscribe(_ => moveDirection.z = -1);

            inputPresenter
                .OnLeftKeyDownAsObservable()
                .Subscribe(_ => moveDirection.x = -1);

            inputPresenter
                .OnUpKeyUpAsObservable()
                .Subscribe(_ => moveDirection.z = 0);

            inputPresenter
                .OnRightKeyUpAsObservable()
                .Subscribe(_ => moveDirection.x = 0);

            inputPresenter
                .OnDownKeyUpAsObservable()
                .Subscribe(_ => moveDirection.z = 0);

            inputPresenter
                .OnLeftKeyUpAsObservable()
                .Subscribe(_ => moveDirection.x = 0);
        }
    }

    public interface IMovePlayerUseCase
    {

    }
}


