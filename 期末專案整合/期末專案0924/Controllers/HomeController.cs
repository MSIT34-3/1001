using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.ViewModels;

namespace 期末專案0924.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(CheckViewModel checkViewModel)
        {
            using (dbtravelwebEntities db = new dbtravelwebEntities())
            {
                var cHotels =
                    (from p in db.tHotelOrderSystem
                     join q in db.tHotelRoomType
                     on p.cHotelSN equals q.cHotelSN
                     join r in db.tHotelInfomation
                     on p.cHotelSN equals r.cHotelSN
                     where
                     p.OrderDate == checkViewModel.checkin &&
                     p.OrderDate < checkViewModel.checkout &&
                     p.CanBookNumber >= checkViewModel.room &&
                     q.cHotelRoomContainAldults >= checkViewModel.adult &&
                     q.cHotelRoomContainChiidren >= checkViewModel.children &&
                     r.cHotelCity.Contains(checkViewModel.destination)
                     select r).ToList();

                cHotels = cHotels.OrderByDescending(m => m.cHotelRatingOfPeople).ToList();

                checkViewModel.selects = new List<SelectViewModel>();
                if (cHotels.Count != 0)
                {
                    List<string> distin = new List<string>();
                    foreach (var SN in cHotels)
                    {
                        if (!distin.Contains(SN.cHotelName))
                        {
                            var price = db.tHotelRoomType.Where(m => m.cHotelSN == SN.cHotelSN).OrderByDescending(m => m.cHotelRoomTypePriceOfWeekdays).FirstOrDefault().cHotelRoomTypePriceOfWeekdays;
                            checkViewModel.selects.Add(new SelectViewModel { cHotelSN = SN.cHotelSN, cHotelName = SN.cHotelName, cHotelPhoto = SN.cHotelInfoPhoto, cHotelAverageRating = SN.cHotelAverageRating, cHotelRatingOfPeople = SN.cHotelRatingOfPeople, cHotelRoomTypePrice = price, cHotelNameEN = SN.cHotelNameEN, cHotelCity = SN.cHotelCity });
                            distin.Add(SN.cHotelName);
                        }
                    }
                }
                else
                {
                    checkViewModel.selects = null;
                }
                return View("Select", checkViewModel);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            ViewBag.Message = "Your Test.";

            return View();
        }
    }
}