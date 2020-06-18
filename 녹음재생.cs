using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 녹음재생 : MonoBehaviour
{
    private AudioSource source;
    public AudioClip aud;
    private int sampleRate = 44100;
    private float[] samples;
    public float rmsValue; //말을 크게 하면 이 값이 올라감
    public float modulate; //rmsValue값에 곱해줄 조정값

    public int resultValue;
    public int cutValue; //이값보다 작으면 그냥 0으로 만들어버림
    void Start()
    {
        source = GetComponent<AudioSource>();
        samples=new float[sampleRate];
        aud = Microphone.Start(Microphone.devices[0].ToString(), true, 1, sampleRate);
    }

   
    void Update()
    {
        aud.GetData(samples, 0); //-1f ~ 1f
        float sum = 0;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i]; //제곱함
        }

        rmsValue = Mathf.Sqrt(sum / samples.Length); //제곱근 구함
        rmsValue = rmsValue * modulate; //값이 작으니 조정값 곱해줌
        rmsValue = Mathf.Clamp(rmsValue, 0, 100); //0과 100이내에서 값 제한
        resultValue = Mathf.RoundToInt(rmsValue); //소수점 버려주고 Int형으로 만들어줌
        if (resultValue < cutValue) //cutValue보다 작으면
            resultValue = 0; //그냥 0으로 만들어줌
    }

    public void PlaySound()
    {
        source.Play();
    }
    
    public void Record()
    {
        source.clip = Microphone.Start(Microphone.devices[0].ToString(), false, 3, 44100);
        //3초 녹음
    }
}
