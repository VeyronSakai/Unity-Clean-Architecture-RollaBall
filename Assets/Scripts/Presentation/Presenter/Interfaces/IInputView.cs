using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Presentation.Presenter
{
    public interface IInputView
    {
        IObservable<Unit> OnUpKeyDownAsObservable();
        IObservable<Unit> OnRightKeyDownAsObservable();
        IObservable<Unit> OnDownKeyDownAsObservable();
        IObservable<Unit> OnLeftKeyDownAsObservable();
    }
}

