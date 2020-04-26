using NotificationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Repository
{
    public class NotificationRepository : INotificationRepository
    {

        private readonly NotificationDbContext _context;
        public NotificationRepository(NotificationDbContext context)
        {
            _context = context;
        }
        public void AddNotification(Notifications obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteNotification(string Notid)
        {
            Notifications  nobj = _context.Notifications.Find(Notid);
            _context.Remove(nobj);
            _context.SaveChanges();
        }

        public void UpdateNotification(Notifications obj)
        {
            _context.Notifications.Update(obj);
            _context.SaveChanges();
        }

        public List<Notifications> ViewNotifications(string uid)
        {

            return _context.Notifications.Where(res => res.Userid == uid).ToList();
        }
    }
}
