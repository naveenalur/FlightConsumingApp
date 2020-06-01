using FlightServiceConsumeApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace FlightServiceConsumeApplication.Controllers
{
    public class FlightSearchController : Controller
    {
        public static List<FlightSegment> ListOfFlightSegment = new List<FlightSegment>();

        // GET: FlightSearch
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Search()
        {
            return View();
        }

        // POST: FlightSearch/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchFlight(FlightSegment collection)
        {
            try
            {
                //This api is configured from appsettings.json

                var client = new RestClient(APIConstatnt.Api);
                var request = new RestRequest(Method.POST);
                request.RequestFormat = DataFormat.Json;
                _ = request.AddBody(new FlightSegmentDto
                {
                    Destination = collection.Destination,
                    OnwardDate = collection.OnwardDate,
                    Origin = collection.Origin,
                    ReturnDate = collection.ReturnDate
                });
                var response = client.Execute(request);
                dynamic materialSerializedObject = JsonConvert.DeserializeObject(response.Content);
                var materialData = (Dictionary<string, List<object>>)JsonConvert.DeserializeObject<Dictionary<string, List<object>>>(JsonConvert.SerializeObject(materialSerializedObject));
                foreach (var item in materialData)
                {
                    if (item.Key.Equals("flightDetails"))
                    {
                        foreach (dynamic data in item.Value)
                        {
                            var serlizedData = (Dictionary<string, List<FlightSegment>>)JsonConvert.DeserializeObject<Dictionary<string, List<FlightSegment>>>(JsonConvert.SerializeObject(data));
                            foreach (var items in serlizedData.Values)
                            {
                                ListOfFlightSegment.AddRange(items);
                            }
                        }
                    }
                }

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details()
        {
            return View(ListOfFlightSegment);
        }
    }
}