using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
using UniRx;

namespace Domain.UseCase
{
    public interface IBlockPresenter
    {
        void InstantiateBlock(Vector3 pos);
        IObservable<Unit> OnTriggerEnterPlayerAsObservable(int i);
    }
}