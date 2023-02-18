using UnityEngine;

[CreateAssetMenu(fileName = "New Void Event", menuName = "Game Events/Void")]
public class VoidEvent : BaseEvent<Void>
{
    public void Raise()
    {
        Raise(new Void());
    }
}
