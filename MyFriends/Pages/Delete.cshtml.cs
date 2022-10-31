using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFriends.Models;
using MyFriends.Data;
using Microsoft.EntityFrameworkCore;

namespace MyFriends.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MyFriendsContext db;
        public DeleteModel(MyFriendsContext db) => this.db = db;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public Friend Friend { get; set; }


        public void OnGet()
        {
            Friend = db.Friends.Find(Id);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var FriendFromDB = await db.Friends.FindAsync(Id);
            db.Friends.Remove(FriendFromDB);
            await db.SaveChangesAsync();

            return RedirectToPage("/DeleteSuccess");
        }
    }
}
