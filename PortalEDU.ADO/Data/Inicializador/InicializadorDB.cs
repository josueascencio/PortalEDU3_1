using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortalEDU.Models;
using PortalEDU.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalEDU.ADO.Data.Inicializador
{
    public class InicializadorDB : IInicializadorDB
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InicializadorDB(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public void Inicializar()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {
               
            }

            if (_db.Roles.Any(ro => ro.Name == Constantes.Admin)) return;

            _roleManager.CreateAsync(new IdentityRole(Constantes.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Constantes.Alumno)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Constantes.Anonimo)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Constantes.Docente)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Constantes.Padre)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "evolutioncompu@gmail.com",
                Email = "evolutioncompu@gmail.com",
                EmailConfirmed = true,
                Nombre = "Jose Ascencio"
            }, "Admin123*").GetAwaiter().GetResult();

            ApplicationUser usuario = _db.ApplicationUser
                .Where(us => us.Email == "evolutioncompu@gmail.com")
                .FirstOrDefault();
            _userManager.AddToRoleAsync(usuario, Constantes.Admin).GetAwaiter().GetResult();

        }
    }
}