//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class ImagesSetter : EditorWindow
//{
//    [MenuItem("Tools/Material Setter")]
//    public static void ShowWindow()
//    {
//        GetWindow<ImagesSetter>("Images Setter");
//    }

//    private void OnGUI()
//    {
//        if (GUILayout.Button("Add Images To Materials"))
//        {
//            AddImagesToMaterials();
//        }
//    }

//    void AddImagesToMaterials()
//    {
//        // Dictionary to map materials to their corresponding textures
//        Dictionary<string, Texture> materialTextures = new Dictionary<string, Texture>
//        {
//            // Add your material names and corresponding textures here
//             { "MaterialName", AssetDatabase.LoadAssetAtPath<Texture>("Assets/Prefabs/CustomPcMaterialsAAndTexture/.png") }
//        };

//        foreach (var obj in Selection.objects)
//        {
//            GameObject gameObject = obj as GameObject;
//            if (gameObject == null)
//                continue;

//            Renderer renderer = gameObject.GetComponent<Renderer>();
//            if (renderer == null || renderer.sharedMaterials == null)
//                continue;

//            foreach (var material in renderer.sharedMaterials)
//            {
//                if (material != null && materialTextures.ContainsKey(material.name))
//                {
//                    Texture texture = materialTextures[material.name];
//                    if (texture != null)
//                    {
//                        material.mainTexture = texture;
//                        EditorUtility.SetDirty(material); // Mark the material as dirty to save changes
//                    }
//                }
//            }
//        }

//        // Save changes to the assets
//        AssetDatabase.SaveAssets();
//    }
//}
