using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   public float shakeForce=0f;
   public Vector3 shakeOffset = Vector3.zero;

   private Quaternion originRot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(ShakeCoroutine());
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            StopAllCoroutines();
            StartCoroutine(Reset());
        }
    }

    IEnumerator ShakeCoroutine()
    {
        Vector3 t_originEuler = transform.eulerAngles;
        while (true)
        {
            //목적값에 랜덤값 배열
            float t_rotX = Random.Range(-shakeOffset.x, shakeOffset.x);
            float t_rotY=Random.Range(-shakeOffset.y, shakeOffset.y);
            float t_rotZ=Random.Range(-shakeOffset.z, shakeOffset.z);

            //랜덤값을 t_randomRot에 합침
            Vector3 t_randomRot = t_originEuler + new Vector3(t_rotX, t_rotY, t_rotZ);
            //합친 Vector3값을 회전값 Quaternion변수 t_rot에 넣는다
            Quaternion t_rot = Quaternion.Euler(t_randomRot);
            
            //목적값까지 움직일 때까지 반복
            while (Quaternion.Angle(transform.rotation, t_rot) > 0.1f) //목표값의 근사치가 될 때까지 반복함
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, t_rot, shakeForce * Time.deltaTime);
                yield return null;
            }
            yield return null;
        }
    }

    IEnumerator Reset()
    {
        while (Quaternion.Angle(transform.rotation, originRot) > 0f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, originRot, shakeForce * Time.deltaTime);
            yield return null;
        }
    }
}
