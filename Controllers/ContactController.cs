using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactContext _context;

        public ContactController(ContactContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null) return NotFound();

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var contactDb = _context.Contacts.Find(contact.Id);
            contactDb.Name = contact.Name;
            contactDb.PhoneNumber = contact.PhoneNumber;
            contactDb.Active = contact.Active;

            _context.Contacts.Update(contactDb);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null) return RedirectToAction(nameof(Index));

            return View(contact);
        }

        public IActionResult Remove(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null) return RedirectToAction(nameof(Index));

            return View(contact);
        }

        [HttpPost]
        public IActionResult Remove(Contact contact)
        {
            var contactDb = _context.Contacts.Find(contact.Id);
            _context.Contacts.Remove(contactDb);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}