using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyFriends.Models;
using MyFriends.Data;
using Microsoft.EntityFrameworkCore;

namespace MyFriends.Pages
{
public class IndexModel : PageModel
    {
        //public IndexModel(MyFriendsContext db) => this.db = db;

        private readonly MyFriendsContext db;
        private readonly ILogger<IndexModel> _logger;        
        public List<Friend> FriendsList { get; set; } = new List<Friend>();


        public IndexModel(MyFriendsContext db, ILogger<IndexModel> logger)
                {
                    this.db = db;
                    _logger = logger;
                }

        public async Task OnGetAsync()
        {
            FriendsList = await db.Friends.ToListAsync();
        }
    }
}