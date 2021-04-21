package com.example.unityplugin;
import android.content.Context;
import android.widget.Toast;

public class Plugin_Java
{
    private static Plugin_Java m_instance;
    private Context context;
    public static Plugin_Java instance()
    {
        if(m_instance==null)
        {
            m_instance=new Plugin_Java();
        }
        return m_instance;
    }

    private void setContext(Context ct)
    {
        context=ct;
    }

    private void ShowToast(String msg, int i)
    {
        if(i==0) //짧게 보이는 경우
        {
            Toast.makeText(context, msg, Toast.LENGTH_SHORT).show();
        }
        else //길게 보이는 경우
        {
            Toast.makeText(context, msg, Toast.LENGTH_LONG).show();
        }
    }
}
