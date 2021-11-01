using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.Model;
using 期末專案0924.ViewModels;
using 期末專題_旅遊網.ViewModels;
using 期末專題_旅遊網.ViewModels.Models;

namespace 期末專題_旅遊網.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //取廣告資料
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            tADFactory factory = new tADFactory();
            ViewBag.adCount = factory.AdCount(today);
            if (factory.AdCount(today) == 0)
                ViewBag.adCount = 1;
            ViewBag.adName = factory.AdName(today);
            ViewBag.adURL = factory.AdURL(today);

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
                     on p.cHotelRoomTypeSN equals q.cHotelRoomTypeSN
                     join r in db.tHotelInfomation
                     on q.cHotelSN equals r.cHotelSN
                     where
                     p.OrderDate == checkViewModel.checkin &&
                     p.OrderDate < checkViewModel.checkout &&
                     p.CanBookNumber >= checkViewModel.room &&
                     q.cHotelRoomContainAldults >= checkViewModel.adult &&
                     q.cHotelRoomContainChiidren >= checkViewModel.children &&
                     q.cHotelRoomContain >= checkViewModel.adult + checkViewModel.children &&
                     r.cHotelCity.Contains(checkViewModel.destination) ||
                     r.cHotelName.Contains(checkViewModel.destination) ||
                     r.cHotelAdress.Contains(checkViewModel.destination)
                     select r).ToList();
                //入住日期及天數到Session裡
                TimeSpan ts = checkViewModel.checkout - checkViewModel.checkin;
                SessionOrderDate sessionOrderDate = new SessionOrderDate()
                {
                    CheckIndate = checkViewModel.checkin,
                    CheckOutdate = checkViewModel.checkout,
                    StayDays = (int)ts.Days

                };
                Session[CDictionary.SK_USER_ORDER] = sessionOrderDate;

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
                            checkViewModel.selects.Add(new SelectViewModel { cHotelSN = SN.cHotelSN, cHotelName = SN.cHotelName, cHotelAdress = SN.cHotelAdress, cHotelAverageRating = SN.cHotelAverageRating, cHotelRatingOfPeople = SN.cHotelRatingOfPeople, cHotelRoomTypePrice = price, cHotelNameEN = SN.cHotelNameEN, cHotelCity = SN.cHotelCity });
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
        public ActionResult SelectRoom(SelectViewModel selectRoomtype)
        {
            //抓不到selectRoomtype
            dbtravelwebEntities db = new dbtravelwebEntities();
            var cHotelRooms =
                (from p in db.tHotelRoomType
                 where p.cHotelSN == selectRoomtype.cHotelSN
                 select p).ToList();
            if (cHotelRooms.Count != 0)
            {
                List<SelectRoomModel> selectRoom = new List<SelectRoomModel>();
                foreach (var SN in cHotelRooms)
                {
                    selectRoomtype.selectRoom = selectRoom;
                    selectRoomtype.selectRoom.Add(new SelectRoomModel { cHotelSN = SN.cHotelSN, cHotelRoomTypeSN = SN.cHotelRoomTypeSN, cHotelRoomTypeName = SN.cHotelRoomTypeName, cHotelRoomContain = SN.cHotelRoomContain, cHotelRoomContainAldults = SN.cHotelRoomContainAldults, cHotelRoomContainChildren = SN.cHotelRoomContainChiidren, cHotelRoomTypePriceOfWeekdays = SN.cHotelRoomTypePriceOfWeekdays, cHotelRoomTypePriceOfHoliday = SN.cHotelRoomTypePriceOfHoliday, cHotelRoomTypePriceOfFestival = SN.cHotelRoomTypePriceOfFestival });
                }
            }
            else
            {
                selectRoomtype = null;
            }

            return View(selectRoomtype);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(CHomeLoginViewModel login)
        {
            HomeLoginFactory factory = new HomeLoginFactory();
            CHomeLoginViewModel info = factory.Identify(login);

            Session.RemoveAll();
            Session["identity"] = info.identity;
            Session["sn"] = info.sn;
            Session["Guestsn"] = info.Guestsn;
            Session["name"] = info.name;
            //登入失敗
            if ((int)Session["identity"] == 0)
            {
                TempData["message"] = "帳號密碼錯誤，請重新登入";
                return View();
            }


            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();

            return RedirectToAction("Index");
        }
    }
}