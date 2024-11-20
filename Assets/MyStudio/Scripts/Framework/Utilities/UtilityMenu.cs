using UnityEditor;
using UnityEngine;

namespace MyStudio.Framework.Utilities
{
    public class UtilityMenu
    {
        [MenuItem("My Studio/Utilities/OK")]
        public static void OK()
        {
            Debug.LogError("OK");
        }

        [MenuItem("My Studio/Edit...")]
        public static void OpenThisScript()
        {
            //
        }
    }
}
