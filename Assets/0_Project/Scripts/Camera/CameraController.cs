using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private FishController fish;
    [Space]
    [SerializeField] private Vector2 clampX = new Vector2(-1f, 1f);

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(fish.transform.position.x, clampX.x, clampX.y), transform.position.y, transform.position.z);
    }
}
