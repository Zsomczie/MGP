using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.Android;

public class BasicNotification : MonoBehaviour
{
    private AndroidNotification notification;

    private void Start()
    {
        Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name="Default Channel",
            Importance=Importance.Default,
            Description="Generic notification",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        notification = new AndroidNotification();
        notification.Title = "You're hungry";
        notification.Text= "Eat!";
        notification.SmallIcon = "icon";
        notification.LargeIcon = "logo";
    }
    public void SendNotif() 
    {
        if (Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
        else
        {
            Debug.Log("No permissions!");
        }
    }
}
