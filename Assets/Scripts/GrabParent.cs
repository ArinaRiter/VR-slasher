using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabParent : MonoBehaviour
{
    public void SetIntParent(SelectEnterEventArgs args)
    {
        transform.SetParent(args.interactorObject.transform);
    }
    public void SetParentWorld()
    {
        transform.SetParent(null);
    }
}
