using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CingeRazor.Pages
{
    public class LoginModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public LoginModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
            //_session = httpContextAccessor.HttpContext.Session;
        }
        
        [BindProperty]
        public LoginData loginData { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Models.Usuarios usuarios = await _context.Usuarios.Include(u => u.IdRolNavigation).FirstOrDefaultAsync(m => m.Usuario == loginData.Username);
                if (usuarios == null || usuarios.Contraseñas != Models.Usuarios.EncriptarContrasena(loginData.Password))
                {
                    ModelState.AddModelError("", "Usuario o contraseña invalidos");
                    return Page();
                }
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginData.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, loginData.Username));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, 
                        new AuthenticationProperties {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(5),
                            IsPersistent = loginData.RememberMe,
                            AllowRefresh = true });

                Models.Compañias companias = await _context.Compañias.FirstOrDefaultAsync();

                //_session.SetString("Compania", companias != null ? companias.IdCompañia : "");

                return RedirectToPage("Index");
            }
            else
            {
                ModelState.AddModelError("", "Usuario o contraseña invalidos");
                return Page();
            }
        }

        public class LoginData
        {
            [Required(ErrorMessage = "El campo Usuario es requerido")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [Display(Name = "Usuario")]
            public string Username { get; set; }

            [Required(ErrorMessage = "El campo Contraseña es requerido")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [Display(Name = "Recordarme")]
            public bool RememberMe { get; set; }
        }
        
    }
}