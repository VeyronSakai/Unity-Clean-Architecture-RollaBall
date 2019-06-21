using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour, IPlayerView
{
    private Transform tr;
    public Transform Tr => tr;

    //private void Awake()
    //{
    //    tr = this.GetComponent<Transform>();
    //}

    [Inject]
    private void Construct()
    {
        tr = this.GetComponent<Transform>();
    }

    //Transformの更新
    public void UpdatePosition(Vector3 pos){
        this.tr.position = pos;
    }
}

public interface IPlayerView {
    Transform Tr{get;}
    void UpdatePosition(Vector3 pos);
}
