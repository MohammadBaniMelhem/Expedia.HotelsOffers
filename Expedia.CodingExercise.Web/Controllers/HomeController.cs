using Expedia.CodingExercise.BusinessLogic.Activities;
using Expedia.CodingExercise.DataType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expedia.CodingExercise.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            using (HotelsOfferingActivities activities = new HotelsOfferingActivities())
            {
                var getOffersResult = activities.GetOffers(null, null);

                return View(getOffersResult.ReturnedObject);
            }
        }

        [HttpPost]
        public ActionResult Index(HotelOfferModel model)
        {
            using (HotelsOfferingActivities activities = new HotelsOfferingActivities())
            {
                var getOffersResult = activities.GetOffers(model.Filter, model.Sorting);

                return View(getOffersResult.ReturnedObject);
            }
        }

        //[HttpPost]
        //public JsonResult GetOffers(HotelsOffersFilter filter)
        //{
        //    using (HotelsOfferingActivities activities = new HotelsOfferingActivities())
        //    {
        //        var getOffersResult = activities.GetOffers(filter);

        //        return Json(getOffersResult.ToJSONResult());
        //    }

        //}
    }
}