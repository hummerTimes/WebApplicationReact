using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApplicationReact.Models;

namespace WebApplicationReact.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        ApplicationContext db;
        public SampleDataController(ApplicationContext context)
        {
            this.db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new User { Name = "Tom", Room = 26});
                db.Users.Add(new User { Name = "Alice", Room = 31 });
                db.Users.Add(new User { Name = "Bob", Room = 35 });
                db.Users.Add(new User { Name = "Jimmy", Room = 31 });
                db.Users.Add(new User { Name = "Clo", Room = 26 });
                db.Users.Add(new User { Name = "Anny", Room = 33 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                ModelState.AddModelError("", "�� ������� ������ ��� ������������");
                return BadRequest(ModelState);
            }
            // ��������� ������� ������� ���������
            if (user.Room == 99)
                ModelState.AddModelError("Age", "������� �� ������ ���� ����� 99");

            if (user.Name == "admin")
            {
                ModelState.AddModelError("Name", "������������ ��� ������������ - admin");
            }
            // ���� ���� ������ - ���������� ������ 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // ���� ������ ���, ��������� � ���� ������
            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }

    }
}
