using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Player_Ship))]
public class NewEditorScript : Editor
{
    bool showBaseEditor = false;
    public override void OnInspectorGUI()
    {

        Player_Ship player = (Player_Ship)target;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Hit Points");
        player.Hit_Points = GUILayout.HorizontalSlider(player.Hit_Points*100, 0, 100)/100;
        player.Hit_Points = EditorGUILayout.FloatField(player.Hit_Points,GUILayout.Width(50));
        EditorGUILayout.EndHorizontal();
        showBaseEditor = EditorGUILayout.BeginToggleGroup("ALL DA THINGS", showBaseEditor);
        if(showBaseEditor){
			base.OnInspectorGUI();
        }
        EditorGUILayout.EndToggleGroup();
    }
}
