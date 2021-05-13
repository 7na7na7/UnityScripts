using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using NativeWifi; //꼭 잇어야 실행댄다!


public class GetWifiName : MonoBehaviour
{
    private void Start()
    {
        print("현재 연결된 와이파이 : "+GetAvailableWifi());
    }

    private string GetAvailableWifi()
    {
        WlanClient client = new WlanClient();
        foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
        {
            Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
            foreach (Wlan.WlanAvailableNetwork network in networks)
            {
                Wlan.Dot11Ssid ssid = network.dot11Ssid;
                string networkname = Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
                if (networkname != "")
                {
                    return networkname;
                }
            }
        }

        return "null";
    }
}
