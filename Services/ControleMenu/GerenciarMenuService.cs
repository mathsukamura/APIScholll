using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Scholl.Data;
using Scholl.Models;
using Scholl.Services.ControleMenu.Interface;
using Scholl.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scholl.Services.ControleMenu
{
    public class GerenciarMenuService : 
        IBuscarMenuService, ICriarMenuService, 
         IAlterarMenuService, IDeletarMenuService
    {
        private readonly AppDbcontext _context;

        public GerenciarMenuService(AppDbcontext context) => _context = context;

        public async Task<IList<Menu>> GetAsync() 
        {
            var menu = await _context.Menus.AsNoTracking().ToListAsync();

            return menu;
        }

        public async Task<Menu> GetByIdAsync(int id) 
        {
            var menu = await _context.Menus.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return menu;
        }

        public async Task<Menu> PostAsync(CreateMenuViewModel model ) 
        {
            var menu = new Menu { Tela = model.Tela, Url = model.Url};

            await _context.Menus.AddAsync(menu);

            await _context.SaveChangesAsync();

            return menu;
        }
        
        public async Task<Menu> PutAsync(CreateMenuViewModel model, int id) 
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);

            if(menu== null) 
            {
                return null;
            }

            menu.Tela= model.Tela;
            menu.Url= model.Url;
            
            _context.Menus.Update(menu);

            await _context.SaveChangesAsync();

            return menu;
        }

        public async Task<bool> DeleteAsync( int id) 
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);

            if (menu == null)
            {
                return false;
            }

            _context.Menus.Remove(menu);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
