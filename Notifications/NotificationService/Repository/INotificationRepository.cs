using NotificationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Repository
{
   public  interface INotificationRepository
    {

        void AddNotification(Notifications obj);

        List<Notifications> ViewNotifications(string uid);

        public void UpdateNotification(Notifications obj);

        public void DeleteNotification(string Notid);



    }
}
