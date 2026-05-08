using Domain;
using Infrastructure;
using Infrastucture.Interfase;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/menu-items")]
public class MenuItemController
{
    private readonly IMenuItem _menuItemService = new MenuItemService();

    [HttpGet]


    [HttpGet("{id:int}")]
    public async Task<MenuItem?> GetByIdAsync(int id)
    {
        return await _menuItemService.GetMenuItemById(id);
    }

    [HttpPost]
    public async Task AddAsync(MenuItem item)
    {
        await _menuItemService.AddMenuItem(item);
    }

    [HttpPut]
    public async Task UpdateAsync(MenuItem item)
    {
        await _menuItemService.UpdateMenuItem(item);
    }

    [HttpDelete("{id:int}")]
    public async Task DeleteAsync(int id)
    {
        await _menuItemService.DeleteMenuItem(id);
    }
}