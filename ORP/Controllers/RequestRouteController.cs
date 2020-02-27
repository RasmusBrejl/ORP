using ORP.Business.Services;
using ORP.Models;
using ORP.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ORP.Controllers
{
    public class RequestRouteController : Controller
    {
        private readonly RouteService _routeService;

        public RequestRouteController(RouteService routeService)
        {
            _routeService = routeService;
        }

        // Respond request
        [System.Web.Http.Route("/api/RequestRoute")]
        [System.Web.Http.HttpGet]
        public ConnectionData GetConnectionData([FromBody] RequestRouteObject Request)
        {
            /*
             * Veify object
             * verify content
             * 
             */

            if (Request is null)
            {
                throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
            }

            Connection RouteConnection = _routeService.GetConnection(Request.CityFrom, Request.CityTo);
            if (RouteConnection == null)
            {
                return null;
            }

            if (RouteConnection.ConnectionType.Equals(ConnectionType.Plane))
            {


                var data = _routeService.GetConnectionData(new Parcel
                {
                    Weight = Request.Weight,
                    Width = Request.Width,
                    Height = Request.Height,
                    Length = Request.Length

                }, out var msg);
                return data;
            }
            throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
        }
    }
}