using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.PlayerCamera
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField]
        Transform target;

        [SerializeField]
        Vector3 offset;

        //A follow camera should always be implemented in LateUpdate because it tracks objects that might have moved inside Update.
        void LateUpdate()
        {
            transform.position = target.position - offset;
        }
    }
}