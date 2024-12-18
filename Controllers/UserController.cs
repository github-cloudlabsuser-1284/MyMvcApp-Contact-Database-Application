using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;
using MyMvcApp.Data;
namespace MyMvcApp.Controllers;

public class UserController : Controller
{
        private readonly IUserService _context;

        public UserController(IUserService context)
        {
            _context = context;
        }
        // GET: User
        public ActionResult Index()
        {
            var users = _context.GetAllUsers();
            return View(users);
        }

        public ActionResult Details(int id)
        {
            var user = _context.GetAllUsers().SingleOrDefault(i=> i.Id == id);
            if (user == null)
            {
            return NotFound();
            }
            return View(user);
        }

        public ActionResult Create()
        {
            var model = new User();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
            _context.AddUser(user);
            return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            var user = _context.GetAllUsers().SingleOrDefault(i=> i.Id == id);
            if (user == null)
            {
            return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(int id, User updatedUser)
        {
            if (ModelState.IsValid)
            {
            var user = _context.GetAllUsers().SingleOrDefault(i=> i.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            updatedUser.Id = id;
            _context.UpdateUser(updatedUser);
            return RedirectToAction(nameof(Index));
            }
            return View(updatedUser);
        }

        public ActionResult Delete(int id)
        {
            var user = _context.GetAllUsers().SingleOrDefault(i=> i.Id == id);
            if (user == null)
            {
            return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var user = _context.GetAllUsers().SingleOrDefault(i=> i.Id == id);
            if (user == null)
            {
            return NotFound();
            }
            _context.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
        
       }
