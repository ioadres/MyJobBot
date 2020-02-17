using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyJobBot.Platform.Messenger.Model;

namespace MyJobBot.Api.Controllers
{
    public class HookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        /*
         * Actión que se utiliza para subscribirse al webhook de facebook
         * Utilidad : Validación por parte de facebook  utilizando la Key FACEBOOK_WEBHOOK_VERIFY_TOKEN
         */
        [HttpGet]
        public IActionResult WebHook()
        {         
            try
            {
                var verifyToken = "";//ConfigurationManager.AppSettings[""];

                var mode = this.Request.Query["hub.mode"];
                var token = this.Request.Query["hub.verify_token"];
                var challenge = this.Request.Query["hub.challenge"];

                if (!string.IsNullOrEmpty(mode) && !string.IsNullOrEmpty(token))
                {
                    if (mode == "subscribe" && token == verifyToken)
                    {
                        return Ok(challenge);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        /*
         * Actión que se utiliza para recibir todos los eventos proporcionados por el chat de facebook
         */
        [HttpPost]
        public IActionResult WebHook([FromBody]FacebookWebHook request)
        {
            var response = Ok("EVENT_RECEIVED");
            
            Task.Run(() =>
            {
                try
                {
                    if (request.@object.Equals("page"))
                    {
                        /*var webhookEventsServiceList = _facebookWebHookEventStrategy.GetEvents();
                        request.entry.ForEach(webHook =>
                        {
                            if (webHook.standby == null || !webHook.standby.Any())
                            {
                                var message = webHook.messaging.FirstOrDefault();
                                var webhookEventService = webhookEventsServiceList.FirstOrDefault(x => x.Check(message));
                                webhookEventService.Execute(message, request.entry.FirstOrDefault().id);
                            }
                        });*/
                    }
                }
                catch (Exception ex)
                {
                   
                }
            });

            return response;
        }
    }
}