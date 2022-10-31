
using System.ComponentModel.DataAnnotations;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Pages
{
    [Authorize]
    public class ArticleAddModel : PageModel
    {
   
        private BlogDbContext db;
        private readonly ILogger<RegisterModel> logger;

        [BindProperty]
        public InputModel Input { get; set; } 

        public ArticleAddModel(BlogDbContext db, ILogger<RegisterModel> logger)
        {
            this.db = db;
            this.logger = logger;
        }


        public class InputModel
        {
            [BindProperty, Required, MinLength(1), Display(Name = "Title")]
            public string Title { get; set; }

            [BindProperty, Required, MinLength(1), Display(Name = "Content")]
            public string Body { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                var user = db.Users.Where(user => user.UserName == userName).FirstOrDefault();
                var newArticle = new Blog.Models.Article { Title = Input.Title, Body = Input.Body, Author = user, Created = DateTime.Now };
                db.Add(newArticle);
                await db.SaveChangesAsync();

                return RedirectToPage("/ArticleAddSuccess");
            }
            return Page();
        }
    }
}
