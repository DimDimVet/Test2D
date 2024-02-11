using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Camera mCamera;
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] ratio;

    private void LateUpdate()
    {
        MoveRatioSprite();
    }
    private void MoveRatioSprite()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i].position = mCamera.transform.position * ratio[i];
        }
    }
}
