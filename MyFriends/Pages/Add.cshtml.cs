using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFriends.Models;
using MyFriends.Data;
using System.ComponentModel.DataAnnotations;

namespace MyFriends.Pages
{
    public class AddModel : PageModel
    {
        private readonly MyFriendsContext db;

        public AddModel(MyFriendsContext db) {
            this.db = db;
        }
        
        [BindProperty]
        public Friend NewFriend { get; set; }

/* Note: we could also handle the fields separately, which allows us to set custom error messages
          [BindProperty] string Name {get; set; }
          [BindProperty] int  Age {get; set; } */

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Friends.Add(NewFriend);
            await db.SaveChangesAsync();

            return RedirectToPage("./AddSuccess");
        }

    }
}
