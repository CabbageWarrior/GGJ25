using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BubbleBase : MonoBehaviour
{
    [SerializeField] private GameObject smallGO;
    [SerializeField] private GameObject midGO;
    [SerializeField] private GameObject bigGO;

    // States: 1 = small, 2 = medium, 3 = big
    private int state = 0;

    public void SetState(int state)
    {
        this.state = state;

        smallGO.SetActive(state == 1);
        midGO.SetActive(state == 2);
        bigGO.SetActive(state == 3);
    }

    protected GameObject GetSphere()
    {
        return state == 1 ? smallGO : state == 2 ? midGO : bigGO;
    }
}
