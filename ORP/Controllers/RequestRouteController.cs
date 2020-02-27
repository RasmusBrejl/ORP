using ORP.Business.Services;
using ORP.Models;
using ORP.Models.Enums;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Http;

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
        [System.Web.Mvc.Route("/api/RequestRoute")]
        [System.Web.Mvc.HttpGet]
        public ConnectionData GetConnectionData([FromBody] RequestRouteObject request)
        {
            /*
             * Veify object
             * verify content
             * 
             */

            if (request is null)
            {
                throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
            }

            Connection RouteConnection = _routeService.GetConnection(request.CityFrom, request.CityTo);
            if (RouteConnection == null)
            {
                return null;
            }

            if (RouteConnection.ConnectionType.Equals(ConnectionType.Plane))
            {


                var data = _routeService.GetConnectionData(new Parcel
                {
                    Weight = request.Weight,
                    Width = request.Width,
                    Height = request.Height,
                    Length = request.Length

                }, out var msg);
                return data;
            }
            throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
        }
    }
}