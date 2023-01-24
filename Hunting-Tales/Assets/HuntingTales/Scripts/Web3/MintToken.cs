using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintToken : MonoBehaviour
{
    public void MintingToken()
    {
        Application.ExternalCall("claimTokens");
    }
}
