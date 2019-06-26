using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;
using System;
using Presentation.Presenter;

namespace Presentation.View
{
    public class BlockView : MonoBehaviour, IBlockView
    {
        // 生成時に実行される
        // 初めからシーン上にインスタンスが生成されていればStart時に実行される
        [Inject]
        public void Construct()
        {
            this.UpdateAsObservable()
                .Subscribe(_ => RotateBlock());
        }

        private void RotateBlock()
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }

        public IObservable<Unit> OnTriggerEnterPlayerAsObservable()
        {
            return this.OnTriggerEnterAsObservable().Where(x => x.tag == "Player").AsUnitObservable();
        }
    }
}
