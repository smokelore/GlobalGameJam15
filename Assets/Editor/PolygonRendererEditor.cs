﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(PolygonRenderer))]
public class PolygonRendererEditor : Editor {

	int n;
	float height;

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		PolygonRenderer target = (serializedObject.targetObject as PolygonRenderer);

		/*if (EditorApplication.isPlaying && GestureHandler.instance != null)
		{
			List<Finger> fingers = GestureHandler.instance.fingers;
			Finger mouse = GestureHandler.instance.mouse;
			if (mouse.isValid)
			{
				fingers.Add(mouse);
			}

			foreach (Finger finger in fingers)
			{
				//Debug.Log("finger");
				Vector2[] Vertices = target.Vertices;
				for (int i = 0; i < Vertices.Length; i++)
				{
					Vector2 vertex = Vertices[i];
					Vector3 vertexWorldPosition = target.GetWorldPosition(i);

					if (Vector2.Distance(finger.GetWorldPosition(), vertexWorldPosition) < 0.5f)
					{
						target.MoveVertex(i, finger.GetWorldPosition());
						//serializedObject.ApplyModifiedProperties();
						//EditorUtility.SetDirty(target);
						//EditorUtility.IsPersistent(target);
						//Debug.Log("moved");
						break;
					}
				}
			}
		}

		// Update Polygon if a vertex is changed
		if (target.VerticesChanged())
		{
			target.Build();
		}*/

		GUILayout.BeginHorizontal();
		GUILayout.Space(EditorGUIUtility.labelWidth);

		if (GUILayout.Button("Create N-Gon"))
		{
			target.CreateNGon(n,height);

		}

		GUILayout.Space(10);
		GUILayout.BeginVertical();
		GUILayout.Label("N");
		GUILayout.Label("Radius");
		GUILayout.EndVertical();
		GUILayout.BeginVertical();
		n = EditorGUILayout.IntField(n);
		height = EditorGUILayout.FloatField(height);
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();

		if (GUILayout.Button("Rebuild"))
		{
			target.Build();
		}

		if (GUILayout.Button("Save Mesh"))
		{
			MeshFilter m = target.GetComponent<MeshFilter>();
			AssetDatabase.CreateAsset(m.mesh, "Assets/Meshes/" + m.gameObject.name + " Mesh.asset");
		}
	}
}
