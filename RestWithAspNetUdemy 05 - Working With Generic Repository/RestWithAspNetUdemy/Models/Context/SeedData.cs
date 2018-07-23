namespace RestWithAspNetUdemy.Models.Context
{
    public sealed class SeedData
    {

        public static void EnsurePopulated()
        {

            using (MySQLContext db = new MySQLContext())
            {

                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

        }

    }
}
