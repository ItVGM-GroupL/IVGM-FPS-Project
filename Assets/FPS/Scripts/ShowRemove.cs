using UnityEngine;
using UnityEditor;

public class ShowRemove : EditorWindow
{
	public string notification;

    [MenuItem("Example/Notification Usage")]
    static void Initialize()
    {
        ShowRemove.GetWindow(typeof(ShowRemove));
    }

    void OnGUI()
    {
        if (GUILayout.Button("Show Notification"))
        {
            this.ShowNotification(new GUIContent(notification));
        }

        if (GUILayout.Button("Remove Notification"))
        {
            this.RemoveNotification();
        }
    }
}

