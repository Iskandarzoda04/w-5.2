using Domain;
namespace Infrastucture.Interfase;

public interface IMenuItem
{
   Task AddMenuItem(MenuItem item);
Task UpdateMenuItem(MenuItem item);
Task DeleteMenuItem(int id);
Task<MenuItem?> GetMenuItemById(int id);

}
