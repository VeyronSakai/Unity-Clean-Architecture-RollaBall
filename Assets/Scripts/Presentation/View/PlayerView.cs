using UnityEngine;
using Zenject;
using Presentation.Presenter;
using UniRx;

namespace Presentation.View
{   public class PlayerView : MonoBehaviour, IPlayerView
    {
        // PlayerのTransformをReactivePropertyで管理
        private ReactiveProperty<Transform> _trProperty;
        public IReadOnlyReactiveProperty<Transform> TransformProperty => _trProperty;
        public Transform Tr => _trProperty.Value;

        // PlayerViewインスタンス生成時に自動的に実行される
        [Inject]
        private void Initialize()
        {
            _trProperty = new ReactiveProperty<Transform>();
            _trProperty.Value = this.GetComponent<Transform>();
            UpdatePosition(new Vector3(0,1,0));
        }

        //Transformの更新
        public void UpdatePosition(Vector3 pos){
            this._trProperty.Value.position = pos;
        }

        public void DestroyPlayer()
        {
            Destroy(this.gameObject);
        }
    }
}

