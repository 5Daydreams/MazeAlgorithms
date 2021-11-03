using UnityEngine;

namespace _Code.Toolbox.SingleScriptables
{
    [CreateAssetMenu(menuName = "CustomScriptables/DebugMessager")]
    public class EventLog : ScriptableObject
    {
        public void ConsoleLog(string message)
        {
            Debug.Log(message);
        }
    }
}
