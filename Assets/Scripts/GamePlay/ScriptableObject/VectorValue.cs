using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject,ISerializationCallbackReceiver
{
    public Vector3 innitialValue;
    public Vector3 defaultValue;

    public void OnAfterDeserialize()
    {
        innitialValue = defaultValue;
    }

    public void OnBeforeSerialize()
    {
    }
}
