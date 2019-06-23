using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Presentation.Presenter;

namespace Presentation.View
{   public class PlayerView : MonoBehaviour, IPlayerView
    {
        private Transform tr;
        public Transform Tr => tr;

        [Inject]
        private void Initialize()
        {
            tr = this.GetComponent<Transform>();
            UpdatePosition(new Vector3(0,1,0));
        }

        //Transformの更新
        public void UpdatePosition(Vector3 pos){
            this.tr.position = pos;
        }
    }
}

