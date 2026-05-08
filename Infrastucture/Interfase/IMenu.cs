using Domain;

namespace Infrastucture.Interfase;

public interface IMenu
{
    Task AddMenu(Menu menu);
Task UpdateMenu(Menu menu);
Task DeleteMenu(int id);
Task<Menu?> GetMenuById(int id);


}