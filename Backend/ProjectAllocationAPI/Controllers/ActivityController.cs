using Core.CommanFunctions;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using DataAccessLayer.Services;
using ProjectAllocationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectAllocationAPI.Controllers
{
    public class ActivityController : ApiController
    {
        public Karan_SatvaEntities objActivity = new Karan_SatvaEntities();
        static readonly IActivityRepository activityRepository = new ActivityRepository();

        public JsonResponse GetActivity(int StartPageNumber, int EndPageNumber)
        {
            var objectResponse = new JsonResponse();
            try
            {
                var Activitylist = activityRepository.GetActivity(StartPageNumber, EndPageNumber);
                if (Activitylist.Count > 0)
                    objectResponse = JsonResponseHelper.JsonMessage(1, "No. of Records " + Activitylist.Count, Activitylist);
                else
                    objectResponse = JsonResponseHelper.JsonMessage(2, "No Record Found", Activitylist);
            }
            catch (Exception ex)
            {
                objectResponse = JsonResponseHelper.JsonMessage(0, "Error", ex.Message);
            }
            return objectResponse;
        }
    }
}
