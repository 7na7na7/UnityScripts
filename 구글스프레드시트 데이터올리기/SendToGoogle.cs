using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{
  public GameObject username, email, phone;

  private string Name, Email, Phone;

  [SerializeField] private string BASE_URL =
      "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdsm55DNje3CHOVAAS-EUkKBD7MklCKNlwpsHksjoyiCBoWKg/formResponse";
  public void Send()
  {
    Name = username.GetComponent<InputField>().text;
   Email = email.GetComponent<InputField>().text;
    Phone = phone.GetComponent<InputField>().text;

    StartCoroutine(Post(Name, Email, Phone));
  }

  IEnumerator Post(string name, string email, string phone)
  {
      WWWForm form=new WWWForm();
      form.AddField("entry.931206827",name);
      form.AddField("entry.2027631050",email);
      form.AddField("entry.1758129288",phone);
      byte[] rawData = form.data;
      WWW www=new WWW(BASE_URL,rawData);
      yield return www;
  }
}
