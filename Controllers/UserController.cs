using Microsoft.AspNetCore.Mvc;
using FinancialTrackerMVC.Models.Users;
using FinancialTrackerMVC.Services.UsersService;

namespace FinancialTrackerMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsers _usersService;
        public UsersController(IUsers usersService)
        {
            _usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _usersService.GetAllUsers();
            return View(users);
        }

        public async Task<IActionResult> Details(int id)
        {
            var users = await _usersService.GetUserById(id);

            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        public async Task<IActionResult> Register()
        {
            var users = await _usersService.GetAllUsers();

            IEnumerable<UsersRegister> model = users
                .Select(u => new UsersRegister()
            {
                fullName = u.fullName,
                email = u.Email
            });

            return View(model);
        }
    

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UsersRegister model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(ModelState);
            }

            bool wasReg = await _usersService.RegisterUser(model);

            if (wasReg)
            {
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var users = await _usersService.GetAllUsers();

            IEnumerable<UsersDetail> user = users
                .Select(u => new UsersDetail()
                {
                    Id = u.Id,
                    fullName = u.fullName,
                    Email = u.Email,
                    birthday = u.birthday,
                    income = u.income
                });

            UsersDetail userId = await _usersService.GetUserById(id);

            if (users == null)
            {
                return NotFound();
            }

            var usersDetail = new UsersDetail();

            return View(usersDetail);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(int id, UsersUpdate model)
        {
            if (id != model.id || !ModelState.IsValid)
            {
                return View(ModelState);
            }

            bool wasUpdated = await _usersService.UpdateUser(id, model);

            if (wasUpdated)
            {
                return RedirectToAction("Details", new { id = model.id });
            }

            ViewData["ErrorMsg"] = "Unable to save to the database. Please try again later.";

            return View(model);
        }

        // [HttpDelete]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var users = await _usersService.GetUserById(id);

        //     if (users == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(users);
        // }

        [HttpDelete]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, UsersDetail model)
        {
            if (await _usersService.DeleteUser(model.Id))
            {
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }
    }
}