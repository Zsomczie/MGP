using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
//using Unity.Notifications.iOS;
using UnityEngine;
using UnityEngine.Android;

public class NotificationManager : MonoBehaviour
{
    AndroidNotification notification;
    void Start()
    {
        Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        var channel = new AndroidNotificationChannel()
        {
            Id = "Channel_Id",
            Name = "Notification_Channel",
            Importance = Importance.Default,
            Description = "Default notification",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        //var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        //{
        //    TimeInterval = new System.TimeSpan(0, 0, 30),
        //    Repeats = true,
        //};

        notification = new AndroidNotification();
        notification.Title = "You're Hungry!";
        notification.Text = "Eat!";
        notification.SmallIcon = "icon";
        notification.LargeIcon = "icon2";

        //var IOSnotification = new iOSNotification();
        //notification.Title = "You're Hungry!";
        //notification.Text = "Eat!";
        //notification.SmallIcon = "icon";
        //notification.LargeIcon = "icon2";

        //iOSNotificationCenter.ScheduleNotification(IOSnotification);
    }

    public void SendNotification() 
    {
        if (Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            AndroidNotificationCenter.SendNotification(notification, "Channel_Id");
        }
        else
        {
            Debug.Log("no permissions");
        }
    }
}
