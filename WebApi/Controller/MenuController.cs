using Domain;
using Infrastructure;
using Infrastucture.Interfase;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/menus")]
public class MenuController
{
    private readonly IMenu _menuService = new MenuService();


    [HttpGet("{id:int}")]
    public async Task<Menu?> GetByIdAsync(int id)
    {
        return await _menuService.GetMenuById(id);
    }

    [HttpPost]
    public async Task AddAsync(Menu menu)
    {
        await _menuService.AddMenu(menu);
    }

    [HttpPut]
    public async Task UpdateAsync(Menu menu)
    {
        await _menuService.UpdateMenu(menu);
    }

    [HttpDelete("{id:int}")]
    public async Task DeleteAsync(int id)
    {
        await _menuService.DeleteMenu(id);
    }
}