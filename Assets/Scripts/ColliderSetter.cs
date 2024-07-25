//using UnityEngine;
//using UnityEditor;

//public class ColliderSetter : EditorWindow
//{
//    [MenuItem("Tools/Collider Setter")]
//    public static void ShowWindow()
//    {
//        GetWindow<ColliderSetter>("Collider Setter");
//    }

//    void OnGUI()
//    {
//        if (GUILayout.Button("Add Mesh Colliders to Objects with MeshRenderer"))
//        {
//            AddCollidersToObjectsWithMeshRenderer();
//        }

//        if (GUILayout.Button("Remove Mesh Colliders"))
//        {
//            RemoveColliders();
//        }
//    }

//    private static void AddCollidersToObjectsWithMeshRenderer()
//    {
//        foreach (GameObject obj in Selection.gameObjects)
//        {
//            AddColliderIfMeshRendererExists(obj);

//            // Recursively check children
//            foreach (Transform child in obj.transform)
//            {
//                AddColliderIfMeshRendererExists(child.gameObject);
//            }
//        }
//    }

//    private static void AddColliderIfMeshRendererExists(GameObject obj)
//    {
//        if (obj.GetComponent<MeshRenderer>() != null && obj.GetComponent<MeshCollider>() == null)
//        {
//            obj.AddComponent<MeshCollider>();
//        }
//    }

//    private static void RemoveColliders()
//    {
//        foreach (GameObject obj in Selection.gameObjects)
//        {
//            MeshCollider collider = obj.GetComponent<MeshCollider>();
//            if (collider != null)
//            {
//                DestroyImmediate(collider);
//            }

//            // Recursively remove colliders from children
//            foreach (Transform child in obj.transform)
//            {
//                collider = child.gameObject.GetComponent<MeshCollider>();
//                if (collider != null)
//                {
//                    DestroyImmediate(collider);
//                }
//            }
//        }
//    }
//}
