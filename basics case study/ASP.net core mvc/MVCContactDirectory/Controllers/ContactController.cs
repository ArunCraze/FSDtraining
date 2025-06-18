using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCContactDirectory.Model;
using System.Collections.Generic;
using System.Linq;

namespace MVCContactDirectory.Controllers
{
    public class ContactController : Controller
    {
        static List<ContactInfo> contacts = new List<ContactInfo>
        {
            new ContactInfo{ContactId=1,FirstName="Kumar",LastName="M",CompanyName="Hexaware",EmailId="kumar@gmail.com",MobileNo=9999988888,Designation="Developer",}
        };

        public IActionResult ShowContacts()
        {
            return View(contacts);
        }

        public IActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
                return NotFound();
            return View(contact);
        }

        [HttpGet]
        [Route("AddContact", Name = "AddContact")]
        public IActionResult AddContact()
        {
            ViewBag.DesignationList = new List<SelectListItem>
    {
        new SelectListItem { Text = "Manager", Value = "Manager" },
        new SelectListItem { Text = "Developer", Value = "Developer" },
        new SelectListItem { Text = "Tester", Value = "Tester" },
        new SelectListItem { Text = "HR", Value = "HR" }
    };

            return View();
        }

        [HttpPost]
        [Route("AddContact")]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            contactInfo.ContactId = contacts.Count > 0 ? contacts.Max(c => c.ContactId) + 1 : 1;
            contacts.Add(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}