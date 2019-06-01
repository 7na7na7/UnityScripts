using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 소리내기: MonoBehaviour
{
    public AudioClip sfx;
    public AudioSource audioSource;
    //그리고 인스펙터에서 audioSource를 추가하고, 그것을 audioSource에 넣는다.
    //인스펙터의 audioSource값조정으로도 사운드는 가능하지만, 한번밖에 낼수없다.
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //스페이스키를 누르면
            audioSource.PlayOneShot(sfx, 1.0f);//sfx를 1배의 크기로 소리를 한 번 낸다.
        this.audioSource.Play(); //audio에 들어 있는 소리 재생

        this.audioSource.loop = true; //반복재생
        this.audioSource.Stop(); //재생중지
    }
}

