using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HologramController))]
public class HologramControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        HologramController hologramController = (HologramController)target;

        EditorGUILayout.BeginHorizontal();
        hologramController.currentTab = GUILayout.Toolbar(hologramController.currentTab, new string[]
        {
            "ColorAdjustment","TextureAdjustment","GlitchAdjustment"
        });
        EditorGUILayout.EndHorizontal();

        switch (hologramController.currentTab)
        {
            case 0:
                ColorAdjustment(hologramController);
                break;
            case 1:
                TextureAdjustmentstment(hologramController);
                break;
            case 2:
                GlitchAdjustment(hologramController);
                break;
        }
    }
    void ColorAdjustment(HologramController hologram)
    {
        EditorGUILayout.LabelField("BodyColor", EditorStyles.boldLabel);
        hologram.colorAdjustment.BodyColor = EditorGUILayout.ColorField(GUIContent.none, hologram.colorAdjustment.BodyColor, true, true, true);

        EditorGUILayout.LabelField("FresnelColor", EditorStyles.boldLabel);
        hologram.colorAdjustment.FresnelColor = EditorGUILayout.ColorField(GUIContent.none, hologram.colorAdjustment.FresnelColor, true, true, true);

        EditorGUILayout.LabelField("FresnelPower", EditorStyles.boldLabel);
        hologram.colorAdjustment.FresnelPower = EditorGUILayout.Slider(GUIContent.none, hologram.colorAdjustment.FresnelPower, 0, 10);
        if (GUILayout.Button("Set Color Adjustment"))
        {
            hologram.SetColorAdjustment();
        }
    }

    void TextureAdjustmentstment(HologramController hologram)
    {
        EditorGUILayout.LabelField("Holo Texture", EditorStyles.boldLabel);
        hologram.textureAdjustment.HoloTexture = (Texture)EditorGUILayout.ObjectField(hologram.textureAdjustment.HoloTexture, typeof(Texture), true);
        EditorGUILayout.LabelField("HoloTextureTiling", EditorStyles.boldLabel);
        hologram.textureAdjustment.HoloTextureTiling = EditorGUILayout.Vector2Field(GUIContent.none, hologram.textureAdjustment.HoloTextureTiling);        
        EditorGUILayout.LabelField("HoloTextureScrollSpeed", EditorStyles.boldLabel);
        hologram.textureAdjustment.HoloTextureScrollSpeed = EditorGUILayout.FloatField(GUIContent.none, hologram.textureAdjustment.HoloTextureScrollSpeed);     
        EditorGUILayout.LabelField("BrachTrue", EditorStyles.boldLabel);
        hologram.textureAdjustment.BrachTrue = EditorGUILayout.Slider(hologram.textureAdjustment.BrachTrue, 0, 10);
        EditorGUILayout.LabelField("BrachFalse", EditorStyles.boldLabel);
        hologram.textureAdjustment.BrachFalse = EditorGUILayout.Slider(hologram.textureAdjustment.BrachFalse, 0, 10);
        if (GUILayout.Button("Set Texture Adjustment"))
        {
            hologram.SetTextureAdjustment();
        }
    }
    void GlitchAdjustment(HologramController hologram)
    {
        EditorGUILayout.LabelField("Use Glitch", EditorStyles.boldLabel);
        hologram.glitchAdjustment.useGlitch = GUILayout.Toggle(hologram.glitchAdjustment.useGlitch, "Use Glitch");
        if (hologram.glitchAdjustment.useGlitch)
        {
            EditorGUILayout.LabelField("Glitch Scale", EditorStyles.boldLabel);
            hologram.glitchAdjustment.GlitchScale = EditorGUILayout.Slider(hologram.glitchAdjustment.GlitchScale, 0, 500);

            EditorGUILayout.LabelField("Glitch Rate", EditorStyles.boldLabel);
            hologram.glitchAdjustment.GlitchRate = EditorGUILayout.Slider(hologram.glitchAdjustment.GlitchRate, 0, 1);

            EditorGUILayout.LabelField("Glitch Scale X", EditorStyles.boldLabel);
            hologram.glitchAdjustment.GlitchScaleX = EditorGUILayout.Slider(hologram.glitchAdjustment.GlitchScaleX, 0, 3);

            EditorGUILayout.LabelField("Glitch Scale Y", EditorStyles.boldLabel);
            hologram.glitchAdjustment.GlitchScaleY = EditorGUILayout.Slider(hologram.glitchAdjustment.GlitchScaleY, 0, 3);

            EditorGUILayout.LabelField("Glitch Scale Z", EditorStyles.boldLabel);
            hologram.glitchAdjustment.GlitchScaleZ = EditorGUILayout.Slider(hologram.glitchAdjustment.GlitchScaleZ, 0, 3);

            if (GUILayout.Button("Set Glitch Adjustment"))
            {
                hologram.SetGlitchAdjustment();
            }
        }
        else
        {
            hologram.SetGlitchAdjustment();
        }
    }
}
