using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPicker : MonoBehaviour
{

    public void ChangeSkin(int i)
    {
        PlayerMovement.Skin = 0;
        PlayerMovement.Skin = i;
    }

}
