using UnityEngine;
using UniRx;
using System;

namespace Domain.UseCase
{
    public interface IInputPresenter
    {
        IObservable<Unit> OnUpKeyDownAsObservable();
        IObservable<Unit> OnRightKeyDownAsObservable();
        IObservable<Unit> OnDownKeyDownAsObservable();
        IObservable<Unit> OnLeftKeyDownAsObservable();
    }
}

