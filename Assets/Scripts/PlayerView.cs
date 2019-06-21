using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour, IPlayerView
{
    private Transform tr;
    public Transform Tr => tr ? tr : tr = this.GetComponent<Transform>();

    //Transformの更新
    public void UpdateTransform(Transform tr){
        this.tr = tr;
    }
}

public interface IPlayerView {
    Transform Tr{get;}
    void UpdateTransform(Transform tr);
}
