using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESpecialBubble
{
    Marijuana, // Green
    Alcohol, // Brown
    Heroine, // Yellow
    Cosby, // Orange
    // TBD
    Viagra
}

public class BubbleBase : MonoBehaviour
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
public class NormalBubble : BubbleBase
{

}
public class SpecialBubble : BubbleBase
{
    [SerializeField] private Color marijuanaColor = Color.white;
    [SerializeField] private Color alcoholColor = Color.white;
    [SerializeField] private Color heroineColor = Color.white;
    [SerializeField] private Color cosbyColor = Color.white;
    [SerializeField] private Color viagraColor = Color.white;

    ESpecialBubble special = ESpecialBubble.Marijuana;

    public void SetSpecial(ESpecialBubble special)
    {
        this.special = special;

        Renderer[] renderers = GetSphere().GetComponents<Renderer>();
        
        Color color = GetColor(special);

        foreach (Renderer renderer in renderers)
        {
            List<Material> mats = new List<Material>();
            renderer.GetMaterials(mats);

            foreach (Material mat in mats)
            {
                mat.color = color;
            }
        }
    }

    private Color GetColor(ESpecialBubble special)
    {
        switch (special)
        {
            case ESpecialBubble.Marijuana:
                return marijuanaColor;
            case ESpecialBubble.Alcohol:
                return alcoholColor;
            case ESpecialBubble.Heroine:
                return heroineColor;
            case ESpecialBubble.Cosby:
                return cosbyColor;
            case ESpecialBubble.Viagra:
                return viagraColor;
            default:
                return marijuanaColor;
        }
    }
}
