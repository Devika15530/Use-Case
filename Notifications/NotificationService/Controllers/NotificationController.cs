using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Models;
using NotificationService.Repository;

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        public INotificationRepository _repo;
        public NotificationController(INotificationRepository repo)
        {
            _repo = repo;
        }


        [HttpPost]
        [Route("AddNotification")]
        public IActionResult AddNotification(Notifications noti)
        {
            try
            {
                _repo.AddNotification(noti);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }




        [HttpDelete]
        [Route("DeleteNotification/{notid}")]
        public IActionResult DeleteNotification(string notid)
        {
            try
            {
                _repo.DeleteNotification(notid);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateNotification")]
        public IActionResult UpdateNotification(Notifications notify)
        {
            try
            {
                _repo.UpdateNotification(notify);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("ViewNotification/{id}")]
        public IActionResult ViewNotifications(string id)
        {
            try
            {

                return Ok(_repo.ViewNotifications(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }




    }
}