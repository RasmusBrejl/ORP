using System;
using ORP.Business.Services;
using ORP.Models;
using ORP.Models.Enums;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Http;
using ORP.Business.Repositories;

namespace ORP.Controllers
{
    public class RequestRouteController : Controller
    {
        private readonly RouteService _routeService;

        public RequestRouteController()
        {
            _routeService = new RouteService(new ConnectionRepository(), new CityRepository());
        }

        // Respond request
        [System.Web.Http.Route("")]
        public async Task<ActionResult> GetConnectionData([FromBody] RequestRouteObject request)
        {

            if (request is null)
            {
                throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
            }

            Connection RouteConnection = _routeService.GetConnection(request.city_from, request.city_to);
            if (RouteConnection == null)
            {
                return Json(new
                {
                    Data = new ConnectionData
                    {
                        Price = 10,
                        Duration = 10,
                        Date = DateTime.UtcNow.Date.ToString()
                    }
                }, JsonRequestBehavior.AllowGet);
            }

            if (RouteConnection.ConnectionType.Equals(ConnectionType.Plane))
            {


                var data = _routeService.GetConnectionData(new Parcel
                {
                    Weight = request.weight,
                    Width = request.width,
                    Height = request.height,
                    Length = request.length

                }, out var msg);
                return Json(new {data}, JsonRequestBehavior.AllowGet);
            }
            throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
        }
    }
}