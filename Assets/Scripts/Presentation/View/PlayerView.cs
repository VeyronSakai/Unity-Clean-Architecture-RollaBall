using UnityEngine;
using Zenject;
using Presentation.Presenter;
using UniRx;
using UniRx.Triggers;

namespace Presentation.View
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        // PlayerのpositionをReactivePropertyで管理
        private ReactiveProperty<Vector3> _playerPositionProperty;
        public IReadOnlyReactiveProperty<Vector3> PlayerPositionProperty => _playerPositionProperty;
        public Vector3 PlayerPostion => _playerPositionProperty.Value;

        // PlayerのTransform
        private Transform tr;
        // Rigidbody
        private Rigidbody rb;

        // PlayerViewインスタンス生成時に自動的に実行される
        [Inject]
        private void Construct()
        {
            tr = this.GetComponent<Transform>();
            UpdatePosition(new Vector3(0, 1, 0));

            rb = this.GetComponent<Rigidbody>();

            _playerPositionProperty = new ReactiveProperty<Vector3>(new Vector3(0, 1, 0));

            // 毎フレーム、ReactivePropertyを更新
            this.UpdateAsObservable()
                .Subscribe(_ => {
                    _playerPositionProperty.Value = this.tr.position;
                });
        }

        //Transformの更新
        public void UpdatePosition(Vector3 pos)
        {
            tr.position = pos;
        }

        public void DestroyPlayer()
        {
            Destroy(this.gameObject);
        }

        // プレイヤーに力を加えて移動させる
        public void Move(Vector3 direction)
        {
            rb.AddForce(direction);
        }
    }
}

