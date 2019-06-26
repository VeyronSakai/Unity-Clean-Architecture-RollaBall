using UnityEngine;
using Zenject;
using UniRx;
using System;
using Domain.UseCase;

namespace Presentation.Presenter
{
    public class InputPresenter : IInputPresenter
    {
        [Inject] private IInputView inputView;

        public IObservable<Unit> OnUpKeyDownAsObservable()
        {
            return inputView.OnUpKeyDownAsObservable();
        }

        public IObservable<Unit> OnRightKeyDownAsObservable()
        {
            return inputView.OnRightKeyDownAsObservable();
        }

        public IObservable<Unit> OnDownKeyDownAsObservable()
        {
            return inputView.OnDownKeyDownAsObservable();
        }

        public IObservable<Unit> OnLeftKeyDownAsObservable()
        {
            return inputView.OnLeftKeyDownAsObservable();
        }
    }

}

