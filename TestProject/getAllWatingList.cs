using footballFantasy.Model;

namespace TestProject
{
    class getAllWatingList
    {
        List<Object> getAllProductAPI()
        {
            List<Object> response = new List<Object>();
            using (var db = new Database())
            {
                foreach (var WaitUser in db.waitingListUsers)
                {
                    response.Add(new
                    {
                        name = WaitUser.name,
                        email = WaitUser.email,
                        userName = WaitUser.userName,
                        password = WaitUser.password
                    });
                }
            }


            return response;
        }
    }
}
