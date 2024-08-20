
using UnityEngine;

public class WaterWaveEffect : MonoBehaviour
{

    public Material _Material;
    //����ϵ��
    public float distanceFactor = 60.0f;
    //ʱ��ϵ��
    public float timeFactor = -30.0f;
    //sin�������ϵ��
    public float totalFactor = 1.0f;

    //���ƿ��
    public float waveWidth = 0.3f;
    //������ɢ���ٶ�
    public float waveSpeed = 0.3f;
    //���ƴ���ʱ��
    public float waveTime = 0.5f;

    private float waveStartTime;
    private Vector4 startPos = new Vector4(0.5f, 0.5f, 0, 0);


    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //���㲨���ƶ��ľ��룬����enable��Ŀǰ��ʱ��*�ٶ����
        float curWaveDistance = (Time.time - waveStartTime) * waveSpeed;
        //����һϵ�в���
        _Material.SetFloat("_distanceFactor", distanceFactor);
        _Material.SetFloat("_timeFactor", timeFactor);
        _Material.SetFloat("_totalFactor", totalFactor);
        _Material.SetFloat("_waveWidth", waveWidth);
        _Material.SetFloat("_curWaveDis", curWaveDistance);
        _Material.SetVector("_startPos", startPos);

        if (Time.time - waveStartTime < waveTime)
            Graphics.Blit(source, destination, _Material);
        else
            Graphics.Blit(source, destination);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;
            //��mousePosת��Ϊ��0��1������
            startPos = new Vector4(mousePos.x / Screen.width, mousePos.y / Screen.height, 0, 0);
            waveStartTime = Time.time;
        }

    }
}