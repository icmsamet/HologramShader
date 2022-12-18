using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HologramController : MonoBehaviour
{
    Material mat;
    [System.Serializable]
    public class ColorAdjustment
    {
        [ColorUsageAttribute(false, true, 0f, 8f, 0.125f, 3f)]
        public Color BodyColor;
        [ColorUsageAttribute(false, true, 0f, 8f, 0.125f, 3f)]
        public Color FresnelColor;
        [Range(0, 10)]
        public float FresnelPower;
    }
    [System.Serializable]
    public class TextureAdjustment
    {
        public Texture HoloTexture;
        public Vector3 HoloTextureTiling;
        public float HoloTextureScrollSpeed;

        [Range(0, 10)]
        public float BrachTrue;

        [Range(0, 10)]
        public float BrachFalse;
    }

    [System.Serializable]
    public class GlitchAdjustment
    {
        public bool useGlitch;

        [Range(0, 500)]
        public float GlitchScale;

        [Range(0, 1)]
        public float GlitchRate;

        [Range(0, 3)]
        public float GlitchScaleX;
        [Range(0, 3)]
        public float GlitchScaleY;
        [Range(0, 3)]
        public float GlitchScaleZ;
    }
    public ColorAdjustment colorAdjustment;
    public TextureAdjustment textureAdjustment;
    public GlitchAdjustment glitchAdjustment;
    [HideInInspector] public int currentTab;

    /// <summary>
    /// Set material properties use "colorAdjustment" variables.
    /// </summary>

    public void SetColorAdjustment()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.SetColor("_BaseColor", colorAdjustment.BodyColor);        
        mat.SetColor("_FresnelColor", colorAdjustment.FresnelColor);
        mat.SetFloat("_FresnelPower", colorAdjustment.FresnelPower);
    }

    /// <summary>
    /// Set material properties use "textureAdjustment" variables.
    /// </summary>

    public void SetTextureAdjustment()
    {
        mat = GetComponent<MeshRenderer>().material;
        mat.SetTexture("_HoloTexture", textureAdjustment.HoloTexture);
        mat.SetVector("_HoloTextureTiling", textureAdjustment.HoloTextureTiling);
        mat.SetFloat("_ScrollSpeed", textureAdjustment.HoloTextureScrollSpeed);
        mat.SetFloat("_BrachTrue", textureAdjustment.BrachTrue);
        mat.SetFloat("_BrachFalse", textureAdjustment.BrachFalse);
    }

    /// <summary>
    /// Set material properties use "glitchAdjustment" variables.
    /// If "useGlitch" is true.
    /// Else use standard values.
    /// </summary>

    public void SetGlitchAdjustment()
    {
        mat = GetComponent<MeshRenderer>().material;
        if (glitchAdjustment.useGlitch)
        {
            mat.SetFloat("_GlitchScale", glitchAdjustment.GlitchScale);
            mat.SetFloat("_GlitchRate", glitchAdjustment.GlitchRate);
            //
            mat.SetFloat("_X_Value", glitchAdjustment.GlitchScaleX);
            mat.SetFloat("_Y_Value", glitchAdjustment.GlitchScaleY);
            mat.SetFloat("_Z_Value", glitchAdjustment.GlitchScaleZ);
        }
        else
        {
            mat.SetFloat("_GlitchScale", 100);
            mat.SetFloat("_GlitchRate", .5f);
            //
            mat.SetFloat("_X_Value", .5f);
            mat.SetFloat("_Y_Value", .5f);
            mat.SetFloat("_Z_Value", .5f);
        }
    }
}
