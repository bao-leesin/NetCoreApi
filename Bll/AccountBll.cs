using NetCoreApi.Entities;
using NetCoreApi.Models;

namespace NetCoreApi.Bll
{
    public class AccountBll
    {
        private static DbContextCore DbContext = new DbContextCore(DbContextCor);
        public AccountBll(DbContextCore dbContextCore) {
            DbContext = dbContextCore;
        }

        public static void GetAll()
        {
            
        }
        public static AccountModel Get(int id)
        {
            ACCOUNT entity =  DbContext.ACCOUNTs.Find(id);
            if (entity == null)
            {
                return new AccountModel();
            }
            else
            {
                return new AccountModel()
                {
                    Id = entity.ID,
                    Username = entity.USERNAME,
                    Password = entity.PASSWORD
                };
            }

        }
        public static void Save(AccountModel model)
        {

            IQueryable<ACCOUNT> query = DbContext.ACCOUNTs;
            ACCOUNT entity = DbContext.ACCOUNTs?.FirstOrDefault(e => e.ID.Equals(model.Id));
            if (entity == null) DbContext.Add(entity);
            entity.USERNAME = model.Username;
            entity.PASSWORD = model.Password;
            DbContext.SaveChanges();

        }
        public static void Delete(AccountModel model) { }
    }
}
