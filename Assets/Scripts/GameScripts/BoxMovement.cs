using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public enum StoneValues
{
    Diamond = 10,
    Emerald = 5,
    Stone = -2,
    Yellow = 3,
    Rubin = 2,
    Heart = 1,
    Bomb = -6,
}
public class BoxMovement : MonoBehaviour
{
    public UnityEvent<int> OnBoxEntered { get; } = new UnityEvent<int>();
    public void UpdateFrame()
    {
        //TODO
        //Move box 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision == null)
            return;
        StoneValues value = default;
        switch (collision.gameObject.name)
        {
            case "Diamond": value = StoneValues.Diamond; break;
            case "Emerald": value = StoneValues.Emerald; break;
            case "Stone": value = StoneValues.Stone; break;
            case "Yellow": value = StoneValues.Yellow; break;
            case "Rubin": value = StoneValues.Rubin; break;
            case "Heart": value = StoneValues.Heart; break;
            case "Bomb": value = StoneValues.Bomb; break;
        }
        OnBoxEntered?.Invoke((int)value);
    }
}