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
        // posにはFactory.Create(pos)の引数posが入る
        [Inject]
        public void Construct(Vector3 pos)
        {
            this.UpdateAsObservable()
                .Subscribe(_ => RotateBlock());

            // 位置を設定
            this.transform.position = pos;
        }

        private void RotateBlock()
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }

        public IObservable<Unit> OnTriggerEnterPlayerAsObservable()
        {
            return this.OnTriggerEnterAsObservable().Where(x => x.tag == "Player").AsUnitObservable();
        }

        public void DestroyBlock()
        {
            Destroy(this.gameObject);
        }
    }
}
