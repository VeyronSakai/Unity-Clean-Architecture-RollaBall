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

        public IObservable<Unit> OnUpKeyUpAsObservable()
        {
            return Observable.EveryUpdate().Where(_ => Input.GetKeyUp(KeyCode.UpArrow)).AsUnitObservable();
        }

        public IObservable<Unit> OnRightKeyUpAsObservable()
        {
            return Observable.EveryUpdate().Where(_ => Input.GetKeyUp(KeyCode.RightArrow)).AsUnitObservable();
        }

        public IObservable<Unit> OnDownKeyUpAsObservable()
        {
            return Observable.EveryUpdate().Where(_ => Input.GetKeyUp(KeyCode.DownArrow)).AsUnitObservable();
        }

        public IObservable<Unit> OnLeftKeyUpAsObservable()
        {
            return Observable.EveryUpdate().Where(_ => Input.GetKeyUp(KeyCode.LeftArrow)).AsUnitObservable();
        }
    }
}


