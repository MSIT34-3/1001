using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.ViewModels;
using 期末專題_旅遊網;

namespace 期末專案0924.Controllers
{
    public class GuestController : Controller
    {
        // GET: Guest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            //dbtravelwebEntities db = new dbtravelwebEntities();
            //List< tGuestAccountInfomation> GuestAccountInfomationModel = new List<tGuestAccountInfomation>();
            //ViewBag.tGuestAccountInfomation = GuestAccountInfomationModel;
            return View();
        }
        [HttpPost]
        public ActionResult Login(string cGuestEmail)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            ViewBag.Name = cGuestEmail;
            if (cGuestEmail == null)
            {
                TempData["message"] = "請輸入正確電子郵件";
                return RedirectToAction("Login");
            }
            tGuestAccountInfomation prod = (new dbtravelwebEntities()).tGuestAccountInfomation.FirstOrDefault(p => p.cGuestEmail == cGuestEmail);
            if (cGuestEmail == null)
            {
                TempData["message"] = "請輸入正確電子郵件與密碼";
                return RedirectToAction("Login");
            }


            GuestModel models = new GuestModel() { GuestAccountInfomation = prod };
            return RedirectToAction("AfterLogin", new { prod.cGuestEmail });

        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(tGuestAccountInfomation GuestAccountInfomation)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            db.tGuestAccountInfomation.Add(GuestAccountInfomation);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            TempData["message"] = "請登入";

            return RedirectToAction("Login");

        }
        public ActionResult Member( )
        {
            int GuestSN =0;
            if ((int)Session["identity"] == 1)
                GuestSN = (int)Session["Guestsn"];

            dbtravelwebEntities db = new dbtravelwebEntities();
            tGuestAccountInfomation prod = db.tGuestAccountInfomation.FirstOrDefault(p => p.cGuestSN == GuestSN);
            tGuestPaymentInfomation pay = db.tGuestPaymentInfomation.FirstOrDefault(p => p.cGuestCreditCardNameID == prod.cGuestID);
            if (prod == null)
            {
                TempData["message"] = "帳號目前沒有資料";
                return RedirectToAction("Login", "Home");
            }
            //MODELS
            GuestAndCreditCardModel models = new GuestAndCreditCardModel() { GuestAccountInfomation = prod, GuestPaymentInfomation = pay };
            //GuestModel models = new GuestModel() { GuestAccountInfomation = prod };


            IEnumerable<tGuestPaymentInfomation> PaymentIEnumerable = null;
            string keyword = Request.Form["cGuestID"];
            if (string.IsNullOrEmpty(keyword))
            {
                PaymentIEnumerable = from p in (new dbtravelwebEntities()).tGuestPaymentInfomation
                                     select p;
            }
            else
            {
                PaymentIEnumerable = from p in (new dbtravelwebEntities()).tGuestPaymentInfomation
                                     where p.cGuestCreditCardNameID.ToString().Contains(keyword)
                                     select p;
            }
            List<GuestAndCreditCardModel> model2 = new List<GuestAndCreditCardModel>();
            
            foreach (tGuestPaymentInfomation t in PaymentIEnumerable)
                model2.Add(new GuestAndCreditCardModel() { GuestAccountInfomation = prod, GuestPaymentInfomation = t });
            return View(models);


            //    IEnumerable<tGuestAccountInfomation> GuestAccountInfomation = null;




        }
        
        [HttpPost]
        public ActionResult Member(tGuestAccountInfomation t)
        {

            dbtravelwebEntities db = new dbtravelwebEntities();
            tGuestAccountInfomation prod = db.tGuestAccountInfomation.FirstOrDefault(p => p.cGuestEmail == t.cGuestEmail);
            //tGuestPaymentInfomation Payment = db.tGuestPaymentInfomation.FirstOrDefault(p => p.cGuestCreditCardNameID == t.cGuestID);
            if (prod != null)
            {
                prod.cGuestAccountCreationDate = t.cGuestAccountCreationDate;
                prod.cGuestBirth = t.cGuestBirth;
                prod.cGuestCitizenship = t.cGuestCitizenship;
                prod.cGuestEmail = t.cGuestEmail;
                prod.cGuestFirstName = t.cGuestFirstName;
                prod.cGuestFirstNameEN = t.cGuestFirstNameEN;
                prod.cGuestGender = t.cGuestGender;
                prod.cGuestLastName = t.cGuestLastName;
                prod.cGuestID = t.cGuestID;
                prod.cGuestLastNameEN = t.cGuestLastNameEN;
                prod.cGuestPhoneNumber = t.cGuestPhoneNumber;
                if (t.cGuestPWDHash == null || t.cGuestPWDSalt == null)
                {
                    prod.cGuestPWDHash = prod.cGuestPWDHash;
                    prod.cGuestPWDSalt = prod.cGuestPWDSalt;
                }
                else
                {
                    prod.cGuestPWDHash = t.cGuestPWDHash;
                    prod.cGuestPWDSalt = t.cGuestPWDSalt;
                }
                db.SaveChanges();


            }
            //p.cGuestAccountCreationDate.ToString().Contains(keyword) ||
            //                   p.cGuestBirth.ToString().Contains(keyword) ||
            //                   p.cGuestCitizenship.Contains(keyword) ||
            //                   p.cGuestEmail.Contains(keyword) ||
            //                   p.cGuestFirstName.Contains(keyword) ||
            //                   p.cGuestFirstNameEN.Contains(keyword) ||
            //                   p.cGuestGender.Contains(keyword) ||
            //                   p.cGuestID.Contains(keyword) ||
            //                   p.cGuestLastName.Contains(keyword) ||
            //                   p.cGuestLastNameEN.Contains(keyword) ||
            //                   p.cGuestPhoneNumber.ToString().Contains(keyword) ||
            //                   p.cGuestPWDHash.Contains(keyword) ||
            //                   p.cGuestPWDSalt.Contains(keyword)
            //                         select p;


            //db.tGuestAccountInfomation.Add(prod);


            TempData["message"] = "會員資料已做變更";
            return RedirectToAction("Member", new { prod.cGuestEmail });
            

        }
        public ActionResult CreditCard(string Id)
        {
            ViewBag.Message = Id;
            TempData["text"] = Id;
            return View();
        }
        [HttpPost]
        public ActionResult CreditCard(tGuestPaymentInfomation GuestPaymentInfomation)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            GuestPaymentInfomation.cGuestCreditCardNameID = (string)TempData["text"];
            db.tGuestPaymentInfomation.Add(GuestPaymentInfomation);

            db.SaveChanges();
            tGuestAccountInfomation prod = db.tGuestAccountInfomation.FirstOrDefault(p => p.cGuestID== GuestPaymentInfomation.cGuestCreditCardNameID);
            return RedirectToAction("Member", new { prod.cGuestEmail });
        }
        public ActionResult AfterLogin(string cGuestEmail)
        {
            if (cGuestEmail == null)
                return RedirectToAction("Login");

            dbtravelwebEntities db = new dbtravelwebEntities();
            tGuestAccountInfomation prod = db.tGuestAccountInfomation.FirstOrDefault(p => p.cGuestEmail == cGuestEmail);
            tGuestPaymentInfomation pay = db.tGuestPaymentInfomation.FirstOrDefault(p => p.cGuestCreditCardNameID == prod.cGuestID);
            if (prod == null)
            {
                TempData["message"] = "帳號目前沒有資料";
                return RedirectToAction("Login");
            }
            //MODELS
            GuestAndCreditCardModel models = new GuestAndCreditCardModel() { GuestAccountInfomation = prod, GuestPaymentInfomation = pay };
            return View(models);
        }
        //[HttpPost]
        //public ActionResult AfterLogin(string cGuestEmail, int PhoneNumber)
        //{
        //    dbtravelwebEntities db = new dbtravelwebEntities();


        //    tGuestAccountInfomation prod = (new dbtravelwebEntities()).tGuestAccountInfomation.FirstOrDefault(p => p.cGuestEmail == cGuestEmail);


        //    GuestModel models = new GuestModel() { GuestAccountInfomation = prod };
        //    return RedirectToAction("Member", new { prod.cGuestEmail });

        //}
        //public ActionResult NewCreditCard(string id)
        //{
        //    dbtravelwebEntities db = new dbtravelwebEntities();
        //    tGuestAccountInfomation prod = db.tGuestAccountInfomation.FirstOrDefault(p => p.cGuestEmail == id);
        //    return RedirectToAction("CreditCard", new { prod.cGuestID });
        //}
	public ActionResult GuestList(/*string id*/)
        {
            IEnumerable<tGuestAccountInfomation> IEnGuestAccountInfomation = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
            {
                IEnGuestAccountInfomation = from p in (new dbtravelwebEntities()).tGuestAccountInfomation
                                            //where p.cGuestID == id
                                            select p;
            }
            else
            {
                IEnGuestAccountInfomation = from p in (new dbtravelwebEntities()).tGuestAccountInfomation
                                         where p.cGuestAccountCreationDate.ToString().Contains(keyword) ||
                                   p.cGuestBirth.ToString().Contains(keyword) ||
                                   p.cGuestCitizenship.Contains(keyword) ||
                                   p.cGuestEmail.Contains(keyword) ||
                                   p.cGuestFirstName.Contains(keyword) ||
                                   p.cGuestFirstNameEN.Contains(keyword) ||
                                   p.cGuestGender.Contains(keyword) ||
                                   p.cGuestID.Contains(keyword) ||
                                   p.cGuestLastName.Contains(keyword) ||
                                   p.cGuestLastNameEN.Contains(keyword) ||
                                   p.cGuestPhoneNumber.ToString().Contains(keyword)

                                     select p;
            }
            List<GuestModel> models = new List<GuestModel>();
            foreach (tGuestAccountInfomation t in IEnGuestAccountInfomation)
                models.Add(new GuestModel() { GuestAccountInfomation = t });
            return View(models);
           
        }
        public ActionResult GuestEdit(string id)
        {
            if (id == null)
                return RedirectToAction("List");

            tGuestAccountInfomation prod = (new dbtravelwebEntities()).tGuestAccountInfomation.FirstOrDefault(p => p.cGuestID == id);
            if (prod == null)
                return RedirectToAction("List");
            GuestModel models = new GuestModel() { GuestAccountInfomation = prod };
            return View(models);
        }
        [HttpPost]
        public ActionResult GuestEdit(tGuestAccountInfomation input)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            tGuestAccountInfomation prod = db.tGuestAccountInfomation.FirstOrDefault(p => p.cGuestID == input.cGuestID);
            if (prod != null)
            {
                //prod.cHotelSN = (int)Session["tHotelRoomType"];
                prod.cGuestAccountCreationDate = input.cGuestAccountCreationDate;
                prod.cGuestBirth = input.cGuestBirth;
                prod.cGuestCitizenship = input.cGuestCitizenship;
                prod.cGuestEmail = input.cGuestEmail;
                prod.cGuestFirstName = input.cGuestFirstName;
                prod.cGuestFirstNameEN = input.cGuestFirstNameEN;
                prod.cGuestGender = input.cGuestGender;
                prod.cGuestID = input.cGuestID;
                prod.cGuestLastName = input.cGuestLastName;
                prod.cGuestLastNameEN = input.cGuestLastNameEN;
                prod.cGuestPhoneNumber = input.cGuestPhoneNumber;
               db.SaveChanges();
            }
            return RedirectToAction("GuestList", new { id = prod.cGuestID });
        }
        public ActionResult GuestDelete(string id)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            tGuestAccountInfomation prod = db.tGuestAccountInfomation.FirstOrDefault(p => p.cGuestID == id);
            if (prod != null)
            {
                db.tGuestAccountInfomation.Remove(prod);
                db.SaveChanges();
            }
            //如果刪除房型管理資料後 List為0 會跳回飯店管理
            tGuestAccountInfomation Zero = db.tGuestAccountInfomation.FirstOrDefault(p => p.cGuestID == prod.cGuestID);
            if (Zero == null)
            {
                return RedirectToAction("GuestList", new { id = prod.cGuestID });
            }
            return RedirectToAction("GuestList", new { id = prod.cGuestID });
        }
    }




}