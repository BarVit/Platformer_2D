using UnityEngine;

public class Weapon : MonoBehaviour
{
    [field : SerializeField] public int Damage { get; private set; }
    [field : SerializeField] public float Range { get; private set; }
}