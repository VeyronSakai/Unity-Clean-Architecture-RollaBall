using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using Presentation.Presenter;

namespace Presentation.View
{
    public class InputView : IInputView
    {
        public IObservable<Unit> OnUpKeyDownAsObservable()
        {
            return Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.UpArrow)).AsUnitObservable();
        }

        public IObservable<Unit> OnRightKeyDownAsObservable()
        {
            return Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.RightArrow)).AsUnitObservable();
        }

        public IObservable<Unit> OnDownKeyDownAsObservable()
        {
            return Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.DownArrow)).AsUnitObservable();
        }

        public IObservable<Unit> OnLeftKeyDownAsObservable()
        {
            return Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.LeftArrow)).AsUnitObservable();
        }
    }
}


