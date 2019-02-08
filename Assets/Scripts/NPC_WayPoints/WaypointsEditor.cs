// Чисто для удобства работы в инспекторе
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Waypoints_System))]
public class WaypointsEditor : UnityEditor.Editor {

	private SerializedProperty _turnLeft;
	private SerializedProperty _turnRight;
	private SerializedProperty _turnDown;
	private SerializedProperty _turnUp;

    private bool lastLeft;
    private bool lastRight;
    private bool lastDown;
    private bool lastUp;

    private SerializedProperty _lookLeft;
    private SerializedProperty _lookRight;
    private SerializedProperty _lookUp;
    private SerializedProperty _lookDown;

    private Waypoints_System ws;

	public void OnEnable()
	{
		_turnLeft = serializedObject.FindProperty("turnLeft");
		_turnRight = serializedObject.FindProperty("turnRight");
		_turnDown = serializedObject.FindProperty("turnDown");
		_turnUp = serializedObject.FindProperty("turnUp");
	}

	public override void OnInspectorGUI()
	{
        serializedObject.Update();

        ws = (Waypoints_System) target;
        EditorGUILayout.LabelField("________________________________________________________________________________");
        _turnLeft.boolValue = EditorGUILayout.Toggle("isTurnLeft", _turnLeft.boolValue);
        if (_turnLeft.boolValue && !lastLeft)
        {
            _turnRight.boolValue = false;
            _turnDown.boolValue = false;
            _turnUp.boolValue = false;
        }
        _turnRight.boolValue = EditorGUILayout.Toggle("isTurnRight", _turnRight.boolValue);
        if (_turnRight.boolValue && !lastRight)
        {
            _turnLeft.boolValue = false;
            _turnDown.boolValue = false;
            _turnUp.boolValue = false;
        }
        _turnDown.boolValue = EditorGUILayout.Toggle("isTurnDown", _turnDown.boolValue);
        if (_turnDown.boolValue && !lastDown)
        {
            _turnLeft.boolValue = false;
            _turnRight.boolValue = false;
            _turnUp.boolValue = false;
        }
        _turnUp.boolValue = EditorGUILayout.Toggle("isTurnUp", _turnUp.boolValue);
        if (_turnUp.boolValue && !lastUp)
        {
            _turnLeft.boolValue = false;
            _turnRight.boolValue = false;
            _turnDown.boolValue = false;
        }
        EditorGUILayout.LabelField("________________________________________________________________________________");

        serializedObject.ApplyModifiedProperties();

       
	}

    void HideFields()
    {
        _turnRight.boolValue = false;
        
    }
}
