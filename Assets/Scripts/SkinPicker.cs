using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPicker : MonoBehaviour
{
    // Method to change skin with designated index
    public void ChangeSkin(int i)
    {
        StartCoroutine(SkinSwap(i));
    }

    // Changes skin using Coroutine because the animator only connects base skin (Index 0) to every other skin
    IEnumerator SkinSwap(int i)
    {
        PlayerMovement.Skin = 0;
        yield return new WaitForSeconds(0.1f);
        PlayerMovement.Skin = i;
    }

}
