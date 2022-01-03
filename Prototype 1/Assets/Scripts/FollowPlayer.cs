using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] Vector3 offset = new Vector3(0f, 5f, -8f);
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
