using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightServiceConsumeApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace FlightServiceConsumeApplication.Controllers
{
    public class FlightSearchController : Controller
    {
        public List<FlightSegment> ListOfFlightSegment = new List<FlightSegment>();
        // GET: FlightSearch
        public ActionResult Index()
        {
            return View();
        }

       

        // GET: FlightSearch/Create
        public ActionResult Create()
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
                // TODO: Add insert logic here
                
                var client = new RestClient("https://trinetiumtest.azurewebsites.net/api/Flights");
                var request = new RestRequest( Method.POST);
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
                foreach(var item in materialData)
                {
                    if (item.Key.Equals("flightDetails"))
                    {
                        foreach(dynamic data in item.Value)
                        {
                            var serlizedData = (Dictionary<string, List<FlightSegment>>)JsonConvert.DeserializeObject<Dictionary<string, List<FlightSegment>>>(JsonConvert.SerializeObject(data));
                            foreach(var items in serlizedData.Values)
                            {
                                ListOfFlightSegment.AddRange(items);
                            }
//                         
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightSearch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightSearch/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightSearch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightSearch/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        
        public ActionResult GetFlightDetails(FlightSegment flightSegment)
        {
            return RedirectToAction(nameof(Index));
        }

    }
}