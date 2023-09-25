using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Register.Data;
using Register.Interfaces;
using Register.Models;
using Register.ViewModels;

namespace Register.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> List()
        {
            IEnumerable<User> users = await _userRepository.GetAll();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                var newuser = new User
                {
                    Name = user.Name,
                    SurName = user.SurName,
                    Email = user.Email,
                    password = user.password,
                    phone = user.phone,
                    Gender = user.Gender
                };
                _userRepository.Add(newuser);
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "User edit Failed.");
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int id)

        {
            User user = await _userRepository.GetByIdAsync(id);
            if (user == null) { return View("Error"); }
            var userVM = new EditUserViewModel
            {
                ID=user.ID,

                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email,
                phone = user.phone,
            };
            return View(userVM);

            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,EditUserViewModel editVM)
        {   
            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", editVM   );
            }
            var tempUser = await _userRepository.GetByIdAsyncNoTracking(id);
            if(tempUser!= null)
            {
                var a = await _userRepository.GetByIdAsyncNoTracking(id);
                var user = new User
                {   
                    
                    ID= id,
                    Name = editVM.Name,
                    SurName =editVM.SurName,
                    password= a.password,
                    Email = editVM.Email,
                    phone = editVM.phone,
                };
                _userRepository.Update(user);

                return RedirectToAction("List");

            }

            else
            {
                return View(editVM);
            }
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
           
            
           var user = await _userRepository.GetByEmailAsync(loginVM.Email);
            if( user != null)
            {
                //User is found, Check Password
               
                if(user.password==loginVM.password)
                {

                    //var result = _signInManager.PasswordSignInAsync(user, loginVM.password, false, false);
                   // if (result.IsCompletedSuccessfully)

                    //{
                        return RedirectToAction("Create", "User");
                   // }
                }
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginVM);


        }


        

        public async Task<IActionResult> Delete(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            return View(user);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
            if (user == null)
            {
                return View("Error");
            }
            _userRepository.Delete(user);
            return RedirectToAction("Create");
        }
    }
}

