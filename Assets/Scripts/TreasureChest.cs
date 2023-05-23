//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TreasureChest : MonoBehaviour
//{
//    private GameObject _player = GameObject.FindWithTag("player");
//    private static readonly int near = Animator.StringToHash("playerIsNear");
//    [SerializeField] private Animator animator;
//    [SerializeField] private float _range;
//    private GameObject _light = GameObject.FindWithTag("TreasureLight");
//    void Update()
//    {
//        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < _range)
//        {
//            animator.SetBool(near, true);
//            _light.SetActive(true);
//        }
//        //else
//        //{
//        //    animator.SetBool(near, false);
//        //}
//    }
//}
