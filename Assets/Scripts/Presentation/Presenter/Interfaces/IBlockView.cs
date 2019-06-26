using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

namespace Presentation.Presenter
{
    public interface IBlockView
    {
        IObservable<Unit> OnTriggerEnterPlayerAsObservable();
    }

}

