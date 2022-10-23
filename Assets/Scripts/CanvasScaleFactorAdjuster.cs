using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class CanvasScaleFactorAdjuster : MonoBehaviour
{
    [SerializeField] Camera MainCamera;

    void Start()
    {
        AdjustScalingFactor();
    }

    void LateUpdate()
    {
        AdjustScalingFactor();
    }

    void AdjustScalingFactor()
    {
        GetComponent<CanvasScaler>().scaleFactor = MainCamera.GetComponent<PixelPerfectCamera>().pixelRatio;
    }
}
