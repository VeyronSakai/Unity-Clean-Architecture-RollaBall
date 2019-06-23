using UnityEngine;

public interface IPlayerView {
    Transform Tr{get;}
    void UpdatePosition(Vector3 pos);
}