using _Code.Toolbox.TextboxStringConversion;
using UnityEditor;
using UnityEngine;

namespace _Code.CustomInspectors
{
    [CustomEditor(typeof(FloatTextboxObserver))]
    public class FloatTextboxObserverEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            FloatTextboxObserver translator = (FloatTextboxObserver) target;
        
            GUILayout.Label("Base Inspector", EditorStyles.boldLabel);
            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
                base.OnInspectorGUI();
        
            GUILayout.Label("Custom Add-ons", EditorStyles.boldLabel);
            if (GUILayout.Button("Translate to time"))
            {
                translator.TranslateValueToTime();
            }
        }
    }
}