using GerenciadorDeTarefas.Model;

namespace GerenciadorDeTarefas.Repositories;

public class UserRepository
{
    /*
     * 1 - Convidado (Pode somente acessar as tarefas.)
     * 2 - Admin (Pode fazer o que quiser.)
     */

    public static IList<User> Users = new List<User>
    {
        new User
        {
            Type = 1,
            UserName = "Willian",
            Password = "Will123"
		},

        new User
        {
            Type = 2,
            UserName = "Renan",
            Password = "Ren123"
        }
    };

    public User? GetByUserName(string userName)
    {
        return Users.Where(user => user.UserName.ToLower() == userName.ToLower()).FirstOrDefault();
    }
}