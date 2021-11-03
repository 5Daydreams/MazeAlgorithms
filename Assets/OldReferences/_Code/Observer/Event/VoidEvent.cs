using _Code.Observer.VoidType;
using UnityEngine;

namespace _Code.Observer.Event
{
    [CreateAssetMenu(menuName = "CustomScriptables/Events/VoidEvent", fileName = "NewVoidEvent")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}